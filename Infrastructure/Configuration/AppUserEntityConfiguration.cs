using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Core.Models;

namespace Infrastructure.Configuration
{
    public class AppUserEntityConfiguration : EntityConfiguration<AppUser>
    {

        public override void Map(EntityTypeBuilder<AppUser> builder)
        {

            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.IsEmployed).IsRequired();
            builder.Property(u => u.Salary);
            builder.Property(u => u.IsEmployed).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.IsMarried).IsRequired();
            builder.Property(u => u.PersonalNumber).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired();

            
        }
    }
}
