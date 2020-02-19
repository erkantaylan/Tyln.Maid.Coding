using System.Threading.Tasks;
using System.Windows;
using AutoHotkey.Interop;
using JetBrains.Annotations;
using Clipboard = System.Windows.Forms.Clipboard;

namespace Tyln.Maid.Coding.Domain.CodingTask.Tasks
{
    [UsedImplicitly]
    public class Tasks
    {
        private readonly AutoHotkeyEngine ahk;


        public Tasks(AutoHotkeyEngine ahk)
        {
            this.ahk = ahk;
        }

        public async Task IncreaseVolume()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Up}";
                for (var i = 0; i < 10; i++)
                {
                    ahk.ExecRaw(code);
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
                    ahk.ExecRaw(code);
                }
            });
        }

        public async Task Mute()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Mute}";
                ahk.ExecRaw(code);
            });
        }

        public async Task PlayPauseMedia()
        {
            await Task.Factory.StartNew(() =>
            {
                const string code = "Send, {Volume_Play_Pause}";
                ahk.ExecRaw(code);
            });
        }

        public async Task ConvertToPrismProperty()
        {
            await Task.Factory.StartNew(() =>
            {
                //cut the current line
                const string function = "CopyLine(){\r\nSend, ^x\r\nclipboard := Clipboard\r\nreturn clipboard\r\n}";
                ahk.ExecRaw(function);
                string eval = ahk.Eval("CopyLine()");
                string line = eval.Trim().Trim('\n'); //trim spaces and line breaks
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                string[] split = line.Split(' ');
                string propertyType = split[1];
                string propertyName = split[2];
                string lowercase = $"{propertyName[0].ToString().ToLower()}{propertyName.Substring(1)}";

                var pattern = @"
private {2} {0};
public {2} {1}
{{
    get => {0};
    set => SetProperty(ref {0},value);
}}
";
                pattern = string.Format(pattern, lowercase, propertyName, propertyType);
                Application.Current.Dispatcher?.Invoke(() => Clipboard.SetText(pattern));
                var paste = "Send, ^v";
                ahk.ExecRaw(paste);
            });
        }
    }
}