using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SmartMaps.Data
{
    class MapProject: INotifyPropertyChanged
    {
        public int LevelHeight { get; set; }
        public ObservableCollection<Building> Buildingparts { get; set; } = new ObservableCollection<Building>();
        public ObservableCollection<Way> Wayparts { get; set; } = new ObservableCollection<Way>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
