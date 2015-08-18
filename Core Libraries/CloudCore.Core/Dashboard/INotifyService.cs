using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.Core.Dashboard
{
    public interface INotifyService
    {
        void NotifyChanged(List<KpiTableEntity> values);
    }
}
