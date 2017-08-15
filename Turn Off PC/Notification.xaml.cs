using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Turn_Off_PC
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public static class Noti_temptime
        {
            public static int noti_temp_time { get; set; }

        }

        public Notification()
        {
            InitializeComponent();
        }
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Noti_temptime.noti_temp_time = 5;
            Hide();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Noti_temptime.noti_temp_time = 10;
            Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /f /t 060 /c " + (char)34 + "YOUR COMPUTER WILL BE TURNED OFF IN 1 MINUTE" + (char)34);
        }
    }
}
