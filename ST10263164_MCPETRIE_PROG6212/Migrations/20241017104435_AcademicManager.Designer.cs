﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ST10263164_MCPETRIE_PROG6212.Data;

#nullable disable

namespace ST10263164_MCPETRIE_PROG6212.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241017104435_AcademicManager")]
    partial class AcademicManager
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ST10263164_MCPETRIE_PROG6212.Models.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LecturerId"));

                    b.Property<string>("LecturerContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LecturerId");

                    b.ToTable("Lecturers");
                });
#pragma warning restore 612, 618
        }
    }
}
