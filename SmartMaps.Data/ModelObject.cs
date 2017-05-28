using System;

namespace SmartMaps.Data
{
    public abstract class ModelObject
    {
        public String IDname { get; set; } = "TestModelObject";
        public String soundFileName { get; private set; }
        public int TipToiCodeID { get; private set; }

        public override string ToString()
        {
            return IDname;
        }
    }
}
