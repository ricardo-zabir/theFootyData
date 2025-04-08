using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theFootyDataWorkerService.Migrations
{
    /// <inheritdoc />
    public partial class firstInitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matchId = table.Column<int>(type: "int", nullable: true),
                    utcDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matchday = table.Column<int>(type: "int", nullable: true),
                    homeTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    awayTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    halfTimeResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullTimeResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    winner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
