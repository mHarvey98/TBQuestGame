using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.DataLayer;
using TBQuestGame.Models;
using TBQuestGame.PresentationLayer;
using WageSlave.Models;
using WageSlave.PresentationLayer;

namespace TBQuestGame.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        PlayerSetupViewModel _playerSetupViewModel;
        bool _newPlayer = true;                                          
        Player _player = new Player();
        List<string> _messages;
        List<Occupation> _allOccupations;
        //PlayerSetupView _playerSetupView = null;                          Uncomment
        Map _gameMap;
        Location _currentLocation;
        Loan _loanTemplate;


        public GameBusiness()
        {
            InitializeDataSet();
            SetupPlayer();
            InstantiateAndShowView();

            //_playerSetupViewModel = new GameSessionViewModel(
            //    _player,
            //    _messages,
            //    _gameMap,
            //    _currentLocation,
            //    _allOccupations);

            //gameSessionView.DataContext = _playerSetupViewModel;

            

        }

        /// <summary>
        /// Initialize Data Set
        /// </summary>
        private void InitializeDataSet()
        {
            _player = GameData.PlayerData(); //This is done in the SetupPlayer method
            _messages = GameData.InitialMessages();
            _gameMap = GameData.GameMap();
            _allOccupations = GameData.PlayerOccupations();
            _loanTemplate = GameData.GameLoan();

            if (!_newPlayer)
            {
                _currentLocation = _gameMap.Locations[0];
            }
        }


        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _player = GameData.PlayerData();

                _playerSetupViewModel = new PlayerSetupViewModel(                    
                    _allOccupations, 
                    _gameMap,                   
                    _player,
                    _currentLocation);

                PlayerSetupView _playerSetupView = new PlayerSetupView(_playerSetupViewModel);
                _playerSetupView.DataContext = _playerSetupViewModel;
                _playerSetupView.ShowDialog();

                _player = _playerSetupViewModel.Player; // Returns the traits selected in the Player Setup View
                _currentLocation = _playerSetupViewModel.GameMap.CurrentLocation;

                //
                // setup game-based player properties (not decided by player)
                //
                _player.Age = 18;
                _player.Cash = 5000;
                _player.Happiness = 100;
                _player.NetworkingPoints = 10;
                _player.Salary = _player.Occupation.AvgSalary;
                _player.Wage = _player.Salary / 52; // Gives a weekly salary
                _player.WageWithAssets = _player.Wage; // No assets, wage is the same
                _player.Debt = _player.Occupation.Debt;
                _player.Expenses = 230;
                _player.PlayerGameItems = new System.Collections.ObjectModel.ObservableCollection<GameItem> { }; // prevents Player's items from being null
                _player.HousingOption = Player.HousingOptions.Stay_With_Parents;
                _player.WeeklyRent = 0;
                _player.HouseHappiness = -1;
                _player.CommutingOption = Player.CommutingOptions.Bicycle;
                _player.CommutingCost = 0;
                _player.CommutingHappiness = -.2;

            }
            else
            {
                _player = GameData.PlayerData();
                _player.Occupation = _allOccupations[3]; // default occupation: Cosmetologist
                _player.Salary = _player.Occupation.AvgSalary;
                _player.Wage = _player.Salary / 52; // Gives a weekly salary
                _player.WageWithAssets = _player.Wage;
                _player.Debt = _player.Occupation.Debt;
                _player.HousingOption = Player.HousingOptions.Stay_With_Parents;
                _player.WeeklyRent = 0;
                _player.HouseHappiness = -1;
                _player.CommutingOption = Player.CommutingOptions.Bicycle;
                _player.CommutingCost = 0;
                _player.CommutingHappiness = -.2;
            }

            //_currentLocation = _gameMap.CurrentLocation;
        }



        /// <summary>
        /// Create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //

            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _messages,
                _gameMap,
                _currentLocation,
                _allOccupations,
                _loanTemplate);

            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            //
            // dialog window is initially hidden to mitigate issues with
            // main window closing after dialog window closes
            //

            //_playerSetupView.Close();
        }
    }
}
