using Microsoft.EntityFrameworkCore.Migrations;

namespace Scientific_report.Migrations
{
    public partial class _33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Users_Teachers_TeacherId",
                table: "Work_Users");

            migrationBuilder.DropIndex(
                name: "IX_Work_Users_TeacherId",
                table: "Work_Users");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Work_Users");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Users_UserId",
                table: "Work_Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Users_Teachers_UserId",
                table: "Work_Users",
                column: "UserId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Users_Teachers_UserId",
                table: "Work_Users");

            migrationBuilder.DropIndex(
                name: "IX_Work_Users_UserId",
                table: "Work_Users");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Work_Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_Users_TeacherId",
                table: "Work_Users",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Users_Teachers_TeacherId",
                table: "Work_Users",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
