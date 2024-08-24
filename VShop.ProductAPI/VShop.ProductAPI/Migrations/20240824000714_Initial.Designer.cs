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
    [Migration("20240824000714_Initial")]
    partial class Initial
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
                            CategoryId = "7e054430-8cd7-4615-9b46-545ad98faf55",
                            CategoryName = "Scholar material"
                        },
                        new
                        {
                            CategoryId = "3255b7f7-ec73-4911-8429-69f8dac47872",
                            CategoryName = "Food"
                        },
                        new
                        {
                            CategoryId = "dcb1eea1-34f2-4043-b6c4-d3f53ea78b79",
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
