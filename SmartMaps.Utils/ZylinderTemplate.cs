using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMaps.Utils
{
    partial class TemplateZylinder
    {        
        public int Height { get; private set; }
        public int Radius { get; private set; }
        public int startY { get; private set; }
        public int startX { get; private set; }
        public TemplateZylinder(int height, int radius, int startY, int startX)
        {
            this.Height = height;
            this.Radius = radius;
            this.startY = startY;
            this.startX = startX;
        }        
    }
}
