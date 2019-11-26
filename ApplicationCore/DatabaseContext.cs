using DomainModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace ApplicationCore
{
    public class DatabaseContext : IdentityDbContext<User, Role, int>
    {
        private IOptions<ConnectionStrings> appsettings;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<ConnectionStrings> _appsettings) : base(options)
        {
            appsettings = _appsettings;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(appsettings.Value.DefaultConnection);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cart>().HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);


            //ASP.NET Core Identity - Primary key is changed from default string to int
            builder.Entity<Role>()
                   .ToTable("Roles")
                   .Property(p => p.Id)
                   .HasColumnName("RoleId");

            builder.Entity<User>()
                   .ToTable("Users")
                   .Property(p => p.Id)
                   .HasColumnName("UserId");

            builder.Entity<IdentityUserRole<int>>()
                   .ToTable("UserRole")
                   .HasKey(k => new { k.RoleId, k.UserId });

            builder.Entity<IdentityRoleClaim<int>>()
                   .ToTable("RoleClaim")
                   .HasKey(k => k.Id);

            builder.Entity<IdentityUserLogin<int>>()
                   .ToTable("UserLogin")
                   .HasKey(k => new { k.ProviderKey, k.LoginProvider });

            builder.Entity<IdentityUserClaim<int>>()
                   .ToTable("UserClaim")
                   .HasKey(k => k.Id);

            builder.Entity<IdentityUserToken<int>>()
                   .ToTable("UserToken")
                   .HasKey(KeyExtensions => KeyExtensions.UserId);

            //Seed Data into tables
            builder.Entity<Role>()
                   .HasData(new Role[2] {
                       new Role()
                       {
                           Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Description = "Administrator",
                            CreatedDate = DateTime.Now,
                            ConcurrencyStamp = "8768686"   // some number
                        },
                        new Role()
                        {
                            Id = 2,
                            Name = "User",
                            NormalizedName = "USER",
                            Description = "User",
                            CreatedDate = DateTime.Now,
                            ConcurrencyStamp = "8768686"
                        }
                   });
            base.OnModelCreating(builder);
        }
    }
}
