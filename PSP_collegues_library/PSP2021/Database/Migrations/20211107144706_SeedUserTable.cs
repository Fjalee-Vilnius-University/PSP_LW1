using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SeedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber", "Surname" },
                values: new object[] { 1, "TestADress1", "TestEmail1@gmail.com", "TestName1", "TestPassword1.", "+37061111111", "TestSurame1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber", "Surname" },
                values: new object[] { 2, "TestADress2", "TestEmail2@gmail.com", "TestName2", "TestPassword2.", "+37062222222", "TestSurame2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber", "Surname" },
                values: new object[] { 3, "TestADress3", "TestEmail3@gmail.com", "TestName3", "TestPassword3.", "+37063333333", "TestSurame3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
