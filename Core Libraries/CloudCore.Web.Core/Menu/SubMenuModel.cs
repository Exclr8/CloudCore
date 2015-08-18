using System.Collections.Generic;
using System.Linq;
using CloudCore.Core;
using CloudCore.Web.Core.Caching;

using WebGrease.Css.Extensions;

namespace CloudCore.Web.Core.Menu
{
    public class SubMenuModel : MenuData
    {
        private List<SubMenuItem> SubMenuItems { get; set; }
        public List<SubMenuItem> RootMenuItems { get; set; }

        public SubMenuModel()
        {            
            Update();
            SubMenuItems = new List<SubMenuItem>();
            var items = MenuItems.OrderBy(r => r.PID);

            items.ForEach(x => SubMenuItems.Add(new SubMenuItem(x)));

            var rootMenuItems = SubMenuItems.FindAll(m => m.PID == 0);
            rootMenuItems.ForEach(FindAndAddChildren);

            //TODO : If you can do it better be my guest....
            RootMenuItems = rootMenuItems.Where(x => x.Title != "System Administration").OrderBy(x => x.Title).ToList();
            RootMenuItems.Add(rootMenuItems.First(x => x.Title == "System Administration"));
        }

        private void FindAndAddChildren(SubMenuItem parentItem)
        {
            parentItem.ChildSubMenuItems.AddRange(SubMenuItems.FindAll(m => m.PID == parentItem.ID));
            foreach (var childSubMenuItem in parentItem.ChildSubMenuItems)
                FindAndAddChildren(childSubMenuItem);
        }

        protected override sealed void Update()
        {
            base.Update();
        }
    }    

    public class SubMenuItem : MenuItem
    {
        public List<SubMenuItem> ChildSubMenuItems { get; set; }

        public SubMenuItem(MenuItem item)
        {
            ID = item.ID;
            PID = item.PID;
            Path = item.Path;
            MType = item.MType;
            Title = item.Title;
            isFolder = item.isFolder;
            ChildSubMenuItems = new List<SubMenuItem>();
        }
    }
}