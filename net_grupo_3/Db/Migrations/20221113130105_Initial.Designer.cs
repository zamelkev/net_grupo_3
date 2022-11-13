﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_grupo_3.Db;

#nullable disable

namespace net_grupo_3.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221113130105_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("net_grupo_3.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<double>("Cost")
                        .HasColumnType("double")
                        .HasColumnName("Cost");

                    b.Property<string>("Name")
                        .IsRequired()
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

            modelBuilder.Entity("net_grupo_3.Models.ProductComment", b =>
                {
                    b.HasOne("net_grupo_3.Models.Product", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("net_grupo_3.Models.Product", b =>
                {
                    b.Navigation("ProductComments");
                });
#pragma warning restore 612, 618
        }
    }
}