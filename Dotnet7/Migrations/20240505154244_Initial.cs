using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnet7.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "kananid44@gmail.com", "Dhaval Kanani", "password" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "info@hjinfotech.com", "HJ Infotech", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
