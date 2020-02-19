using System.Windows.Forms;
using System.Windows.Input;
using JetBrains.Annotations;
using Tyln.Maid.Coding.Domain.Hotkey;

namespace Tyln.Maid.Coding.Domain.CodingTask
{
    [UsedImplicitly]
    public class AhkTaskManager
    {
        private readonly IHotkeyRegistry registry;
        private readonly Tasks.Tasks tasks;

        public AhkTaskManager(Tasks.Tasks tasks, IHotkeyRegistry registry)
        {
            this.tasks = tasks;
            this.registry = registry;
        }

        public void RegisterTasks()
        {
            registry.Register("volume_increase", Keys.F12, ModifierKeys.Control, tasks.IncreaseVolume);
            registry.Register("volume_decrease", Keys.F11, ModifierKeys.Control, tasks.DecreaseVolume);
            registry.Register("volume_mute", Keys.F10, ModifierKeys.Control, tasks.Mute);
            registry.Register("media_play_pause", Keys.F9, ModifierKeys.Control, tasks.PlayPauseMedia);
            registry.Register("prism_convert_auto_property", Keys.NumPad7, ModifierKeys.Control, tasks.ConvertToPrismProperty);
        }

        public double Type { get; set; }
    }
}