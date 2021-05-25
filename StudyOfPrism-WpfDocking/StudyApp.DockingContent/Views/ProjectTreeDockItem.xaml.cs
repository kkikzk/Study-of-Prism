using Prism.Events;
using StudyApp.DockingContent.Base.ViewModels;
using StudyApp.DockingContent.Base.Views;
using StudyApp.DockingContent.ViewModels;
using System.Windows.Controls;

namespace StudyApp.DockingContent.Views
{
    /// <summary>
    /// ProjectTreeDockItem.xaml の相互作用ロジック
    /// </summary>
    internal partial class ProjectTreeDockItem
    {
        public ProjectTreeDockItem()
        {
            InitializeComponent();

            ((ProjectTreeDockItemViewModel)DataContext).EventAggregator
                .GetEvent<ProjectTreeDockItemViewModel.ProjectTreeDockItemSelectedEvent>().Subscribe(ProjectTreeDockItemSelected, ThreadOption.UIThread);
        }

        private void ProjectTreeDockItemSelected()
        {
            var content = (ContentControl)Content;
            var contentBase = (ContentBase)content.Content;
            var dataContext = ((ContentBaseViewModel)contentBase.DataContext);
            dataContext.Activate();
        }
    }
}
