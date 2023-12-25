using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkySelf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForStudentProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "StudentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "StudentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "StudentId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StudentId",
                table: "Products",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Students_StudentId",
                table: "Products",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Students_StudentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StudentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Products");
        }
    }
}
