using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        //Enums
        public enum SchoolRoute { None, TradeSchool, University}
        
        // Fields
        private int _age;
        private int _cash;
        private int _costOfLiving;
        private int _wage;
        private int _networkingPoints;
        private int _totalEarned;
        private int _totalSpent;
        private int _weeksPassed;
        private SchoolRoute _schoolRoute;




        //Properties
        public int WeeksPassed
        {
            get { return _weeksPassed; }
            set { _weeksPassed = value; }
        }

        public SchoolRoute School_Route
        {
            get { return _schoolRoute; }
            set { _schoolRoute = value; }
        }

        public int Wage
        {
            get { return _wage; }
            set { _wage = value; }
        }

        public int TotalSpent
        {
            get { return _totalSpent; }
            set { _totalSpent = value; }
        }

        public int TotalEarned
        {
            get { return _totalEarned; }
            set { _totalEarned = value; }
        }

        public int NetworkingPoints
        {
            get { return _networkingPoints; }
            set { _networkingPoints = value; }
        }

        public int CostOfLiving
        {
            get { return _costOfLiving; }
            set { _costOfLiving = value; }
        }

        public int Cash
        {
            get { return _cash; }
            set { _cash = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }



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
                LocationId = 0
            };
        }

        public override string GetOccupation()
        {
            string occupation = "";

            // Use the player setup for this

            return occupation;
        }

        /// <summary>
        /// override the default greeting in the Character class to include the job title
        /// set the proper article based on the job title
        /// </summary>
        /// <returns>default greeting</returns>
        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(occupation.ToString().Substring(0, 1)))
            {
                article = "an";
            }

            return $"Hello, my name is {Name} and I am {article} {occupation} for the Aion Project.";
        }
    }
}
