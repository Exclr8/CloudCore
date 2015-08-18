using System;
using System.Linq;
using System.Collections.Generic;
using CloudCore.Core.Menu;

namespace CloudCore.Core.ModuleActions
{
    public class ModuleActionList
    {
        private readonly Dictionary<Tuple<string, string, string>, ModuleAction> actionList;
        public Dictionary<Tuple<string, string, string>, ModuleAction> Actions { get { return actionList; } }

        public ModuleActionList()
        {
            actionList = new Dictionary<Tuple<string, string, string>, ModuleAction>();
        }
        public ModuleActionList(IEnumerable<ModuleAction> moduleActions)
        {
            actionList = new Dictionary<Tuple<string, string, string>, ModuleAction>();

            foreach (var action in moduleActions)
            {
                AddAction(action);
            }
        }

        public void AddAction(ModuleAction action)
        {
            if (action.IsFolder)
            {
                actionList.Add(Tuple.Create(action.ActionGuid.ToString().ToLower(), string.Empty, string.Empty), action);
            }
            else
            {
                actionList.Add(Tuple.Create(action.Area.ToLower(), action.Controller.ToLower(), action.Action.ToLower()), action);
            }
            action.ListIndex = actionList.Count - 1;
        }

        public ModuleAction FindAction(string area, string controller, string action)
        {
            return FindAction(Tuple.Create(area.ToLower(), controller.ToLower(), action.ToLower()));
        }

        public ModuleAction FindAction(Tuple<string, string, string> keyAsTuple)
        {
            ModuleAction modAction;
            try
            {
                modAction = actionList[keyAsTuple];
            }
            catch
            {
                modAction = null;
            }
            return modAction;

        }

        public bool HasAction(string area, string controller, string action)
        {
            return HasAction(Tuple.Create(area.ToLower(), controller.ToLower(), action.ToLower()));
        }

        public bool HasAction(Tuple<string, string, string> keyAsTuple)
        {
            return actionList.ContainsKey(keyAsTuple);
        }

        public bool HasAction(Guid actionGuid)
        {
            return actionList.FirstOrDefault(x => x.Value.ActionGuid.Equals(actionGuid)).Value != null;
        }

        public bool HasItems()
        {
            return actionList.Count > 0;
        }

        public IEnumerable<ModuleAction> AsEnumerable()
        {
            var actions = actionList.GetEnumerator();

            while (actions.MoveNext())
            {
                yield return actions.Current.Value;
            }
        }

        internal ModuleAction GetRoot()
        {
            return actionList.FirstOrDefault(x => x.Value.GetType() == typeof(MenuRoot)).Value;
        }
    }
}
