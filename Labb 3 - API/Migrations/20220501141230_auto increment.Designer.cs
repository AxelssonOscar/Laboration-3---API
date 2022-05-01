﻿// <auto-generated />
using System;
using Labb_3___API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb_3___API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220501141230_auto increment")]
    partial class autoincrement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb_3___API.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The importance of low level programming.",
                            PersonId = 1,
                            Title = "Programming in C++"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The flexibility of a more modern language",
                            PersonId = 1,
                            Title = "Programmering in C#"
                        });
                });

            modelBuilder.Entity("Labb_3___API.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InterestId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestId = 1,
                            PersonId = 1,
                            WebsiteLink = "https://en.wikipedia.org/wiki/C%2B%2B"
                        },
                        new
                        {
                            Id = 2,
                            InterestId = 2,
                            PersonId = 1,
                            WebsiteLink = "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)"
                        });
                });

            modelBuilder.Entity("Labb_3___API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adam",
                            PhoneNumber = "123"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bertil",
                            PhoneNumber = "456"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ceasar",
                            PhoneNumber = "789"
                        });
                });

            modelBuilder.Entity("Labb_3___API.Models.Interest", b =>
                {
                    b.HasOne("Labb_3___API.Models.Person", "Person")
                        .WithMany("Interests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb_3___API.Models.Link", b =>
                {
                    b.HasOne("Labb_3___API.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId");

                    b.HasOne("Labb_3___API.Models.Person", "Person")
                        .WithMany("Links")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
