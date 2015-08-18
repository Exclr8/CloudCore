using System.Collections.Generic;

namespace CloudCore.Web.Areas.CUI.Models
{
    public class SubMenuModel
    {
        public List<RootFolder> RootFolders { get; set; }

        public SubMenuModel()
        {
            RootFolders = new List<RootFolder>
            {
                new RootFolder("Clients", new List<SubMenuItem>
                {
                    new SubMenuItem("Create Client", "Client", "CreateClient"),
                    new SubMenuItem("Find Client", "Client", "CreateClient")
                }),
                new RootFolder("Deals", new List<SubMenuItem>
                {
                    new SubMenuItem("Create Deal", "Deal", "CreateDeal"),
                    new SubMenuItem("Find Deal", "Deal", "CreateClient")
                }),
                new RootFolder("Locations", new List<SubMenuItem>
                {
                    new SubMenuItem("Create Deal", "Deal", "CreateDeal"),
                    new SubMenuItem("Find Deal", "Deal", "CreateClient")
                }),
            };
        }
    }

    public class RootFolder
    {
        public string Title { get; set; }
        public List<SubMenuItem> ChildSubMenuItems { get; set; }

        public RootFolder(string title, List<SubMenuItem> childSubMenuItems)
        {
            Title = title;
            ChildSubMenuItems = childSubMenuItems;
        }
    }

    public class SubMenuItem
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public object Parameter { get; set; }

        public SubMenuItem(string title, string controller, string action, object parameter = null)
        {
            Title = title;
            Controller = controller;
            Action = action;
            Parameter = parameter;
        }
    }
}