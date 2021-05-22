using Design.StudyApp.ProjectContentManager;
using System;

namespace StudyApp.Model
{
    public class ProjectContentManager : IProjectContentManager
    {
        private readonly Action _action;

        public ProjectContentManager(Action action)
        {
            _action = action;
        }

        public void Execute()
        {
            _action();
        }
    }
}
