using System.Collections.Generic;
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

namespace WpfLab2Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name ="Ahmed" , Salary = 10000,Image ="1.jpg"},
                new Employee() {Id = 2, Name ="Mohamed" , Salary = 5000,Image ="2.jpg"},
                new Employee() {Id = 3, Name ="Shadi" , Salary = 6000,Image ="3.jpg"},
                new Employee() {Id = 4, Name ="Abdallah" , Salary = 5000,Image ="4.jpg"},
                new Employee() {Id = 5, Name ="mahmoud" , Salary = 7000,Image ="5.jpg"},
                new Employee() {Id = 6, Name ="Mostafa" , Salary = 3000,Image ="3.jpg"},
                new Employee() {Id = 7, Name ="Ali" , Salary = 6000,Image ="4.jpg"},
                new Employee() {Id = 8, Name ="Ebrahim" , Salary = 5500,Image ="5.jpg"},
                new Employee() {Id = 9, Name ="Ziad" , Salary = 2500,Image ="1.jpg"},

            };

            lst.ItemsSource = employees;
        }
    }
}