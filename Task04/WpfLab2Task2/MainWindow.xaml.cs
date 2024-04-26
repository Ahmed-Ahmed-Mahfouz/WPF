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

namespace WpfLab2Task2
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
            // Set Text
            rBoxText.Document.Blocks.Clear();
            rBoxText.Document.Blocks.Add(new Paragraph(new Run("Replace default text with initial text value")));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Select All
            rBoxText.Focus();
            rBoxText.SelectAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Clear
            rBoxText.Document.Blocks.Clear();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // Prepend
            if (rBoxText.Document.Blocks.Count == 0)
            {
                rBoxText.Document.Blocks.Add(new Paragraph(new Run("*** Prepended text *** ")));
            }
            else if (rBoxText.Document.Blocks.FirstBlock is Paragraph paragraph)
            {
                if (paragraph.Inlines.FirstInline is Run run)
                {
                    run.Text = "*** Prepended text *** " + run.Text;
                }
                else
                {
                    paragraph.Inlines.InsertBefore(paragraph.Inlines.FirstInline, new Run("*** Prepended text *** "));
                }
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            // Insert
            if (rBoxText.Document.Blocks.Count == 0)
            {
                rBoxText.Document.Blocks.Add(new Paragraph(new Run("*** inserted text ***")));
            }
            else
            {
                rBoxText.CaretPosition.InsertTextInRun("*** inserted text ***");
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // Append
            rBoxText.AppendText(" *** Appended text ***");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Cut
            if (rBoxText.Selection.Text.Length > 0)
            {
                string selectedText = rBoxText.Selection.Text;
                rBoxText.Cut();
                MessageBox.Show("Cut: " + selectedText, "Cut Operation", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Select text to cut first.", "Cut Operation", MessageBoxButton.OK);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Paste
            rBoxText.Paste();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Undo
            rBoxText.Undo();
        }

        private void OnCheckReadOrWrite(object sender, RoutedEventArgs e)
        {
            // Editable or Read Only
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Content.ToString() == "Editable")
                {
                    rBoxText.IsReadOnly = false;
                }
                else
                {
                    rBoxText.IsReadOnly = true;
                }
            }
        }

        private void OnCheckTextAlignment(object sender, RoutedEventArgs e)
        {
            // Text Alignment
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                TextAlignment alignment = TextAlignment.Left;
                switch (rb.Content.ToString())
                {
                    case "Left":
                        alignment = TextAlignment.Left;
                        break;
                    case "Center":
                        alignment = TextAlignment.Center;
                        break;
                    case "Right":
                        alignment = TextAlignment.Right;
                        break;
                }

                foreach (Block block in rBoxText.Document.Blocks)
                {
                    block.TextAlignment = alignment;
                }
            }
        }
    }
}