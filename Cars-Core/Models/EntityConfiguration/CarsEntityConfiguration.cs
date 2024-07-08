using Cars_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Core.Models.EntityConfiguration
{
    public class CarsEntityConfiguration : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Brand).IsRequired(false);
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.Platenumber).HasMaxLength(10);
            builder.HasIndex(x => x.Platenumber).IsUnique();
            builder.Property(x => x.IsAvailable).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        }
    }
}
