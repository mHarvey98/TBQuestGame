using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models
{
    public class GameItem : ObservableObject
    {
        public enum Condition {Decrepit, Poor, Fair, Good, Excellent}


        private string _name;
        private int _id;
        private int _price;
        private int _value;
        private double _happinessFactor;




        public double HappinessFactor
        {
            get { return _happinessFactor; }
            set { _happinessFactor = value; }
        }


        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
