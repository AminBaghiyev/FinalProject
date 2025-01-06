using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject.DL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8329d499-a035-4462-909b-08852c3eaee0", null, "User", "USER" },
                    { "be2d8e7a-3bc4-462b-83c8-998b57942350", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb726cd3-71c1-4b46-9c25-fa7038bd185b", 0, "4d32e5dd-6d40-4a91-a624-d7b054ed479d", null, false, "Super", "Admin", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEN+O1Nyx4f9C8iEVTdiBSHDFNUBB/6rDoKB/DjN7eeKWtaW1Tj2NZWFzAii7buax6A==", null, false, "07d2671b-1b3f-426d-9fe8-3de639fe874b", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be2d8e7a-3bc4-462b-83c8-998b57942350", "eb726cd3-71c1-4b46-9c25-fa7038bd185b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8329d499-a035-4462-909b-08852c3eaee0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be2d8e7a-3bc4-462b-83c8-998b57942350", "eb726cd3-71c1-4b46-9c25-fa7038bd185b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be2d8e7a-3bc4-462b-83c8-998b57942350");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb726cd3-71c1-4b46-9c25-fa7038bd185b");
        }
    }
}
