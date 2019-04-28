using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models.GameObjects
{
    public class RealEstate : GameItem
    {
        private string _description;
        private int _bedrooms;
        private double _bathrooms;
        private int _yearBuilt;
        private int _sqFootage;
        private Condition _condition;
        private bool _playerLivesIn;
        private bool _rentOut;
        private int _rentPrice;
        private double _appreciationMax;
        private double _appreciationMin;
        private int _familiesAllowed;
        private int _milesFromTown;
        //private Location _locale;


        //public Location Locale
        //{
        //    get { return _locale; }
        //    set { _locale = value; }
        //}

        public int MilesFromTown
        {
            get { return _milesFromTown; }
            set { _milesFromTown = value; }
        }

        public int FamiliesAllowed
        {
            get { return _familiesAllowed; }
            set { _familiesAllowed = value; }
        }

        public double AppreciationMax
        {
            get { return _appreciationMax; }
            set { _appreciationMax = value; }
        }

        public double AppreciationMin
        {
            get { return _appreciationMin; }
            set { _appreciationMin = value; }
        }

        public double Bathrooms
        {
            get { return _bathrooms; }
            set { _bathrooms = value; }
        }

        public int RentPrice
        {
            get { return _rentPrice; }
            set { _rentPrice = value; }
        }

        public bool RentOut
        {
            get { return _rentOut; }
            set { _rentOut = value; }
        }

        public bool PlayerLivesIn
        {
            get { return _playerLivesIn; }
            set { _playerLivesIn = value; }
        }

        public Condition condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public int SqFootage
        {
            get { return _sqFootage; }
            set { _sqFootage = value; }
        }

        public int YearBuilt
        {
            get { return _yearBuilt; }
            set { _yearBuilt = value; }
        }

        public int Bedrooms
        {
            get { return _bedrooms; }
            set { _bedrooms = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
