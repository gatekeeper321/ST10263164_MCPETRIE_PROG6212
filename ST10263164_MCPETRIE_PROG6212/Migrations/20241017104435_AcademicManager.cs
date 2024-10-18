using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10263164_MCPETRIE_PROG6212.Migrations
{
    /// <inheritdoc />
    public partial class AcademicManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicManagers",
                columns: table => new
                {
                    AcademicManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicManagerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicManagerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicManagerContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicManagers", x => x.AcademicManagerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicManagers");
        }
    }
}
