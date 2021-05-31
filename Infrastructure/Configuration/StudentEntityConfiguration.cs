using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    class StudentEntityConfiguration : EntityConfiguration<Student>
    {
        public override void Map(EntityTypeBuilder<Student> builder)
        {

            builder.ToTable("Student");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Rate).HasPrecision(11, 6); 

        }
    }
}
