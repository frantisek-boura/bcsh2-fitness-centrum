using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class bcrypt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordMD5",
                table: "Users",
                newName: "PasswordBcrypt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordBcrypt",
                table: "Users",
                newName: "PasswordMD5");
        }
    }
}
