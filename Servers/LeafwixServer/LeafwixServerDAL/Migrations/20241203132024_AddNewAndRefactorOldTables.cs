using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafwixServerDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAndRefactorOldTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "NotificationSettings");

            migrationBuilder.RenameColumn(
                name: "WateringFrequency",
                table: "PlantSpecies",
                newName: "Watering");

            migrationBuilder.RenameColumn(
                name: "LightRequirements",
                table: "PlantSpecies",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "PlantSpecies",
                newName: "Lighting");

            migrationBuilder.RenameColumn(
                name: "OwnPlantImage",
                table: "Plants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "NotificationSettings",
                newName: "TimeZone");

            migrationBuilder.AddColumn<string>(
                name: "Humidity",
                table: "PlantSpecies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "InterestingFacts",
                table: "PlantSpecies",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "Age",
                table: "Plants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastWatered",
                table: "Plants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "EnableNotifications",
                table: "NotificationSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PlantCareHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareType = table.Column<int>(type: "integer", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCareHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantCareHistories_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PlantSpeciesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantImages_PlantSpecies_PlantSpeciesId",
                        column: x => x.PlantSpeciesId,
                        principalTable: "PlantSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantCareHistories_PlantId",
                table: "PlantCareHistories",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantImages_PlantSpeciesId",
                table: "PlantImages",
                column: "PlantSpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantCareHistories");

            migrationBuilder.DropTable(
                name: "PlantImages");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "PlantSpecies");

            migrationBuilder.DropColumn(
                name: "InterestingFacts",
                table: "PlantSpecies");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "LastWatered",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "EnableNotifications",
                table: "NotificationSettings");

            migrationBuilder.RenameColumn(
                name: "Watering",
                table: "PlantSpecies",
                newName: "WateringFrequency");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "PlantSpecies",
                newName: "LightRequirements");

            migrationBuilder.RenameColumn(
                name: "Lighting",
                table: "PlantSpecies",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plants",
                newName: "OwnPlantImage");

            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "NotificationSettings",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "NotificationSettings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
