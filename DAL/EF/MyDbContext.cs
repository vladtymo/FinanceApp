using DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=FinanceApp")
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }

}