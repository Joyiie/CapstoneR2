﻿// <auto-generated />
using System;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CapstoneR2.Migrations
{
    [DbContext(typeof(DefaultDBContext))]
    [Migration("20230126165950_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Appointment", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("PatientID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Symptom")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            ID = new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"),
                            EndTime = new DateTime(2023, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientID = new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                            StartTime = new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            Symptom = "Dry Eyes"
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.ConsultationRecord", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AppointmentID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("PatientID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentID");

                    b.HasIndex("PatientID");

                    b.ToTable("ConsultationRecords");

                    b.HasData(
                        new
                        {
                            ID = new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                            AppointmentID = new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"),
                            DateCreated = new DateTime(2022, 1, 7, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(2022, 1, 7, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            PatientID = new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a")
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Finding", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ConsultationRecordID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ConsultationRecordID");

                    b.ToTable("Findings");

                    b.HasData(
                        new
                        {
                            ID = new Guid("441d8139-8042-416f-b3cd-ea0d25b9628d"),
                            ConsultationRecordID = new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                            Description = "sore eyes",
                            Tags = "123"
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Patient", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            ID = new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                            Address = "Dinalupihan, Orani, Bataan",
                            BirthDate = new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Raniel",
                            Gender = 1,
                            LastName = "Morales",
                            MiddleName = "Adan"
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Prescription", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ConsultationRecordID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ConsultationRecordID");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            ID = new Guid("df4e8a69-63e7-42c1-895c-ca64b71d86d9"),
                            ConsultationRecordID = new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                            Description = "biogesic",
                            Tags = "123"
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Role", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                            Abbreviation = "Pt",
                            Description = "One who receives medical treatment",
                            Name = "patient"
                        },
                        new
                        {
                            ID = new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"),
                            Abbreviation = "Adm",
                            Description = "One who manages the system",
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.User", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("PatientID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("RoleID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"),
                            Address = "Dinalupihan, Orani, Bataan",
                            BirthDate = new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "renieldavid@yahoo.com",
                            FirstName = "Reniel",
                            Gender = 1,
                            LastName = "David",
                            MiddleName = "Adan",
                            PatientID = new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                            RoleID = new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a")
                        },
                        new
                        {
                            ID = new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                            Address = "Dinalupihan, Orani , Bataan",
                            BirthDate = new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Janedavid@yahoo.com",
                            FirstName = "Jane",
                            Gender = 0,
                            LastName = "David",
                            MiddleName = "Adan",
                            RoleID = new Guid("54f00f70-72b8-4d34-a953-83321ff6b101")
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.UserLogin", b =>
                {
                    b.Property<Guid?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Key")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("UserLogins");

                    b.HasData(
                        new
                        {
                            ID = new Guid("117c1d19-e163-4b9b-8133-187179ca03e2"),
                            Key = "Password",
                            Type = "General",
                            UserID = new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                            Value = "$2a$11$7Zgvm5lr4tHiGzVYBhBLmOMwuziDUfA/tQynKquvKtZJJp19Z2LMu"
                        },
                        new
                        {
                            ID = new Guid("c99e0070-91fa-4469-a220-d2f205629b70"),
                            Key = "IsActive",
                            Type = "General",
                            UserID = new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                            Value = "true"
                        },
                        new
                        {
                            ID = new Guid("0397ea8c-1989-46a7-a7f0-e68844a64cf0"),
                            Key = "LoginRetries",
                            Type = "General",
                            UserID = new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                            Value = "0"
                        },
                        new
                        {
                            ID = new Guid("ea408e14-cf63-4db5-adaf-7d9b51557d1a"),
                            Key = "Password",
                            Type = "General",
                            UserID = new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"),
                            Value = "$2a$11$E148er5gzo1tB6X7QHVoZ.Gb/H0E1Cr6p4ypbOOKVbdGZTAdsQhnK"
                        },
                        new
                        {
                            ID = new Guid("695bd3eb-5e0f-4d40-97d7-063bcb7d7417"),
                            Key = "IsActive",
                            Type = "General",
                            UserID = new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"),
                            Value = "true"
                        },
                        new
                        {
                            ID = new Guid("89d61d48-d60f-40d5-84f1-78ede1202d04"),
                            Key = "LoginRetries",
                            Type = "General",
                            UserID = new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"),
                            Value = "0"
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.UserRole", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("RoleID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4e4c9b3-e71e-4579-8c39-81c21ee6bfd4"),
                            RoleID = new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                            UserID = new Guid("7e5e4f74-9902-43da-9974-4b2a08814398")
                        },
                        new
                        {
                            Id = new Guid("10c3d4a7-57fa-45d9-9bfa-045b19627b17"),
                            RoleID = new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"),
                            UserID = new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4")
                        });
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Appointment", b =>
                {
                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.ConsultationRecord", b =>
                {
                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentID");

                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.Navigation("Appointment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Finding", b =>
                {
                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.ConsultationRecord", "Consultation")
                        .WithMany()
                        .HasForeignKey("ConsultationRecordID");

                    b.Navigation("Consultation");
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.Prescription", b =>
                {
                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.ConsultationRecord", "Consultation")
                        .WithMany()
                        .HasForeignKey("ConsultationRecordID");

                    b.Navigation("Consultation");
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.User", b =>
                {
                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("Patient");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CapstoneR2.Infrastructure.Domain.Models.UserRole", b =>
                {
                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.HasOne("CapstoneR2.Infrastructure.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}