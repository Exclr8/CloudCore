using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Modeling;
using System.Windows;

namespace Architect.CustomCode.ContextMenu
{
    public abstract class CmdShowSourceBase : DSLMenuCommandImplBase
    {
        protected readonly Guid commandGuid = new Guid("EF92F3C6-017F-493A-AD03-110773120FEC");
        protected PageShape SelectedPage { get; set; }

        public override void StatusHandler(CommandSetState state)
        {
            foreach (object selectedObject in state.CurrentSelection)
            {
                if (selectedObject is PageShape)
                {
                    SelectedPage = (PageShape)selectedObject;
                    MenuCommand.Visible = true;
                    var store = state.CurrentDocView.CurrentDiagram.Store;
                    MenuCommand.Enabled = true;
                    return;
                }
                else
                {
                    MenuCommand.Visible = false;
                    MenuCommand.Enabled = false;
                }
            }
        }

    }
}
