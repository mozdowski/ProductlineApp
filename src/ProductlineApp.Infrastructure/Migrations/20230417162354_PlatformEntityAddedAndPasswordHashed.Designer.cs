﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductlineApp.Infrastructure.Persistance;

#nullable disable

namespace ProductlineApp.Infrastructure.Migrations
{
    [DbContext(typeof(ProductlineDbContext))]
    [Migration("20230417162354_PlatformEntityAddedAndPasswordHashed")]
    partial class PlatformEntityAddedAndPasswordHashed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductlineApp.Infrastructure.Persistance.Entities.Platform.PlatformEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Platform", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b96f52d-fba0-4cdf-a1dc-53ea3eede744"),
                            Name = "ebay",
                            Url = "https://www.ebay.com/"
                        },
                        new
                        {
                            Id = new Guid("6399be07-3338-41b2-8ef0-82c2ce75309b"),
                            Name = "allegro",
                            Url = "https://allegro.pl/"
                        },
                        new
                        {
                            Id = new Guid("c73fc91f-4f1b-414d-b4d4-30850eed0022"),
                            Name = "amazon",
                            Url = "https://amazon.com/"
                        });
                });

            modelBuilder.Entity("ProductlineApp.Infrastructure.Persistance.Entities.User.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ProductlineApp.Infrastructure.Persistance.Entities.User.UserEntity", b =>
                {
                    b.OwnsMany("ProductlineApp.Infrastructure.Persistance.Entities.User.PlatformConnectionEntity", "PlatformConnections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<string>("AccessToken")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("PlatformId")
                                .HasColumnType("uuid");

                            b1.Property<string>("RefreshToken")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("PlatformConnection", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PlatformConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
