using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Encrypt;
using Microsoft.EntityFrameworkCore;

namespace ApplicationWeb.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<SellOrder> SellOrders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);


            modelBuilder.Entity<SuperAdmin>()
            .HasBaseType<User>()
            .HasDiscriminator<string>("UserType")
             .HasValue("SuperAdmin");

            modelBuilder.Entity<Admin>()
          .HasBaseType<User>()
          .HasDiscriminator<string>("UserType")
           .HasValue("Admin");

            modelBuilder.Entity<Customer>()
         .HasBaseType<User>()
         .HasDiscriminator<string>("UserType")
          .HasValue("Customer");


            modelBuilder.Entity<User>().HasData(new User
            {
                idUser = 1,
                UserName = "SuperAdmin",
                Email = "SuperAdmin@SuperAdmin.com",
                UserType = "SuperAdmin",
                Password = "SuperAdmin".Hash()
            });


            modelBuilder.Entity<User>().HasData(new User
            {
                idUser = 2,
                UserName = "Admin",
                Email = "Admin@Admin.com",
                UserType = "Admin",
                Password = "Admin".Hash()
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                idUser = 3,
                UserName = "Customer",
                Email = "Customer@Customer.com",
                UserType = "Customer",
                Password = "Customer".Hash()
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
