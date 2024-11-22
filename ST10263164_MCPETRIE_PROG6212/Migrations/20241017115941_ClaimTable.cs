/*
 * WILLIAM MCPETRIE
 * ST10263164
 * PROG6212
 * POE PART 3
*/

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10263164_MCPETRIE_PROG6212.Migrations
{
    /// <inheritdoc />
    public partial class ClaimTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SupportingDocuments",
                table: "Claims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportingDocuments",
                table: "Claims");
        }
    }
}
