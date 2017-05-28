using System.Windows;

namespace SmartMaps.Data
{
    public class Building : ModelObject
    {
        /// <summary>
        /// Definiert den Punkt Links Oben an einem Gebäude.
        /// </summary>
        public Point Position { get; private set ; }
        public double Height { get ; private set ; }
        public double Width { get ; private set ; }
        public double Depth { get ; private set ; }
    }
}
