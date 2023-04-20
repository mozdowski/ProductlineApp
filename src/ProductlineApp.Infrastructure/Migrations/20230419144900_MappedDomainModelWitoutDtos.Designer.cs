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
    [Migration("20230419144900_MappedDomainModelWitoutDtos")]
    partial class MappedDomainModelWitoutDtos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Platform", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("83feca4c-5193-4557-8157-c209cf7d60e3"),
                            Name = "ebay"
                        },
                        new
                        {
                            Id = new Guid("7da9981e-14fe-44f1-bfc4-1ff877e6c7b2"),
                            Name = "allegro"
                        },
                        new
                        {
                            Id = new Guid("63f5d2f0-882e-40c6-bebc-f21f85ee3f63"),
                            Name = "amazon"
                        });
                });

            modelBuilder.Entity("ProductlineApp.Domain.Aggregates.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Password")
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
