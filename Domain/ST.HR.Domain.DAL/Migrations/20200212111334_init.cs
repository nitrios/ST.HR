using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ST.HR.Domain.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(nullable: true),
                    EmploymentDate = table.Column<DateTime>(nullable: false),
                    Group = table.Column<int>(nullable: false),
                    BaseSalaryRate = table.Column<double>(nullable: false),
                    HeadId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Administrator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryRules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearPremium = table.Column<double>(nullable: false),
                    YearPremiumMax = table.Column<double>(nullable: false),
                    SubordinatePremium = table.Column<double>(nullable: false),
                    SubordinateLevelMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryRules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 1L, true, 50.100000000000001, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Administrator", 2, 0L, "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", "Admin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 2L, false, 10.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "User U. A.", 2, 0L, "F6E0A1E2AC41945A9AA7FF8A8AAA0CEBC12A3BCC981A929AD5CF810A090E11AE", "user1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 3L, false, 20.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "User GU. GA.", 1, 2L, "9B871512327C09CE91DD649B3F96A63B7408EF267C8CC5710114E629730CB61F", "user2" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 4L, false, 20.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "User RU. RA.", 1, 2L, "556D7DC3A115356350F1F9910B1AF1AB0E312D4B3E4FC788D2DA63668F36D017", "user3" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 5L, false, 10.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "User With Sub Employees", 2, 2L, "3538A1EF2E113DA64249EEA7BD068B585EC7CE5DF73B2D1E319D8C9BF47EB314", "user4" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 6L, false, 10.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Sub SUB Employees", 1, 5L, "91A73FD806AB2C005C13B4DC19130A884E909DEA3F72D46E30266FE1A1F588D8", "user5" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 7L, false, 25.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Salesman Man Sales", 3, 0L, "C7E616822F366FB1B5E0756AF498CC11D2C0862EDCB32CA65882F622FF39DE1B", "user6" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 8L, false, 25.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Salesman Sub Man Sales", 3, 7L, "C7E616822F366FB1B5E0756AF498CC11D2C0862EDCB32CA65882F622FF39DE1B", "user6" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Administrator", "BaseSalaryRate", "EmploymentDate", "FullName", "Group", "HeadId", "PasswordHash", "UserName" },
                values: new object[] { 9L, false, 25.0, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Salesman Sub Man Sales", 3, 8L, "EAF89DB7108470DC3F6B23EA90618264B3E8F8B6145371667C4055E9C5CE9F52", "user7" });

            migrationBuilder.InsertData(
                table: "SalaryRules",
                columns: new[] { "Id", "SubordinateLevelMax", "SubordinatePremium", "YearPremium", "YearPremiumMax" },
                values: new object[] { 1L, 0, 0.0, 3.0, 30.0 });

            migrationBuilder.InsertData(
                table: "SalaryRules",
                columns: new[] { "Id", "SubordinateLevelMax", "SubordinatePremium", "YearPremium", "YearPremiumMax" },
                values: new object[] { 2L, 1, 0.5, 5.0, 40.0 });

            migrationBuilder.InsertData(
                table: "SalaryRules",
                columns: new[] { "Id", "SubordinateLevelMax", "SubordinatePremium", "YearPremium", "YearPremiumMax" },
                values: new object[] { 3L, -1, 0.29999999999999999, 1.0, 35.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SalaryRules");
        }
    }
}
