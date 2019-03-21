using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame.PresentationLayer;
using WageSlave.Models;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using System.Windows.Resources;
using TBQuestGame;
using WageSlave;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;
        string lastMove = "UP";
        
        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
            Location current = _gameSessionViewModel.CurrentLocation;
            _gameSessionViewModel.Player.PreviousCash = 9999;

            //InitializeWindowTheme(); Not sure what to do with this

            InitializeComponent();
        }

        private void InitializeWindowTheme()
        {
            this.Title = "WageSlave";
        }



        private void Button_TravelGo_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerMove(); // function updates Cash based on location travelled to

            if (_gameSessionViewModel.Player.Cash > _gameSessionViewModel.Player.PreviousCash) // If cash went up, do this animation
            {
                if (lastMove == "UP") // If last move was up, go up again; green to green
                {

                    ((Storyboard)this.Resources["Label_PlayerCash_NumberUp_Again"]).Begin(this);

                }
                else // move up; red to green
                {
                    ((Storyboard)this.Resources["Label_PlayerCash_NumberUp"]).Begin(this);
                    lastMove = "UP";
                }

            }

            else if (_gameSessionViewModel.Player.Cash < _gameSessionViewModel.Player.PreviousCash) // If cash went down, do this animation
            {
                if (lastMove == "DOWN") // If last move was down, go down again; red to red
                {
                    ((Storyboard)this.Resources["Label_PlayerCash_NumberDown_Again"]).Begin(this);
                }
                else // move down; green to red
                {
                    ((Storyboard)this.Resources["Label_PlayerCash_NumberDown"]).Begin(this);
                    lastMove = "DOWN";
                }

            }

            else
            {
                ((Storyboard)this.Resources["Label_PlayerCash_Error"]).Begin(this);
            }

            //Updating PreviousCash is now handled in OnPlayerMove Method
            //
            //_gameSessionViewModel.Player.PreviousCash = _gameSessionViewModel.Player.Cash;
        }
    }
}
