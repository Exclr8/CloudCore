using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class BaseBatchStart
    {
        internal sealed partial class StartActivityGuidPropertyHandler
        {
            protected override void OnValueChanged(BaseBatchStart element, Guid oldValue, Guid newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);

                if (element.Store.InSerializationTransaction)
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "create new model")
                    return;

                if (oldValue == newValue)
                    return;

                var propertiesList = SubProcessFiles.GetModelElementProperties(element, "StartActivityGuid");
                var baseClass = (element is DatabaseBatchStart) ? " : " + FileType.SqlBatchStartActivity.ToString() : string.Empty;

                SubProcessFiles.CreatePropertiesFile(element.Store, element.VisioId, element.SubProcess.VisioId, baseClass, propertiesList);
            }
        }
    }
}
