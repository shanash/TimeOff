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

namespace TimeOff
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();

            // Run 태그에 텍스트 설정
            HourRun.Text = Define.WorkingTime.Hours.ToString();
            MinuteRun.Text = Define.WorkingTime.Minutes.ToString();

            LaunchRun.Text = Define.LunchTime.Hours.ToString();

            LeaveEarlyHourRun.Text = Define.LeaveEarlyTime.Hours.ToString();
            LeaveEarlyMinuteRun.Text = Define.LeaveEarlyTime.Minutes.ToString();
        }

        private void GithubUrl_Click(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)
            {
                UseShellExecute = true
            });
            e.Handled = true;
        }


        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
