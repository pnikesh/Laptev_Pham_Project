using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laptev_Pham_Project.Models
{
    public class Ticket
    {
        public int ID { get; set; }

        public TicketType TicketType { get; set; }

        public int Price { get; set; }

        public bool isRound { get; set; }

        public string DepartureTimeTo { get; set; }

        public string ArrivalTimeTo { get; set; }

        public string DepartureTimeFrom { get; set; }

        public string ArrivalTimeFrom { get; set; }

        [ForeignKey("OrderNumber")]
        public Order Order { get; set; }

    }

    public enum TicketType
    {
        Economic,
        Business,
        Premium
    }
}
