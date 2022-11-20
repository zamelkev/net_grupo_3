﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_grupo_3.Db;

#nullable disable

namespace net_grupo_3.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("net_grupo_3.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("net_grupo_3.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_client")
                        .HasColumnOrder(0);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasColumnName("client_name")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("client");
                });

            modelBuilder.Entity("net_grupo_3.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal>("Depth")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("Height")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("height");

                    b.Property<decimal?>("Volume")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("volume");

                    b.Property<decimal>("Width")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.ToTable("container");
                });

            modelBuilder.Entity("net_grupo_3.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("FoundationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("foundation_date");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("manufacturer");
                });

            modelBuilder.Entity("net_grupo_3.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("order_date");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("net_grupo_3.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CPU")
                        .HasColumnType("longtext")
                        .HasColumnName("cpu");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ContainerId")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("double")
                        .HasColumnName("Cost");

                    b.Property<string>("GraphicCard")
                        .HasColumnType("longtext")
                        .HasColumnName("graphiccard");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<string>("Ram")
                        .HasColumnType("longtext")
                        .HasColumnName("ram");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<double>("Tax")
                        .HasColumnType("double")
                        .HasColumnName("tax");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ContainerId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ShopId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("net_grupo_3.Models.ProductComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .HasColumnType("longtext")
                        .HasColumnName("body");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("post_date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_comment");
                });

            modelBuilder.Entity("net_grupo_3.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("foundation_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("shop");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("net_grupo_3.Models.Order", b =>
                {
                    b.HasOne("net_grupo_3.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("net_grupo_3.Models.Product", b =>
                {
                    b.HasOne("net_grupo_3.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("net_grupo_3.Models.Container", "Container")
                        .WithMany("Products")
                        .HasForeignKey("ContainerId");

                    b.HasOne("net_grupo_3.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("net_grupo_3.Models.Shop", null)
                        .WithMany("Products")
                        .HasForeignKey("ShopId");

                    b.Navigation("Category");

                    b.Navigation("Container");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("net_grupo_3.Models.ProductComment", b =>
                {
                    b.HasOne("net_grupo_3.Models.Product", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("net_grupo_3.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("net_grupo_3.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("net_grupo_3.Models.Container", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("net_grupo_3.Models.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("net_grupo_3.Models.Product", b =>
                {
                    b.Navigation("ProductComments");
                });

            modelBuilder.Entity("net_grupo_3.Models.Shop", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
