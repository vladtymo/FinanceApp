using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UserDbContext : DbContext
    {
        public UserDbContext() : base("name=UserDbContext")
        {
            Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfig());
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
