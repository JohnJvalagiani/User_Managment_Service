using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class AdressEntityConfiguration : EntityConfiguration<Address>
    {



        public override void Map(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Adress");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.State).IsRequired();
            builder.Property(a => a.ZipCode).IsRequired();
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.Country).IsRequired();
        }


    }
}
