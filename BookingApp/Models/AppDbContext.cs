using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    class AppDbContext:DbContext
    {
        public AppDbContext() : base("AppConnection")
        {
           
        }

        public DbSet<User> Users { get; set; }
    }
}
