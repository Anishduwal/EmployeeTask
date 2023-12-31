﻿// <auto-generated />
using EmployeeTask.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeTask.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20230609081219_edited nullable middlename")]
    partial class editednullablemiddlename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeTask.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(256)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
