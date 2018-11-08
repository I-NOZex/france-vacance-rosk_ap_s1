using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model {
    class AccommodationModel {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _address { get; set; }
        private bool _availability { get; set; }
        private double _price { get; set; }
        private int _numberOfRooms { get; set; }
        private int _rating { get; set; }

        public int Id {
            get { return _id; }
            set { _id = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public string Address {
            get { return _address; }
            set { _address = value; }
        }

        public bool Availability {
            get { return _availability; }
            set { _availability = value; }
        }

        public double Price {
            get { return _price; }
            set { _price = value; }
        }

        public int NumberOfRooms {
            get { return _numberOfRooms; }
            set { _numberOfRooms = value; }
        }

        public int Rating {
            get { return _rating; }
            set { _rating = value; }
        }


        public AccommodationModel() {

        }

    }
}
