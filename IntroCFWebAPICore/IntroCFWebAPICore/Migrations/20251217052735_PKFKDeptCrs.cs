using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroCFWebAPICore.Migrations
{
    /// <inheritdoc />
    public partial class PKFKDeptCrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptId",
                table: "Courses",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DeptId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Courses");
        }
    }
}
