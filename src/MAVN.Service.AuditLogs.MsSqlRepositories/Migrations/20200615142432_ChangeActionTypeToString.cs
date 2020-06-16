using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Migrations
{
    public partial class ChangeActionTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "action_type",
                schema: "audit_logs",
                table: "audit_logs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "action_type",
                schema: "audit_logs",
                table: "audit_logs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
