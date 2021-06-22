﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiPA.Web.Data;

namespace SiPA.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210622124353_CompleteDBWRequests")]
    partial class CompleteDBWRequests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiPA.Web.Data.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParishionerId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParishionerId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.Parishioner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FixedPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Parishioners");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("ParishionerId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParishionerId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.Sacrament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParishionerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParishionerId");

                    b.ToTable("Sacraments");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.History", b =>
                {
                    b.HasOne("SiPA.Web.Data.Entities.Parishioner", "Parishioner")
                        .WithMany("Histories")
                        .HasForeignKey("ParishionerId");

                    b.HasOne("SiPA.Web.Data.Entities.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeId");

                    b.Navigation("Parishioner");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.Request", b =>
                {
                    b.HasOne("SiPA.Web.Data.Entities.Parishioner", "Parishioner")
                        .WithMany()
                        .HasForeignKey("ParishionerId");

                    b.HasOne("SiPA.Web.Data.Entities.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeId");

                    b.Navigation("Parishioner");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.Sacrament", b =>
                {
                    b.HasOne("SiPA.Web.Data.Entities.Parishioner", "Parishioner")
                        .WithMany()
                        .HasForeignKey("ParishionerId");

                    b.Navigation("Parishioner");
                });

            modelBuilder.Entity("SiPA.Web.Data.Entities.Parishioner", b =>
                {
                    b.Navigation("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}
