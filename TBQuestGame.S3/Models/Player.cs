using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using WageSlave.Models;
using System.Collections.ObjectModel;
using WageSlave.Models.GameObjects;
using System.Windows;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public class Player : Character
    {        
        public enum HousingOptions { Rent, Own_House, Stay_With_Parents }
        public enum CommutingOptions { Bus, Bicycle, Car}

        // Fields
        private int _age;
        private int _cash;
        private int _costOfLiving;
        private int _wage;
        private int _networkingPoints;
        private int _totalEarned;
        private int _totalSpent;
        private int _weeksPassed;
        private List<Location> _locationsVisited;
        private int _previousCash;
        private List<Occupation> _allOccupations;
        private Occupation _occupation;
        private ObservableCollection<GameItem> _playerGameItems;
        private ObservableCollection<Loan> _playerLoans;
        private double _debtPayment;
        private int _debt;
        private int _salary;
        private int _wageWithAssets;
        private HousingOptions _housingOption;
        private int _weeklyRent;
        private double _houseHappiness;
        private int _expenses;
        private CommutingOptions _commutingOption;
        private int _commutingCost;
        private double _commutingHappiness;



        //Properties
        public double CommutingHappiness
        {
            get { return _commutingHappiness; }
            set
            {
                _commutingHappiness = value;
                OnPropertyChanged(nameof(CommutingHappiness));
            }
        }

        public int CommutingCost
        {
            get { return _commutingCost; }
            set
            {
                _commutingCost = value;
                OnPropertyChanged(nameof(CommutingCost));
            }
        }

        public CommutingOptions CommutingOption
        {
            get { return _commutingOption; }
            set
            {
                _commutingOption = value;
                OnPropertyChanged(nameof(CommutingOption));
            }
        }

        public int Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }

        public double HouseHappiness
        {
            get { return _houseHappiness; }
            set
            {
                _houseHappiness = value;
                OnPropertyChanged(nameof(HouseHappiness));
            }
        }

        public int WeeklyRent
        {
            get { return _weeklyRent; }
            set
            {
                _weeklyRent = value;
                OnPropertyChanged(nameof(WeeklyRent));
            }
        }

        public HousingOptions HousingOption
        {
            get { return _housingOption; }
            set
            {
                _housingOption = value;
                OnPropertyChanged(nameof(HousingOption));
            }
        }
        
        public int WageWithAssets
        {
            get { return _wageWithAssets; }
            set
            {
                _wageWithAssets = value;
                OnPropertyChanged(nameof(WageWithAssets));
            }
        }

        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public ObservableCollection<Loan> PlayerLoans
        {
            get { return _playerLoans; }
            set { _playerLoans = value; }
        }

        public int Debt
        {
            get { return _debt; }
            set { _debt = value; }
        }

        public double DebtPayment
        {
            get { return _debtPayment; }
            set { _debtPayment = value; }
        }

        public ObservableCollection<GameItem> PlayerGameItems
        {
            get { return _playerGameItems; }
            set { _playerGameItems = value; }
        }

        public Occupation Occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }

        public List<Occupation> AllOccupations
        {
            get { return _allOccupations; }
            set { _allOccupations = value; }
        }

        public int PreviousCash
        {
            get { return _previousCash; }
            set
            {
                _previousCash = value;
                OnPropertyChanged(nameof(PreviousCash));
            }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public int WeeksPassed
        {
            get { return _weeksPassed; }
            set
            {
                _weeksPassed = value;
                OnPropertyChanged(nameof(WeeksPassed));
            }
        }

        public int Wage
        {
            get { return _wage; }
            set
            {
                _wage = value;
                OnPropertyChanged(nameof(Wage));
            }
        }

        public int TotalSpent
        {
            get { return _totalSpent; }
            set
            {
                _totalSpent = value;
                OnPropertyChanged(nameof(TotalSpent));
            }
        }

        public int TotalEarned
        {
            get { return _totalEarned; }
            set
            {
                _totalEarned = value;
                OnPropertyChanged(nameof(TotalEarned));
            }
        }

        public int NetworkingPoints
        {
            get { return _networkingPoints; }
            set
            {
                _networkingPoints = value;
                OnPropertyChanged(nameof(NetworkingPoints));
            }
        }

        public int CostOfLiving
        {
            get { return _costOfLiving; }
            set
            {
                _costOfLiving = value;
                OnPropertyChanged(nameof(CostOfLiving));
            }
        }

        public int Cash
        {
            get { return _cash; }
            set
            {
                _cash = value;
                OnPropertyChanged(nameof(Cash)); // using nameof eliminates the need for a magic string here. Can change the name of "Cash" without affecting the operation. 
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        // Methods   todo ... Refactor some viewmodel methods to be in Player class (player related methods)

        public static Player PlayerData() // Binding does not reference this method, uses the one in GameData instead
        {
            return new Player()
            {
                ID = 1,
                Name = "Mitch",
                Age = 21,
                Cash = 10000,
                CostOfLiving = 200,
                NetworkingPoints = 10,
                TotalEarned = 50000,
                TotalSpent = 40000,
                WeeksPassed = 0, 
                LocationId = 0,
                PlayerGameItems = new ObservableCollection<GameItem>
                {

                }
            };
        }

        public override string GetOccupation()
        {
            string occupation = "";

            // Use the player setup for this

            return occupation;
        }

        public void PlayerYearPassedUpdate() // Update all year-dependant variables (Age, appreciation/depreciation of assets, ...?)
        {
            _age++;

            if (_playerGameItems != null)
            {
                foreach (GameItem item in _playerGameItems)
                {
                    switch (item)
                    {
                        case Business business:
                            Business B_item = (Business)item; // Allows the use of Business properties of the item
                            item.Value = (int)(item.Value * B_item.GrowthRate); // increase value at a fixed rate every year
                            break;

                        case OtherItem otherItem:
                            OtherItem O_item = (OtherItem)item;
                            item.Value = (int)(item.Value * GetAppreciationRandom(O_item.AppreciationMin, O_item.AppreciationMax));
                            break;

                        case RealEstate realEstate:
                            RealEstate RE_item = (RealEstate)item;
                            item.Value = (int)(item.Value * GetAppreciationRandom(RE_item.AppreciationMin, RE_item.AppreciationMax));
                            break;

                        case Stock stock: break; // todo ... Create a similar method for updating stock value every week/month

                        case Vehicle vehicle:
                            if (item.Value > 250) // vehicle cannot be worth less than 200
                            {
                                Vehicle V_item = (Vehicle)item;
                                item.Value = (int)(item.Value * V_item.DepreciationRate); // decrease value at a fixed rate every year
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public double GetAppreciationRandom(double appMin, double appMax) // picks a random appreciation amount between the set minimum and maximum
        {
            Random random = new Random();
            return random.NextDouble() * (appMax - appMin) + appMin;
        }

        public double PlayerHappinessUpdate(Player player, double weeklyPayment)
        {
            double happiness = 0;
            double happiness1 = 0;
            double happiness2 = 0;
            double happiness3 = 0;
            double happiness4 = 0;
            double happiness5 = 0;
            double happiness6 = 0;
            int count = 0; // counts number of game items, to be used as an average

            if (player.PlayerGameItems.Count != 0 && player.PlayerGameItems != null) // if player has no game items, don't execute this code
            {
                foreach (GameItem item in player.PlayerGameItems)
                {
                    happiness1 += item.HappinessFactor;
                    count++;
                }

                happiness1 = happiness1 / count; // returns the average happiness impact of current assets
            }

            happiness += happiness1;

            happiness2 -= (((player.Wage / player.Occupation.HourlyRate) * .05) - 2); //Work happiness
            happiness2 = Math.Round(happiness2, 3);
            happiness += happiness2;

            happiness3 += player.HouseHappiness; // House happiness
            happiness += happiness3;

            happiness4 += (Expenses * .00227) - .34; // Expenses happiness
            happiness += happiness4;

            happiness5 += (player.WageWithAssets - weeklyPayment);
            happiness5 = Math.Round(happiness5 * .0001,2); // happiness is impacted by over-spending/under-spending
            happiness += happiness5;

            happiness6 = player.CommutingHappiness;
            happiness += happiness6;

            if (player.Happiness + happiness > 100) // if happiness would exceed 100 in this pass, set player.Happiness to 100
            {
                happiness = 100 - player.Happiness;
            }

            else if (player.Happiness == 100 && happiness > 0) // sets 100 as maximum health
            {
                happiness = 0;
            }

            else if (player.Happiness + happiness < 0) // Happiness hits 0, game is over
            {
                happiness = -(player.Happiness);
            }

            return happiness;
        }

        public string PlayerGetHappinessStats(Player player, double weeklyPayment)
        {
            string happinessString = "";
            double happiness1 = 0;
            double happiness2 = 0;
            double happiness3 = 0;
            double happiness4 = 0;
            double happiness5 = 0;
            double happiness6 = 0;
            int count = 0;

            if (player.PlayerGameItems.Count != 0 && player.PlayerGameItems != null) // if player has no game items, don't execute this code
            {
                foreach (GameItem item in player.PlayerGameItems)
                {
                    happiness1 += item.HappinessFactor;
                    count++;
                }

                happiness1 = happiness1 / count; // returns the average happiness impact of current assets
            }

            happinessString += $"Happiness from Assets: {happiness1} \n";

            happiness2 -= (((player.Wage / player.Occupation.HourlyRate) * .05) - 2); // Work happiness
            happiness2 = Math.Round(happiness2, 3);
            happinessString += $"Happiness from Work: {happiness2} \n";

            happiness3 += player.HouseHappiness; // House happiness
            if (player.HousingOption == HousingOptions.Rent)
            {
                happinessString += $"Happiness from Housing: {happiness3} (Currently Renting) \n";
            }
            else if (player.HousingOption == HousingOptions.Own_House)
            {
                happinessString += $"Happiness from Housing: {happiness3} (Currently Living in Own House) \n";
            }
            else if (player.HousingOption == HousingOptions.Stay_With_Parents)
            {
                happinessString += $"Happiness from Housing: {happiness3} (Currently Staying with Parents) \n";
            }


            happiness4 += (Expenses * .00227) - .34; // Expenses happiness
            happiness4 = Math.Round(happiness4, 2); // Rounds expenses happiness to 2 decimal places
            happinessString += $"Happiness from Expenses: {happiness4} \n";

            happiness6 = player.CommutingHappiness; // Commuting Happiness
            happinessString += $"Happiness from Commuting: {player.CommutingHappiness} (Using {player.CommutingOption}) \n";

            happiness5 += (player.WageWithAssets - weeklyPayment);
            if (happiness5 > 1 || happiness5 == 0)
            {
                happiness5 = Math.Round(happiness5 * .0001,2); // Happiness increases when spending less than earning
                happinessString += $"Happiness from Overall Spending: {happiness5}";
            }
            else if (happiness5 < 1)
            {
                happiness5 = Math.Round(happiness5 * .0001,2); // Happiness decreases when spending overcomes earning
                happinessString += $"Happiness from Overall Spending: {happiness5} (Over-Spending)";
            }

            return happinessString;
        }

        public void PlayerRemoveLoan(Player player, Loan loan)
        {
            if (player.PlayerLoans != null && player.PlayerLoans.Contains(loan) && loan.RemainingLoanBalance <= 0)
            {
                MessageBox.Show($"Congratulations, you just paid off your ${loan.LoanAmount} loan!", "Loan Paid Off!", MessageBoxButton.OK, MessageBoxImage.Information);
                player.PlayerLoans.Remove(loan);
            }
        }

        public void PlayerUpdateWage(Player player, int hours)
        {
            player.Salary = (player.Occupation.HourlyRate * hours) * 52;
            player.Wage = player.Occupation.HourlyRate * hours;

            double assetIncome = 0;

            if (player.PlayerGameItems != null && player.PlayerGameItems.Count > 0)
            {
                foreach (GameItem item in player.PlayerGameItems)
                {
                    switch (item) // Polymorphism
                    {
                        case Business business:
                            Business B_item = (Business)item;
                            assetIncome += B_item.NetIncome / 52; // Get the business's income per week
                            break;

                        case RealEstate realEstate:
                            RealEstate RE_item = (RealEstate)item;
                            if (RE_item.RentOut == true) // Only collects rent if the player is renting out the house.
                            { assetIncome += RE_item.RentPrice / 4; }
                            break;

                        case Stock stock:
                            Stock S_item = (Stock)item;
                            if (S_item.KeepDividends == true)
                            {
                                assetIncome += (S_item.TTMyield * S_item.PlayersAmountofStocks) / 52;
                            } break;

                        default: break;
                    }
                }
            }


            player.WageWithAssets = player.Wage + (int)assetIncome; // Adds the player's working wage to income from assets, giving a total weekly income
            OnPropertyChanged(nameof(WageWithAssets));
        }

        public void PlayerUpdateHousing(Player.HousingOptions housingOption, int rent, Player player)
        {
            switch (housingOption)
            {
                case HousingOptions.Rent:
                    player.HousingOption = HousingOptions.Rent;
                    player.WeeklyRent = rent;
                    player.HouseHappiness = Math.Round(((rent - 75) * .0047) - 1, 2); // multiplier so that $75 rent = -1 happiness, $500 rent = +1 happiness
                    break;
                case HousingOptions.Own_House:
                    player.HousingOption = HousingOptions.Own_House;
                    player.WeeklyRent = 0;
                    player.HouseHappiness = 1;
                    // todo ... house happiness = house's happiness factor
                    break;
                case HousingOptions.Stay_With_Parents:
                    player.HousingOption = HousingOptions.Stay_With_Parents;
                    player.WeeklyRent = 0;
                    player.HouseHappiness = -1;
                    break;
                default:
                    break;
            }
        }

        public void PlayerUpdateExpenses(int foodCost, int spendingBudget, Player player)
        {
            player.Expenses = foodCost + spendingBudget;
        }

        public void PlayerUpdateCommuting(Player.CommutingOptions commutingOption, Player player)
        {
            switch (commutingOption)
            {
                case CommutingOptions.Bus:
                    player.CommutingOption = Player.CommutingOptions.Bus;
                    player.CommutingHappiness = -.1;
                    player.CommutingCost = 20;
                    break;
                case CommutingOptions.Bicycle:
                    player.CommutingOption = Player.CommutingOptions.Bicycle;
                    player.CommutingHappiness = -.2;
                    player.CommutingCost = 0;
                    break;
                case CommutingOptions.Car:
                    player.CommutingOption = Player.CommutingOptions.Car;
                    player.CommutingHappiness = 0;
                    player.CommutingCost = 0;
                    break;
                default:
                    break;
            }

            
        }

        /// <summary>
        /// override the default greeting in the Character class to include the job title
        /// set the proper article based on the job title
        /// </summary>
        /// <returns>default greeting</returns>
        //public override string DefaultGreeting()
        //{
        //    //string article = "a";

        //    //List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

        //    //if (vowels.Contains(occupation.ToString().Substring(0, 1)))
        //    //{
        //    //    article = "an";
        //    //}

        //    //return $"Hello, my name is {Name} and I am {article} {occupation} for the Aion Project.";
        //}
    }
}
