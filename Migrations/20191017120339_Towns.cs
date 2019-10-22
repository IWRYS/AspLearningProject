using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp.net.LearningProject.Migrations
{
    public partial class Towns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Region = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");
        }
    }
}
