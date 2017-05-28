using System.Collections.ObjectModel;

namespace SmartMaps.Data
{
    public class MapProject
    {
        public int LevelHeight { get; set; }
        public ObservableCollection<Building> Buildingparts { get; set; } = new ObservableCollection<Building>();
        public ObservableCollection<Way> Wayparts { get; set; } = new ObservableCollection<Way>();
        public MapProject()
        {
            Buildingparts.Add(new Building()
            {
                IDname = "Z1Test",
            });
        }
    }
}
