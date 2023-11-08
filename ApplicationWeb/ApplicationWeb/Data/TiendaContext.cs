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
        public DbSet<DtoUser> DtoUsers { get; set; }
        public DbSet<DtoAdmin> dtoAdmins { get; set; }
        public DbSet<DtoCustomer> dtoCustomers { get; set; }
        public DbSet<DtoSuperAdmin> dtoSuperAdmins { get; set; }
        public DbSet<DtoProducts> DtoProducts { get; set; }

        public DbSet<DtoSellOrder> DtoSellOrders { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtoUser>().HasDiscriminator(u => u.UserType);


            modelBuilder.Entity<DtoSuperAdmin>()
            .HasBaseType<DtoUser>()
            .HasDiscriminator<string>("UserType")
             .HasValue("SuperAdmin");

            modelBuilder.Entity<DtoAdmin>()
          .HasBaseType<DtoUser>()
          .HasDiscriminator<string>("UserType")
           .HasValue("Admin");

            modelBuilder.Entity<DtoCustomer>()
         .HasBaseType<DtoUser>()
         .HasDiscriminator<string>("UserType")
          .HasValue("Customer");


            modelBuilder.Entity<DtoUser>().HasData(new User
            {
                idUser = 1,
                UserName = "SuperAdmin",
                Email = "SuperAdmin@SuperAdmin.com",
                UserType = "SuperAdmin",
                Password = "SuperAdmin".Hash()
            });


            modelBuilder.Entity<DtoUser>().HasData(new User
            {
                idUser = 2,
                UserName = "Admin",
                Email = "Admin@Admin.com",
                UserType = "Admin",
                Password = "Admin".Hash()
            });
            modelBuilder.Entity<DtoUser>().HasData(new User
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
