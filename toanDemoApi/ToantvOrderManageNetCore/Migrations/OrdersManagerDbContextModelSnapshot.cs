﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToantvOrderManageNetCore.Data;

namespace ToantvOrderManageNetCore.Migrations
{
    [DbContext(typeof(OrdersManagerDbContext))]
    partial class OrdersManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToantvOrderManageNetCore.Data.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnName("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ToantvOrderManageNetCore.Data.Entities.CompanyOrder", b =>
                {
                    b.Property<int>("CompanyOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnName("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comments")
                        .HasColumnName("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalOrderNo")
                        .HasColumnName("ExternalOrderNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalOrderNo")
                        .HasColumnName("InternalOrderNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnName("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendorId")
                        .HasColumnName("VendorId")
                        .HasColumnType("int");

                    b.HasKey("CompanyOrderId");

                    b.HasIndex("VendorId");

                    b.ToTable("CompanyOrder");
                });

            modelBuilder.Entity("ToantvOrderManageNetCore.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderItemId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnName("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnName("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnName("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnName("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("ToantvOrderManageNetCore.Data.Entities.Vendor", b =>
                {
                    b.Property<int>("VenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VenderId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VendorName")
                        .HasColumnName("VendorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VenderId");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("ToantvOrderManageNetCore.Data.Entities.CompanyOrder", b =>
                {
                    b.HasOne("ToantvOrderManageNetCore.Data.Entities.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("ToantvOrderManageNetCore.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("ToantvOrderManageNetCore.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("ToantvOrderManageNetCore.Data.Entities.CompanyOrder", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
