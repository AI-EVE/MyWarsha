﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWarsha_DataAccess.Data;

#nullable disable

namespace MyWarsha_DataAccess.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarInfoProduct", b =>
                {
                    b.Property<int>("CarInfosId")
                        .HasColumnType("int");

                    b.Property<string>("ProductsName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CarInfosId", "ProductsName");

                    b.HasIndex("ProductsName");

                    b.ToTable("CarInfoProduct");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarInfoId")
                        .HasColumnType("int");

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarInfoId");

                    b.HasIndex("ClientId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarGeneration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarGeneration");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImage");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarGenerationId")
                        .HasColumnType("int");

                    b.Property<int>("CarMakerId")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarGenerationId");

                    b.HasIndex("CarMakerId");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarInfo");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarMaker");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarMakerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarMakerId");

                    b.ToTable("CarModel");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Product", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateAdded")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductBrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("UnitsSold")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductBrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductBought", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BoughtFor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RelevantDataToTheBoughtId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductName");

                    b.HasIndex("RelevantDataToTheBoughtId");

                    b.ToTable("ProductBought");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductName");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductToSell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("SoldFor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductName");

                    b.HasIndex("ServiceId");

                    b.ToTable("ProductToSell");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.RelevantDataToTheBought", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfOrder")
                        .HasColumnType("date");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelevantDataToTheBought");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ServiceFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceFee");
                });

            modelBuilder.Entity("CarInfoProduct", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.CarInfo", null)
                        .WithMany()
                        .HasForeignKey("CarInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Car", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.CarInfo", "CarInfo")
                        .WithMany()
                        .HasForeignKey("CarInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarInfo");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarGeneration", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.CarModel", "CarModel")
                        .WithMany("CarGenerations")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarImage", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Car", "Car")
                        .WithMany("CarImages")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarInfo", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.CarGeneration", "CarGeneration")
                        .WithMany()
                        .HasForeignKey("CarGenerationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.CarMaker", "CarMaker")
                        .WithMany()
                        .HasForeignKey("CarMakerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CarGeneration");

                    b.Navigation("CarMaker");

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarModel", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.CarMaker", "CarMaker")
                        .WithMany("CarModels")
                        .HasForeignKey("CarMakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarMaker");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Phone", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Client", "Client")
                        .WithMany("Phones")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Product", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductBought", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.RelevantDataToTheBought", "RelevantDataToTheBought")
                        .WithMany("ProductsBought")
                        .HasForeignKey("RelevantDataToTheBoughtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("RelevantDataToTheBought");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductImage", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ProductToSell", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.Service", "Service")
                        .WithMany("ProductsToSell")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Service", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyWarsha_Models.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.ServiceFee", b =>
                {
                    b.HasOne("MyWarsha_Models.Models.Service", "Service")
                        .WithMany("ServiceFees")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Car", b =>
                {
                    b.Navigation("CarImages");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarMaker", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.CarModel", b =>
                {
                    b.Navigation("CarGenerations");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Client", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Product", b =>
                {
                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.RelevantDataToTheBought", b =>
                {
                    b.Navigation("ProductsBought");
                });

            modelBuilder.Entity("MyWarsha_Models.Models.Service", b =>
                {
                    b.Navigation("ProductsToSell");

                    b.Navigation("ServiceFees");
                });
#pragma warning restore 612, 618
        }
    }
}
