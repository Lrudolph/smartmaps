using System.Collections.ObjectModel;

namespace SmartMaps.Data
{
    public class MapProject
    {
        /// <summary> Dieser Parameter dient zum angeben der Höhe der Zwischenebene, die die Kraft auf Gebäude außerhalb der Talfalte weiterleitet. </summary>
        public int LevelHeight { get; set; }
        /// <summary> Observable List of all elementar 3D Map-Parts (e.g. cubiod-building elements) </summary>
        public ObservableCollection<Building> Rectangles { get; set; }
        
        public ObservableCollection<Building> Circles { get; set; }
        
        /// <summary> Observable List of all elementar 2D-Map-Parts (e.g. streets, pavements and crossroads)  </summary>
        public ObservableCollection<Way> Wayparts { get; set; }

        /// <summary> Vorinstatiierung der Collections, notwendig für das DataBinding. </summary>
        public MapProject()
        {
            Rectangles = new ObservableCollection<Building>();
            Circles = new ObservableCollection<Building>();
            Wayparts = new ObservableCollection<Way>();
        }
    }
}
