using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laptev_Pham_Project.Models;

    public class FlightsDBContext : DbContext
    {
        public FlightsDBContext (DbContextOptions<FlightsDBContext> options)
            : base(options)
        {
        }

        public DbSet<Laptev_Pham_Project.Models.ArrivalCity> ArrivalCity { get; set; }

        public DbSet<Laptev_Pham_Project.Models.Customer> Customer { get; set; }

        public DbSet<Laptev_Pham_Project.Models.DepartureCity> DepartureCity { get; set; }

        public DbSet<Laptev_Pham_Project.Models.Flight> Flight { get; set; }

        public DbSet<Laptev_Pham_Project.Models.Order> Order { get; set; }

        public DbSet<Laptev_Pham_Project.Models.Ticket> Ticket { get; set; }
    }
