using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.VS.Controls.Wizard;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.CRO
{
    public abstract partial class BasePropertiesPage<PropertyItemType, DataColumnItemType> : WizardPage
        where PropertyItemType : UserControl, DataColumnItemType, new()
        where DataColumnItemType : IDataColumn
    {
        private IQueryData data = null;
        public Panel PropertiesPanel 
        {
            get
            {
                return this.Controls.Find("panel1", false)[0] as Panel;
            }
            
        }

        public BasePropertiesPage()
        {
            InitializeComponent();
            data = ((IQueryData)WizardDataStore.Data);
        }

        protected virtual void SetPropertyItemColumnValues(DataColumnItemType dataColumnItem, DataColumnItemType propertyItem)
        {
            UpdateObjectPropertiesFrom(((DataColumnItemType)propertyItem), dataColumnItem);
        }

        private void clearPropertyList()
        {
            PropertiesPanel.Controls.Clear();
        }

        protected void SaveProperties()
        {
            int i = 0;

            foreach (PropertyItemType item in PropertiesPanel.Controls)
            {
                var column = (DataColumnItemType)data.Columns[i];

                SavePropertyItem(column, item);

                i++;
            }
        }

        protected virtual void SavePropertyItem(DataColumnItemType dataColumnItem, PropertyItemType propertyItem)
        {
            UpdateObjectPropertiesFrom(dataColumnItem, propertyItem);
        }

        private static void UpdateObjectPropertiesFrom(IDataColumn target, IDataColumn source)
        {
            var targetItemType = target.GetType();
            var sourceItemType = source.GetType();

            List<PropertyInfo> properties = new List<PropertyInfo>();

            properties.AddRange(typeof(IDataColumn).GetProperties());
            properties.AddRange(typeof(DataColumnItemType).GetProperties());

            foreach (var property in properties)
            {
                var value = sourceItemType.GetProperty(property.Name).GetValue(source);
                var targetProperty = targetItemType.GetProperty(property.Name);

                if (targetProperty == null)
                    continue;

                targetProperty.SetValue(target, value);
            }
        }

        protected void BasePropertiesPage_SetActive(object sender, CancelEventArgs e)
        {
            this.SetWizardButtons(WizardButtons.Next | WizardButtons.Back);

            clearPropertyList();

            Point p = new Point(13, 0);

            foreach (DataColumnItemType item in data.Columns)
            {
                PropertyItemType i = new PropertyItemType();

                SetPropertyItemColumnValues(item, i);

                ((UserControl)i).Location = p;
                p.Y += 25;

                PropertiesPanel.Controls.Add(i);
            }
        }

        protected void BasePropertiesPage_WizardBack(object sender, WizardPageEventArgs e)
        {
            SaveProperties();
        }

        protected void BasePropertiesPage_WizardNext(object sender, WizardPageEventArgs e)
        {
            e.Cancel = !IsFormValid();

            if (e.Cancel)
                return;

            SaveProperties();
        }

        private bool IsFormValid()
        {
            if (!IsGlobalControlsValid(PropertiesPanel.Controls.Cast<PropertyItemType>().ToList()))
                return false;

            foreach (PropertyItemType item in PropertiesPanel.Controls)
                if (!IsEachPropertyItemValid(item))
                    return false;

            return true;
        }

        protected abstract bool IsGlobalControlsValid(List<PropertyItemType> controls);

        protected abstract bool IsEachPropertyItemValid(PropertyItemType item);

    }
}
