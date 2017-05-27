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
        Point currentPoint = new Point();
        private EDrawingMode drawMode;
        private Object activDrawingObject;
        private double ClickX = 0.0;
        private double ClickY = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Canvas myCanvas = (Canvas)sender;
            ClickX = e.GetPosition(myCanvas).X;
            ClickY = e.GetPosition(myCanvas).Y;

            myCanvas.MouseMove += DrawingFunctionality;
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
            myCanvas.MouseUp += MyCanvas_MouseUp;
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Canvas myCanvas = (Canvas)sender;
            myCanvas.MouseMove -= DrawingFunctionality;
            activDrawingObject = null;
        }

        private void DrawingFunctionality(object sender, MouseEventArgs e)
        {
            Canvas myCanvas = (Canvas)sender;
            switch (drawMode)
            {
                case EDrawingMode.building:
                    
                    Rectangle rect = activDrawingObject as Rectangle ?? new Rectangle();
                    //rect.Stroke = new Brush(Colors.Blue);
                    rect.Width = e.GetPosition(myCanvas).X - ClickX;
                    rect.Height = e.GetPosition(myCanvas).Y - ClickY;

                    myCanvas.Children.Remove(rect);
                    myCanvas.Children.Add(rect);
                    Canvas.SetLeft(rect, ClickX);
                    Canvas.SetTop(rect, ClickY);
                    
                    break;
                case EDrawingMode.street:
                    break;
                case EDrawingMode.pavement:
                    break;
            }
        }

            private void Canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                main_canvas.Children.Add(line);
            }
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           Console.Out.Write( SVGDesigner.makeQuader(100,200,130));
        }

        private void Building_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            this.drawMode = EDrawingMode.building;
        }

        private void Street_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            this.drawMode = EDrawingMode.street;
        }

        private void Pavement_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            this.drawMode = EDrawingMode.pavement;
        }
        }
    }
}