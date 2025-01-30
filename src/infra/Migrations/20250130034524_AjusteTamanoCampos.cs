using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTamanoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Employee",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Employee",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employee",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerName",
                table: "Employee",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "Employee",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employee",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employee",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerName",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employee",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
