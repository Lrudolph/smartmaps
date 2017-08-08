using System.Windows;

namespace SmartMaps.Data
{
    public class Building : ModelObject
    {
        public bool IsRectangle { get; private set; }
        /// <summary> Definiert den Punkt Links Oben an einem Gebäude. </summary>
        public Point Position { get; private set ; }
        public double Height { get ; private set ; }
        public double Width { get ; private set ; }
        public double Depth { get ; private set ; }

        public Building (double height, double width, double depth, Point position, bool isRectangle)
        {
            this.Position = position;
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
            this.IsRectangle = isRectangle;
        }

        public override string ToString()
        {
            return "TestBuilding";
        }
    }
}
