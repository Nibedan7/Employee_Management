﻿// <auto-generated />
using System;
using EmployeeCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeCrud.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250312090252_addusertableToDb")]
    partial class addusertableToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeCrud.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "nibedan1@gmail.com",
                            Password = "Nibedan@12",
                            User_name = "nibedan@12"
                        });
                });

            modelBuilder.Entity("EmployeeCrud.Models.Employee.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Joining_date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "IT",
                            Designation = "Software Engineer",
                            Joining_date = new DateOnly(2020, 5, 15),
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Department = "HR",
                            Designation = "HR Manager",
                            Joining_date = new DateOnly(2018, 3, 22),
                            Name = "Jane Smith"
                        },
                        new
                        {
                            Id = 3,
                            Department = "Marketing",
                            Designation = "Marketing Specialist",
                            Joining_date = new DateOnly(2021, 8, 10),
                            Name = "Alice Brown"
                        },
                        new
                        {
                            Id = 4,
                            Department = "Product",
                            Designation = "Product Manager",
                            Joining_date = new DateOnly(2017, 11, 1),
                            Name = "Bob Johnson"
                        },
                        new
                        {
                            Id = 5,
                            Department = "IT",
                            Designation = "QA Engineer",
                            Joining_date = new DateOnly(2019, 6, 30),
                            Name = "Charlie Davis"
                        },
                        new
                        {
                            Id = 6,
                            Department = "Business",
                            Designation = "Business Analyst",
                            Joining_date = new DateOnly(2020, 2, 5),
                            Name = "David Wilson"
                        },
                        new
                        {
                            Id = 7,
                            Department = "Sales",
                            Designation = "Sales Executive",
                            Joining_date = new DateOnly(2022, 7, 20),
                            Name = "Emily Clark"
                        },
                        new
                        {
                            Id = 8,
                            Department = "IT",
                            Designation = "Systems Architect",
                            Joining_date = new DateOnly(2016, 4, 18),
                            Name = "Frank Harris"
                        },
                        new
                        {
                            Id = 9,
                            Department = "Support",
                            Designation = "Customer Support",
                            Joining_date = new DateOnly(2021, 1, 12),
                            Name = "Grace Lewis"
                        },
                        new
                        {
                            Id = 10,
                            Department = "Design",
                            Designation = "UI/UX Designer",
                            Joining_date = new DateOnly(2019, 9, 25),
                            Name = "Henry Walker"
                        });
                });

            modelBuilder.Entity("EmployeeCrud.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "nibedan2@gmail.com",
                            Name = "Nibedan",
                            Password = "Nibe@1000"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
