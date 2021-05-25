using Prism.Events;
using StudyApp.DockingContent.Base.ViewModels;
using StudyApp.DockingContent.Base.Views;
using StudyApp.DockingContent.ViewModels;
using System.Windows.Controls;

namespace StudyApp.DockingContent.Views
{
    /// <summary>
    /// PropertyDockItem.xaml の相互作用ロジック
    /// </summary>
    internal partial class PropertyDockItem
    {
        public PropertyDockItem()
        {
            InitializeComponent();

            ((PropertyDockItemViewModel)DataContext).EventAggregator
                .GetEvent<PropertyDockItemViewModel.PropertyDockItemSelectedEvent>().Subscribe(PropertyDockItemSelected, ThreadOption.UIThread);
        }

        public void PropertyDockItemSelected()
        {
            var content = (ContentControl)Content;
            var contentBase = (ContentBase)content.Content;
            var dataContext = ((ContentBaseViewModel)contentBase.DataContext);
            dataContext.Activate();
        }
    }
}
