using Microsoft.EntityFrameworkCore.Migrations;

namespace MineCraft_Bedrock_Server_Manager.Data.Migrations
{
    public partial class SeedRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b40f35c-344c-4ca0-b3d5-62271459a047", "3a34740c-401c-446d-9895-542df0972c28", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c1da344-e5ea-4f87-8ede-b965c136aeb4", "d61cc94f-11eb-4568-9c88-a37d3efeeef5", "member", "member" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1da344-e5ea-4f87-8ede-b965c136aeb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b40f35c-344c-4ca0-b3d5-62271459a047");
        }
    }
}
