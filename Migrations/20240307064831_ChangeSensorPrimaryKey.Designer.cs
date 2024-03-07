﻿// <auto-generated />
using System;
using AquaCare_Web_App.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AquaCare_Web_App.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240307064831_ChangeSensorPrimaryKey")]
    partial class ChangeSensorPrimaryKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AquaCare_Web_App.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Ph")
                        .HasColumnType("decimal(6,4)");

                    b.Property<decimal>("Salinity")
                        .HasColumnType("decimal(10,4)");

                    b.Property<decimal>("SunlightIntensity")
                        .HasColumnType("decimal(10,4)");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(8,4)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Turbidity")
                        .HasColumnType("decimal(8,4)");

                    b.HasKey("Id");

                    b.ToTable("Sensor");
                });
#pragma warning restore 612, 618
        }
    }
}
