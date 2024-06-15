using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4._07._23_2_.Migrations
{
    /// <inheritdoc />
    public partial class mig25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_firmas_isSahibis_IsSahibiId",
                table: "firmas");

            migrationBuilder.DropIndex(
                name: "IX_firmas_IsSahibiId",
                table: "firmas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_firmas_IsSahibiId",
                table: "firmas",
                column: "IsSahibiId");

            migrationBuilder.AddForeignKey(
                name: "FK_firmas_isSahibis_IsSahibiId",
                table: "firmas",
                column: "IsSahibiId",
                principalTable: "isSahibis",
                principalColumn: "Id");
        }
    }
}
