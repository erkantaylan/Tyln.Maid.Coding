using System;
using System.Windows.Interop;
using Vanara.PInvoke;

namespace Tyln.Maid.ClockReminder.Views
{
    public partial class ShellWindow
    {
        private const int WsExTransparent = 0x00000020;

        public ShellWindow()
        {
            InitializeComponent();
            ContentRendered += OnContentRendered;
        }

        private void OnContentRendered(object sender, EventArgs e)
        {
            IntPtr windowHandle = new WindowInteropHelper(this).Handle;
            int extentedStyle = User32.GetWindowLong(windowHandle, User32.WindowLongFlags.GWL_EXSTYLE);
            User32.SetWindowLong(windowHandle, User32.WindowLongFlags.GWL_EXSTYLE, extentedStyle | WsExTransparent);
        }
    }
}