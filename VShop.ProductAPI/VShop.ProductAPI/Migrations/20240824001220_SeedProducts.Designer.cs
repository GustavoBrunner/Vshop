﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VShop.ProductAPI.Context;

#nullable disable

namespace VShop.ProductAPI.Migrations
{
    [DbContext(typeof(ProductApiContext))]
    [Migration("20240824001220_SeedProducts")]
    partial class SeedProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VShop.ProductAPI.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("PK_category_id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = "e6125517-15c7-4615-b8c3-99759bc652bc",
                            CategoryName = "Scholar material"
                        },
                        new
                        {
                            CategoryId = "757b45b1-784a-4ffd-b93c-fe242738696f",
                            CategoryName = "Food"
                        },
                        new
                        {
                            CategoryId = "796477c8-f946-4ea7-b950-4e33d19041ef",
                            CategoryName = "Clothes"
                        });
                });

            modelBuilder.Entity("VShop.ProductAPI.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PK_product_id");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("FK_category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("price");

                    b.Property<long>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(100L)
                        .HasColumnName("stock");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("VShop.ProductAPI.Models.Product", b =>
                {
                    b.HasOne("VShop.ProductAPI.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("VShop.ProductAPI.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
