using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace WpfLab1Task2
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

        private void OnColorChanged(object sender, RoutedEventArgs e)
        {
            string con = (sender as RadioButton).Content.ToString();
            switch (con)
            {
                case "Red":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Red;
                    break;
                case "Green":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Green;
                    break;
                case "Blue":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Yellow":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Yellow;
                    break;
                case "Cyan":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Cyan;
                    break;
                case "Magenta":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;
                case "Black":
                    inkcan.DefaultDrawingAttributes.Color = Colors.Black;
                    break;
            }
        }

        private void OnModeChanged(object sender, RoutedEventArgs e)
        {
            string con = (sender as RadioButton).Content.ToString();
            switch (con)
            {
                case "Ink":
                    inkcan.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select":
                    inkcan.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Erase":
                    inkcan.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "EraseByStroke":
                    inkcan.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void OnShapeChanged(object sender, RoutedEventArgs e)
        {
            string con = (sender as RadioButton).Content.ToString();
            switch (con)
            {
                case "Rectangle":
                    inkcan.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    break;
                case "Ellipse":
                    inkcan.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;
            }
        }
        private void OnSizeChanged(object sender, RoutedEventArgs e)
        {
            string con = (sender as RadioButton).Content.ToString();
            switch (con)
            {
                case "Small":
                    inkcan.DefaultDrawingAttributes.Height = 2;
                    inkcan.DefaultDrawingAttributes.Width = 2;
                    break;
                case "Normal":
                    inkcan.DefaultDrawingAttributes.Height = 10;
                    inkcan.DefaultDrawingAttributes.Width = 10;
                    break;
                case "Large":
                    inkcan.DefaultDrawingAttributes.Height = 25;
                    inkcan.DefaultDrawingAttributes.Width = 25;
                    break;
            }
        }

        private void ClearCanvas(object sender, RoutedEventArgs e)
        {
            inkcan.Strokes.Clear();
        }

        private void CopyCanvas(object sender, RoutedEventArgs e)
        {
            if (inkcan.GetSelectedStrokes().Count > 0)
            {
                inkcan.CopySelection();
            }
        }

        private void CutCanvas(object sender, RoutedEventArgs e)
        {
            if (inkcan.GetSelectedStrokes().Count > 0)
            {
                inkcan.CutSelection();
            }
        }

        private void PasteCanvas(object sender, RoutedEventArgs e)
        {
            inkcan.Paste();
        }

        private void SaveDraw(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ink serialized format (*.isf)|*.isf";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    inkcan.Strokes.Save(fs);
                }
            }
        }

        private void LoadDraw(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ink serialized format (*.isf)|*.isf";
            if (openFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    StrokeCollection strokes = new StrokeCollection(fs);
                    inkcan.Strokes = strokes;
                }
            }
        }
    }
}