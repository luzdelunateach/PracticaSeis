using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Reflection;

namespace Model
{
    public class AppDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PurchaseOrderCart> PurchaseOrderCarts { get; set; }
        public DbSet<PurchaseOrderProvider> PurchaseOrderProviders { get; set; }
        public DbSet<Subdepartment> Subdepartments { get; set; }
        public DbSet<PurchaseOrderProviderDetail> PurchaseOrderProviderDetails { get; set; }
        public DbSet<PurchaseOrderCartDetail> PurchaseOrderCartDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EShopApp;Integrated Security=True");
        }
    }
}
