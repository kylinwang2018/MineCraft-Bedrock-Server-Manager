using Microsoft.EntityFrameworkCore.Migrations;

namespace MineCraft_Bedrock_Server_Manager.Data.Migrations
{
    public partial class ChangeNormalizedNameToUpperCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1da344-e5ea-4f87-8ede-b965c136aeb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b40f35c-344c-4ca0-b3d5-62271459a047");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f712ad6-b751-4a6f-98ea-44d6f8df1c1f", "84cfcecd-c7c8-4da4-b063-27d612dbb59b", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2946e71b-1328-4080-89d8-0cdb67a2df89", "306168e6-2804-481f-bb57-bcd8a847c361", "member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2946e71b-1328-4080-89d8-0cdb67a2df89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f712ad6-b751-4a6f-98ea-44d6f8df1c1f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b40f35c-344c-4ca0-b3d5-62271459a047", "3a34740c-401c-446d-9895-542df0972c28", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c1da344-e5ea-4f87-8ede-b965c136aeb4", "d61cc94f-11eb-4568-9c88-a37d3efeeef5", "member", "member" });
        }
    }
}
