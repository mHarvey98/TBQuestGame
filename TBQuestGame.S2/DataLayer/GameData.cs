using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using WageSlave.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Mitch",
                Age = 21,
                Cash = 10000,
                PreviousCash = 10000,
                CostOfLiving = 450,
                NetworkingPoints = 100,
                happiness = Character.Happiness.VeryHigh,
                Wage = 1000,
                TotalEarned = 50000,
                TotalSpent = 40000,
                WeeksPassed = 0,
                LocationId = 0
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

            //List<Occupation> _occupations = new List<Occupation>()
            //{
            //    new Occupation()
            //    {

            //    },

            //    new Occupation()
            //    {

            //    },

            //    new Occupation()
            //    {

            //    }
            //};

            //return _occupations;
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

        public static Location InitialGameMapLocation()
        {
            return new Location()
            {
                Id = 4,
                Name = "Newberry, MI",
                Description = "Description goes here.",
                Accessible = true,
                ModifyCash = 5
            };
        }

        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.Locations = new ObservableCollection<Location>()
            {
                new Location()
                {
                    Id = 4,
                    Name = "Newberry, MI",
                    Description = "Newberry Description here.",
                    Accessible = true,
                    ModifyCash = -5
                },

                new Location()
                {
                    Id = 3,
                    Name = "Grand Rapids, MI",
                    Description = "Grand Rapids Description here.",
                    Accessible = true,
                    ModifyCash = -10
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

            return gameMap;
        }
    }
}
