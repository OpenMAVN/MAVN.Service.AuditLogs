using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Migrations
{
    public partial class AddDatePropertyWithIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                schema: "audit_logs",
                table: "audit_logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_audit_logs_date",
                schema: "audit_logs",
                table: "audit_logs",
                column: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_audit_logs_date",
                schema: "audit_logs",
                table: "audit_logs");

            migrationBuilder.DropColumn(
                name: "date",
                schema: "audit_logs",
                table: "audit_logs");
        }
    }
}
