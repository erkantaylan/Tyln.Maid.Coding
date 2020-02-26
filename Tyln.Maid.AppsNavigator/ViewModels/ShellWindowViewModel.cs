using JetBrains.Annotations;
using Prism.Mvvm;

namespace Tyln.Maid.AppsNavigator.ViewModels
{
    
    [UsedImplicitly]
    public class ShellWindowViewModel : BindableBase
    {
        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}