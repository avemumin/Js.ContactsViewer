﻿// <auto-generated />
using System;
using Js.ContactsViewer.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Js.ContactsViewer.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230906200859_InitialMig")]
    partial class InitialMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Js.ContactsViewer.Shared.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryDescription = "wszystko zwiazane z biznesem",
                            CategoryName = "Business",
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(426)
                        },
                        new
                        {
                            Id = 2,
                            CategoryDescription = "Twoje prywaty",
                            CategoryName = "Private",
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(428)
                        },
                        new
                        {
                            Id = 3,
                            CategoryDescription = "Gdy wybrane można utworzyć swoje widzi mi się",
                            CategoryName = "Inne",
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(430)
                        });
                });

            modelBuilder.Entity("Js.ContactsViewer.Shared.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("date");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(1983, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(443),
                            CategoryId = 1,
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(439),
                            Email = "john.doe@kukuryku.pl",
                            LastName = "Doe",
                            Name = "John",
                            Password = "1234",
                            Phone = "12345678",
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDay = new DateTime(1981, 6, 15, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(452),
                            CategoryId = 1,
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(450),
                            Email = "sabinka.doe@kukuryku.pl",
                            LastName = "Doe",
                            Name = "Sabina",
                            Password = "sabina",
                            Phone = "22233344",
                            SubCategoryId = 2
                        });
                });

            modelBuilder.Entity("Js.ContactsViewer.Shared.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsManualyEditAvail")
                        .HasColumnType("bit");

                    b.Property<string>("SubCatDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SubCatName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(273),
                            IsManualyEditAvail = false,
                            SubCatDescription = "Szef i wsio co z nim zwiazane",
                            SubCatName = "Szef"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2023, 9, 6, 22, 8, 59, 481, DateTimeKind.Local).AddTicks(329),
                            IsManualyEditAvail = false,
                            SubCatDescription = "Co tam klient chciał",
                            SubCatName = "Klient"
                        });
                });

            modelBuilder.Entity("Js.ContactsViewer.Shared.Models.Contact", b =>
                {
                    b.HasOne("Js.ContactsViewer.Shared.Models.Category", "Category")
                        .WithMany("Contacts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Js.ContactsViewer.Shared.Models.SubCategory", "SubCategory")
                        .WithMany("Contacts")
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Js.ContactsViewer.Shared.Models.Category", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Js.ContactsViewer.Shared.Models.SubCategory", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
