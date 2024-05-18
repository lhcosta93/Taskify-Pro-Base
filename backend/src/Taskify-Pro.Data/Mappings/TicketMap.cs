using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify_Pro.Domain.Entities;

namespace Taskify_Pro.Data.Mappings
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(a => a.Title)
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Description)
                .HasColumnType("varchar(255)");
        }
    }
}