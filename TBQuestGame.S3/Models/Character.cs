using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageSlave;

namespace TBQuestGame.Models
{
    public abstract class Character : ObservableObject
    {
        // Fields
        public enum Happiness { VeryHigh, High, Moderate, Low, VeryLow}

        private int _id;
        private string _name;
        private int _locationId;
        private Happiness _happiness;

        // Properties
        public int LocationId
        {
            get { return _locationId; }
            set
            {
                _locationId = value;
                OnPropertyChanged(nameof(LocationId));
            }
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

        public Happiness happiness
        {
            get { return _happiness; }
            set
            {
                _happiness = value;
                OnPropertyChanged(nameof(happiness));
            }
        }


        //Methods
        public virtual string DefaultGreeting() // Virtual allows child classes to alter this method. Virtual also means it doesn't have to be used.
        {
            return $"Hello, my name is {_name}";
        }

        public abstract string GetOccupation();
    }
}
