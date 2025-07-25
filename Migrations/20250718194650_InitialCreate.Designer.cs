﻿// <auto-generated />
using System;
using AppRoma.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace app_roma.Migrations
{
    [DbContext(typeof(AppRomaDbContext))]
    [Migration("20250718194650_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppRoma.Models.Like", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Liked")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("AppRoma.Models.Profile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("LikeProfile", b =>
                {
                    b.Property<Guid>("LikesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfilesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LikesID", "ProfilesID");

                    b.HasIndex("ProfilesID");

                    b.ToTable("LikeProfile", (string)null);
                });

            modelBuilder.Entity("LikeProfile", b =>
                {
                    b.HasOne("AppRoma.Models.Like", null)
                        .WithMany()
                        .HasForeignKey("LikesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppRoma.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
