﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMaps
{
    public class SVGDesigner
    {
        public static String makeQuader(int height, int depth, int width)
        {
            SvgTemplate page = new SvgTemplate(height, width, depth, 200);
            return page.TransformText();
           // System.IO.File.WriteAllText("outputPage.html", pageContent);
        }
    }
}
