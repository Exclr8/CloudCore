using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudCore.Core
{
    public interface ITableObjectModel
    {
        void AddTableObjectsToRender(TableObjectList tableObjectList);
    }
}
