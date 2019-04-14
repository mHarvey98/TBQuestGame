using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using WageSlave.Models;
using System.Collections.ObjectModel;
using WageSlave.Models.GameObjects;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Player Name",
                Age = 18,
                Cash = 5000,
                PreviousCash = 5000,
                CostOfLiving = 125, // Weekly CoL
                NetworkingPoints = 100,
                happiness = Character.Happiness.VeryHigh,
                Wage = 150, // Weekly Wage
                TotalEarned = 50000,
                TotalSpent = 45000,
                WeeksPassed = 0,
                LocationId = 0,
                PlayerGameItems = new ObservableCollection<GameItem>
                {

                },
                PlayerLoans = new ObservableCollection<Loan>
                {

                }
            };
        }

        public static Loan GameLoan()
        {
            return new Loan
            {
                Name = "Loan_Template",
                Id = 00001,
                loanType = Loan.LoanType.Personal,
                APR = .15,
                LoanInterestIsFixed = true
            };
        }

        public static List<Occupation> PlayerOccupations()
        {
            return new List<Occupation>
            {
                new Occupation()
                {
                    Name = "Factory Worker",
                    YearsInSchool = 0,
                    Debt = 0,
                    AvgSalary = 26000
                },

                new Occupation()
                {
                    Name = "Machinist",
                    YearsInSchool = 0,
                    Debt = 0,
                    AvgSalary = 40000
                },

                new Occupation()
                {
                    Name = "Electrician",
                    YearsInSchool = 2,
                    Debt = 15000,
                    AvgSalary = 50000
                },

                new Occupation()
                {
                    Name = "Cosmetologist",
                    YearsInSchool = 2,
                    Debt = 12000,
                    AvgSalary = 35000
                },

                new Occupation()
                {
                    Name = "Computer Engineer",
                    YearsInSchool = 4,
                    Debt = 100000,
                    AvgSalary = 104000
                },

                new Occupation()
                {
                    Name = "History Teacher",
                    YearsInSchool = 4,
                    Debt = 100000,
                    AvgSalary = 55000
                }
            
            };
        }

        //Methods
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You are a recent high school graduate, " +
                "and at 18 years old you must decide what direction your life will take. ", 
                "Your first task is to decide to go straight to work, go to a trade school, " +
                "or a 4-year University. In any of these three cases you will decide between two " +
                "careers.",
                "After that, the rest of your working life's financial decisions will be simulated. " +
                "How you choose to spend and invest your money is critical, as the object of the game " +
                "is to retire as early as possible. However, this must be done while maintaining at least a moderate " +
                "happiness level, as dropping too low will cause the game to end. ",
                "Welcome to 'WageSlave'!"
            };
        }

        //public static Location InitialGameMapLocation()
        //{
        //    return new Location()
        //    {
        //        Id = 4,
        //        Name = "Newberry, MI",
        //        Description = "Newberry Description here.",
        //        Accessible = true,
        //        ModifyCash = -5,
        //        LocationItems = new ObservableCollection<GameItem>
        //            {
        //                GameItemById(30401), // Real Estate
        //                GameItemById(10401), // Business
        //                GameItemById(50401)  // Car                      
        //            }
        //    };
        //}

        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.AllGameItems = AllGameItems();

            gameMap.Locations = new ObservableCollection<Location>()
            {
                new Location()
                {
                    Id = 4,
                    Name = "Newberry, MI",
                    Description = "Newberry Description here.",
                    Accessible = true,
                    ModifyCash = -5,
                    LocationItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(30401), // Real Estate
                        GameItemById(10401), // Business
                        GameItemById(50401)  // Car                      
                    }
                },

                new Location()
                {
                    Id = 3,
                    Name = "Grand Rapids, MI",
                    Description = "Grand Rapids Description here.",
                    Accessible = true,
                    ModifyCash = -10,
                    LocationItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(30301), // Real Estate
                        GameItemById(10301), // Business
                        GameItemById(50301), // Car
                        GameItemById(50302), // Car
                        GameItemById(50303)  // Car
                    }
                },

                new Location()
                {
                    Id = 2,
                    Name = "Ennis, MT",
                    Description = "Ennis Description here.",
                    Accessible = true,
                    ModifyCash = 20
                },

                new Location()
                {
                    Id = 1,
                    Name = "Salt Lake City, UT",
                    Description = "Salt Lake City Description here.",
                    Accessible = true,
                    ModifyCash = 50
                }
            };

            //AllLocations = gameMap.Locations;   Was trying to use the "Newberry" in this list as the InitialGameMapLocation

            return gameMap;
        }

        // todo add items to appropriate locations
        public static List<GameItem> AllGameItems()
        {
            return new List<GameItem>
            {
                // Location: Newberry
                new RealEstate()
                {
                    Name = "4710 E. Greenwood Dr.",
                    Id = 30401, // Id denotes Item type, location, and index number. First digit denotes item type (3 = Real Estate... Alphabetical order). 
                                // Third digit denotes location (location ID; Newberry ID is 4). Fifth digit denotes item index (this is the first
                                // Newberry Real Estate, so its index is 1).
                    Description = "Beautiful home situated in quiet Greenwood Subdivision. This property has it all - living/dining room combo with sliding door onto the deck, stamped concrete patio, massive garage with space for 3-4 vehicles and a gorgeous kitchen with stainless appliances. Easy maintenance vinyl on the exterior with a new roof. Basement boasts 9'' ceilings and could be finished for additional living space.",
                    Price = 154900,
                    Value = 154900,
                    Bedrooms = 4,
                    Bathrooms = 2,
                    YearBuilt = 1995,
                    SqFootage = 1800,
                    condition = GameItem.Condition.Good,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 800, // Maybe check this number
                    AppreciationMax = 1.06, // Check Newberry Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessImpact = 15, //*** todo Happiness should be a multiplier, so that a positive number here gradually increases happines over time, maybe with an initial bonus
                    MilesFromTown = 5
                },

                new Business()
                {
                    Name = "Falls Hotel",
                    Id = 10401,
                    Industry = "Hotel",
                    YearsInBusiness = 100,
                    NetIncome = 3000, // Monthly Revenue
                    GrowthRate = 1.03,
                    Price = 115000,
                    Value = 115000 // Will fluctuate randomly, using the GrowthRate as a base
                },

                new Vehicle()
                {
                    Name = "2000 Chevy Silverado", // Name could be generated by Year, Brand, Model
                    Id = 50401,
                    Year = 2000,
                    Model = "Silverado",
                    Brand = "Chevrolet",
                    Description = "2000 Chevy Silverado 4 wheel drive has 195k on it runs great. plow works great it does have rust and needs tires soon and does need wheel bearing hubs" +
                    " (I have 2 brand new ones). It really does run great I just would like something different.",
                    Mileage = 195000,
                    condition = GameItem.Condition.Poor,
                    Price = 2500,
                    Value = 1900,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Low,
                    DriveDaily = false,
                    HappinessImpact = -10
                },

                new OtherItem()
                {

                },

                // Location: Grand Rapids
                new RealEstate()
                {
                    Name = "250 Dickinson St SE",
                    Id = 30301,
                    Description = "Newer style home. Full, deep, unfinished basement. Open stairway to 3 bedrooms upstairs. Vinyl siding. Paved driveway for off-street parking. St. Francis Xavier Church nearby.",
                    Price = 129900,
                    Value = 129900,
                    Bedrooms = 3,
                    Bathrooms = 1.5,
                    YearBuilt = 1998,
                    SqFootage = 1216,
                    condition = GameItem.Condition.Good,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 800, // Maybe check this number
                    AppreciationMax = 1.06, // Check GR Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessImpact = 5,
                    MilesFromTown = 2
                },

                new Business()
                {
                    Name = "Lucky Luciano's Pizza",
                    Id = 10301,
                    Industry = "Restaurant",
                    YearsInBusiness = 10,
                    NetIncome = 8500, // Monthly Revenue
                    GrowthRate = 1.06,
                    Price = 225000,
                    Value = 225000
                },

                new Vehicle()
                {
                    Name = "1998 Toyota Sienna",
                    Id = 50301,
                    Year = 1998,
                    Model = "Sienna",
                    Brand = "Toyota",
                    Description = "Toyota Sienna bought used from previous owner, who kept it extremely well maintained. No rust on body, all seats included and install/remove, handle missing on one side-door" +
                    " (still opens from inside), passenger-side window motor is disabled (unplugged it from power), interior in great shape, smoke free owners, crack down middle of windshield. " +
                    "It starts and drives, but there are engine misfire check engine codes. Toyota's never give up. I replaced the battery, spark plugs, coils, wires recently to try and fix the misfires but " +
                    "the engine still misfires and rough idles, so it could be the fuel injectors. I'm out of my depth at this point trying to DIY repair. " +
                    "If you work on cars and have the tools/space it's a reasonably inexpensive fix, also could be used for parts. " +
                    "Every mechanic who has looked at the vehicle has been surprised at what great shape the vehicle is in.",
                    Mileage = 299000,
                    condition = GameItem.Condition.Fair,
                    Price = 800,
                    Value = 500,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Moderate,
                    DriveDaily = false,
                    HappinessImpact = -10
                },

                new Vehicle()
                {
                    Name = "2005 Pontiac Grand Am GT 2-door",
                    Id = 50302,
                    Year = 2005,
                    Model = "Grand Am GT",
                    Brand = "Pontiac",
                    Description = "No Description.",
                    Mileage = 139000,
                    condition = GameItem.Condition.Good,
                    Price = 2500,
                    Value = 1900,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Low,
                    DriveDaily = false,
                    HappinessImpact = 0
                },

                new Vehicle()
                {
                    Name = "2006 Mustang Gt",
                    Id = 50303,
                    Year = 2006,
                    Model = "Mustang GT",
                    Brand = "Ford",
                    Description = "2006 Mustang Gt has 62500 miles on it and is well taken care of. Great shape for year. Runs perfect. Modifications are professionally installed and are as follows: " +
                    "C&L cold air intake. New hotter coil packs and plugs. Shock tower brace. New lowering springs and shocks. Hurst short throw shifter and new lower control arms.",
                    Mileage = 62500,
                    condition = GameItem.Condition.Excellent,
                    Price = 11300,
                    Value = 10000,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Low,
                    DriveDaily = false,
                    HappinessImpact = 10
                },


                // Location: Ennis



                // Location: Salt Lake



                // Location: NONE -- Stocks
                new Stock()
                {
                    Name = "Schwab S&P 500 Index",
                    Id = 4001,
                    Type = Stock.StockType.IndexFund,
                    Code = "SWPPX",
                    Price = 44,
                    TTMyield = 1.93,
                    KeepDividends = false,
                    Value = 44,
                    PlayersAmountofStocks = 1
                },
            };
        }

        //Methods
        private static GameItem GameItemById(int id)
        {
            return AllGameItems().FirstOrDefault(i => i.Id == id);
        }

        //private static Location LocationById(int id)
        //{
        //    return AllLocations().FirstOrDefault(i => i.Id == id);
        //}
    }
}
