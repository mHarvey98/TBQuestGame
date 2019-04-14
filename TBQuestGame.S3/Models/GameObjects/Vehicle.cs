using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models.GameObjects
{
    public class Vehicle : GameItem
    {
        public enum MaintenanceCosts { VeryLow, Low, Moderate, High, VeryHigh}

        private int _year;
        private string _model;
        private string _brand;
        private int _mileage;
        private Condition _condition;
        private double _depreciationRate;
        private MaintenanceCosts _maintenanceCost;
        private bool _driveDaily;
        private int _happinessImpact;
        private string _description;


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int HappinessImpact
        {
            get { return _happinessImpact; }
            set { _happinessImpact = value; }
        }


        public bool DriveDaily
        {
            get { return _driveDaily; }
            set { _driveDaily = value; }
        }


        public MaintenanceCosts MaintenanceCost
        {
            get { return _maintenanceCost; }
            set { _maintenanceCost = value; }
        }



        public double DepreciationRate
        {
            get { return _depreciationRate; }
            set { _depreciationRate = value; }
        }

        public Condition condition
        {
            get { return _condition; }
            set { _condition = value; }
        }


        public int Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }


        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }


        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }


        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

    }
}
