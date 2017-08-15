using System;
using System.Windows;
using System.Windows.Threading;
using System.Drawing;
using System.Windows.Forms;

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
        TimeSpan _time;

        public int VariableTime;
        public int temptime;
        public int Vt;

        NotifyIcon appIcon = new NotifyIcon();

        window2 win2 = new window2();
        win2.Show();


        public MainWindow()
        {
            InitializeComponent();
            startclock();
            Stop.IsEnabled = false;
            Continue.IsEnabled = false;
            Reset.IsEnabled = false;
            Notification();
            

        }

        private void Notification()
        {
            appIcon.Icon = new Icon("C:/Users/Taz/Documents/Visual Studio 2015/Projects/Turn Off PC/Turn Off PC/Resources/icon.ico");
            appIcon.Visible = true;
        }

        private void startclock()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent1;
            timer.Start();
        }

        private void tickevent1(object sender, EventArgs e)
        {
            Time_Now.Text = DateTime.Now.ToString("HH:mm:ss  dd.MM.yyyy"); 
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
                    timer2.Stop();
                    
                }

                if (_time == TimeSpan.Zero)
                {
                    timer2.Stop();
                    //System.Windows.MessageBox.Show("Shutdown.");
                    System.Diagnostics.Process.Start("shutdown", "/s /f /t 060 /c " + (char)34 + "YOUR COMPUTER WILL BE TURNED OFF IN 1 MINUTE" + (char)34);
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                VariableTime--;
                temptime = (int)_time.Seconds;
            },
            System.Windows.Application.Current.Dispatcher);
            
        }

        private void countup()
        {
            timer3 = new DispatcherTimer();
            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Interval = TimeSpan.FromMilliseconds(1);
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Vt < VariableTime)
            {
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                Vt++;
                RemaingTime.Text = Convert_to_time(Vt);
                
               
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
            countup();
        }

        private void TwoHour_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 7200;
            countup();
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
            countup();
        }

        private void FourHours_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 14400;
            countup();
        }

        private void TenMin_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 600;
            countup();
        }

        private void TwentyMin_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 1200;
            countup();
        }

        private void ThirtyMin_Click(object sender, RoutedEventArgs e)
        {
            VariableTime += 1800;
            countup();
        }

        private void ResetTime_Click(object sender, RoutedEventArgs e)
        {
            VariableTime = 0;
            temptime = 0;
            Vt = 0;
            RemaingTime.Text = Convert_to_time(Vt);
        }
    }
}
