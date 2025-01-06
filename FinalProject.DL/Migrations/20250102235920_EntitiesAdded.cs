using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.DL.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseAuditableEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: true),
                    Product_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Size_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAuditableEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAuditableEntity_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseAuditableEntity_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseAuditableEntity_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseAuditableEntity_BaseAuditableEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BaseAuditableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseAuditableEntity_BaseAuditableEntity_ColorId",
                        column: x => x.ColorId,
                        principalTable: "BaseAuditableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseAuditableEntity_BaseAuditableEntity_SizeId",
                        column: x => x.SizeId,
                        principalTable: "BaseAuditableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_CategoryId",
                table: "BaseAuditableEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_ColorId",
                table: "BaseAuditableEntity",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_CreatedById",
                table: "BaseAuditableEntity",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_DeletedById",
                table: "BaseAuditableEntity",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_SizeId",
                table: "BaseAuditableEntity",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAuditableEntity_UpdatedById",
                table: "BaseAuditableEntity",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseAuditableEntity");
        }
    }
}
