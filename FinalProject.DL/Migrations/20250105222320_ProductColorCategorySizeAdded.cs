using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.DL.Migrations
{
    /// <inheritdoc />
    public partial class ProductColorCategorySizeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseAuditableEntity_AspNetUsers_CreatedById",
                table: "BaseAuditableEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAuditableEntity_AspNetUsers_DeletedById",
                table: "BaseAuditableEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAuditableEntity_AspNetUsers_UpdatedById",
                table: "BaseAuditableEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAuditableEntity_BaseAuditableEntity_CategoryId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAuditableEntity_BaseAuditableEntity_ColorId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAuditableEntity_BaseAuditableEntity_SizeId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseAuditableEntity",
                table: "BaseAuditableEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseAuditableEntity_CategoryId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseAuditableEntity_ColorId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseAuditableEntity_SizeId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Product_Title",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Size_Value",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "BaseAuditableEntity");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BaseAuditableEntity");

            migrationBuilder.RenameTable(
                name: "BaseAuditableEntity",
                newName: "Sizes");

            migrationBuilder.RenameIndex(
                name: "IX_BaseAuditableEntity_UpdatedById",
                table: "Sizes",
                newName: "IX_Sizes_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_BaseAuditableEntity_DeletedById",
                table: "Sizes",
                newName: "IX_Sizes_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_BaseAuditableEntity_CreatedById",
                table: "Sizes",
                newName: "IX_Sizes_CreatedById");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colors_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Colors_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb726cd3-71c1-4b46-9c25-fa7038bd185b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0822c9a7-c415-4b7d-ba26-73743a2df9fc", "AQAAAAIAAYagAAAAELxmMbD/jPQioC1dpV3PEIC9S98i9qbG3iH7ELo4suD6kWwm0i9NFpBBcQUDlbvhiQ==", "086f577c-8971-4946-96db-b58fbfaeffc8" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedById",
                table: "Categories",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_CreatedById",
                table: "Colors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_DeletedById",
                table: "Colors",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_UpdatedById",
                table: "Colors",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedById",
                table: "Products",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedById",
                table: "Products",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_AspNetUsers_CreatedById",
                table: "Sizes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_AspNetUsers_DeletedById",
                table: "Sizes",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_AspNetUsers_UpdatedById",
                table: "Sizes",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_AspNetUsers_CreatedById",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_AspNetUsers_DeletedById",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_AspNetUsers_UpdatedById",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "BaseAuditableEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_UpdatedById",
                table: "BaseAuditableEntity",
                newName: "IX_BaseAuditableEntity_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_DeletedById",
                table: "BaseAuditableEntity",
                newName: "IX_BaseAuditableEntity_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_CreatedById",
                table: "BaseAuditableEntity",
                newName: "IX_BaseAuditableEntity_CreatedById");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "BaseAuditableEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BaseAuditableEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "BaseAuditableEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseAuditableEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "BaseAuditableEntity",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseAuditableEntity",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "BaseAuditableEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BaseAuditableEntity",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Title",
                table: "BaseAuditableEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "BaseAuditableEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size_Value",
                table: "BaseAuditableEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "BaseAuditableEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BaseAuditableEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseAuditableEntity",
                table: "BaseAuditableEntity",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb726cd3-71c1-4b46-9c25-fa7038bd185b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d32e5dd-6d40-4a91-a624-d7b054ed479d", "AQAAAAIAAYagAAAAEN+O1Nyx4f9C8iEVTdiBSHDFNUBB/6rDoKB/DjN7eeKWtaW1Tj2NZWFzAii7buax6A==", "07d2671b-1b3f-426d-9fe8-3de639fe874b" });

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_CategoryId",
                table: "BaseAuditableEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_ColorId",
                table: "BaseAuditableEntity",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_SizeId",
                table: "BaseAuditableEntity",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAuditableEntity_AspNetUsers_CreatedById",
                table: "BaseAuditableEntity",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAuditableEntity_AspNetUsers_DeletedById",
                table: "BaseAuditableEntity",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAuditableEntity_AspNetUsers_UpdatedById",
                table: "BaseAuditableEntity",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAuditableEntity_BaseAuditableEntity_CategoryId",
                table: "BaseAuditableEntity",
                column: "CategoryId",
                principalTable: "BaseAuditableEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAuditableEntity_BaseAuditableEntity_ColorId",
                table: "BaseAuditableEntity",
                column: "ColorId",
                principalTable: "BaseAuditableEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAuditableEntity_BaseAuditableEntity_SizeId",
                table: "BaseAuditableEntity",
                column: "SizeId",
                principalTable: "BaseAuditableEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
