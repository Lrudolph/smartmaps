using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;
using SmartMaps.Utils;
using Microsoft.Win32;
using SmartMaps.Data;

namespace SmartMaps
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
        private MapProject myDataSource;

        public MainWindow()
        {
            InitializeComponent();
            myDataSource = new MapProject();
            DataContext = myDataSource;
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
            if (activDrawingObject != null)
            {
                Canvas myCanvas = (Canvas)sender;
                switch (drawMode)
                {
                    case EDrawingMode.rectangle:
                        Rectangle rect = activDrawingObject as Rectangle;
                        myDataSource.Rectangles.Add(new Building(rect.ActualHeight, rect.ActualWidth, 100, new Point(ClickX, ClickY), true));
                        break;
                    case EDrawingMode.zylinder:
                        Ellipse ellipse = activDrawingObject as Ellipse;
                        myDataSource.Circles.Add(new Building(ellipse.ActualHeight, ellipse.ActualWidth, 100, new Point(ClickX, ClickY), false));
                        break;
                }
                myCanvas.MouseMove -= DrawingFunctionality;
                ClickX = 0.0;
                ClickY = 0.0;
                activDrawingObject = null;
            }
        }

        private void DrawingFunctionality(object sender, MouseEventArgs e)
        {
            Canvas myCanvas = (Canvas)sender;
            switch (drawMode)
            {
                case EDrawingMode.rectangle:
                    DrawRectangle(3.0, Brushes.Blue, myCanvas, e);
                    break;
                case EDrawingMode.zylinder:
                    DrawZylinder(3.0, Brushes.Blue, myCanvas, e);
                    break;
                case EDrawingMode.line:
                    DrawLine(2.0, Brushes.Red, myCanvas, e);
                    break;
            }
        }

        private void DrawZylinder(double v, SolidColorBrush colorBrush, Canvas myCanvas, MouseEventArgs e)
        {
            if (activDrawingObject as Ellipse != null) myCanvas.Children.Remove((Ellipse)activDrawingObject);
            Ellipse rect = activDrawingObject as Ellipse ?? new Ellipse();
            rect.Stroke = colorBrush;
            rect.StrokeThickness = v;
            double xPosition = e.GetPosition(myCanvas).X > 0 ? e.GetPosition(myCanvas).X : 0.0;
            double yPosition = e.GetPosition(myCanvas).Y > 0 ? e.GetPosition(myCanvas).Y : 0.0;
            double maxX = Math.Max(ClickX, xPosition);
            double minX = Math.Min(ClickX, xPosition);
            double maxY = Math.Max(ClickY, yPosition);
            double minY = Math.Min(ClickY, yPosition);
            rect.Width = maxX - minX;
            rect.Height = maxY - minY;
            myCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, minX);
            Canvas.SetTop(rect, minY);
            activDrawingObject = rect;
        }

        private void DrawRectangle(double v, SolidColorBrush colorBrush, Canvas myCanvas, MouseEventArgs e)
        {
            if (activDrawingObject as Rectangle != null) myCanvas.Children.Remove((Rectangle)activDrawingObject);
            Rectangle rect = activDrawingObject as Rectangle ?? new Rectangle();
            rect.Stroke = colorBrush;
            rect.StrokeThickness = v;
            double xPosition = e.GetPosition(myCanvas).X > 0 ? e.GetPosition(myCanvas).X : 0.0;
            double yPosition = e.GetPosition(myCanvas).Y > 0 ? e.GetPosition(myCanvas).Y : 0.0;
            double maxX = Math.Max(ClickX, xPosition);
            double minX = Math.Min(ClickX, xPosition);
            double maxY = Math.Max(ClickY, yPosition);
            double minY = Math.Min(ClickY, yPosition);
            rect.Width = maxX - minX;
            rect.Height = maxY - minY;
            myCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, minX);
            Canvas.SetTop(rect, minY);
            activDrawingObject = rect;
        }

        private void DrawLine(double v, SolidColorBrush colorBrush, Canvas myCanvas, MouseEventArgs e)
        {
            if (activDrawingObject as Line != null) myCanvas.Children.Remove((Line)activDrawingObject);
            Line line = activDrawingObject as Line ?? new Line();
            line.StrokeThickness = v;
            line.Stroke = colorBrush;
            double xPosition = e.GetPosition(myCanvas).X > 0 ? e.GetPosition(myCanvas).X : 0.0;
            double yPosition = e.GetPosition(myCanvas).Y > 0 ? e.GetPosition(myCanvas).Y : 0.0;
            line.X2 = xPosition;
            line.X1 = ClickX;
            line.Y1 = ClickY;
            line.Y2 = yPosition;
            myCanvas.Children.Add(line);
            activDrawingObject = line;
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
            MemoryStream ms = new MemoryStream();
            SmartMaps.Properties.Resources.KarteHTW.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            img.StreamSource = ms;
            img.EndInit();
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
            String mySvg = SVGDesigner.makeQuader(100,200,130);
            SaveFileDialog dlg = new SaveFileDialog()
            {
                FileName = "schnittmuster", // Default file name
                DefaultExt = ".svg", // Default file extension
                Filter = "SVG Grafiken (.svg)|*.svg" // Filter files by extension
            };

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                File.WriteAllText(dlg.FileName, mySvg);
            }
        }

        private void Rectangle_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            this.drawMode = EDrawingMode.rectangle;
        }

        private void Zylinder_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            this.drawMode = EDrawingMode.zylinder;
        }

        private void Line_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            this.drawMode = EDrawingMode.line;
        }

        private void Load_Reference_Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "image files (*.png)|*.png";
            if (openFileDialog1.ShowDialog() == true)
            {
                String imagename = openFileDialog1.FileName;
                Console.WriteLine(imagename);
                BitmapImage image = new BitmapImage(new Uri(imagename,
                                             UriKind.Absolute));
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.Freeze();
                resource_img.Source = image;
            }
        }
    }
}
