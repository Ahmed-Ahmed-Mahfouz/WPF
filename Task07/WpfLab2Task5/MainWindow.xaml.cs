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

namespace WpfLab2Task5
{
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private string selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(((Button)sender).Content.ToString(), out double selectedValue))
            {
                txtDisplay.Text = (txtDisplay.Text == "0") ? $"{selectedValue}" : $"{txtDisplay.Text}{selectedValue}";
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out lastNumber))
            {
                txtDisplay.Text = "0";
            }

            selectedOperator = ((Button)sender).Content.ToString();
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double newNumber))
            {
                switch (selectedOperator)
                {
                    case "+":
                        result = lastNumber + newNumber;
                        break;
                    case "-":
                        result = lastNumber - newNumber;
                        break;
                    case "x":
                        result = lastNumber * newNumber;
                        break;
                    case "÷":
                        result = lastNumber / newNumber;
                        break;
                }

                txtDisplay.Text = result.ToString();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text = $"{txtDisplay.Text}.";
            }
        }
    }
}