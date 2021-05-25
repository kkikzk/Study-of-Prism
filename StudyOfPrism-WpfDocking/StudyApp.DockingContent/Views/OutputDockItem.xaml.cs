using Prism.Events;
using StudyApp.DockingContent.Base.ViewModels;
using StudyApp.DockingContent.Base.Views;
using StudyApp.DockingContent.ViewModels;
using System.Windows.Controls;

namespace StudyApp.DockingContent.Views
{
    /// <summary>
    /// OutputDockItem.xaml の相互作用ロジック
    /// </summary>
    internal partial class OutputDockItem
    {
        public OutputDockItem()
        {
            InitializeComponent();

            ((OutputDockItemViewModel)DataContext).EventAggregator
                .GetEvent<OutputDockItemViewModel.OutputDockItemSelectedEvent>().Subscribe(OutputDockItemSelected, ThreadOption.UIThread);
        }

        public void OutputDockItemSelected()
        {
            var content = (ContentControl)Content;
            var contentBase = (ContentBase)content.Content;
            var dataContext = ((ContentBaseViewModel)contentBase.DataContext);
            dataContext.Activate();
        }
    }
}
