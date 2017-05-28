namespace SmartMaps.Utils
{
    partial class SvgTemplate
    {
        int Height;
        int Width;
        int Depth;
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
