using Directions_of_training.DAL.Entities;
using Directions_of_training.DAL.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.EF
{
    internal class DalContext : DbContext
    {
        public DalContext()
        {
           bool  isCreated=Database.EnsureCreated();
           // если база создана то заполнить каталог из файла
            if (isCreated)
            {
                if  (Catalog.Fill(this))
                {
                    this.SaveChanges();
                }
            }


        }

        public DbSet<Direction> Directions => Set<Direction>();
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<User> Users => Set<User>();
        public DbSet<CartDirection> CartDirections => Set<CartDirection>();
        public DbSet<CartProfile> CartProfiles => Set<CartProfile>();   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
