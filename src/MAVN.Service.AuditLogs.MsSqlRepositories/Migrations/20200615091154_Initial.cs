using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "audit_logs");

            migrationBuilder.CreateTable(
                name: "audit_logs",
                schema: "audit_logs",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_user_id = table.Column<Guid>(nullable: false),
                    action_context = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false),
                    action_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit_logs", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_audit_logs_admin_user_id",
                schema: "audit_logs",
                table: "audit_logs",
                column: "admin_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_audit_logs_timestamp",
                schema: "audit_logs",
                table: "audit_logs",
                column: "timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_logs",
                schema: "audit_logs");
        }
    }
}
