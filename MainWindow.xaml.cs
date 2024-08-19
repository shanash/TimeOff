using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HourTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 숫자인지 확인
            e.Handled = !IsTextAllowed(e.Text);

            // 입력된 텍스트와 기존 텍스트를 합쳐서 범위 확인
            var newText = (sender as TextBox).Text + e.Text;
            if (int.TryParse(newText, out int hour))
            {
                // 0 ~ 23 범위 확인
                if (hour < 0 || hour > 23)
                {
                    e.Handled = true;
                }
            }
        }

        private void MinuteTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 숫자인지 확인
            e.Handled = !IsTextAllowed(e.Text);

            // 입력된 텍스트와 기존 텍스트를 합쳐서 범위 확인
            var newText = (sender as TextBox).Text + e.Text;
            if (int.TryParse(newText, out int minute))
            {
                // 0 ~ 59 범위 확인
                if (minute < 0 || minute > 59)
                {
                    e.Handled = true;
                }
            }
        }

        private static bool IsTextAllowed(string text)
        {
            // 숫자만 허용
            Regex regex = new Regex("[^0-9]+"); // 숫자가 아닌 문자
            return !regex.IsMatch(text);
        }

        private void InputCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            // 현재 시각 가져오기
            DateTime now = DateTime.Now;

            // 시와 분을 TextBox에 입력
            HourTextBox.Text = now.Hour.ToString();
            MinuteTextBox.Text = now.Minute.ToString();
        }

        private void ShowTimeOff_Click(object sender, RoutedEventArgs e)
        {
            // TextBox에서 시(hour)와 분(minute) 가져오기
            if (int.TryParse(HourTextBox.Text, out int hour) && int.TryParse(MinuteTextBox.Text, out int minute))
            {
                // 출근 시간을 DateTime 객체로 생성
                DateTime startTime = DateTime.Today.AddHours(hour).AddMinutes(minute);

                int addedHour = (LeaveEarlyCheckBox.IsChecked == true) ? 3 : 7;
                int addedMinute = (LeaveEarlyCheckBox.IsChecked == true) ? 45 : 30;

                if (LunchCheckBox.IsChecked == true)
                {
                    addedHour++;
                }

                if (DinnerCheckBox.IsChecked == true)
                {
                    addedHour++;
                }

                // 현재 시각 가져오기
                DateTime timeoff = startTime + new TimeSpan(addedHour, addedMinute, 0);

                // 결과 표시
                MessageBox.Show($"나의 퇴근시간은 {((timeoff.Hour <= 12) ? $"오전 {timeoff.Hour}": $"오후 {timeoff.Hour - 12}")}시 {timeoff.Minute}분 이다.", "알림");
            }
            else
            {
                MessageBox.Show("유효한 시각을 입력하세요.");
            }
        }

        private void OpenWebsite_Click(object sender, RoutedEventArgs e)
        {
            // 열고 싶은 웹사이트 URL
            string url = "https://g1playground.ncpworkplace.com/user/main/myboard/index";

            try
            {
                // 디폴트 웹브라우저로 URL 열기
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot open the website: {ex.Message}");
            }
        }

        private void HowToUse_Click(object sender, RoutedEventArgs e)
        {
            string message = "지금시간넣기\n" +
                             "\t지금의 시간을 출근시간에 입력합니다.\n" +
                             "\n" +
                             "난 언제 퇴근해?\n" +
                             "\t퇴근시간을 팝업으로 알려줍니다.\n" +
                             "\n" +
                             "알람 켜기\n" +
                             "\t퇴근 1분전 최상단 메세지 팝업으로 퇴근을 알려주며\n" +
                             "\t네이버웍스가 자동으로 켜집니다.\n" +
                             "\t프로그램을 종료할 경우 작동하지 않습니다.\n" +
                             "\n" +
                             "시작 레지 등록\n" +
                             "\t윈도우 시작 시 프로그램이 켜집니다.\n" +
                             "\n" +
                             "시작 레지 해제\n" +
                             "\t윈도우 시작 시 등록된 레지를 삭제합니다.";

            MessageBox.Show(message, "How To Use");
        }
    }
}