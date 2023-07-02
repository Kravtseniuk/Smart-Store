using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAttributeToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_Products_ProductId",
                table: "ProductAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute");

            migrationBuilder.RenameTable(
                name: "ProductAttribute",
                newName: "ProductAttributes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttribute_ProductId",
                table: "ProductAttributes",
                newName: "IX_ProductAttributes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes");

            migrationBuilder.RenameTable(
                name: "ProductAttributes",
                newName: "ProductAttribute");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttribute",
                newName: "IX_ProductAttribute_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_Products_ProductId",
                table: "ProductAttribute",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
