﻿// <auto-generated />
using ApplicationWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationWeb.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20231128202028_edit")]
    partial class edit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationWeb.Data.Dto.DtoProducts", b =>
                {
                    b.Property<int>("idProducts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProducts"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("idProducts");

                    b.ToTable("DtoProducts");
                });

            modelBuilder.Entity("ApplicationWeb.Data.Dto.DtoSellOrder", b =>
                {
                    b.Property<int>("idOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idOrder"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("QuantityProducts")
                        .HasColumnType("int");

                    b.Property<int>("TotalValue")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Validation")
                        .HasColumnType("bit");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idOrder");

                    b.ToTable("DtoSellOrders");
                });

            modelBuilder.Entity("ApplicationWeb.Data.Dto.DtoUser", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUser");

                    b.ToTable("DtoUsers");

                    b.HasDiscriminator<string>("UserType").HasValue("DtoUser");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            idUser = 1,
                            Email = "SuperAdmin@SuperAdmin.com",
                            Password = "f94d3a61fc4b322de134ab222d849e50f4a407f68d201ddd1ff44e57ee20339d",
                            UserName = "SuperAdmin",
                            UserType = "SuperAdmin"
                        },
                        new
                        {
                            idUser = 2,
                            Email = "Admin@Admin.com",
                            Password = "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f",
                            UserName = "Admin",
                            UserType = "Admin"
                        },
                        new
                        {
                            idUser = 3,
                            Email = "Customer@Customer.com",
                            Password = "bf3763383aaf43069885db20b386631c6d5d8b8481df2a26769e9de5fe2f9c82",
                            UserName = "Customer",
                            UserType = "Customer"
                        });
                });

            modelBuilder.Entity("ApplicationWeb.Data.Models.DtoAdmin", b =>
                {
                    b.HasBaseType("ApplicationWeb.Data.Dto.DtoUser");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("ApplicationWeb.Data.Models.DtoCustomer", b =>
                {
                    b.HasBaseType("ApplicationWeb.Data.Dto.DtoUser");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("ApplicationWeb.Data.Models.DtoSuperAdmin", b =>
                {
                    b.HasBaseType("ApplicationWeb.Data.Dto.DtoUser");

                    b.HasDiscriminator().HasValue("SuperAdmin");
                });
#pragma warning restore 612, 618
        }
    }
}
