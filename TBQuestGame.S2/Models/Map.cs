using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; // Allows the use of Observable Collection

namespace WageSlave.Models
{
    public class Map
    {
        // Fields
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private ObservableCollection<Location> _locations;

        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }



        // Properties
        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                ObservableCollection<Location> accessibleLocations = new ObservableCollection<Location>();
                foreach (var location in _locations)
                {
                    if (location.Accessible == true) // If location is accessible, add it to Observable Collection of locations
                    {
                        accessibleLocations.Add(location);
                    }
                }
                return accessibleLocations;
            }

            //get
            //{
            //    ObservableCollection<Location> _accessibleLocations = (ObservableCollection<Location>)

            //    return _accessibleLocations;
            //}

        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        // Methods

        public void Move(Location location)
        {
            _currentLocation = location;
        }

    }
}
