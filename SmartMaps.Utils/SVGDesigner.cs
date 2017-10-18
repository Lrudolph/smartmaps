using System;

namespace SmartMaps.Utils
{
    public class SVGDesigner
    {
        public static String makeQuader(int height, int depth, int width)
        {
            SvgTemplate page = new SvgTemplate(height, width, depth, 200);
            return page.TransformText();
           // System.IO.File.WriteAllText("outputPage.html", pageContent);
        }

        public static string makeZylinder(int v1, int v2, int v3)
        {
            TemplateZylinder temp = new TemplateZylinder(v1, v2, v3, 300);
            return temp.TransformText();
        }
    }
}
