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
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace WageSlave.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        public PlayerSetupView(PlayerSetupViewModel playerSetupViewModel)
        {

            InitializeComponent();

            

            //todo Finish Player Setup Window
            SetupWindow();
        }

        private void SetupWindow()
        {
            //List<string> schoolRoute = Enum.GetNames(typeof(Player.SchoolRoute)).ToList();



            //
            // generate lists for each enum to use in the combo boxes       NOT USING ENUMS ANYMORE
            //
            //List<string> schoolRoute = Enum.GetNames(typeof(Player.SchoolRoute)).ToList();
            //List<string> occupation = Enum.GetNames(typeof(Player.Occupation)).ToList();
            //ComboBox_SchoolRoute.ItemsSource = schoolRoute;
            //ComboBox_Occupation.ItemsSource = occupation;

            //
            // hide error message box initially
            //
            //ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                //
                // get values from combo boxes
                //
                //Enum.TryParse(ComboBox_SchoolRoute.SelectionBoxItem.ToString(), out Player.SchoolRoute schoolRoute);
                //Enum.TryParse(ComboBox_Occupation.SelectionBoxItem.ToString(), out Player.Occupation occupation);

                //
                // set player properties
                //
                //_player.School_Route = schoolRoute;
                //_player.occupation = occupation;

                Visibility = Visibility.Hidden;
            }
            else
            {
                //
                // display error messages
                //
                //ErrorMessageTextBlock.Visibility = Visibility.Visible;
                //ErrorMessageTextBlock.Text = errorMessage;
            }
        }

        /// <summary>
        /// validate user input and generate appropriate error messages
        /// </summary>
        /// <param name="errorMessage">user feedback</param>
        /// <returns>is user input valid</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (TextBox_Name.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                //_player.Name = TextBox_Name.Text;
            }

            return errorMessage == "" ? true : false;
        }




        // First Attempt at binding SchoolRoute to PlayerSetupWindow
        //
        //private Player.SchoolRoute _selectedMyEnumType;
        //public Player.SchoolRoute SelectedMyEnumType
        //{
        //    get { return _selectedMyEnumType; }
        //    set
        //    {
        //        _selectedMyEnumType = value;

        //    }
        //}

        //public IEnumerable<Player.SchoolRoute> MyEnumTypeValues
        //{
        //    get
        //    {
        //        return Enum.GetValues(typeof(Player.SchoolRoute))
        //            .Cast<Player.SchoolRoute>();
        //    }
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    ComboBox_Locations.ItemsSource = Enum.GetValues(typeof(Player.SchoolRoute)).Cast<Player.SchoolRoute>();
        //}
    }
}
