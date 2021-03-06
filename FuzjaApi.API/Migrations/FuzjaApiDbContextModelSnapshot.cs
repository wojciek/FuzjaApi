﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using FuzjaApi.Infrastructure;

namespace FuzjaApi.Migrations
{
    [DbContext(typeof(FuzjaApiDbContext))]
    partial class FuzjaApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FuzjaApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarName");

                    b.Property<DateTime>("CarPublicationDate");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("FuzjaApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PersonPublicationDate");

                    b.Property<int>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("FuzjaApi.Models.Car", b =>
                {
                    b.HasOne("FuzjaApi.Models.Person", "Person")
                        .WithOne("Car")
                        .HasForeignKey("FuzjaApi.Models.Car", "PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
