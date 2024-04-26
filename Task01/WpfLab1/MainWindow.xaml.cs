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

namespace WpfLab1
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
        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            foreach (var child in Grid.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            string firstName = textBox.Text;
            string lastName = textBox1.Text;
            string gender = textBox2.Text;
            string address = textBox3.Text;
            string phone = textBox4.Text;
            string mobile = textBox5.Text;
            string email = textBox6.Text;
            string jobTitle = textBox7.Text;

            string message = $"You have entered:\n" +
                             $"Name = {firstName} {lastName}\n" +
                             $"Gender = {gender}\n" +
                             $"Address = {address}\n" +
                             $"Job Title = {jobTitle}\n" +
                             $"Phone = {phone}\n" +
                             $"Mobile = {mobile}\n" +
                             $"Email = {email}";

            
            MessageBoxResult result = MessageBox.Show(message, "Information", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                CancelClicked(sender, e);
            }
        }
    }
}