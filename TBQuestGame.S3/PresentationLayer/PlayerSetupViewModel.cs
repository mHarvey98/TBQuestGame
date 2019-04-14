using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WageSlave.Models;
using TBQuestGame.Models;

namespace WageSlave.PresentationLayer
{
    public class PlayerSetupViewModel : ObservableObject
    {
        // Fields
        private List<Occupation> _allOccupations;
        private Map _gameMap;
        private Occupation _selectedOccupation;
        private Player _player;
        private Location _currentLocation;


        // Properties
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;

                OnPropertyChanged(nameof(Player));
            }
        }

        public Occupation SelectedOccupation
        {
            get { return _selectedOccupation; }
            set
            {
                _selectedOccupation = value;

                OnPropertyChanged(nameof(SelectedOccupation));
                Player.Occupation = SelectedOccupation;
            }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set
            {
                _gameMap = value;

                OnPropertyChanged(nameof(GameMap));
            }

            
        }

        public List<Occupation> AllOccupations
        {
            get { return _allOccupations; }
            set { _allOccupations = value; }
        }

        // Constructors
        public PlayerSetupViewModel()
        {

        }

        public PlayerSetupViewModel(List<Occupation> allOccupations, Map gameMap, Player player, Location currentLocation)
        {
            _allOccupations = allOccupations;
            _gameMap = gameMap;
            _player = player;
            _currentLocation = currentLocation;

            _player.Name = "";

        }
    }
}
