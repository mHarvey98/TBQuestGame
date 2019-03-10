using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.DataLayer;
using TBQuestGame.Models;
using TBQuestGame.PresentationLayer;
using WageSlave.PresentationLayer;

namespace TBQuestGame.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        //bool _newPlayer = true;                                           Uncomment
        Player _player = new Player();
        List<string> _messages;
        //PlayerSetupView _playerSetupView = null;                          Uncomment


        public GameBusiness()
        {
            //SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        /// <summary>
        /// Initialize Data Set
        /// </summary>
        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
        }


        //private void SetupPlayer()
        //{
        //    if (_newPlayer)
        //    {
        //        PlayerSetupView _playerSetupView = new PlayerSetupView(_player);
        //        _playerSetupView.ShowDialog();

        //        //
        //        // setup game based player properties
        //        //
        //        _player.Cash = 10000;
        //        _player.happiness = Character.Happiness.VeryHigh;
        //        _player.NetworkingPoints = 10;
        //    }
        //    else
        //    {
        //        _player = GameData.PlayerData();
        //    }
        //}



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
                GameData.InitialMessages()
                );

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
