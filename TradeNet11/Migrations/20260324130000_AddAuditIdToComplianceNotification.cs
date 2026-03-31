using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeNet11.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditIdToComplianceNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditId",
                table: "ComplianceNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceNotifications_AuditId",
                table: "ComplianceNotifications",
                column: "AuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceNotifications_Audits_AuditId",
                table: "ComplianceNotifications",
                column: "AuditId",
                principalTable: "Audits",
                principalColumn: "Id");

            migrationBuilder.UpdateData(
                table: "ComplianceNotifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "AuditId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplianceNotifications_Audits_AuditId",
                table: "ComplianceNotifications");

            migrationBuilder.DropIndex(
                name: "IX_ComplianceNotifications_AuditId",
                table: "ComplianceNotifications");

            migrationBuilder.DropColumn(
                name: "AuditId",
                table: "ComplianceNotifications");
        }
    }
}
