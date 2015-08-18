using System;
using System.Drawing.Design;
using System.Security.Permissions;
// Need to add a reference to System.Drawing DLL.
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Design;
using System.Windows.Forms;

namespace Architect
{
    // FxCop rule: must have same security demands as parent class
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust"),
    PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    class ConnectionStringBuilder : UITypeEditor
    {
        /// <summary>
        /// Overridden to specify that our editor is a modal form
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle
        GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        /// <summary>
        /// Called by VS whenever the user clicks on the ellipsis in the 
        /// properties window for a property to which this editor is linked.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Get a reference to the underlying property element
            ElementPropertyDescriptor descriptor = context.PropertyDescriptor as ElementPropertyDescriptor; ModelElement underlyingModelElent = descriptor.ModelElement;
            // context.Instance also returns a model element, but this will either
            // be the shape representing the underlying element (if you selected
            // the element via the design surface), or the underlying element 
            // itself (if you selected the element via the model explorer)

            ModelElement element = context.Instance as ModelElement;
            ConnectionStringBuilderPopup theForm = new ConnectionStringBuilderPopup();

            try
            {
                if ((value != null) && (value.ToString() != ""))
                    theForm.MyConnectionString = value.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
            if (theForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                value = theForm.MyConnectionString.Trim();
            }
            return value;
        }
    }
}
