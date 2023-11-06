using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
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

            
            base.OnModelCreating(modelBuilder);
        }

    }
}
