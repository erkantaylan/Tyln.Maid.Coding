using System.Threading.Tasks;
using AutoHotkey.Interop;
using JetBrains.Annotations;

namespace Tyln.Maid.Coding.Domain.CodingTask.Tasks
{
    [UsedImplicitly]
    public class Tasks
    {
        private readonly AutoHotkeyEngine engine;

        public Tasks(AutoHotkeyEngine engine)
        {
            this.engine = engine;
        }

        public async Task IncreaseVolume()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Up}";
                for (var i = 0; i < 10; i++)
                {
                    engine.ExecRaw(code);
                }
            });
        }

        public async Task DecreaseVolume()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Down}";
                for (var i = 0; i < 10; i++)
                {
                    engine.ExecRaw(code);
                }
            });
        }

        public async Task Mute()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Mute}";
                engine.ExecRaw(code);
            });
        }

        public async Task PlayPauseMedia()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Play_Pause}";
                engine.ExecRaw(code);
            });
        }

        public string Asdf { get; set; }

        public async Task ConvertToPrismProperty()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = @"Send,^x";
                string eval = engine.Eval(code);
                string line = eval.Trim().Trim('\n');
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                if (!line.StartsWith("public"))
                {
                    
                    return;
                }

                string[] split = line.Split(' ');
                
                
            });
        }
        
    }
}