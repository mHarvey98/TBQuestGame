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

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
            Location current = _gameSessionViewModel.CurrentLocation;

            //InitializeWindowTheme();

            InitializeComponent();

            ObservableCollection<Location> SelectableLocations = _gameSessionViewModel.AccessibleLocations;
            var list = from AccessibleLocations in SelectableLocations where AccessibleLocations != current select AccessibleLocations;
            ComboBox_TravelLocations.ItemsSource = list;




            //ComboBox_TravelLocations.SetBinding(
            //    ItemsControl.ItemsSourceProperty,
            //    new Binding { Source = Map.AccessibleLocations });

            //myComboBox.SetBinding(
            //ItemsControl.ItemsSourceProperty,
            //new Binding { Source = myList });

            //myComboBox.SetBinding(
            //Selector.SelectedItemProperty,
            //new Binding("SelectedItem") { Source = mySelectedItemSource });
        }

        private void InitializeWindowTheme()
        {
            this.Title = "Laughing Leaf Productions";
        }

        private void Button_TravelGo_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerMove();
        }
    }
}
