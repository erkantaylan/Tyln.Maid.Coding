using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tyln.Maid.Coding.Domain.Hotkey
{
    public class HotkeyAction
    {
        public HotkeyAction(string name, int id, Func<Task> task, Keys key, ModifierKeys modifiers)
        {
            Name = name;
            Id = id;
            Task = task;
            Key = key;
            Modifiers = modifiers;
        }

        public string Name { get; }
        public int Id { get; }
        public Func<Task> Task { get; }
        public Keys Key { get; }
        public ModifierKeys Modifiers { get; }

        public bool SameShortcut(Keys key, ModifierKeys modifiers)
        {
            return key == Key && modifiers == Modifiers;
        }
    }
}