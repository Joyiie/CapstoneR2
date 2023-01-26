using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneR2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Symptom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConsultationRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsultationRecords_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConsultationRecords_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Findings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationRecordID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Findings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Findings_ConsultationRecords_ConsultationRecordID",
                        column: x => x.ConsultationRecordID,
                        principalTable: "ConsultationRecords",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationRecordID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_ConsultationRecords_ConsultationRecordID",
                        column: x => x.ConsultationRecordID,
                        principalTable: "ConsultationRecords",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "Address", "BirthDate", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[] { new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "Dinalupihan, Orani, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raniel", 1, "Morales", "Adan" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Abbreviation", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), "Pt", "One who receives medical treatment", "patient" },
                    { new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), "Adm", "One who manages the system", "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "Key", "Type", "UserID", "Value" },
                values: new object[,]
                {
                    { new Guid("0397ea8c-1989-46a7-a7f0-e68844a64cf0"), "LoginRetries", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "0" },
                    { new Guid("117c1d19-e163-4b9b-8133-187179ca03e2"), "Password", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "$2a$11$7Zgvm5lr4tHiGzVYBhBLmOMwuziDUfA/tQynKquvKtZJJp19Z2LMu" },
                    { new Guid("695bd3eb-5e0f-4d40-97d7-063bcb7d7417"), "IsActive", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "true" },
                    { new Guid("89d61d48-d60f-40d5-84f1-78ede1202d04"), "LoginRetries", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "0" },
                    { new Guid("c99e0070-91fa-4469-a220-d2f205629b70"), "IsActive", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "true" },
                    { new Guid("ea408e14-cf63-4db5-adaf-7d9b51557d1a"), "Password", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "$2a$11$E148er5gzo1tB6X7QHVoZ.Gb/H0E1Cr6p4ypbOOKVbdGZTAdsQhnK" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "ID", "EndTime", "PatientID", "StartTime", "Symptom" },
                values: new object[] { new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"), new DateTime(2023, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), "Dry Eyes" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "Email", "FirstName", "Gender", "LastName", "MiddleName", "PatientID", "RoleID" },
                values: new object[] { new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janedavid@yahoo.com", "Jane", 0, "David", "Adan", null, new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "Email", "FirstName", "Gender", "LastName", "MiddleName", "PatientID", "RoleID" },
                values: new object[] { new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "renieldavid@yahoo.com", "Reniel", 1, "David", "Adan", new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") });

            migrationBuilder.InsertData(
                table: "ConsultationRecords",
                columns: new[] { "ID", "AppointmentID", "DateCreated", "DateUpdated", "PatientID" },
                values: new object[] { new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"), new DateTime(2022, 1, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[] { new Guid("10c3d4a7-57fa-45d9-9bfa-045b19627b17"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[] { new Guid("c4e4c9b3-e71e-4579-8c39-81c21ee6bfd4"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("7e5e4f74-9902-43da-9974-4b2a08814398") });

            migrationBuilder.InsertData(
                table: "Findings",
                columns: new[] { "ID", "ConsultationRecordID", "Description", "Tags" },
                values: new object[] { new Guid("441d8139-8042-416f-b3cd-ea0d25b9628d"), new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), "sore eyes", "123" });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "ID", "ConsultationRecordID", "Description", "Tags" },
                values: new object[] { new Guid("df4e8a69-63e7-42c1-895c-ca64b71d86d9"), new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), "biogesic", "123" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRecords_AppointmentID",
                table: "ConsultationRecords",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRecords_PatientID",
                table: "ConsultationRecords",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ConsultationRecordID",
                table: "Findings",
                column: "ConsultationRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ConsultationRecordID",
                table: "Prescriptions",
                column: "ConsultationRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PatientID",
                table: "Users",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Findings");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ConsultationRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
