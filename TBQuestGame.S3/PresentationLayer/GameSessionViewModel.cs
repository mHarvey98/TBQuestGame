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
using System.Windows.Threading;
using WageSlave.Models.GameObjects;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        public DispatcherTimer timer = new DispatcherTimer();

        // Fields
        private Player _player;
        private List<string> _messages;
        private List<Occupation> _allOccupations;
        private Map _gameMap;
        private Location _currentLocation;
        private Location _selectedLocation;
        private string _currentLocationName;
        private ObservableCollection<Location> _accessibleLocations;
        private GameItem _currentGameItem;
        private GameItem _currentLocationGameItem;
        private double _playerOriginalDebt;
        private double _weeklyPayment;
        private Loan _loanTemplate;

        // Time-Related Fields
        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private TimeSpan _gameTime;
        private int _yearsPassed;


        
        // Properties
        public Loan LoanTemplate
        {
            get { return _loanTemplate; }
            set { _loanTemplate = value; }
        }

        public int YearsPassed
        {
            get { return _yearsPassed; }
            set
            {
                _yearsPassed = value;
                OnPropertyChanged(nameof(YearsPassed));
            }
        }

        public string GameTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(GameTimeDisplay));
            }
        }

        public double WeeklyPayment
        {
            get { return _weeklyPayment; }
            set
            {
                _weeklyPayment = value;

                OnPropertyChanged("WeeklyPayment");
            }
        }


        public double PlayerOriginalDebt
        {
            get { return _playerOriginalDebt; }
            set
            {
                _playerOriginalDebt = value;

                OnPropertyChanged("PlayerBeginningDebt");
            }
        }


        public GameItem CurrentLocationGameItem
        {
            get { return _currentLocationGameItem; }
            set { _currentLocationGameItem = value; }
        }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set
            {
                _currentGameItem = value;
            }
        }

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
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
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
            List<Occupation> allOccupations, Loan loanTemplate)
        {
            _player = player;
            _playerOriginalDebt = player.Occupation.Debt;
            _messages = initialMessages;
            _gameMap = gameMap;
            _currentLocation = currentLocation;
            _currentLocationName = currentLocation.Name;
            _allOccupations = allOccupations;
            _player.PreviousCash = _player.Cash;
            _loanTemplate = loanTemplate;

            //UpdatePlayerWeeklyPayment();

            InitializeView();
        }

        //Methods

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            _accessibleLocations = _gameMap.AccessibleLocations;
            UpdateAccessibleLocation();

            _yearsPassed = _player.Occupation.YearsInSchool;
            _player.Age += _yearsPassed;
            GameTimer();
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

        public void PlayerBuyAsset()
        {
            if (CurrentLocationGameItem != null)
            {
                Player.PlayerGameItems.Add(CurrentLocationGameItem);
                Player.Cash -= CurrentLocationGameItem.Price;
                CurrentLocation.LocationItems.Remove(CurrentLocationGameItem);
                OnPropertyChanged("CurrentLocation");
            }
        }

        public void PlayerSellAsset()
        {
            if (CurrentGameItem != null)
            {
                var itemType = CurrentGameItem.GetType(); // returns the CurrentGameItem's object type

                if (itemType == typeof(Vehicle) | itemType == typeof(OtherItem)) // item can be sold in any location
                {
                    CurrentLocation.LocationItems.Add(CurrentGameItem); // sells the item to current location
                    Player.Cash += CurrentGameItem.Value;
                    Player.PlayerGameItems.Remove(CurrentGameItem);
                    UpdateAccessibleLocation();
                }

                else if (itemType == typeof(Stock)) // Stock does not belong to a specific location
                {

                }

                else // item needs to return to original location
                {
                    string itemID = CurrentGameItem.Id.ToString();

                    //Determine item's original location NOTE: Current code always returns item to original location... should drop in current location in the case of Vehicle or OtherItem
                    int[] numbers = new int[itemID.Length]; //Create array of ints
                    for (int i = 0; i < itemID.Length; i++)
                    {
                        //Parse each character to an integer
                        numbers[i] = Int32.Parse(itemID[i].ToString());
                    }

                    int locationID = numbers[2]; // Return the middle digit (location denoter) of the ID

                    foreach (Location location in _gameMap.Locations)
                    {
                        try
                        {
                            if (location.Id == locationID)
                            {
                                location.LocationItems.Add(CurrentGameItem);
                                Player.Cash += CurrentGameItem.Value;
                                Player.PlayerGameItems.Remove(CurrentGameItem);
                                UpdateAccessibleLocation(); // todo ... this might not work, need to update the location "CurrentGameItem" was added to
                            }
                        }
                        catch (Exception)
                        { }
                    }
                }
            }



        }

        public void CaculatePlayerDebt(double debtFactor)
        {
            _player.DebtPayment = 0;
            _player.DebtPayment = _playerOriginalDebt* debtFactor;

            UpdatePlayerWeeklyPayment();
        }

        public void UpdatePlayerWeeklyPayment() // todo ... Stop debt payments once debt is paid
        {
            int loanPayment = 0;

            if (_player.PlayerLoans != null) // Add together all of the player's loan payments
            {
                foreach (Loan loan in _player.PlayerLoans)
                {
                    loanPayment += loan.LoanWeeklyPayment;
                }
            }

            _weeklyPayment = Math.Truncate(_player.DebtPayment + _player.CostOfLiving + loanPayment); // Add up all weekly expenses
            OnPropertyChanged("WeeklyPayment");            
        }

        public void UpdatePlayerWeeklyVariables()
        {
            _player.PreviousCash = _player.Cash;
            _player.Cash += _player.Wage;
            _player.Cash -= (int)_weeklyPayment;            
            OnPropertyChanged(nameof(Player));
            Player.Debt -= (int)_player.DebtPayment;
            OnPropertyChanged(nameof(PlayerOriginalDebt));
        }

        public int CalculateLoanWeeklyPayment(int lengthInYears, int loanAmount) // todo ... could factor in "Networking Points" as credit score
        {
            int LoanWeeklyPayment = 0;
            double i; // Periodic Interest Rate (Weekly)
            int n; // Total number of Payments
            double d; // Discount Factor

            n = 52 * lengthInYears;

            i = _loanTemplate.APR / 52;

            double d1 = (Math.Pow((1 + i), n) - 1);
            double d2 = i * (Math.Pow((1 + i), n));

            d = d1 / d2; // Discount Factor Formula: (((1 + i) ^ n) - 1) / (i * (1 + i) ^ n)

            LoanWeeklyPayment = (int)(loanAmount / d);

            return LoanWeeklyPayment;
        }

        public int CalculateTotalLoanAmount(int lengthInYears, int weeklyLoanPayment) // Multiply Weekly Payment by amount of Weeks in the loan
        {
            int TotalLoanAmount = weeklyLoanPayment * (52 * lengthInYears);

            return TotalLoanAmount;
        }

        public void AddPlayerLoan(int LoanAmount, int LoanLength, int LoanWeeklyPayment, int TotalLoanCost)
        {
            Loan newLoan = new Loan();

            newLoan = _loanTemplate;
            newLoan.Name = "Player_Loan";
            newLoan.LoanAmount = LoanAmount;
            newLoan.LoanLifetimeYears = LoanLength;
            newLoan.LoanWeeklyPayment = LoanWeeklyPayment;
            newLoan.RemainingLoanBalance = TotalLoanCost;

            _player.PreviousCash = _player.Cash;
            _player.Cash += newLoan.LoanAmount;

            _player.PlayerLoans.Add(newLoan);

            UpdatePlayerWeeklyPayment();

            OnPropertyChanged(nameof(Player));
        }



        // Time-Related Methods

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        /// <summary>
        /// game time event, publishes every 1 second
        /// </summary>
        public void GameTimer()
        {
            //DispatcherTimer timer = new DispatcherTimer();   timer is now global
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += OnGameTimerTick;                  
            timer.Start();
        }

        /// <summary>
        /// game timer event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGameTimerTick(object sender, EventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (_gameTime.Seconds == 52) // Increases "years passed" every 52 seconds ("weeks")
                {
                    VM_YearPassedUpdate();

                    _gameTime -= TimeSpan.FromSeconds(52); // effectively resets the timer
                }

                _gameTime += TimeSpan.FromSeconds(1);
                GameTimeDisplay = _gameTime.ToString(@"ss");

                UpdatePlayerWeeklyVariables();
            }
        }

        public void VM_YearPassedUpdate()
        {
            _yearsPassed++;
            OnPropertyChanged(nameof(YearsPassed));

            Player.PlayerYearPassedUpdate();
            OnPropertyChanged(nameof(Player));
        }


        public void PauseGameTimer()
        {
            timer.IsEnabled = false;
        }

        public void StartGameTimer()
        {
            timer.IsEnabled = true;
        }
    }
}
