using RPM_Lab3.Creators;
using System.Windows;
using System.Windows.Controls;
using RPM_Lab3.AbstractFactory;

namespace RPM_Lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IFigureFactory currentFactory;
        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            drawPanel.Children.Clear();

            if (comboBoxColors.SelectedItem == null) return;

            string selectedColor = ((ComboBoxItem)comboBoxColors.SelectedItem).Content.ToString();

            switch (selectedColor)
            {
                case "Red":
                    currentFactory = new RedFactory();
                    break;
                case "Blue":
                    currentFactory = new BlueFactory();
                    break;
                case "Green":
                    currentFactory = new GreenFactory();
                    break;
                default:
                    return;
            }

            var circle = currentFactory.CreateCircle();
            var square = currentFactory.CreateSquare();
            var triangle = currentFactory.CreateTriangle();

            drawPanel.Children.Add(circle.CreateUIElement());
            drawPanel.Children.Add(square.CreateUIElement());
            drawPanel.Children.Add(triangle.CreateUIElement());
        }
    }
}