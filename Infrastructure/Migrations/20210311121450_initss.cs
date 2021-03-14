using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserForeignKey",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserForeignKey",
                table: "Address",
                column: "UserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserForeignKey",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserForeignKey",
                table: "Address",
                column: "UserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
