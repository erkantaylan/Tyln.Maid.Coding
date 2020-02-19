using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using JetBrains.Annotations;

namespace Tyln.Maid.Coding.Domain.Hotkey
{
    [UsedImplicitly]
    public class HotkeyRegistry : IHotkeyRegistry
    {
        private readonly List<HotkeyAction> Actions = new List<HotkeyAction>();

        public HotkeyRegistry()
        {
            HotKeyManager.HotKeyPressed += HotKeyManagerOnHotKeyPressed;
        }

        public void UnRegister(string name)
        {
            HotkeyAction action = Actions.First(o => o.Name == name);
            HotKeyManager.UnregisterHotKey(action.Id);
        }

        /// <inheritdoc />
        public void UnRegisterAll()
        {
            Actions.ForEach(action => HotKeyManager.UnregisterHotKey(action.Id));
        }

        public void Register(string name, Keys key, ModifierKeys modifiers, Func<Task> task)
        {
            int id = HotKeyManager.RegisterHotKey(key, modifiers);
            var action = new HotkeyAction(name, id, task, key, modifiers);
            Actions.Add(action);
        }

        private void HotKeyManagerOnHotKeyPressed(object sender, HotKeyEventArgs e)
        {
            RunMachingTask(e.Key, e.Modifiers);
        }

        private void RunMachingTask(Keys key, ModifierKeys modifiers)
        {
            Func<Task> task = Actions.First(o => o.SameShortcut(key, modifiers)).Task;
            Task invoke = task.Invoke();
            //invoke.Wait();
            if (invoke.Exception != null)
            {
                throw invoke.Exception;
            }
        }
    }

    public interface IHotkeyRegistry
    {
        void Register(string name, Keys key, ModifierKeys modifiers, Func<Task> task);

        void UnRegister(string name);

        void UnRegisterAll();
    }
}