using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS_DBTC_API_v2.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Program",
                table: "Students");
        }
    }
}
