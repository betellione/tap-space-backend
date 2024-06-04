using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class GunsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerLootBoxes",
                table: "PlayerLootBoxes");

            migrationBuilder.DropIndex(
                name: "IX_PlayerLootBoxes_PlayerId",
                table: "PlayerLootBoxes");

            migrationBuilder.DropColumn(
                name: "PlayerLootBoxId",
                table: "PlayerLootBoxes");

            migrationBuilder.RenameColumn(
                name: "OpenSlots",
                table: "Players",
                newName: "OpenLootBoxSlots");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "LootBoxTypes",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "OpenGunSlots",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Achievements",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerLootBoxes",
                table: "PlayerLootBoxes",
                columns: new[] { "PlayerId", "SlotNumber" });

            migrationBuilder.CreateTable(
                name: "GunTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerAchievements",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    AchievementId = table.Column<int>(type: "integer", nullable: false),
                    Progress = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAchievements", x => new { x.PlayerId, x.AchievementId });
                    table.ForeignKey(
                        name: "FK_PlayerAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerAchievements_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGuns",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    SlotNumber = table.Column<int>(type: "integer", nullable: false),
                    GunTypeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGuns", x => new { x.PlayerId, x.SlotNumber });
                    table.ForeignKey(
                        name: "FK_PlayerGun_GunType",
                        column: x => x.GunTypeId,
                        principalTable: "GunTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGuns_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAchievements_AchievementId",
                table: "PlayerAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGuns_GunTypeId",
                table: "PlayerGuns",
                column: "GunTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerAchievements");

            migrationBuilder.DropTable(
                name: "PlayerGuns");

            migrationBuilder.DropTable(
                name: "GunTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerLootBoxes",
                table: "PlayerLootBoxes");

            migrationBuilder.DropColumn(
                name: "OpenGunSlots",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "OpenLootBoxSlots",
                table: "Players",
                newName: "OpenSlots");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LootBoxTypes",
                newName: "TypeName");

            migrationBuilder.AddColumn<int>(
                name: "PlayerLootBoxId",
                table: "PlayerLootBoxes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Achievements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerLootBoxes",
                table: "PlayerLootBoxes",
                column: "PlayerLootBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLootBoxes_PlayerId",
                table: "PlayerLootBoxes",
                column: "PlayerId");
        }
    }
}
