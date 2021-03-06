﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architect.CustomCode.ContextMenu;
using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;

namespace Architect
{
    internal partial class ScheduledTasksCommandSetBase : DslShell::CommandSet
    {
        protected ScheduledTasksCommandSetBase(global::System.IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override global::System.Collections.Generic.IList<global::System.ComponentModel.Design.MenuCommand> GetMenuCommands()
        {
            var commands = base.GetMenuCommands();

            commands.Add(new DSLMenuCommand<DeployCommand>(new EventHandler(OnPopUpMenuDisplayAction), new EventHandler(OnCommandInvoke)));

            return commands;
        }

        CommandSetState GetDiagramState()
        {
            var state = new CommandSetState();
            state.CurrentSelection = this.CurrentSelection;
            state.CurrentDocView = this.CurrentDocView;
            return state;
        }

        internal void OnPopUpMenuDisplayAction(object sender, EventArgs e)
        {
            var command = sender as IDSLMenuCommand;
            var state = GetDiagramState();

            var impl = command.GetImplementation();
            impl.StatusHandler(state);
        }


        internal void OnCommandInvoke(object sender, EventArgs e)
        {
            var command = sender as IDSLMenuCommand;
            var state = GetDiagramState();

            var impl = command.GetImplementation();
            impl.InvokeHandler(state);
        }

    }
}
