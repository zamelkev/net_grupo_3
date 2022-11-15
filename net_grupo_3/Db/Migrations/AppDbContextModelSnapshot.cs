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
                        .HasColumnName("id_category")
                        .HasColumnOrder(0);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasColumnName("category_name")
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

                    b.Property<double>("Depth")
                        .HasColumnType("double")
                        .HasColumnName("depth");

                    b.Property<double>("Height")
                        .HasColumnType("double")
                        .HasColumnName("height");

                    b.Property<double?>("Volume")
                        .HasColumnType("double")
                        .HasColumnName("volume");

                    b.Property<double>("Width")
                        .HasColumnType("double")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.ToTable("container");
                });

            modelBuilder.Entity("net_grupo_3.Models.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Manufacture");
                });

            modelBuilder.Entity("net_grupo_3.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime(6)");

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

                    b.Property<int?>("ContainerId")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("double")
                        .HasColumnName("Cost");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<double>("Tax")
                        .HasColumnType("double")
                        .HasColumnName("tax");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("net_grupo_3.Models.ProductComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductComments");
                });

            modelBuilder.Entity("net_grupo_3.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Shop");
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
                    b.HasOne("net_grupo_3.Models.Container", null)
                        .WithMany("Products")
                        .HasForeignKey("ContainerId");
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

            modelBuilder.Entity("net_grupo_3.Models.Container", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("net_grupo_3.Models.Product", b =>
                {
                    b.Navigation("ProductComments");
                });
#pragma warning restore 612, 618
        }
    }
}
