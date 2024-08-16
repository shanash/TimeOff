using System.Diagnostics;
using System.Text;
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
                    UseShellExecute = true // UseShellExecute를 true로 설정해야 디폴트 브라우저가 사용됩니다.
                });
            }
            catch (Exception ex)
            {
                // 예외 처리: 웹사이트를 열지 못한 경우
                MessageBox.Show($"Cannot open the website: {ex.Message}");
            }
        }
    }
}