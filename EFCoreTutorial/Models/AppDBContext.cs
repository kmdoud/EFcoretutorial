using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTutorial.Models
{
    public class AppDBContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connStr = @"server=localhost\sqlexpress;database=SalesDb2;Trusted_Connection=true";
            builder.UseSqlServer(connStr);
        }
    }
}
