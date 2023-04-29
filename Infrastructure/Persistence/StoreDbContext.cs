using Application.Common.Interfaces;
using Common.Roles;
using Domain.Entities;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class StoreDbContext : DbContext , IStoreDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductComments> ProductComments { get; set; }
        public DbSet<ProductPrice> ProductPrices  { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=. ;Initial Catalog=StoreDatabase;Integrated Security=True ; Encrypt=False ;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //
            RoleHasData(modelBuilder);
            //
            ApplyQueryFilter(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsRemove);
            modelBuilder.Entity<Category>().HasQueryFilter(e => !e.IsRemove);
        }
        private void RoleHasData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, RoleName = nameof(AllRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = nameof(AllRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, RoleName = nameof(AllRoles.Customer) });

        }
    }
}