using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Modeling;
using System.Windows;

namespace Architect.CustomCode.ContextMenu
{
    public abstract class CmdArchitectBase : DSLMenuCommandImplBase
    {
        protected readonly Guid commandGuid = new Guid("294A7B97-9247-41EC-81E5-3F97A5C8E70B");

        public override void StatusHandler(CommandSetState state)
        {
            MenuCommand.Visible = true;
            MenuCommand.Enabled = true;
        }
    }
}
