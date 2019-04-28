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
                Expenses = 230, // Weekly CoL
                NetworkingPoints = 100,
                Happiness = 100,
                Wage = 150, // Weekly Wage
                Salary = 0,
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
                    AvgSalary = 26000,
                    HourlyRate = (26000 / 52) / 40
                },

                new Occupation()
                {
                    Name = "Machinist",
                    YearsInSchool = 0,
                    Debt = 0,
                    AvgSalary = 40000,
                    HourlyRate = (40000 / 52) / 40
                },

                new Occupation()
                {
                    Name = "Electrician",
                    YearsInSchool = 2,
                    Debt = 15000,
                    AvgSalary = 50000,
                    HourlyRate = (50000 / 52) / 40
                },

                new Occupation()
                {
                    Name = "Cosmetologist",
                    YearsInSchool = 2,
                    Debt = 12000,
                    AvgSalary = 35000,
                    HourlyRate = (35000 / 52) / 40
                },

                new Occupation()
                {
                    Name = "Computer Engineer",
                    YearsInSchool = 4,
                    Debt = 100000,
                    AvgSalary = 104000,
                    HourlyRate = (104000 / 52) / 40
                },

                new Occupation()
                {
                    Name = "History Teacher",
                    YearsInSchool = 4,
                    Debt = 100000,
                    AvgSalary = 55000,
                    HourlyRate = (55000 / 52) / 40
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

                "Retiring can only happen when your income from assets is greater than your cost of living by $500, " +
                "AND you have no debt, AND your happiness is greater than 80. Keep all of these things in mind while deciding " +
                "on your strategy.",

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
                    Description = "Newberry is a small, rural town in Michigan's Upper Peninsula. Economy is fair, given its size. However, there are limited businesses and other assets to be found here.",
                    Accessible = true,
                    ModifyCash = 60,
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
                    Description = "Grand Rapids is the second-largest city in Michigan. Annual economic growth has greatly increased in the last 10 years.",
                    Accessible = true,
                    ModifyCash = 40,
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
                    Description = "Ennis is a quaint town in rural south-west Montana. Being in Montana, Ennis hasn't grown much in recent history, but it is an old town with deep roots in the surrounding area, and has moderate potential for investment opportunities.",
                    Accessible = true,
                    ModifyCash = 70,
                    LocationItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(50201), //Car
                        GameItemById(50202), //Car
                        GameItemById(30201), //Real Estate
                        GameItemById(10201), //Business
                    }
                },

                new Location()
                {
                    Id = 1,
                    Name = "Salt Lake City, UT",
                    Description = "Salt Lake has absolutely boomed in the last 10 years. It is a beautiful place to live, situated between the Great Salt Lake and the Rocky Mountains. Investment opportunities are plentiful.",
                    Accessible = true,
                    ModifyCash = 50,
                    LocationItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(10101), //Business
                        GameItemById(10102), //Business
                        GameItemById(30201), //Real Estate
                        GameItemById(30202), //Real Estate
                        GameItemById(50101), //Vehicle
                        GameItemById(50102), //Vehicle
                    }
                }
            };

            return gameMap;
        }

        //add items to appropriate locations
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
                    FamiliesAllowed = 1,
                    YearBuilt = 1995,
                    SqFootage = 1800,
                    condition = GameItem.Condition.Good,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 800, // Maybe check this number
                    AppreciationMax = 1.06, // Check Newberry Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessFactor = .6, //*** Happiness should be a multiplier, so that a positive number here gradually increases happines over time, maybe with an initial bonus
                    MilesFromTown = 5
                },

                new Business()
                {
                    Name = "Falls Hotel",
                    Id = 10401,
                    Industry = "Hotel",
                    YearsInBusiness = 100,
                    NetIncome = 30000, // Monthly Revenue
                    GrowthRate = 1.03,
                    Price = 115000,
                    Value = 115000, // Will fluctuate randomly, using the GrowthRate as a base
                    HappinessFactor = .5
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
                    HappinessFactor = -.1
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
                    FamiliesAllowed = 1,
                    YearBuilt = 1998,
                    SqFootage = 1216,
                    condition = GameItem.Condition.Good,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 800, // Maybe check this number (monthly rent... will divide by 4 to add to weekly asset income)
                    AppreciationMax = 1.06, // Check GR Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessFactor = .5,
                    MilesFromTown = 2
                },

                new Business()
                {
                    Name = "Lucky Luciano's Pizza",
                    Id = 10301,
                    Industry = "Restaurant",
                    YearsInBusiness = 10,
                    NetIncome = 85000, // Monthly Revenue
                    GrowthRate = 1.06,
                    Price = 225000,
                    Value = 225000,
                    HappinessFactor = .5
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
                    HappinessFactor = -.2
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
                    HappinessFactor = .1
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
                    HappinessFactor = .4
                },


                // Location: Ennis
                new Vehicle()
                {
                    Name = "1997 Chrysler Cirrus",
                    Id = 50201,
                    Year = 1997,
                    Model = "Cirrus",
                    Brand = "Chrysler",
                    Description = "1997 Chrysler Cirrus 6 cylinder automatic. Water pump is starting to leak out of weep hole and that means it needs to be replaced when you do it might as well do the timing belt as well. ",
                    Mileage = 217060,
                    condition = GameItem.Condition.Poor,
                    Price = 500,
                    Value = 400,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Moderate,
                    DriveDaily = false,
                    HappinessFactor = -.2
                },

                new Vehicle()
                {
                    Name = "1995 Chevy Pickup",
                    Id = 50202,
                    Year = 1995,
                    Model = "Silverado",
                    Brand = "Chevrolet",
                    Description = "1995 Chevy Silverado pickup 2500 extended cab. New upper and lower ball joints, new torsion bar, new radiator, new water pump, new front brakes good tires, runs strong.",
                    Mileage = 212000,
                    condition = GameItem.Condition.Good,
                    Price = 4500,
                    Value = 4000,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Moderate,
                    DriveDaily = false,
                    HappinessFactor = .2
                },

                new RealEstate()
                {
                    Name = "846 Mirza Way",
                    Id = 30201,
                    Description = "Affordable housing at it's finest. All one level 3 bedroom 2 bath and over 1200 Square feet close to the school and just a short distance to downtown.",
                    Price = 249900,
                    Value = 249900,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    FamiliesAllowed = 1,
                    YearBuilt = 2018,
                    SqFootage = 1287,
                    condition = GameItem.Condition.Excellent,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 1000, // Maybe check this number (monthly rent... will divide by 4 to add to weekly asset income)
                    AppreciationMax = 1.06, // Check GR Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessFactor = .7,
                    MilesFromTown = 2
                },

                new Business()
                {
                    Name = "Continental Divide Bistro",
                    Id = 10201,
                    Industry = "Restaurant",
                    YearsInBusiness = 18,
                    NetIncome = 75000, // Monthly Revenue
                    GrowthRate = 1.06,
                    Price = 299000,
                    Value = 299000,
                    HappinessFactor = .5
                },


                // Location: Salt Lake
                new Business()
                {
                    Name = "SuperCuts",
                    Id = 10101,
                    Industry = "Salon",
                    YearsInBusiness = 8,
                    NetIncome = 45000, // Monthly Revenue
                    GrowthRate = 1.06,
                    Price = 209000,
                    Value = 209000,
                    HappinessFactor = .5
                },

                new Business()
                {
                    Name = "Auto-Glass Repair",
                    Id = 10102,
                    Industry = "Car Repair",
                    YearsInBusiness = 20,
                    NetIncome = 85000, // Monthly Revenue
                    GrowthRate = 1.06,
                    Price = 230000,
                    Value = 230000,
                    HappinessFactor = .5
                },

                new RealEstate()
                {
                    Name = "729 E Linden Ave",
                    Id = 30101,
                    Description = "Great downtown investment on quiet Linden Avenue with (2) 2-1 units. New electrical service, new meters, new panels, mostly rewired inside, 2 gas furnaces, 2 gas water heaters, partially replaced plumbing, and *large parking area in back of lot.",
                    Price = 325000,
                    Value = 325000,
                    Bedrooms = 4,
                    Bathrooms = 2,
                    FamiliesAllowed = 2,
                    YearBuilt = 1900,
                    SqFootage = 1384,
                    condition = GameItem.Condition.Good,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 2000, // Maybe check this number (monthly rent... will divide by 4 to add to weekly asset income)
                    AppreciationMax = 1.06, // Check GR Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessFactor = .6,
                    MilesFromTown = 4
                },

                new RealEstate()
                {
                    Name = "312 G St",
                    Id = 30102,
                    Description = "Great downtown investment on quiet Linden Avenue with (2) 2-1 units. New electrical service, new meters, new panels, mostly rewired inside, 2 gas furnaces, 2 gas water heaters, partially replaced plumbing, and *large parking area in back of lot.",
                    Price = 485000,
                    Value = 485000,
                    Bedrooms = 4,
                    Bathrooms = 2,
                    FamiliesAllowed = 1,
                    YearBuilt = 1940,
                    SqFootage = 2160,
                    condition = GameItem.Condition.Good,
                    PlayerLivesIn = false,
                    RentOut = false,
                    RentPrice = 1500, // Maybe check this number (monthly rent... will divide by 4 to add to weekly asset income)
                    AppreciationMax = 1.06, // Check GR Appreciation Rates
                    AppreciationMin = 1.02,
                    HappinessFactor = .8,
                    MilesFromTown = 1
                },

                new Vehicle()
                {
                    Name = "2006 Chevy Trailblazer LT",
                    Id = 50101,
                    Year = 2006,
                    Model = "Trailblazer",
                    Brand = "Chevrolet",
                    Description = "2006 Chevrolet Trailblazer LT 4x4. This Trailblazer runs awesome. It has the 4.2 inline 6 cylinder Vortec with 270 HP. ",
                    Mileage = 145205,
                    condition = GameItem.Condition.Excellent,
                    Price = 3500,
                    Value = 3000,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.Moderate,
                    DriveDaily = false,
                    HappinessFactor = .1
                },

                new Vehicle()
                {
                    Name = "2014 Audi SQ5",
                    Id = 50102,
                    Year = 2014,
                    Model = "SQ5",
                    Brand = "Audi",
                    Description = "Ultimate crossover of sports and luxury. This Audi SQ5 stands at the top of the mountain for a sporty SUV.",
                    Mileage = 68000,
                    condition = GameItem.Condition.Excellent,
                    Price = 29000,
                    Value = 25000,
                    DepreciationRate = .844, // Average car depreciation per year is 15.6%
                    MaintenanceCost = Vehicle.MaintenanceCosts.High,
                    DriveDaily = false,
                    HappinessFactor = .5
                },



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
                    PlayersAmountofStocks = 1,
                    HappinessFactor = 0
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
