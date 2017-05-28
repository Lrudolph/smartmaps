using System;

namespace SmartMaps.Data
{
    public abstract class ModelObject
    {
        public String IDname { get; private set; }
        public String soundFileName { get; private set; }
        public int TipToiCodeID { get; private set; }
    }
}
