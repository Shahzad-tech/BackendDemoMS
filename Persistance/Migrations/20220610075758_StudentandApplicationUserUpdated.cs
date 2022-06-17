using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class StudentandApplicationUserUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniRollNo",
                table: "Students",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Students",
                newName: "LastProgram");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "FatherName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "CurrentGPA",
                table: "Students",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "CurrentProgram",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentGPA",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentProgram",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Students",
                newName: "UniRollNo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "LastProgram",
                table: "Students",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "FatherName",
                table: "Students",
                newName: "Email");
        }
    }
}
