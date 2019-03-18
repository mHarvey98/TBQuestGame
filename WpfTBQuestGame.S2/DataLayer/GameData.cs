using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

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
                "After that, the rest of your working life's financial decisions will be simulated." +
                "How you choose to spend and invest your money is critical, as the object of the game" +
                "is to retire as early as possible.",
                "Welcome to 'WageSlave'!"
            };
        }
    }
}
