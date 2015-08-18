using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProcessViewer.Library.Common
{
    class ComboBoxSelector : System.Windows.Controls.DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var presenter = (ContentPresenter)container;

            if (presenter.TemplatedParent is ComboBox)
            {
                return (DataTemplate)presenter.FindResource("RevisionComboCollapsed");

            }
            return (DataTemplate)presenter.FindResource("RevisionComboExpanded");
        }
    }
}
