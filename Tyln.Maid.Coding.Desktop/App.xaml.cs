using System.Windows;
using AutoHotkey.Interop;
using Prism.Ioc;
using Tyln.Maid.Coding.Desktop.Views;
using Tyln.Maid.Coding.Domain.Hotkey;

namespace Tyln.Maid.Coding.Desktop
{
    public partial class App
    {
        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterInstance(AutoHotkeyEngine.Instance);
            container.Register<IHotkeyRegistry, HotkeyRegistry>();
        }

        /// <inheritdoc />
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }
    }
}