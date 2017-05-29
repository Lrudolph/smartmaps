using System;

namespace SmartMaps.Data
{
    // An abstract model of all mapobjects (Buildings, Streets etc.)
    public abstract class ModelObject
    {
        // Map-Project unique Identifier
        public String IDname { get; set; }

        // Absolute Path to the soundfile played, whether the Object is touched with tiptoi
        public String soundFilePath { get; private set; }

        // The ID of the TipToi-Point-Code
        public int TipToiCodeID { get; private set; }

        // Override default ToString() Methode for easy Databinding to GUI
        public override string ToString()
        {
            return IDname;
        }
    }
}
