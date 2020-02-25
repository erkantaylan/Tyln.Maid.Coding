using System.Windows;
using Prism.Ioc;
using Tyln.Maid.ClockReminder.Views;

namespace Tyln.Maid.ClockReminder
{
    public partial class App
    {
        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <inheritdoc />
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }
    }
}