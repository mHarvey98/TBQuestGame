using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using WageSlave.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WageSlave;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        // Fields
        private Player _player;
        private List<string> _messages;
        private List<Occupation> _allOccupations;
        private DateTime _gameStartTime;
        private Map _gameMap;
        private Location _currentLocation;
        private Location _selectedLocation;
        private string _currentLocationName;
        private ObservableCollection<Location> _accessibleLocations;


        // Properties
        public List<Occupation> AllOccupations
        {
            get { return _allOccupations; }
            set { _allOccupations = value; }
        }

        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;

                OnPropertyChanged("SelectedLocation");
            }
        }

        public DateTime GameStartTime
        {
            get { return _gameStartTime; }
            set { _gameStartTime = value; }
        }

        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;

                OnPropertyChanged("CurrentLocation");
            }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
            }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public List<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }


        //Constructors
        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(        // Constructor for new GameSessionView
            Player player,
            List<string> initialMessages,
            Map gameMap,
            Location currentLocation,
            List<Occupation> allOccupations)
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _currentLocationName = currentLocation.Name;
            _currentLocation = currentLocation;
            _allOccupations = allOccupations;

            InitializeView();
        }

        //Methods

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            _accessibleLocations = _gameMap.AccessibleLocations;
            UpdateAccessibleLocation();
        }

        public void OnPlayerMove()
        {
            if (_selectedLocation != _currentLocation) // Execute code if selected location isn't the same as current location
            {
                try
                {
                    //
                    // set new current location
                    //
                    _currentLocationName = _selectedLocation.Name;

                    _currentLocation = AccessibleLocations.FirstOrDefault(l => l.Name == _currentLocationName);

                    OnPropertyChanged("CurrentLocation");

                    //
                    // update cash
                    //
                    _player.PreviousCash = _player.Cash;
                    _player.Cash += _selectedLocation.ModifyCash;

                    // First attempt at removing accessible locations
                    UpdateAccessibleLocation();
                }
                catch (NullReferenceException) { } // prevents null selected location from crashing program
            }
        }

        //
        // return the list of strings converted to a single string 
        // with new lines between each message
        //
        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        public void UpdateAccessibleLocation()
        {
            _accessibleLocations.Clear();

            foreach (Location location in _gameMap.Locations)
            {
                if (location.Accessible == true)
                {
                    _accessibleLocations.Add(location);
                }
            }

            //remove current location
            _accessibleLocations.Remove(_accessibleLocations.FirstOrDefault(l => l.Name == _currentLocationName));

            OnPropertyChanged("CurrentLocation");
            OnPropertyChanged("AccessibleLocations");
        }



    }
}
