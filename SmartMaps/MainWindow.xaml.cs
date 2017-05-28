using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;
using SmartMaps.Utils;

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
            ClickX = 0.0;
            ClickY = 0.0;
            activDrawingObject = null;
        }

        private void DrawingFunctionality(object sender, MouseEventArgs e)
        {
            Canvas myCanvas = (Canvas)sender;
            switch (drawMode)
            {
                case EDrawingMode.building:
                    DrawRectangle(3.0, Brushes.Blue, myCanvas, e);
                    break;
                case EDrawingMode.street:
                    DrawLine(4.0, Brushes.Gray, myCanvas, e);
                    break;
                case EDrawingMode.pavement:
                    DrawLine(2.0, Brushes.Green, myCanvas, e);
                    break;
            }
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
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "schnittmuster"; // Default file name
            dlg.DefaultExt = ".svg"; // Default file extension
            dlg.Filter = "SVG Grafiken (.svg)|*.svg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                File.WriteAllText(dlg.FileName, mySvg);
            }
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
