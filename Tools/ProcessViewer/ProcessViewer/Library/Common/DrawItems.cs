using System;
using System.Collections.Generic;
using ProcessViewer.Library.Shapes;

namespace ProcessViewer.Library
{
    

    public class DrawItem
    {
        public DrawItem()
        {
            Options = Options.None;
            ViewLevel = ViewLevel.Activity;
            DiagramType = DiagramType.Msagl;
            ConnectionString = String.Empty;
            Version = DBVersion.Version1;
        }
        
        public string ConnectionString { get; set; }
        public DiagramType DiagramType { get; set; }
        public ViewLevel ViewLevel { get; set; }
        public Options Options { get; set; }
        public List<Process> Process { get; set; }
        public DBVersion Version { get; set; }
        public bool ResetRevisions { get; set; }
    }

    public class Node
    {
        public int? ID { get; set; }
        public int? GroupID { get; set; }       
        public String Title { get; set; }
        public String GroupTitle { get; set; }
        public String Content { get; set; }
        public bool Startable { get; set; }
        public bool Decision { get; set; }
        public int Instances { get; set; }
        public String ActivityType { get; set; }
    }

    public class Connector
    {
        public int FromID { get; set; }
        public int ToID { get; set; }
        public String Title { get; set; }
        public int FlowInd { get; set; }
    }

    public class Revision
    {
        public String Name { get; set; }
        public int ProcessID { get; set; }
        public int ID { get; set; }
        public String Date { get; set; }
        public String User { get; set; }

    }

    public class Snope
    {
        public int Sid { get; set; }
        public Microsoft.Office.Interop.Visio.Shape Shape { get; set; }
    }

    public class PaletteColor
    {
        public int Pid { get; set; }
        public System.Drawing.Color Color { get; set; }
        public string Label { get; set; }
    }
}
