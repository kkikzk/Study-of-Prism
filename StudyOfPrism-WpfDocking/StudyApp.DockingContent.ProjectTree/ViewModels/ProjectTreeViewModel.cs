﻿using Design.StudyApp.ActiveViewManager;
using Reactive.Bindings;
using StudyApp.DockingContent.Base.ViewModels;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ProjectTreeViewModel : ContentBaseViewModel
    {
        private readonly IProjectTreeData _data;

        public ReactiveCollection<IProjectTreeData> Children { get { return _data.Children; } }

        public ProjectTreeViewModel(IProjectTreeData data, IActiveViewManager activeViewManager)
            : base(activeViewManager)
        {
            _data = data;
            Disposables.Add(_data);
        }

        protected override void CopyFunction()
        {
        }

        protected override void PasteFunction()
        {
        }
    }
}
