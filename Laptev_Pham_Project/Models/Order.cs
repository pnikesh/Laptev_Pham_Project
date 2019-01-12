using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptev_Pham_Project.Models
{
    public class Order
    {
        public int ID { get; set; }

        public DepartureCity DepartureCityName { get; set; }

        public ArrivalCity ArrivalCityName { get; set; }

        public Flight Flight { get; set; }

        public Ticket Ticket { get; set; }
    }
}
