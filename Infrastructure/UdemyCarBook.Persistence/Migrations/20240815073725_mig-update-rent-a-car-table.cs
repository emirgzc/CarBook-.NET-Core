using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migupdaterentacartable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_LocationID",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "RentACars");

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_PickUpLocationID",
                table: "RentACars",
                column: "PickUpLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationID",
                table: "RentACars",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationID",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_PickUpLocationID",
                table: "RentACars");

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_LocationID",
                table: "RentACars",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
