using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    class AccModel

    {
        public int ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public bool availability { get; set; }
        public double price { get; set; }
        public int NumberOfRooms { get; set; }
        public int Rating { get; set; }


        public AccModel()
        {
            
        }

    }
}
