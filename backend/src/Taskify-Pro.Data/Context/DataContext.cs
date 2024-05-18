using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskify_Pro.Data.Mappings;
using Taskify_Pro.Domain.Entities;

namespace Taskify_Pro.Data.Context
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketMap());
        }
    }
}