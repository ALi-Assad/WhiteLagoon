using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAllTablesAndSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_Date", "Descreption", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "Updated_Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5928), "A beautiful villa with a stunning sunset view.", "https://placehold.co/600x401", "Sunset Villa", 4, 250.0, 1500, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5943) },
                    { 2, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5947), "A cozy retreat in the mountains.", "https://placehold.co/600x401", "Mountain Retreat", 6, 300.0, 2000, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5948) },
                    { 3, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5950), "A charming bungalow right on the beach.", "https://placehold.co/600x401", "Beachfront Bungalow", 5, 400.0, 1800, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5951) },
                    { 4, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5954), "A modern loft with a view of the city lights.", "https://placehold.co/600x401", "City Lights Loft", 3, 350.0, 1200, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5954) },
                    { 5, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5957), "A quaint cottage in the countryside.", "https://placehold.co/600x401", "Countryside Cottage", 4, 200.0, 1400, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5957) },
                    { 6, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5960), "A luxurious lodge with a view of the lake.", "https://placehold.co/600x401", "Lakeview Lodge", 8, 450.0, 2200, new DateTime(2024, 10, 1, 13, 51, 47, 829, DateTimeKind.Local).AddTicks(5961) }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "Hotel With pool", "Hotel", 1 },
                    { 2, "School with bus", "School", 2 },
                    { 3, "football field", "Football field", 3 }
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 203, null, 2 },
                    { 301, null, 3 },
                    { 302, null, 3 },
                    { 303, null, 3 },
                    { 401, null, 4 },
                    { 402, null, 4 },
                    { 403, null, 4 },
                    { 501, null, 5 },
                    { 502, null, 5 },
                    { 503, null, 5 },
                    { 601, null, 6 },
                    { 602, null, 6 },
                    { 603, null, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
