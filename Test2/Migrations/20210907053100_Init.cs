using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserPhone = table.Column<int>(nullable: false),
                    UserBirthday = table.Column<DateTime>(nullable: true),
                    UserPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserCreatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
