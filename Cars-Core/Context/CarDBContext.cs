using Cars_Core.Models.Entity;
using Cars_Core.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Core.Context
{
    public class CarDBContext : DbContext
    {
        public CarDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CarsEntityConfiguration());
        }
        public virtual DbSet<Cars> Car { get; set; }
    }
}
