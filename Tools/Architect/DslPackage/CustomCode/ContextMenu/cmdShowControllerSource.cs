using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Modeling;
using System.Windows;
using Architect.CustomCode.Helpers;

namespace Architect.CustomCode.ContextMenu
{
    class CmdShowControllerSource : CmdShowSourceBase
    {
        int commandID = 0x101;

        public override void InvokeHandler(CommandSetState state)
        {
            var store = state.CurrentDocView.CurrentDiagram.Store;
            var btPage = (SelectedPage.ModelElement as CloudcoreUser);

            SubProcessFiles.OpenController(store, btPage.VisioId, btPage.SubProcess.VisioId);
        }

        public override System.ComponentModel.Design.CommandID GetCommandID()
        {
            return new CommandID(this.commandGuid, commandID);
        }

    }
}
