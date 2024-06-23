using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KolokwiumPoprawa.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PriceForVisit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PK", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    IdSchedule = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Schedule_PK", x => x.IdSchedule);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_IdSchedule",
                        column: x => x.IdSchedule,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    IdVisit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Visit_PK", x => x.IdVisit);
                    table.ForeignKey(
                        name: "FK_Visits_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Patient_Visit_FK",
                        column: x => x.IdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "FirstName", "LastName", "PriceForVisit", "Specialization" },
                values: new object[,]
                {
                    { 1, "Test", "Test", 123.0, "Tstowa" },
                    { 2, "x", "d", 643.29999999999995, "Neuropatia" },
                    { 3, "Mikołaj", "Nowy", 50.0, "Kardio" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Date", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 23, 20, 43, 42, 465, DateTimeKind.Local).AddTicks(5126), "Ala", "Ma kota" },
                    { 2, new DateTime(2024, 6, 23, 20, 43, 42, 474, DateTimeKind.Local).AddTicks(5635), "Karol", "Karo" },
                    { 3, new DateTime(2024, 6, 23, 20, 43, 42, 474, DateTimeKind.Local).AddTicks(5669), "Kamil", "Bąk" },
                    { 4, new DateTime(2024, 6, 23, 20, 43, 42, 474, DateTimeKind.Local).AddTicks(5683), "Jacob", "Testowski" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "IdSchedule", "DateFrom", "DateTo", "IdDoctor" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 23, 20, 43, 42, 478, DateTimeKind.Local).AddTicks(9207), new DateTime(2024, 6, 23, 20, 43, 42, 478, DateTimeKind.Local).AddTicks(9599), 1 },
                    { 2, new DateTime(2024, 6, 23, 20, 43, 42, 478, DateTimeKind.Local).AddTicks(9936), new DateTime(2024, 6, 23, 20, 43, 42, 478, DateTimeKind.Local).AddTicks(9956), 2 },
                    { 3, new DateTime(2024, 6, 23, 20, 43, 42, 478, DateTimeKind.Local).AddTicks(9970), new DateTime(2024, 6, 23, 20, 43, 42, 478, DateTimeKind.Local).AddTicks(9984), 3 }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "IdVisit", "Date", "IdDoctor", "IdPatient", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 23, 20, 43, 42, 480, DateTimeKind.Local).AddTicks(6106), 1, 1, 123.2 },
                    { 2, new DateTime(2024, 6, 23, 20, 43, 42, 480, DateTimeKind.Local).AddTicks(7346), 2, 2, 150.19999999999999 },
                    { 3, new DateTime(2024, 6, 23, 20, 43, 42, 480, DateTimeKind.Local).AddTicks(7369), 3, 3, 50.200000000000003 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_IdDoctor",
                table: "Visits",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_IdPatient",
                table: "Visits",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
