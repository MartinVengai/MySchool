﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MySchool.Persistence;
using System;

namespace MySchool.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MySchool.Core.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("MySchool.Core.Models.ClassSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassSections");
                });

            modelBuilder.Entity("MySchool.Core.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("MySchool.Core.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassSectionId");

                    b.Property<DateTime>("DateEnrolled");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .HasMaxLength(255);

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.HasIndex("ClassSectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MySchool.Core.Models.ClassSection", b =>
                {
                    b.HasOne("MySchool.Core.Models.Class", "Class")
                        .WithMany("ClassSections")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MySchool.Core.Models.Photo", b =>
                {
                    b.HasOne("MySchool.Core.Models.Student")
                        .WithMany("Photos")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("MySchool.Core.Models.Student", b =>
                {
                    b.HasOne("MySchool.Core.Models.ClassSection", "ClassSection")
                        .WithMany()
                        .HasForeignKey("ClassSectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MySchool.Core.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("StudentId");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(255);

                            b1.Property<string>("Country")
                                .HasMaxLength(255);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(255);

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasMaxLength(10);

                            b1.ToTable("Students");

                            b1.HasOne("MySchool.Core.Models.Student")
                                .WithOne("Address")
                                .HasForeignKey("MySchool.Core.Models.Address", "StudentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
