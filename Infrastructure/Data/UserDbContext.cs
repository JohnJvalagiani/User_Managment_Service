using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UserService.Core.Models;

namespace Infrastructure.Data
{
    public class UserDbContext:IdentityDbContext<AppUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<AppUser>()
            .HasMany(a => a.Students)
            .WithOne(u => u.Teacher)
            .HasForeignKey(a => a.ForeignKey);
            //.OnDelete(DeleteBehavior.SetNull);

        }
    }
}
