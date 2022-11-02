﻿// <auto-generated />
using System;
using Distributed_Caching.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Distributed_Caching.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Distributed_Caching.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EmployeeId"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1L,
                            DateOfBirth = new DateTime(1375, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "MisterDeveloper@yahoo.com",
                            FirstName = "Hassan",
                            LastName = "Jalali",
                            PhoneNumber = "0901615****"
                        },
                        new
                        {
                            EmployeeId = 2L,
                            DateOfBirth = new DateTime(1369, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "AliSalempanah@yahoo.com",
                            FirstName = "Ali",
                            LastName = "Salempanah",
                            PhoneNumber = "0935928****"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
