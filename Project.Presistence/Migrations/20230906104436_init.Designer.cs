﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Presistence.Context;

namespace Project.Presistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230906104436_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Domain.Entites.Departments.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            InsertTime = new DateTime(2023, 9, 6, 3, 44, 33, 985, DateTimeKind.Local).AddTicks(8814),
                            IsRemoved = false,
                            Name = "اموراداری ",
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            InsertTime = new DateTime(2023, 9, 6, 3, 44, 33, 990, DateTimeKind.Local).AddTicks(7326),
                            IsRemoved = false,
                            Name = "امورانسانی  ",
                            UserId = 2L
                        });
                });

            modelBuilder.Entity("Project.Domain.Entites.Log.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("logs");
                });

            modelBuilder.Entity("Project.Domain.Entites.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "gmail@.com",
                            InsertTime = new DateTime(2023, 9, 6, 3, 44, 33, 990, DateTimeKind.Local).AddTicks(8678),
                            IsRemoved = false,
                            Name = "user1"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "gmail1@.com",
                            InsertTime = new DateTime(2023, 9, 6, 3, 44, 33, 991, DateTimeKind.Local).AddTicks(296),
                            IsRemoved = false,
                            Name = "user2"
                        });
                });

            modelBuilder.Entity("Project.Domain.Entites.Users.Supply", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DeparetmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("departmentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("departmentId");

                    b.ToTable("supplies");
                });

            modelBuilder.Entity("Project.Domain.Entites.Departments.Department", b =>
                {
                    b.HasOne("Project.Domain.Entites.User", "user")
                        .WithMany("department")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Project.Domain.Entites.Users.Supply", b =>
                {
                    b.HasOne("Project.Domain.Entites.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Domain.Entites.Departments.Department", "department")
                        .WithMany()
                        .HasForeignKey("departmentId");

                    b.Navigation("department");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Project.Domain.Entites.User", b =>
                {
                    b.Navigation("department");
                });
#pragma warning restore 612, 618
        }
    }
}