using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Architect.ProcessOverview
{
    //public partial class BTSubProcessSerializer
    //{
       
    //    protected override void WritePropertiesAsAttributes(SerializationContext serializationContext, ModelElement element, global::System.Xml.XmlWriter writer)
    //    {
    //        // Always call the base class so any extensions are serialized
    //        base.WritePropertiesAsAttributes(serializationContext, element, writer);

    //        BTSubProcess instanceOfBTSubProcess = element as BTSubProcess;
    //        global::System.Diagnostics.Debug.Assert(instanceOfBTSubProcess != null, "Expecting an instance of BTSubProcess");

    //        // Name
    //        if (!serializationContext.Result.Failed && !string.IsNullOrWhiteSpace(serializationContext.Location))
    //        {
    //            global::System.String propValue = instanceOfBTSubProcess.Name;
    //            if (!serializationContext.Result.Failed)
    //            {
    //                ProcessOverviewSerializationHelper.Instance.WriteAttributeString(serializationContext, element, writer, "name", propValue);
    //            }
    //        }
    //        // SubProcessRef
    //        if (!serializationContext.Result.Failed && !string.IsNullOrWhiteSpace(serializationContext.Location))
    //        {
    //            global::Microsoft.VisualStudio.Modeling.Integration.ModelBusReference propValue = instanceOfBTSubProcess.SubProcessRef;
    //            string serializedPropValue = SerializationUtilities.GetString<global::Microsoft.VisualStudio.Modeling.Integration.ModelBusReference>(serializationContext, propValue);
    //            if (!serializationContext.Result.Failed)
    //            {
    //                ProcessOverviewSerializationHelper.Instance.WriteAttributeString(serializationContext, element, writer, "subProcessRef", serializedPropValue);
    //            }
    //        }
    //    }
    //}
}
