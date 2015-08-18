using System.Web;
using CloudCore.Core.ModuleActions;

namespace CloudCore.Web.Core.Menu
{
    public class ModuleActionAndParent
    {
        public ModuleAction Action { get; set; }
        public ModuleAction Parent { get; set; }

        public MenuItem TransformAsMenuItem()
        {
            return new MenuItem()
                {
                    ID = Action.ListIndex,
                    PID = Parent.ListIndex,
                    isFolder = Action.IsFolder,
                    MType = Action.IsFolder?"folder":Action.ActionType.ToString().ToLower(),
                    Title = Action.ActionTitle,
                    Path = VirtualPathUtility.ToAbsolute( string.Format("~/{0}/{1}/{2}", Action.Area, Action.Controller, Action.Action) )
                };
        }
    }
}
