using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models
{
    public class Loan
    {
        public enum LoanType { Housing, Car, Personal}

        private string _name;
        private int _id;
        private LoanType _loanType;
        private int _loanAmount;
        private int _remainingLoanBalance;
        private int _loanLifetimeYears;
        private double _aPR;
        private bool _loanInterestIsFixed;
        private int _loanWeeklyPayment;


        public int LoanWeeklyPayment
        {
            get { return _loanWeeklyPayment; }
            set { _loanWeeklyPayment = value; }
        }

        public int RemainingLoanBalance
        {
            get { return _remainingLoanBalance; }
            set { _remainingLoanBalance = value; }
        }
        public bool LoanInterestIsFixed
        {
            get { return _loanInterestIsFixed; }
            set { _loanInterestIsFixed = value; }
        }

        public double APR
        {
            get { return _aPR; }
            set { _aPR = value; }
        }

        public int LoanLifetimeYears
        {
            get { return _loanLifetimeYears; }
            set { _loanLifetimeYears = value; }
        }

        public int LoanAmount
        {
            get { return _loanAmount; }
            set { _loanAmount = value; }
        }

        public LoanType loanType
        {
            get { return _loanType; }
            set { _loanType = value; }
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
