using JetBrains.Annotations;
using Prism.Mvvm;
using Tyln.Maid.Coding.Domain.CodingTask;

namespace Tyln.Maid.Coding.Desktop.ViewModels
{
    [UsedImplicitly]
    public class ShellWindowViewModel : BindableBase
    {
        private readonly AhkTaskManager taskManager;
        private string title;

        public ShellWindowViewModel(AhkTaskManager taskManager)
        {
            this.taskManager = taskManager;
            title = "Tyln.Maid.Coding.Desktop";
            taskManager.RegisterTasks();
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}