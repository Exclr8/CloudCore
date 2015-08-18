using System;
using System.Collections.Generic;
using System.Linq;
using ProcessViewer.Interface;
using ProcessViewer.Library;
using ProcessViewer.Library.Common;
using ProcessViewer.Library.Shapes;
using CommandLine;
using CommandLine.Text;


namespace ProcessViewerConsole
{
    class Program
    {
        private static readonly HeadingInfo _headingInfo = new HeadingInfo("ProcessViewer", "2.0");

        private sealed class Arguments
        {
            #region Standard Option Attributes

            [Option("c", "connection", Required = true, HelpText = "Connection to the database.")]
            public string Connection = String.Format(@"server=localhost;database=CloudCore;user id=user; password=password");

            [Option("f", "path", Required = true, HelpText = "File path to save the diagram.")]  
            public string Path = "diagram.png";

            [Option("p", "processId", Required = true, HelpText = "Process id of the process to be drawn.")]
            public int ProcessID = 1;

            [Option("l", "viewLevel", Required = true, HelpText = "View Level: [Activity] | [SubProcess]")]
            public ViewLevel ViewLevel = ViewLevel.Activity;

            [Option("r", "revision", Required = false, HelpText = "Process Revision of the process to be drawn. The latest revision is selected by default")]
            public int Revision = -1;

            [Option("v", "visio", Required = false, HelpText = "Render diagram in Microsoft Visio 2010 (.vsd).The default is MSAGL(.png)")]
            public bool Visio = false;

            [Option("u", "colour", Required = false, HelpText = "Render diagram with colour designation.")]
            public bool Colour = false;

            [Option("i", "identity", Required = false, HelpText = "Show node id's in the drawing.")]
            public bool Identity = false;

            [Option("t", "instance", Required = false, HelpText = "Show number of active instances in the drawing.")]
            public bool Instance = false;

            #endregion

            #region Specialized Option Attribute

            [ValueList(typeof(List<string>))]
            public IList<string> DefinitionFiles = null;

            //[OptionList("o", "operators", Separator=';',
            //    HelpText = "Operators included in processing (+;-;...).")]
            [OptionList("o", "operators", Separator = ';',
                HelpText = "Operators included in processing (+;-;...)." +
                " Separate each operator with a semicolon." +
                " Do not include spaces between operators and separator.")]
            public IList<string> AllowedOperators = null;

            [HelpOption(
                    HelpText = "Display this help screen.")]
            public string GetUsage()
            {
                var help = new HelpText(_headingInfo);
                help.AdditionalNewLineAfterOption = true;
                help.Copyright = new CopyrightInfo("Exclr8 Business Automation", 2015);
                help.AddPreOptionsLine("This software gets shipped with CloudCore. For more information ");
                help.AddPreOptionsLine("go to <http://www.exclr8.co.za>.");
                help.AddPreOptionsLine(@"Usage:  ProcessViewerConsole.exe");
                help.AddPreOptionsLine(@"        -c ""server=localhost;database=CloudCoreDB;user id=user;password=psw;""");
                help.AddPreOptionsLine(@"        -p 1 -f""msagldiagram.png"" -lActivity -u");
                help.AddPreOptionsLine(@"         ProcessViewerConsole.exe");
                help.AddPreOptionsLine(@"        -c ""server=localhost;database=CloudCoreDB;user id=user;password=psw;""");
                help.AddPreOptionsLine(@"        -p 1 -r3 -f""visiodigram.vsd"" -lActivity -u -v ");
                help.AddOptions(this);

                return help;
            }

            #endregion
        }

        static void Main(string[] args)
        {
            var options = new Arguments();
            ICommandLineParser parser = new CommandLineParser(new CommandLineParserSettings(false, Console.Error));
            if (!parser.ParseArguments(args, options))
                Environment.Exit(1);

            if (!DoCoreTask(options))
                Environment.Exit(1);
            
            Environment.Exit(0);
        }

        private static bool DoCoreTask(Arguments args)
        {
            try
            {
                var db = new ProcessViewer.Data1.CloudCoreDB(args.Connection);

                 var drawItem = new DrawItem
                                   {
                                       ConnectionString = args.Connection,
                                       ViewLevel = args.ViewLevel,
                                       DiagramType = args.Visio ? DiagramType.Visio : DiagramType.Msagl,
                                       Version = DBVersion.Version2,
                                       ResetRevisions = false,

                                   };

                var processes = from p in db.Cloudcoremodel_ProcessModel
                                join r in db.Cloudcoremodel_ProcessRevision on p.ProcessModelId equals r.ProcessModelId
                                orderby r.ProcessRevision descending
                                where p.ProcessModelId == args.ProcessID
                                select new Process(drawItem)
                                           {
                                               Id = p.ProcessModelId,
                                               Title = p.ProcessName,
                                               RevisionId = r.ProcessRevisionId
                                           };

                if (args.Revision > 0)
                    processes = processes.Where(p => p.RevisionId == args.Revision);

                var options = Options.None;

                if (args.Colour)
                    options |= Options.Colour;
                if (args.Identity)
                    options |= Options.Id;
                if (args.Instance)
                    options |= Options.Instance;

                var palette = new Palette(2, 20, 10);

                drawItem.Options = options;
                drawItem.Process = new List<Process> {processes.FirstOrDefault()};

                if (args.Visio)
                    VisioGraph.GenerateGraph(drawItem, ref palette, args.Path);
                else
                    MsaglGraph.GenerateGraph(drawItem, ref palette, args.Path);
  
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
