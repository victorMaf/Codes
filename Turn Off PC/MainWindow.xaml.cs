using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        public int VariableTime;
        TimeSpan _time;
        public int temptime;
        public int Vt;
        

        public MainWindow()
        {
            InitializeComponent();
            startclock();
            Stop.IsEnabled = false;
            Continue.IsEnabled = false;
            Reset.IsEnabled = false;
            

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
            OraActula.Text = DateTime.Now.ToString("HH:mm:ss  dd.MM.yyyy"); 
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

        private void countdown()
        {
            _time = TimeSpan.FromSeconds(VariableTime);
            timer2 = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimpRamas.Text = Convert_to_time(VariableTime);
                if (_time == TimeSpan.Zero)
                {
                    timer2.Stop();
                    MessageBox.Show("Shutdown");
                    //Process.Start("shutdown", "/s /t 0");
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                VariableTime--;
                temptime = (int)_time.Seconds;
            }, Application.Current.Dispatcher);

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
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                Vt++;
                TimpRamas.Text = Convert_to_time(Vt);
                
               
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
            TimpRamas.Text = Convert_to_time(Vt);
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
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Continue.Visibility = System.Windows.Visibility.Hidden;
            Stop.Visibility = System.Windows.Visibility.Visible;
            timer2.Start();
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
            TimpRamas.Text = Convert_to_time(Vt);
        }
    }
}
