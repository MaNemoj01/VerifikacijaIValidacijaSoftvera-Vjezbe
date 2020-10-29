﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentskiDom.Models;

namespace StudentskiDom.Migrations
{
    [DbContext(typeof(StudentskiDomContext))]
    [Migration("20200526111158_Bismillah3")]
    partial class Bismillah3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentskiDom.Models.DnevniMeni", b =>
                {
                    b.Property<int>("DnevniMeniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("DnevniMeniId");

                    b.ToTable("DnevniMeni");
                });

            modelBuilder.Entity("StudentskiDom.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestoranId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId1")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestoranId");

                    b.HasIndex("StudentId1");

                    b.ToTable("Korisnik");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Korisnik");
                });

            modelBuilder.Entity("StudentskiDom.Models.Rucak", b =>
                {
                    b.Property<int>("RucakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DnevniMeniId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RucakId");

                    b.HasIndex("DnevniMeniId");

                    b.ToTable("Rucak");
                });

            modelBuilder.Entity("StudentskiDom.Models.Vecera", b =>
                {
                    b.Property<int>("VeceraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DnevniMeniId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VeceraId");

                    b.HasIndex("DnevniMeniId");

                    b.ToTable("Vecera");
                });

            modelBuilder.Entity("StudentskiDom.Models.Restoran", b =>
                {
                    b.HasBaseType("StudentskiDom.Models.Korisnik");

                    b.Property<int>("DnevniMeniId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasIndex("DnevniMeniId")
                        .IsUnique()
                        .HasFilter("[DnevniMeniId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Restoran");
                });

            modelBuilder.Entity("StudentskiDom.Models.Student", b =>
                {
                    b.HasBaseType("StudentskiDom.Models.Korisnik");

                    b.Property<int>("BrojRucaka")
                        .HasColumnType("int");

                    b.Property<int>("BrojVecera")
                        .HasColumnType("int");

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.Property<int>("PrebivalisteInfoId")
                        .HasColumnType("int");

                    b.Property<int>("SkolovanjeInfoId")
                        .HasColumnType("int");

                    b.Property<int>("SobaId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("StudentskiDom.Models.Korisnik", b =>
                {
                    b.HasOne("StudentskiDom.Models.Restoran", "Restoran")
                        .WithMany()
                        .HasForeignKey("RestoranId");

                    b.HasOne("StudentskiDom.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId1");
                });

            modelBuilder.Entity("StudentskiDom.Models.Rucak", b =>
                {
                    b.HasOne("StudentskiDom.Models.DnevniMeni", "DnevniMeni")
                        .WithMany("Rucak")
                        .HasForeignKey("DnevniMeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentskiDom.Models.Vecera", b =>
                {
                    b.HasOne("StudentskiDom.Models.DnevniMeni", "DnevniMeni")
                        .WithMany("Vecera")
                        .HasForeignKey("DnevniMeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentskiDom.Models.Restoran", b =>
                {
                    b.HasOne("StudentskiDom.Models.DnevniMeni", "DnevniMeni")
                        .WithOne("Restoran")
                        .HasForeignKey("StudentskiDom.Models.Restoran", "DnevniMeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
