using System.Collections.Generic;
using System.Linq;
using CloudCore.Web.Core.Caching;

namespace CloudCore.Web.Models
{
    public class SystemAdminModel : MenuData
    {        
        public List<Core.Menu.SubMenuItem> Folders { get; set; }        
        private List<Core.Menu.SubMenuItem> allItems { get; set; }

        public SystemAdminModel()
        {
            Folders = new List<Core.Menu.SubMenuItem>();
            allItems = new List<Core.Menu.SubMenuItem>();
            Update();
            LoadAllItems();
        }

        private void LoadAllItems()
        {
            var items = MenuItems.OrderBy(r => r.PID);
            foreach (var item in items)
                allItems.Add(new Core.Menu.SubMenuItem(item));
        }

        public void LoadPages()
        {
            Folders.AddRange(allItems.Where(i => i.PID == 1));

            foreach (var folder in Folders)
                FindAndAddChildren(folder);
        }

        private void FindAndAddChildren(Core.Menu.SubMenuItem parentItem)
        {
            parentItem.ChildSubMenuItems.AddRange(allItems.Where(m => m.PID == parentItem.ID));
            foreach (var childSubMenuItem in parentItem.ChildSubMenuItems)
                FindAndAddChildren(childSubMenuItem);
        }

        protected override sealed void Update()
        {
            base.Update();
        }
    }
}
