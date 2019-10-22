using Microsoft.EntityFrameworkCore.Migrations;

namespace asp.net.LearningProject.Migrations
{
    public partial class relationshipAndseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "TownId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "Name", "Region" },
                values: new object[] { 1, "Town1", "Region1" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "Name", "Region" },
                values: new object[] { 2, "Town3", "Region2" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "Name", "Region" },
                values: new object[] { 3, "Town3", "Region3" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Department", "Email", "Name", "TownId" },
                values: new object[] { 2, 1, "pesho@email.com", "Pesho", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Department", "Email", "Name", "TownId" },
                values: new object[] { 1, 4, "george@email.com", "George", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "TownId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
