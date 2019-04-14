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
using WageSlave.Models.GameObjects;
using WageSlave.PresentationLayer;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        public enum AssetTypes { Businesses, OtherItems, RealEstate, Stocks, Vehicles}
        public enum ActionTypes { Assets, Housing, Commuting, Work, Expenses, Debt, Loans } // Other ideas: Living expenses, Work-related actions (Quit, work more hours -- raise income, lower happiness)

        GameSessionViewModel _gameSessionViewModel;
        string lastMove = "UP";
        
        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
            Location current = _gameSessionViewModel.CurrentLocation;
            //_gameSessionViewModel.Player.PreviousCash = _gameSessionViewModel.Player.Cash;

            //InitializeWindowTheme(); Not sure what to do with this

            InitializeComponent();
            GameTimePause(); // Starts the game in the "Paused" State

            // "Actions" Box

            // "Assets"
            ComboBox_Actions.ItemsSource = Enum.GetValues(typeof(ActionTypes));
            ComboBox_Actions.SelectedValue = ActionTypes.Assets;

            ComboBox_LocationAssetTypes.ItemsSource = Enum.GetValues(typeof(AssetTypes));
            ComboBox_LocationAssetTypes.SelectedValue = AssetTypes.Businesses;

            // "Debt"
            //TextBox_Actions_Debt_Years.Text = (double)Slider_Actions_Debt_LoanPayments. * 52;
            UpdateDebtTextbox();


            // "Assets Owned" Box
            ComboBox_AssetTypes.ItemsSource = Enum.GetValues(typeof (AssetTypes)); // Sets data source for AssetTypes combobox
            ComboBox_AssetTypes.SelectedValue = AssetTypes.Businesses; // Sets the initial value of the combobox

            //GameItem gameItem = (GameItem)ComboBox_AssetName.SelectedValue;
            //TextBox_AssetsOwned_CurrentValue.Text = gameItem.Value.ToString();

            // AssetTypes userAssetType = (AssetTypes)this.ComboBox_AssetTypes.SelectedItem;
        }

        private void InitializeWindowTheme()
        {
            this.Title = "WageSlave";
        }



        private void Button_TravelGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_gameSessionViewModel.SelectedLocation.Name != _gameSessionViewModel.CurrentLocationName) // Don't execute if current location = selected location
                {
                    _gameSessionViewModel.OnPlayerMove(); // function updates Cash based on location travelled to
                    if (Label_YearsWeeksPassed_Paused.Visibility == Visibility.Visible) // show cash animation if game is Paused
                    {
                        UpdatePlayerCash();
                    }
                }
            }
            catch (Exception) {}
                                 
            //Updating PreviousCash is now handled in OnPlayerMove Method
            //
            //_gameSessionViewModel.Player.PreviousCash = _gameSessionViewModel.Player.Cash;
        }

        private void ComboBox_AssetTypes_SelectionChanged(object sender, SelectionChangedEventArgs e) // updates Asset Name combobox with appropriate Assets when Asset Type combobox is changed
                                                                                                      // todo ... Change the AssetName list to include all Player Assets   
        {
            AssetTypesChanged();
            AssetNameChanged();
        }

        private void ComboBox_AssetName_SelectionChanged(object sender, SelectionChangedEventArgs e) // Updates Asset info textbox text with description (for vehicle, other-item, real estate)
                                                                                                     // todo ... Change this Asset list to include all Player Assets   
        {
            AssetNameChanged();
        }

        private void TextBox_CurrentLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            LocationAssetsTypeChanged();
            LocationAssetNameChanged();
            AssetTypesChanged();
            AssetNameChanged();
        }

        private void AssetTypesChanged()
        {
            AssetTypes userAssetType = (AssetTypes)this.ComboBox_AssetTypes.SelectedItem; // gets the Asset type that's selected


            switch (userAssetType)
            {
                case AssetTypes.Businesses:
                    ComboBox_AssetName.ItemsSource = _gameSessionViewModel.Player.PlayerGameItems.OfType<Business>();
                    try
                    {
                        ComboBox_AssetName.SelectedValue = _gameSessionViewModel.Player.PlayerGameItems.OfType<Business>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;


                case AssetTypes.OtherItems:
                    ComboBox_AssetName.ItemsSource = _gameSessionViewModel.Player.PlayerGameItems.OfType<OtherItem>();
                    try
                    {
                        ComboBox_AssetName.SelectedValue = _gameSessionViewModel.Player.PlayerGameItems.OfType<OtherItem>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case AssetTypes.RealEstate:
                    ComboBox_AssetName.ItemsSource = _gameSessionViewModel.Player.PlayerGameItems.OfType<RealEstate>();
                    try
                    {
                        ComboBox_AssetName.SelectedValue = _gameSessionViewModel.Player.PlayerGameItems.OfType<RealEstate>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case AssetTypes.Stocks:
                    ComboBox_AssetName.ItemsSource = _gameSessionViewModel.Player.PlayerGameItems.OfType<Stock>();
                    try
                    {
                        ComboBox_AssetName.SelectedValue = _gameSessionViewModel.Player.PlayerGameItems.OfType<Stock>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case AssetTypes.Vehicles:
                    ComboBox_AssetName.ItemsSource = _gameSessionViewModel.Player.PlayerGameItems.OfType<Vehicle>();
                    try
                    {
                        ComboBox_AssetName.SelectedValue = _gameSessionViewModel.Player.PlayerGameItems.OfType<Vehicle>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;
                default:
                    ComboBox_AssetName.ItemsSource = null;
                    break;
            }

            AssetNameChanged();
        } // Updates Asset Name combobox when Asset Type combobox is changed

        private void AssetNameChanged()
        {
            AssetTypes userAssetType = (AssetTypes)this.ComboBox_AssetTypes.SelectedItem;

            try
            {
                GameItem gameItem = (GameItem)ComboBox_AssetName.SelectedValue;
                TextBox_AssetsOwned_CurrentValue.Text = gameItem.Value.ToString();
            }
            catch (Exception)
            {
                TextBox_AssetsOwned_CurrentValue.Text = "";
            }


            //switch (userAssetType)
            //{
            //    case AssetTypes.Businesses: // todo ... add a string here with Business stats instead of Description
            //        break;

            //    case AssetTypes.OtherItems:
            //        try
            //        {
            //            OtherItem userItem = (OtherItem)this.ComboBox_AssetName.SelectedItem;
            //            TextBox_AssetInfo.Text = userItem.Description;
            //        }
            //        catch (Exception)
            //        {
            //            TextBox_AssetInfo.Text = null;
            //        }
            //        break;

            //    case AssetTypes.RealEstate:
            //        try
            //        {
            //            RealEstate userItem = (RealEstate)this.ComboBox_AssetName.SelectedItem;
            //            TextBox_AssetInfo.Text = userItem.Description;
            //        }
            //        catch (Exception)
            //        {
            //            TextBox_AssetInfo.Text = null;
            //        }
            //        break;

            //    case AssetTypes.Stocks: // todo ... add a string here with Business stats instead of Description
            //        break;

            //    case AssetTypes.Vehicles:
            //        try
            //        {
            //            Vehicle userItem = (Vehicle)this.ComboBox_AssetName.SelectedItem;
            //            TextBox_AssetInfo.Text = userItem.Description;
            //        }
            //        catch (Exception)
            //        {
            //            TextBox_AssetInfo.Text = null;
            //        }
            //        break;

            //    default:
            //        TextBox_AssetInfo.Text = null;
            //        break;
            //}
        } // Updates Asset info textbox text with description (for vehicle, other-item, real estate)

        private void ComboBox_Actions_SelectionChanged(object sender, SelectionChangedEventArgs e) // Shows different stackpanels based on which action type is selected
        {
            List<StackPanel> Action_StackPanels = new List<StackPanel> { StackPanel_Actions_Example, StackPanel_Actions_Assets, StackPanel_Actions_Debt, StackPanel_Actions_Loans }; // have to add new action stackPanels here manually
            foreach (StackPanel stackPanel in Action_StackPanels)
            {
                stackPanel.Visibility = Visibility.Hidden;
            }

            ActionTypes userActionType = (ActionTypes)this.ComboBox_Actions.SelectedItem; // gets the selected action type

            switch (userActionType)
            {
                case ActionTypes.Assets:
                    StackPanel_Actions_Assets.Visibility = Visibility.Visible;
                    break;
                case ActionTypes.Housing:
                    break;
                case ActionTypes.Commuting:
                    break;
                case ActionTypes.Work:
                    break;
                case ActionTypes.Expenses:
                    break;
                case ActionTypes.Debt:
                    StackPanel_Actions_Debt.Visibility = Visibility.Visible;
                    break;
                case ActionTypes.Loans:
                    StackPanel_Actions_Loans.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

        }

        private void ComboBox_LocationAssetTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocationAssetsTypeChanged();
        }

        private void ComboBox_LocationAssetName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocationAssetNameChanged();
        }

        private void LocationAssetsTypeChanged() // Should move this to View Model
        {
            AssetTypes userAssetType = (AssetTypes)this.ComboBox_LocationAssetTypes.SelectedItem; // gets the Asset type that's selected



            switch (userAssetType)
            {
                case AssetTypes.Businesses:
                    ComboBox_LocationAssetName.ItemsSource = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<Business>();
                    try
                    {
                        ComboBox_LocationAssetName.SelectedValue = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<Business>().FirstOrDefault();
                        //_gameSessionViewModel.CurrentLocationGameItem = (GameItem)ComboBox_LocationAssetName.SelectedValue; // experimental
                    }
                    catch (Exception)
                    {
                    }
                    break;


                case AssetTypes.OtherItems:
                    ComboBox_LocationAssetName.ItemsSource = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<OtherItem>();
                    try
                    {
                        ComboBox_LocationAssetName.SelectedValue = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<OtherItem>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;

                case AssetTypes.RealEstate:
                    ComboBox_LocationAssetName.ItemsSource = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<RealEstate>();
                    try
                    {
                        ComboBox_LocationAssetName.SelectedValue = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<RealEstate>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;

                case AssetTypes.Stocks:
                    ComboBox_LocationAssetName.ItemsSource = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<Stock>();
                    try
                    {
                        ComboBox_LocationAssetName.SelectedValue = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<Stock>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;

                case AssetTypes.Vehicles:
                    ComboBox_LocationAssetName.ItemsSource = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<Vehicle>();
                    try
                    {
                        ComboBox_LocationAssetName.SelectedValue = _gameSessionViewModel.CurrentLocation.LocationItems.OfType<Vehicle>().FirstOrDefault();
                    }
                    catch (Exception)
                    {
                    }
                    break;

                default:
                    ComboBox_LocationAssetName.ItemsSource = null;
                    break;
            }

            _gameSessionViewModel.CurrentLocationGameItem = (GameItem)ComboBox_LocationAssetName.SelectedValue; // udpates CurrentLocationGameItem
            LocationAssetNameChanged();
        }

        private void LocationAssetNameChanged()
        {
            AssetTypes userAssetType = (AssetTypes)this.ComboBox_LocationAssetTypes.SelectedItem;

            string assetPrice = "";

            try
            {
                GameItem gameItem = (GameItem)ComboBox_LocationAssetName.SelectedValue;

                switch (gameItem)
                {
                    case Business business:
                        Business B_item = (Business)gameItem; // Allows the use of Business properties of the item
                        assetPrice = B_item.Price.ToString();
                        break;

                    case OtherItem otherItem:
                        OtherItem O_item = (OtherItem)gameItem;
                        assetPrice = O_item.Price.ToString();
                        break;

                    case RealEstate realEstate:
                        RealEstate RE_item = (RealEstate)gameItem;
                        assetPrice = RE_item.Price.ToString();
                        break;

                    case Stock stock: break; // todo ... Create a similar method for updating stock value every week/month

                    case Vehicle vehicle:
                        Vehicle V_item = (Vehicle)gameItem;
                        assetPrice = V_item.Price.ToString();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                TextBox_AssetsOwned_CurrentValue.Text = "";
            }

            TextBox_Actions_Assets_Price.Text = assetPrice;
        }

        private void Button_Actions_Assets_Buy_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_LocationAssetName.SelectedItem != null)
            {
                _gameSessionViewModel.CurrentLocationGameItem = (GameItem)ComboBox_LocationAssetName.SelectedItem;
                if (_gameSessionViewModel.CurrentLocationGameItem.Price > _gameSessionViewModel.Player.Cash) //Warn Player that they do not have enough cash to buy the asset.
                {
                    MessageBox.Show("You do not have enough cash to buy this Asset outright. Please take out a loan first, or select a different Asset.", _gameSessionViewModel.CurrentLocationGameItem.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                else
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to buy this Asset?", _gameSessionViewModel.CurrentLocationGameItem.Name, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            _gameSessionViewModel.Player.PreviousCash = _gameSessionViewModel.Player.Cash;
                            _gameSessionViewModel.PlayerBuyAsset();
                            if (Label_YearsWeeksPassed_Paused.Visibility == Visibility.Visible) // show cash animation if game is Paused
                            {
                                UpdatePlayerCash();
                            }
                            LocationAssetsTypeChanged();
                            AssetTypesChanged();
                            break;

                        case MessageBoxResult.No:
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void Slider_Actions_Debt_LoanPayments_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int years = (int)e.NewValue;
            TextBox_Actions_Debt_Years.Text = ((int)years).ToString();

            double factor = years * 52;
            factor = 1 / factor;
            //string factorString = factor.ToString();    Used for debugging debt factor
            //try
            //{
            //    Label_Action_Debt_Factor.Content = factorString;
            //}
            //catch (Exception)
            //{
            //}

            _gameSessionViewModel.CaculatePlayerDebt(factor);
            UpdateDebtTextbox();
        }

        private void UpdateDebtTextbox()
        {
            try
            {
                TextBox_Actions_Debt_WeeklyPayment.Text = (_gameSessionViewModel.WeeklyPayment - _gameSessionViewModel.Player.CostOfLiving).ToString();
            }
            catch (Exception)
            { }

        }

        private void Button_Actions_Assets_SeeDetails_Click(object sender, RoutedEventArgs e)
        {
            ItemDetailsView itemDetails = new ItemDetailsView(_gameSessionViewModel, (AssetTypes)ComboBox_LocationAssetTypes.SelectedValue, true); // Send the View Model to Item Details window... There might be a better way to do this
            
            itemDetails.ShowDialog();            
        }

        private void Button_Time_Pause_Click(object sender, RoutedEventArgs e)
        {
            GameTimePause();
        }

        private void GameTimePause()
        {
            _gameSessionViewModel.PauseGameTimer();
            Grid_YearsWeeksPassed.Opacity = .4;
            Label_YearsWeeksPassed_Paused.Visibility = Visibility.Visible;
        }

        private void Button_Time_Start_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.StartGameTimer();
            Grid_YearsWeeksPassed.Opacity = 1;
            Label_YearsWeeksPassed_Paused.Visibility = Visibility.Hidden;
        }

        private void UpdatePlayerCash()
        {
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
                //((Storyboard)this.Resources["Label_PlayerCash_Error"]).Begin(this);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePlayerCash();
        }

        private void Button_AssetsOwned_SeeDetails_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.CurrentGameItem = (GameItem)ComboBox_AssetName.SelectedItem;

            ItemDetailsView itemDetails = new ItemDetailsView(_gameSessionViewModel, (AssetTypes)ComboBox_AssetTypes.SelectedItem, false); // Send the View Model to Item Details window... There might be a better way to do this

            itemDetails.ShowDialog();
        }

        private void Button_AssetsOwned_Sell_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_AssetName.SelectedItem != null)
            {
                _gameSessionViewModel.CurrentGameItem = (GameItem)ComboBox_AssetName.SelectedItem;
                _gameSessionViewModel.Player.PreviousCash = _gameSessionViewModel.Player.Cash;
                _gameSessionViewModel.PlayerSellAsset();
                UpdatePlayerCash();
                LocationAssetsTypeChanged();
                LocationAssetNameChanged();
                AssetTypesChanged();
                AssetNameChanged();
            }
        }

        private void TextBox_Player_Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update fields when a year passes       
            if (ComboBox_AssetName.SelectedValue != null) // maintains current selected item after update
            {
                GameItem userGameItem = (GameItem)ComboBox_AssetName.SelectedValue;
                AssetTypesChanged();
                ComboBox_AssetName.SelectedValue = userGameItem;
                AssetNameChanged();
            }
            else
            {
                AssetTypesChanged();
                AssetNameChanged();
            }
        }

        private void TextBox_Actions_Loans_LoanAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox_Actions_Loans_LoanAmount.Text != null && TextBox_Actions_Loans_LoanAmount.Text != "") // makes sure textbox is not empty
            {
                if (int.TryParse(TextBox_Actions_Loans_LoanAmount.Text, out int loanAmount)) // tries to parse to int
                {
                    TextBox_Actions_Loans_WeeklyPayment.Text = _gameSessionViewModel.CalculateLoanWeeklyPayment((int)Slider_Actions_Loans_LoanLifetime.Value, loanAmount).ToString();

                    TextBox_Actions_Loans_TotalLoanCost.Text = _gameSessionViewModel.CalculateTotalLoanAmount((int)Slider_Actions_Loans_LoanLifetime.Value, int.Parse(TextBox_Actions_Loans_WeeklyPayment.Text)).ToString();
                }

                else
                {
                    MessageBox.Show("Please enter an integer in the 'Amount' Text Box.", "Invalid Entry", MessageBoxButton.OK, MessageBoxImage.Exclamation); // Tells user about the validation
                    TextBox_Actions_Loans_LoanAmount.Text = ""; // Resets Textbox text
                }
            }           
        }

        private void TextBox_Actions_Loans_LoanLifetime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox_Actions_Loans_LoanAmount.Text != null && TextBox_Actions_Loans_LoanAmount.Text != "") // makes sure textbox is not empty
            {
                if (int.TryParse(TextBox_Actions_Loans_LoanAmount.Text, out int loanAmount)) // tries to parse to int
                {
                    TextBox_Actions_Loans_WeeklyPayment.Text = _gameSessionViewModel.CalculateLoanWeeklyPayment((int)Slider_Actions_Loans_LoanLifetime.Value, loanAmount).ToString();

                    TextBox_Actions_Loans_TotalLoanCost.Text = _gameSessionViewModel.CalculateTotalLoanAmount((int)Slider_Actions_Loans_LoanLifetime.Value, int.Parse(TextBox_Actions_Loans_WeeklyPayment.Text)).ToString();
                }

                else
                {
                    MessageBox.Show("Please enter an integer in the 'Amount' Text Box.", "Invalid Entry", MessageBoxButton.OK, MessageBoxImage.Exclamation); // Tells user about the validation
                    TextBox_Actions_Loans_LoanAmount.Text = ""; // Resets Textbox text
                }
            }
        }

        private void Button_Actions_Loans_Apply_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Actions_Loans_LoanAmount.Text != null && TextBox_Actions_Loans_LoanAmount.Text != "") // makes sure textbox is not empty
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to take out this loan?", "New Loan", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                switch (result)
                {
                    case MessageBoxResult.Yes: // Create new loan using these parameters, and add it to Player.PlayerLoans
                        _gameSessionViewModel.AddPlayerLoan(int.Parse(TextBox_Actions_Loans_LoanAmount.Text), int.Parse(TextBox_Actions_Loans_LoanLifetime.Text), int.Parse(TextBox_Actions_Loans_WeeklyPayment.Text), int.Parse(TextBox_Actions_Loans_TotalLoanCost.Text));
                        UpdatePlayerCash();
                        TextBox_Actions_Loans_LoanAmount.Text = "";
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
