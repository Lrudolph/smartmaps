namespace SmartMaps.Utils
{
    partial class SvgTemplate
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Depth { get; private set; }
        public int Level { get; private set; }
        public SvgTemplate(int height, int width, int depth, int level)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
            this.Level = level;
        }
    }
}
