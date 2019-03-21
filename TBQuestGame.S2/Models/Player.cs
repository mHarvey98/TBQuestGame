using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using WageSlave.Models;
using System.Collections.ObjectModel;


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


        //Properties
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
