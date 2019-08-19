using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Infrastructure.Data.Migrations
{
    public partial class BoolProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                table: "TestEntities",
                nullable: true,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrue",
                table: "TestEntities");
        }
    }
}
