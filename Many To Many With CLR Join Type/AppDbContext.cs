using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_To_Many_With_CLR_Join_Type
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString =
            @"Server=(localdb)\mssqllocaldb;
             Database=PeopleAndGroups;
             Trusted_Connection=True";

        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Membership>() 
            //    .HasKey(x => new {x.GroupId, x.PersonId});

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Groups)
                .WithMany(e => e.People)
                .UsingEntity<Membership>(
                    b => b.HasOne<Group>(x => x.Group).WithMany().HasForeignKey("GroupId"),
                    b => b.HasOne<Person>(x => x.Person).WithMany().HasForeignKey("PersonId")
                    );
        }
    }

}