﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeminarskiTemp1.EF;

namespace SeminarskiTemp1.Migrations
{
    [DbContext(typeof(MojDBContext))]
    [Migration("20201210124516_stanovanje")]
    partial class stanovanje
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Fakultet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Fakultets");
                });

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Opstina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Opstinas");
                });

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Soba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrojKreveta")
                        .HasColumnType("int");

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Sobas");
                });

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Stanovanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AkademskaGodina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sobaID")
                        .HasColumnType("int");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("sobaID");

                    b.HasIndex("studentID");

                    b.ToTable("Stanovanjes");
                });

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BrojIndeksa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatumRodjenja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FakultetID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FakultetID");

                    b.HasIndex("OpstinaID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Stanovanje", b =>
                {
                    b.HasOne("SeminarskiTemp1.EntityModels.Soba", "soba")
                        .WithMany()
                        .HasForeignKey("sobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiTemp1.EntityModels.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("soba");

                    b.Navigation("student");
                });

            modelBuilder.Entity("SeminarskiTemp1.EntityModels.Student", b =>
                {
                    b.HasOne("SeminarskiTemp1.EntityModels.Fakultet", "Fakultet")
                        .WithMany()
                        .HasForeignKey("FakultetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiTemp1.EntityModels.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fakultet");

                    b.Navigation("Opstina");
                });
#pragma warning restore 612, 618
        }
    }
}