﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductlineApp.Infrastructure.Persistance;

#nullable disable

namespace ProductlineApp.Infrastructure.Migrations
{
    [DbContext(typeof(ProductlineDbContext))]
    partial class ProductlineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.Listing.Listing", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Listings", (string)null);
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.Order.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<decimal>("DeliveryCost")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PlacedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uuid");

                    b.Property<string>("PlatformOrderId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("SubtotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Condition")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<bool>("IsListed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.User.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Platforms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("245115f9-02c1-446d-a265-b27faec8fe7f"),
                            CreatedAt = new DateTime(2023, 7, 20, 10, 12, 46, 564, DateTimeKind.Utc).AddTicks(6150),
                            CreatedBy = "system",
                            LastModified = new DateTime(2023, 7, 20, 10, 12, 46, 706, DateTimeKind.Utc).AddTicks(950),
                            LastModifiedBy = "system",
                            Name = "ebay"
                        },
                        new
                        {
                            Id = new Guid("6caa1f53-524e-4f55-93a5-aa8bf04eb386"),
                            CreatedAt = new DateTime(2023, 7, 20, 10, 12, 46, 564, DateTimeKind.Utc).AddTicks(6170),
                            CreatedBy = "system",
                            LastModified = new DateTime(2023, 7, 20, 10, 12, 46, 706, DateTimeKind.Utc).AddTicks(1020),
                            LastModifiedBy = "system",
                            Name = "allegro"
                        });
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProductlineApp.Infrastructure.Logging.LogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Severity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Logging", (string)null);
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.Listing.Listing", b =>
                {
                    b.OwnsMany("ProductlineApp.Domain.Aggregates.Listing.Entities.ListingInstance", "Instances", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("text");

                            b1.Property<int?>("ExpiresIn")
                                .HasColumnType("integer");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("text");

                            b1.Property<Guid>("ListingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("ListingUrl")
                                .HasMaxLength(500)
                                .HasColumnType("character varying(500)");

                            b1.Property<Guid>("PlatformId")
                                .HasColumnType("uuid");

                            b1.Property<string>("PlatformListingId")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("ListingId");

                            b1.ToTable("ListingInstances", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ListingId");
                        });

                    b.Navigation("Instances");
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.Order.Order", b =>
                {
                    b.OwnsMany("ProductlineApp.Domain.Aggregates.Order.Entities.Document", "Documents", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("varchar(500)")
                                .HasColumnName("DocumentUrl");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId");

                            b1.ToTable("Document");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsMany("ProductlineApp.Domain.Aggregates.Order.Entities.OrderLine", "OrderLines", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("PlatformListingId")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric");

                            b1.Property<int>("Quantity")
                                .HasColumnType("integer");

                            b1.Property<string>("Sku")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderLines", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("ProductlineApp.Domain.Aggregates.Order.ValueObjects.BillingAddress", "BillingAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("character varying(500)")
                                .HasColumnName("BillingAddress_Address");

                            b1.Property<string>("Email")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("BillingAddress_Email");

                            b1.Property<string>("FirstName")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("BillingAddress_Firstname");

                            b1.Property<string>("LastName")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("BillingAddress_Lastname");

                            b1.Property<string>("PhoneNumber")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("BillingAddress_Phone");

                            b1.Property<string>("Username")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("BillingAddress_Username");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("ProductlineApp.Domain.Aggregates.Order.ValueObjects.ShippingAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("character varying(500)")
                                .HasColumnName("ShippingAddress_Address");

                            b1.Property<string>("CompanyName")
                                .HasColumnType("text");

                            b1.Property<string>("FirstName")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("ShippingAddress_Firstname");

                            b1.Property<string>("LastName")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("ShippingAddress_Lastname");

                            b1.Property<string>("PhoneNumber")
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("ShippingAddress_Phone");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("BillingAddress")
                        .IsRequired();

                    b.Navigation("Documents");

                    b.Navigation("OrderLines");

                    b.Navigation("ShippingAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.Products.Product", b =>
                {
                    b.OwnsMany("ProductlineApp.Domain.ValueObjects.Image", "Gallery", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("varchar(800)")
                                .HasColumnName("ImageUrl");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Products_Gallery");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ProductlineApp.Domain.ValueObjects.Image", "Image", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("varchar(800)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ProductlineApp.Domain.Aggregates.Products.ValueObjects.Brand", "Brand", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ProductlineApp.Domain.Aggregates.Products.ValueObjects.Category", "Category", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Brand")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Gallery");

                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.User.User", b =>
                {
                    b.OwnsMany("ProductlineApp.Domain.Aggregates.User.Entities.PlatformConnection", "PlatformConnections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<string>("AccessToken")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("text");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("text");

                            b1.Property<Guid>("PlatformId")
                                .HasColumnType("uuid");

                            b1.Property<string>("RefreshToken")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("RefreshTokenExpirationDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("PlatformConnections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PlatformConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
