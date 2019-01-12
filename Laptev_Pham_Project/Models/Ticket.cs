using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptev_Pham_Project.Models
{
    public class Ticket
    {
        public int ID { get; set; }

        public TicketType TicketType { get; set; }

        public int Price { get; set; }

    }

    public enum TicketType
    {
        Economic,
        Business,
        Premium
    }
}
