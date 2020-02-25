using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using JetBrains.Annotations;
using Prism.Mvvm;

namespace Tyln.Maid.ClockReminder.ViewModels
{
    [UsedImplicitly]
    public class ShellWindowViewModel : BindableBase
    {
        private readonly DispatcherTimer hourlyTimer;
        private readonly DispatcherTimer timer;
        private string date;
        private string pmAm;
        private string second;
        private string time;
        private string title;

        public ShellWindowViewModel()
        {
            hourlyTimer = new DispatcherTimer();
            TimeSpan reminderMinutes = TimeSpan.FromMinutes(60 - DateTime.Now.Minute);
            int currentSeconds = DateTime.Now.Second;
            double reminderSeconds = reminderMinutes.TotalMinutes * 60 - currentSeconds;
            hourlyTimer.Interval = TimeSpan.FromSeconds(reminderSeconds);

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            hourlyTimer.Tick += HourlyTimerOnTick;
            timer.Tick += TimerOnTick;
            timer.Start();
            hourlyTimer.Start();
        }

        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }

        public string PmAm
        {
            get => pmAm;
            set => SetProperty(ref pmAm, value);
        }

        public string Second
        {
            get => second;
            set => SetProperty(ref second, value);
        }

        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private void HourlyTimerOnTick(object sender, EventArgs e)
        {
            //todo start animation
            hourlyTimer.Interval = TimeSpan.FromHours(1);
            Application.Current.MainWindow?.Activate();
            var sb = Application.Current.MainWindow?.FindResource("goTransparentStoryboard") as Storyboard;
            sb?.Begin();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            Date = DateTime.Now.ToString("dddd - MMMM dd");
            Time = DateTime.Now.ToString("hh:mm");
            PmAm = DateTime.Now.ToString("tt");
            Second = DateTime.Now.ToString("ss");
        }
    }
}