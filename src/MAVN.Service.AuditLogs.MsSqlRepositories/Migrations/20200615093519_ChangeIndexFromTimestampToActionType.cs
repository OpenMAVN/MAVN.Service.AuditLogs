using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Migrations
{
    public partial class ChangeIndexFromTimestampToActionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_audit_logs_timestamp",
                schema: "audit_logs",
                table: "audit_logs");

            migrationBuilder.CreateIndex(
                name: "IX_audit_logs_action_type",
                schema: "audit_logs",
                table: "audit_logs",
                column: "action_type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_audit_logs_action_type",
                schema: "audit_logs",
                table: "audit_logs");

            migrationBuilder.CreateIndex(
                name: "IX_audit_logs_timestamp",
                schema: "audit_logs",
                table: "audit_logs",
                column: "timestamp");
        }
    }
}
