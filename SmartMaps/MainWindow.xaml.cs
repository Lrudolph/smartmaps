using SmartMaps;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
           
            // ... Assign Source.
           // image.Source = (ImageSource)SmartMaps.Properties.Resources.KarteHTW;
            MemoryStream ms = new MemoryStream();
            SmartMaps.Properties.Resources.KarteHTW.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            img.StreamSource = ms;
            img.EndInit();
            

            // ... Get Image reference from sender.
            var image = sender as Image;
            image.Source = img;
        }

        private void RectangleClick(object sender, MouseButtonEventArgs e)
        {
            Rectangle t = (Rectangle)sender;
            double x= e.GetPosition(main_canvas).X;
            double y = e.GetPosition(main_canvas).Y;
            buildingmenu menu = new buildingmenu();
            main_canvas.Children.Add(menu);
            Canvas.SetLeft(menu, x);
            Canvas.SetTop(menu, y);
        }

        private void Rectangle_Click(object sender, MouseButtonEventArgs e)
        {
            Canvas t = (Canvas)sender;
            double x = e.GetPosition(t).X;
            double y = e.GetPosition(t).Y;
            buildingmenu menu = new buildingmenu();
            t.Children.Add(menu);
            Canvas.SetLeft(menu, x);
            Canvas.SetTop(menu, y);

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           Console.Out.Write( SVGDesigner.makeQuader(100,200,130));
        }
    }
}
