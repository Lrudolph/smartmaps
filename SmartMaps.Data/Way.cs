using System.Windows;

namespace SmartMaps.Data
{
    public class Way : ModelObject
    {
        public int Thickness { get; private set; }
        public Point Position1 { get; private set; }
        public Point Position2 { get; private set; }
    }
}
