using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagement.data_access.migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WasteBins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FillLevel = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteBins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WasteBinId = table.Column<int>(type: "int", nullable: false),
                    CollectionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteCollections_WasteBins_WasteBinId",
                        column: x => x.WasteBinId,
                        principalTable: "WasteBins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WasteCollections_WasteBinId",
                table: "WasteCollections",
                column: "WasteBinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WasteCollections");

            migrationBuilder.DropTable(
                name: "WasteBins");
        }
    }
}
