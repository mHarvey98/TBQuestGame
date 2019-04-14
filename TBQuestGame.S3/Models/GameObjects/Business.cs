using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models.GameObjects
{
    public class Business : GameItem
    {
        private string _industry;
        private int _yearsInBusiness;
        private int _netIncome;
        private double _growthRate;
        //private Location _locale;  // Get location from Item ID

        //public Location Locale
        //{
        //    get { return _locale; }
        //    set { _locale = value; }
        //}

        public double GrowthRate
        {
            get { return _growthRate; }
            set { _growthRate = value; }
        }


        public int NetIncome
        {
            get { return _netIncome; }
            set { _netIncome = value; }
        }


        public int YearsInBusiness
        {
            get { return _yearsInBusiness; }
            set { _yearsInBusiness = value; }
        }


        public string Industry
        {
            get { return _industry; }
            set { _industry = value; }
        }

    }
}
