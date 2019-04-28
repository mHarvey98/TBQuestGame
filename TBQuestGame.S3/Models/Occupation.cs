using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models
{
    public class Occupation
    {
        //fields
        private string _name;
        private int _yearsInSchool;
        private int _debt;
        private int _avgSalary; // hourly rate * 40 hours per week * 52 weeks a year
        private int _hourlyRate;



        //properties
        public int AvgSalary
        {
            get { return _avgSalary; }
            set { _avgSalary = value; }
        }

        public int HourlyRate
        {
            get { return _hourlyRate; }
            set
            {
                _hourlyRate = value;
            }
        }

        public int Debt
        {
            get { return _debt; }
            set { _debt = value; }
        }

        public int YearsInSchool
        {
            get { return _yearsInSchool; }
            set { _yearsInSchool = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
