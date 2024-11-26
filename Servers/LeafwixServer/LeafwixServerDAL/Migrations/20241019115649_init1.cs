using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafwixServerDAL.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    PreferredNotificationTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantSpecies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WateringFrequency = table.Column<string>(type: "text", nullable: false),
                    LightRequirements = table.Column<string>(type: "text", nullable: false),
                    SoilType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantSpecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantDiseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiseaseName = table.Column<string>(type: "text", nullable: false),
                    Symptoms = table.Column<string>(type: "text", nullable: false),
                    Causes = table.Column<string>(type: "text", nullable: false),
                    Treatment = table.Column<string>(type: "text", nullable: false),
                    Prevention = table.Column<string>(type: "text", nullable: false),
                    PlantSpeciesId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantDiseases_PlantSpecies_PlantSpeciesId",
                        column: x => x.PlantSpeciesId,
                        principalTable: "PlantSpecies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnPlantImage = table.Column<string>(type: "text", nullable: false),
                    PlantSpeciesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_PlantSpecies_PlantSpeciesId",
                        column: x => x.PlantSpeciesId,
                        principalTable: "PlantSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSettings_UserId",
                table: "NotificationSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantDiseases_PlantSpeciesId",
                table: "PlantDiseases",
                column: "PlantSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantSpeciesId",
                table: "Plants",
                column: "PlantSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserId",
                table: "Plants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationSettings");

            migrationBuilder.DropTable(
                name: "PlantDiseases");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "PlantSpecies");
        }
    }
}
