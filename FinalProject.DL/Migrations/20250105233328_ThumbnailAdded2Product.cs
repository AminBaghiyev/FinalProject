using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.DL.Migrations
{
    /// <inheritdoc />
    public partial class ThumbnailAdded2Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Products");
        }
    }
}
