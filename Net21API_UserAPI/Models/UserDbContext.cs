using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net21API_UserAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data 
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Name = "Pelle" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, Name = "Sara" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, Name = "Linnea" });
        }
    }
}
