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
        bool _newPlayer = false;                                          
        Player _player = new Player();
        List<string> _messages;
        List<Occupation> _allOccupations;
        //PlayerSetupView _playerSetupView = null;                          Uncomment
        Map _gameMap;
        Location _currentLocation;


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
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
            _gameMap = GameData.GameMap();
            _currentLocation = GameData.InitialGameMapLocation();
            _allOccupations = GameData.PlayerOccupations();
        }


        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupViewModel = new PlayerSetupViewModel(                    
                    _allOccupations, 
                    _gameMap,                   
                    _player,
                    _currentLocation);

                PlayerSetupView _playerSetupView = new PlayerSetupView(_playerSetupViewModel);
                _playerSetupView.DataContext = _playerSetupViewModel;
                _playerSetupView.ShowDialog();

                //
                // setup game-based player properties (not decided by player)
                //
                _player.Cash = 10000;
                _player.happiness = Character.Happiness.VeryHigh;
                _player.NetworkingPoints = 10;
            }
            else
            {
                _player = GameData.PlayerData();
            }
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
                _allOccupations);

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
