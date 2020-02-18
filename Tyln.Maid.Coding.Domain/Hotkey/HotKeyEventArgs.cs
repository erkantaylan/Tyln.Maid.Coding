using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tyln.Maid.Coding.Domain.Hotkey
{
    public class HotKeyEventArgs : EventArgs
    {
        public readonly Keys Key;
        public readonly ModifierKeys Modifiers;

        public HotKeyEventArgs(Keys key, ModifierKeys modifiers)
        {
            Key = key;
            Modifiers = modifiers;
        }

        public HotKeyEventArgs(IntPtr hotKeyParam)
        {
            var param = (uint) hotKeyParam.ToInt64();
            Key = (Keys) ((param & 0xffff0000) >> 16);
            Modifiers = (ModifierKeys) (param & 0x0000ffff);
        }
    }
}