using System.Collections.Generic;
using CloudCore.Web.Core.Menu;


namespace CloudCore.Web.Core.Caching
{
    public class MenuData : LiteralCache<MenuData>
    {

        private IEnumerable<MenuItem> _Items;

        public IEnumerable<MenuItem> MenuItems { get { return _Items; } }

        protected override void Update()
        {
            _Items = MenuStructure.PermittedMenuItems();
        }

    }
}
