using System.Windows;
using AutoHotkey.Interop;
using Prism.Ioc;
using Prism.Mvvm;
using Tyln.Maid.Coding.Desktop.ViewModels;
using Tyln.Maid.Coding.Desktop.Views;

namespace Tyln.Maid.Coding.Desktop
{
    public partial class App
    {
        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterInstance(AutoHotkeyEngine.Instance);
        }

        /// <inheritdoc />
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        /// <inheritdoc />
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            //ViewModelLocationProvider.Register<ShellWindow, ShellWindowViewModel>();
        }
    }
}