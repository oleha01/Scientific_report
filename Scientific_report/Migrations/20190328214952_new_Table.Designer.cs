﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scientific_report.Models;

namespace Scientific_report.Migrations
{
    [DbContext(typeof(AppReportContext))]
    [Migration("20190328214952_new_Table")]
    partial class new_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scientific_report.Models.Cafedra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultetId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FacultetId");

                    b.ToTable("Cafedras");
                });

            modelBuilder.Entity("Scientific_report.Models.Facultet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Facultets");
                });

            modelBuilder.Entity("Scientific_report.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Academic_status");

                    b.Property<int>("CafedraId");

                    b.Property<string>("Chair");

                    b.Property<string>("Degree");

                    b.Property<string>("Name");

                    b.Property<string>("Patronymic");

                    b.Property<string>("Position");

                    b.Property<string>("SurName");

                    b.Property<int>("Year_of_Assignment");

                    b.Property<int>("Year_of_birth");

                    b.Property<int>("Year_of_graduation");

                    b.Property<int>("year_of_Protection");

                    b.HasKey("Id");

                    b.HasIndex("CafedraId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Scientific_report.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Status");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Scientific_report.Models.Work_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TeacherId");

                    b.Property<int>("UserId");

                    b.Property<int>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("WorkId");

                    b.ToTable("Work_Users");
                });

            modelBuilder.Entity("Scientific_report.Models.WorkEnum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkEnums");
                });

            modelBuilder.Entity("Scientific_report.Models.Cafedra", b =>
                {
                    b.HasOne("Scientific_report.Models.Facultet", "Facultet")
                        .WithMany()
                        .HasForeignKey("FacultetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Scientific_report.Models.Teacher", b =>
                {
                    b.HasOne("Scientific_report.Models.Cafedra", "Cafedra")
                        .WithMany()
                        .HasForeignKey("CafedraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Scientific_report.Models.Work", b =>
                {
                    b.HasOne("Scientific_report.Models.WorkEnum", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Scientific_report.Models.Work_User", b =>
                {
                    b.HasOne("Scientific_report.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("Scientific_report.Models.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
