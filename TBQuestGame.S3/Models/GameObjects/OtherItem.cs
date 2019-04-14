using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models.GameObjects
{
    public class OtherItem : GameItem
    {
        private string _description;
        private double _appreciationMax;
        private double _appreciationMin;
        private int _happinessImpact;


        public int HappinessImpact
        {
            get { return _happinessImpact; }
            set { _happinessImpact = value; }
        }

        public double AppreciationMin
        {
            get { return _appreciationMin; }
            set { _appreciationMin = value; }
        }

        public double AppreciationMax
        {
            get { return _appreciationMax; }
            set { _appreciationMax = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
