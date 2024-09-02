using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migupdatecardescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDescriptions_Cars_CarID",
                table: "CardDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_CardDescriptions_CarID",
                table: "CardDescriptions");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "CardDescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_CardDescriptions_CardID",
                table: "CardDescriptions",
                column: "CardID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDescriptions_Cars_CardID",
                table: "CardDescriptions",
                column: "CardID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDescriptions_Cars_CardID",
                table: "CardDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_CardDescriptions_CardID",
                table: "CardDescriptions");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "CardDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CardDescriptions_CarID",
                table: "CardDescriptions",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDescriptions_Cars_CarID",
                table: "CardDescriptions",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
