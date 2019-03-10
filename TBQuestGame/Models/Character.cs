using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class Character
    {
        // Fields
        public enum Happiness { VeryHigh, High, Moderate, Low, VeryLow}
        public enum Occupation { FactoryWorker, Machinist, Electrician, Cosmetologist, SoftwareEngineer, HistoryMajor}

        private int _id;
        private string _name;
        private int _locationId;
        private Happiness _happiness;
        private Occupation _occupation;

        // Properties
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Occupation occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }

        public Happiness happiness
        {
            get { return _happiness; }
            set { _happiness = value; }
        }


        //Methods
        public virtual string DefaultGreeting() // Virtual allows child classes to alter this method. Virtual also means it doesn't have to be used.
        {
            return $"Hello, my name is {_name}";
        }

        public abstract string GetOccupation();
    }
}
