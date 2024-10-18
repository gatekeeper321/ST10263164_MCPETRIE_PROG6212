﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ST10263164_MCPETRIE_PROG6212.Data;

#nullable disable

namespace ST10263164_MCPETRIE_PROG6212.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ST10263164_MCPETRIE_PROG6212.Models.AcademicManager", b =>
                {
                    b.Property<int>("AcademicManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicManagerId"));

                    b.Property<string>("AcademicManagerContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicManagerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicManagerPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicManagerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicManagerId");

                    b.ToTable("AcademicManagers");
                });

            modelBuilder.Entity("ST10263164_MCPETRIE_PROG6212.Models.Claim", b =>
                {
                    b.Property<int>("ClaimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimId"));

                    b.Property<int>("ClaimApprovalId")
                        .HasColumnType("int");

                    b.Property<string>("ClaimTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.HasKey("ClaimId");

                    b.ToTable("Claims");
                });

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

            modelBuilder.Entity("ST10263164_MCPETRIE_PROG6212.Models.ProgrammeCoordinator", b =>
                {
                    b.Property<int>("ProgrammeCoordinatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgrammeCoordinatorId"));

                    b.Property<string>("ProgrammeCoordinatorContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammeCoordinatorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammeCoordinatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammeCoordinatorPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammeCoordinatorSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgrammeCoordinatorId");

                    b.ToTable("ProgrammeCoordinators");
                });
#pragma warning restore 612, 618
        }
    }
}
