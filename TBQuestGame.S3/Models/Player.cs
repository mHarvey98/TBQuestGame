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


namespace TBQuestGame.Models
{
    public class Player : Character
    {        
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


        //Properties
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
