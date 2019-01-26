using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laptev_Pham_Project.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Column("Name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        
    }
}
