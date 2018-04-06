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
    [Migration("20180329224418_AddClasses")]
    partial class AddClasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ClassId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassSections");
                });

            modelBuilder.Entity("MySchool.Core.Models.ClassSection", b =>
                {
                    b.HasOne("MySchool.Core.Models.Class")
                        .WithMany("ClassSections")
                        .HasForeignKey("ClassId");
                });
#pragma warning restore 612, 618
        }
    }
}
