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
using System.Windows.Threading;

namespace WpfLab2Task3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            button.Foreground = new SolidColorBrush(Colors.Magenta);
            button.FontSize = 20;

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(.2) };
            timer.Tick += (s, args) =>
            {
                button.ClearValue(ForegroundProperty);
                button.ClearValue(FontSizeProperty);
                ((DispatcherTimer)s).Stop();
            };
            timer.Start();
        }
    }
}