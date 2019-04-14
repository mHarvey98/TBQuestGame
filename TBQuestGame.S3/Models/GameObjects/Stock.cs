using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageSlave.Models.GameObjects
{
    public class Stock : GameItem
    {
        public enum StockType {MutualFund, IndexFund, Common}

        private StockType _type;
        private string _code;
        private bool _keepDividends;
        private double _tTmYield; // This is the growth percentage over the last 12 months. Program should fluctuate this number randomly every month
        private int _playersAmountofStocks; // Act as a quantity of stocks the player owns


        public int PlayersAmountofStocks
        {
            get { return _playersAmountofStocks; }
            set { _playersAmountofStocks = value; }
        }

        public double TTMyield
        {
            get { return _tTmYield; }
            set { _tTmYield = value; }
        }

        public bool KeepDividends
        {
            get { return _keepDividends; }
            set { _keepDividends = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public StockType Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
