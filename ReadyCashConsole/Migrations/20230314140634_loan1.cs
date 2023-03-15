using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadyCashConsole.Migrations
{
    /// <inheritdoc />
    public partial class loan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Laons",
                table: "Laons");

            migrationBuilder.RenameTable(
                name: "Laons",
                newName: "Loans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loans",
                table: "Loans",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Loans",
                table: "Loans");

            migrationBuilder.RenameTable(
                name: "Loans",
                newName: "Laons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laons",
                table: "Laons",
                column: "Id");
        }
    }
}
