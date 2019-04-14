using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WageSlave.Models
{
    public class Location
    {
        // Fields
        private int _id;
        private string _name;
        private string _description;
        private int _modifyCash;
        private bool _accessible;
        private ObservableCollection<GameItem> _locationItems;


        // Properties
        public ObservableCollection<GameItem> LocationItems
        {
            get { return _locationItems; }
            set { _locationItems = value; }
        }
                     
        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int ModifyCash
        {
            get { return _modifyCash; }
            set { _modifyCash = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // Constructors

        public Location()
        {
            _locationItems = new ObservableCollection<GameItem>();
        }

        // Methods
        public override string ToString()
        {
            return _name;
        }
    }
}
