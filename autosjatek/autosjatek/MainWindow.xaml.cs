using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace autosjatek
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll")]
        public static extern void AllocConsole();
        private Car jatekosauto ;

        public MainWindow()
        {
            InitializeComponent();
            AllocConsole();
            jatekosauto = new((int)(mycanvas.Width / 2), (int)(mycanvas.Height * 0.8), 100, 1);
            autoletrehozas(jatekosauto);
        }
        private void autoletrehozas(Car car)
        {
            Rectangle rectfasz = new Rectangle();
            rectfasz.Width = 100;
            rectfasz.Height = 100;
            rectfasz.Stroke = Brushes.Blue;
            rectfasz.Fill = new SolidColorBrush(Color.FromArgb(255,0,0,255));
            rectfasz.StrokeThickness = 2;
            Canvas.SetLeft(rectfasz, car.PosX);
            Canvas.SetTop(rectfasz, car.PosY);
            mycanvas.Children.Add(rectfasz);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    jatekosauto.Move(true);
                    Console.WriteLine(jatekosauto.PosX);
                    break;
                case Key.Left:
                    jatekosauto.Move(false);
                    Console.WriteLine(jatekosauto.PosX);
                    break;
                default: break;
            }
            
        }
        
    }
}
