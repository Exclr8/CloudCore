using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Architect.CustomCode;
using Architect.CustomCode.Forms;
using Microsoft.VisualStudio.Modeling.Shell;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.CSharp;
using Microsoft.VisualStudio.Modeling;

namespace Architect
{
    /*
    internal partial class SubProcessDSLCommandSet : SubProcessDSLCommandSetBase
    {
        // Note: Here you need to repeat the code from the VSCT .
        //       I could not find an easy way of re-using the Symbols from the vsct
        public Guid cmdAutoLayoutGUID = new Guid("D0CC72F7-1B2D-4BFF-B6DC-A6CEFA613FC2");
        public const int cmdAutoLayoutID = 0x810;

        protected override IList<MenuCommand> GetMenuCommands()
        {
            var commands = base.GetMenuCommands();

            var cmdidNewCommand =
                new DynamicStatusMenuCommand(
                     OnStatusNewCommand,
                     OnNewMenuClick,
                     new CommandID(Guids.guidFileMenuCmdSet, Guids.cmdidNewCommandID));

            var cmdidExportCommand =
                 new DynamicStatusMenuCommand(
                      OnStatusExportCommand,
                      OnExportMenuClick,
                      new CommandID(Guids.guidExportCmdSet, Guids.cmdidExportCommandID));

            var cmdidImportCommand =
               new DynamicStatusMenuCommand(
                    OnStatusImportCommand,
                    OnImportMenuClick,
                    new CommandID(Guids.guidImportCmdSet, Guids.cmdidImportCommandID));

            var cmdShowControllerSource =
                   new DynamicStatusMenuCommand(
                        new global::System.EventHandler(OnShowControllerSourceDisplayAction),
                        new global::System.EventHandler(OnShowControllerSourceClick),
                        new CommandID(Guids.guidShowControllerSourceCmdSet, Guids.cmdShowControllerSourceId));     
      
      
            commands.Add(cmdShowControllerSource);
            commands.Add(cmdidExportCommand);
            commands.Add(cmdidImportCommand);
            commands.Add(cmdidNewCommand);

            return commands;
        }

        override 

        internal void OnExportMenuClick(object sender, EventArgs e) { }

        internal void OnNewMenuClick(object sender, EventArgs e)
        {
            var nProcess = new NewProcess();
            
            nProcess.ShowDialog();
        }

        internal void OnImportMenuClick(object sender, EventArgs e)
        {
            var importFrm = new Import();   
            importFrm.ShowDialog();
        }

        internal void OnStatusNewCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            if (command == null) return;
            // The popMenu command is always visible
            command.Visible = command.Enabled = true;
        }

        internal void OnStatusImportCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            if (command == null) return;
            // The popMenu command is always visible
            command.Visible = command.Enabled = true;            
        }

        internal void OnStatusExportCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            if (command == null) return;

            if (CurrentModelingDocView != null)
            {
                command.Visible = true;
                command.Enabled = true;
                return;
            }

            // The popMenu command is always visible
            command.Visible = false;
            command.Enabled = false;
        }

       

        internal void OnShowControllerSourceDisplayAction(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            if (command == null) return;
            // The popMenu command is always visible
            command.Visible = false;
            command.Enabled = false;

            foreach (object item in this.CurrentSelection)
            {
                if (item is PageShape)
                {
                    command.Visible = true;
                    command.Enabled = true;
                    return;
                }
            }
  
        }

        internal void OnShowControllerSourceClick(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;

            
            MessageBox.Show("Kuckuck");
        }

     


    }
     * */
}
