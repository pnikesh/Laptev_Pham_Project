using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laptev_Pham_Project.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }

        public float TotalSum { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("ID")]
        public Customer CustomerId { get; set; }

    }
}
