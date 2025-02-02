using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infra.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoColunaNovoCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employee");
        }
    }
}
