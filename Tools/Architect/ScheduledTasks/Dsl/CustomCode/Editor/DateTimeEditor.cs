using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace Architect.ScheduledTasks.Editors
{
    public class CCDateTimeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            if (context != null)
                return UITypeEditorEditStyle.Modal;

            return base.GetEditStyle(context);
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null)) 
            {
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (editorService != null)
                {
                    DateTimeForm modalEditor = new DateTimeForm();

                    modalEditor.SelectedDate = (DateTime)value;

                    if (editorService.ShowDialog(modalEditor) == DialogResult.OK)
                        return modalEditor.SelectedDate;
                }
            }

            return base.EditValue(context, provider, value);
        }
    }
}
