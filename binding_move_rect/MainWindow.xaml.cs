using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace binding_move_rect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyRect _rect;
        public MainWindow()
        {
            InitializeComponent();

            _rect = new MyRect();
            _rect.Width = 100;
            _rect.Height = 100;
            _rect.Background = Brushes.Blue;
            _rect.BorderBrush = Brushes.Black;
            _rect.BorderThickness = new Thickness(3);


            MyCanvas.Children.Add(_rect);
            Canvas.SetLeft(_rect, 100);
            Canvas.SetTop(_rect, 10);

            DataContext = _rect;
        }
    }
}
