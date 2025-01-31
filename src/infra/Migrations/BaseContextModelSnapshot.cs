﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infra;

#nullable disable

namespace infra.Migrations
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("domain.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessLevel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("AccessLevel");

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Address");

                    b.Property<int>("AddressNumber")
                        .HasColumnType("int")
                        .HasColumnName("AddressNumber");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("City");

                    b.Property<string>("DocumentNumber")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("DocumentNumber");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Email");

                    b.Property<string>("ManagerName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("ManagerName");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Phone");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("State");

                    b.Property<string>("Zip")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Zip");

                    b.HasKey("Id");

                    b.ToTable("Employee", null, t =>
                        {
                            t.Property("BirthDate")
                                .HasColumnName("BirthDate1");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
