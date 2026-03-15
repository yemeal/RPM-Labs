using RPM_Lab3.Creators;
using System.Windows;
using System.Windows.Controls;

namespace RPM_Lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            drawPanel.Children.Clear();

            if (comboBoxColors.SelectedItem == null) return;

            string selectedColor = ((ComboBoxItem)comboBoxColors.SelectedItem).Content.ToString();

            CircleCreator circleCreator = null;
            SquareCreator squareCreator = null;
            TriangleCreator triangleCreator = null;

            switch (selectedColor)
            {
                case "Red": 
                    circleCreator = new RedCircleCreator();
                    squareCreator = new RedSquareCreator();
                    triangleCreator = new RedTriangleCreator();
                    break;
                case "Blue":
                    circleCreator = new BlueCircleCreator();
                    squareCreator = new BlueSquareCreator();
                    triangleCreator = new BlueTriangleCreator();
                    break;
                case "Green":
                    circleCreator = new GreenCircleCreator();
                    squareCreator = new GreenSquareCreator();
                    triangleCreator = new GreenTriangleCreator();
                    break;
                default:
                    return;
            }

            var circle = circleCreator.CreateCircle();
            var square = squareCreator.CreateSquare();
            var triangle = triangleCreator.CreateTriangle();

            drawPanel.Children.Add(circle.CreateUIElement());
            drawPanel.Children.Add(square.CreateUIElement());
            drawPanel.Children.Add(triangle.CreateUIElement());
        }
    }
}