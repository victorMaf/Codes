using System;
using System.Windows;
using System.Windows.Threading;
using System.Drawing;
using System.Windows.Forms;
using static Turn_Off_PC.Notification;

namespace Turn_Off_PC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        DispatcherTimer timer2;
        DispatcherTimer timer3;

        public TimeSpan _time;
        public int VariableTime;
        public int temptime;
        public int Vt;

        NotifyIcon appIcon = new NotifyIcon();
        Notification win2 = new Turn_Off_PC.Notification();

        public MainWindow()
        {
            InitializeComponent();
            startclock();
            Stop.IsEnabled = false;
            Continue.IsEnabled = false;
            Reset.IsEnabled = false;
            Notification();
            win2.Show();
        }

        private void Notification()
        {
            appIcon.Icon = new Icon("C:/Users/Taz/Documents/Visual Studio 2015/Projects/Turn Off PC/Turn Off PC/Resources/icon.ico");
            appIcon.Visible = true;
        }

        private void startclock()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += tickevent1;
            timer.Start();
        }

        private void tickevent1(object sender, EventArgs e)
        {
            Time_Now.Text = DateTime.Now.ToString("HH:mm:ss  dd.MM.yyyy");
            Noti_Time();
        }

        private string Convert_to_time(int time)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            string elapsed = string.Format("{0:D1}d : {1:D2}h : {2:D2}m : {3:D2}s",
                t.Days,
                t.Hours,
                t.Minutes,
                t.Seconds);
            return elapsed;
        }

        private string Convert_to_time2(int time)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            string elapsed = string.Format("{0:D1} : {1:D2} : {2:D2} : {3:D2}",
                t.Days,
                t.Hours,
                t.Minutes,
                t.Seconds);
            return elapsed;
        }

        private void countdown()
        {
            _time = TimeSpan.FromSeconds(VariableTime);
            timer2 = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                RemaingTime.Text = Convert_to_time(VariableTime);

                if (_time == TimeSpan.FromSeconds(300))
                {                 
                    win2.Show();
                }

                if (_time == TimeSpan.Zero)
                {
                    timer2.Stop();
                    System.Diagnostics.Process.Start("shutdown", "/s /f /t 060 /c " + (char)34 + "YOUR COMPUTER WILL BE TURNED OFF IN 1 MINUTE" + (char)34);
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                VariableTime--;
                temptime = (int)_time.Seconds;
            },
            System.Windows.Application.Current.Dispatcher);
            
        }

        public  void remaining()
        {
            RemaingTime.Text = Convert_to_time(Vt);
        }

        public void CountUp()
        {
            timer3 = new DispatcherTimer();
            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Interval = TimeSpan.FromMilliseconds(1);
            timer3.Start();
        }

        public void timer3_Tick(object sender, EventArgs e)
        {
            if (Vt < VariableTime)
            {
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
                Vt++; remaining();
            }
            if (Vt == VariableTime)
                timer3.Stop();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            Continue.IsEnabled = true;
            Reset.IsEnabled = true;
            OneHour.IsEnabled = false;
            TwoHours.IsEnabled = false;
            ThreeHours.IsEnabled = false;
            FourHours.IsEnabled = false;
            TenMin.IsEnabled = false;
            TwentyMin.IsEnabled = false;
            ThirtyMin.IsEnabled = false;
            ResetTime.IsEnabled = false;

            switch (VariableTime)
            {

                case 0:
                    Start.IsEnabled = true;
                    Stop.IsEnabled = false;
                    Continue.IsEnabled = false;
                    OneHour.IsEnabled = true;
                    TwoHours.IsEnabled = true;
                    ThreeHours.IsEnabled = true;
                    FourHours.IsEnabled = true;
                    TenMin.IsEnabled = true;
                    TwentyMin.IsEnabled = true;
                    ThirtyMin.IsEnabled = true;
                    Reset.IsEnabled = false;
                    ResetTime.IsEnabled = true;
                    break;

                default:
                    countdown();
                    appIcon.ShowBalloonTip(500, "The countdown has started"," ", ToolTipIcon.Info);
                    break;

            }
        }

        private void OneHour_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 3600;
            CountUp();
        }

        private void TwoHour_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 7200;
            CountUp();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            VariableTime = 0;
            temptime = 0;
            Vt = 0;
            timer2.Stop();
            RemaingTime.Text = Convert_to_time(Vt);
            Start.IsEnabled = true;
            Stop.IsEnabled = false;
            Continue.IsEnabled = false;
            OneHour.IsEnabled = true;
            TwoHours.IsEnabled = true;
            ThreeHours.IsEnabled = true;
            FourHours.IsEnabled = true;
            TenMin.IsEnabled = true;
            TwentyMin.IsEnabled = true;
            ThirtyMin.IsEnabled = true;
            Reset.IsEnabled = false;
            ResetTime.IsEnabled = true;
            appIcon.ShowBalloonTip(500, "The countdown has stoped", " ", ToolTipIcon.Info);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Stop.Visibility = System.Windows.Visibility.Hidden;
            Continue.Visibility = System.Windows.Visibility.Visible;
            timer2.Stop();
            temptime = VariableTime;
            appIcon.ShowBalloonTip(500, "The countdown has stoped", " ", ToolTipIcon.Info);
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Continue.Visibility = System.Windows.Visibility.Hidden;
            Stop.Visibility = System.Windows.Visibility.Visible;
            timer2.Start();
            appIcon.ShowBalloonTip(500, "The countdown has started", " ", ToolTipIcon.Info);
        }

        private void ThreeHours_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 10800;
            CountUp();
        }

        private void FourHours_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 14400;
            CountUp();
        }

        private void TenMin_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 600;
            CountUp();
        }

        private void TwentyMin_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 1200;
            CountUp();
        }

        private void ThirtyMin_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 1800;
            CountUp();
        }

        private void ResetTime_Click(object sender, RoutedEventArgs e)
        {
            VariableTime = 0;
            temptime = 0;
            Vt = 0;
            RemaingTime.Text = Convert_to_time(Vt);
        }

        private void Noti_Time()
        {
            switch (Noti_temptime.noti_temp_time)
            {
                case 5:
                    VariableTime += 20;
                    CountUp();
                    Noti_temptime.noti_temp_time = 0;
                    break;

                case 10:
                    VariableTime += 600;
                    CountUp();
                    Noti_temptime.noti_temp_time = 0;
                    break;

                default:
                    break;
            }
            
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 310;
            CountUp();
        }


        
    }
}
