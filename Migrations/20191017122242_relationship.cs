using Microsoft.EntityFrameworkCore.Migrations;

namespace asp.net.LearningProject.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TownId",
                table: "Employees",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TownId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 4, "george@email.com", "George" },
                    { 2, 1, "pesho@email.com", "Pesho" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "Name", "Region" },
                values: new object[,]
                {
                    { 1, "Town1", "Region1" },
                    { 2, "Town3", "Region2" },
                    { 3, "Town3", "Region3" }
                });
        }
    }
}
