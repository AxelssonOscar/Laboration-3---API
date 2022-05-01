using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    Id = 1,
                    Name = "Adam",
                    PhoneNumber = "123"
                });

            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    Id = 2,
                    Name = "Bertil",
                    PhoneNumber = "456"
                });

            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    Id = 3,
                    Name = "Ceasar",
                    PhoneNumber = "789"
                });


            modelBuilder.Entity<Interest>()
                .HasData(new Interest
                {
                    Id = 1,
                    PersonId = 1, //Adam
                    Title = "Programming in C++",
                    Description = "The importance of low level programming."                    
                });

            modelBuilder.Entity<Interest>()
                .HasData(new Interest
                {
                    Id = 2,
                    PersonId = 1, //Adam
                    Title = "Programmering in C#",
                    Description = "The flexibility of a more modern language"
                });

            modelBuilder.Entity<Link>()
                .HasData(new Link
                {
                    Id = 1,
                    PersonId = 1, //Adam
                    InterestId = 1, // Programming in C++
                    WebsiteLink = "https://en.wikipedia.org/wiki/C%2B%2B",
                });

            modelBuilder.Entity<Link>()
                .HasData(new Link
                {
                    Id = 2,
                    PersonId = 1, //Adam
                    InterestId = 2, // Programming in C#
                    WebsiteLink = "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)",
                });


        }




    }
}
