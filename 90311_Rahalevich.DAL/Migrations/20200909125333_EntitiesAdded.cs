using Microsoft.EntityFrameworkCore.Migrations;

namespace _90311_Rahalevich.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsulinGroups",
                columns: table => new
                {
                    InsulinGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsulinGroups", x => x.InsulinGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Insulins",
                columns: table => new
                {
                    InsulinId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsulinName = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    InsulinGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insulins", x => x.InsulinId);
                    table.ForeignKey(
                        name: "FK_Insulins_InsulinGroups_InsulinGroupId",
                        column: x => x.InsulinGroupId,
                        principalTable: "InsulinGroups",
                        principalColumn: "InsulinGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insulins_InsulinGroupId",
                table: "Insulins",
                column: "InsulinGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insulins");

            migrationBuilder.DropTable(
                name: "InsulinGroups");
        }
    }
}
