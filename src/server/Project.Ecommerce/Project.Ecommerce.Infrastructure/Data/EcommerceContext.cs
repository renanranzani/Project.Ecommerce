using Microsoft.EntityFrameworkCore;
using Project.Ecommerce.Infrastructure.Entities;
using System;

namespace Project.Ecommerce.Infrastructure.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=Ecommerce; user id=root; password=abc@1234", new MySqlServerVersion(new Version()),
            optionsBuilder =>
            optionsBuilder.MigrationsAssembly("Project.Ecommerce.Infrastructure"));
        }

        public DbSet<Products> Products { get; set; }
    }
}