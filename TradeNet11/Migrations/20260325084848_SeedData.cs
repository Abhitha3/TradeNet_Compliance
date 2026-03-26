using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeNet11.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComplianceCases",
                columns: new[] { "Id", "AssignedOfficerId", "BusinessName", "Description", "IssueType", "LicenseNumber", "ReportedAt", "ResolvedAt", "Severity", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Alpha Trading Co.", "Operating without updated trade license since Jan 2025.", "Violation", "LIC-2025-001", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "High", "Pending" },
                    { 2, 1, "Beta Imports Ltd.", "Certificate of origin appears forged for shipment #8821.", "DocumentFraud", "LIC-2025-042", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, "Critical", "Investigating" },
                    { 3, 1, "Gamma Exports", "Trade license expired 3 months ago, still conducting business.", "Expired", "LIC-2024-318", new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, "Medium", "Pending" },
                    { 4, 1, "Delta Wholesale", "Unusual volume of transactions flagged by monitoring system.", "SuspiciousActivity", "LIC-2025-099", new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, "High", "Pending" },
                    { 5, 1, "Epsilon Services", "Declared goods do not match inspection findings.", "Mismatch", "LIC-2025-205", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Low", "Compliant" }
                });

            migrationBuilder.InsertData(
                table: "ComplianceNotifications",
                columns: new[] { "Id", "AlertType", "AssignedOfficerId", "ComplianceCaseId", "CreatedAt", "Description", "IsRead", "Severity", "Title" },
                values: new object[] { 4, "AuditDue", 1, null, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Scheduled audit for Gamma Exports is due.", true, "Medium", "Audit Due Today" });

            migrationBuilder.InsertData(
                table: "ProgramCompliances",
                columns: new[] { "Id", "BusinessName", "EligibilityStatus", "FundUsageSummary", "IsMisuseFlag", "ProgramName", "Remarks", "ReviewedAt", "ReviewedByOfficerId" },
                values: new object[,]
                {
                    { 1, "Alpha Trading Co.", "Pending", "Received $50,000 for export incentives.", false, "Trade Subsidy Scheme 2025", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, "Gamma Exports", "Eligible", "Used $20,000 for packaging equipment.", false, "SME Support Program", "Usage verified.", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 3, "Beta Imports Ltd.", "NotEligible", "Claimed $15,000 waiver on restricted goods.", true, "Import Duty Waiver", "Goods not in approved list. Misuse suspected.", new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1 }
                });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "Id", "AssignedOfficerId", "AuditTitle", "BusinessName", "ChecklistJson", "CompletedDate", "ComplianceCaseId", "Findings", "ScheduledDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Annual License Audit – Gamma Exports", "Gamma Exports", null, null, 3, null, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Scheduled" },
                    { 2, 1, "Document Verification – Beta Imports", "Beta Imports Ltd.", null, null, 2, null, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "InProgress" },
                    { 3, 1, "Transaction Review – Delta Wholesale", "Delta Wholesale", null, null, 4, null, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Scheduled" }
                });

            migrationBuilder.InsertData(
                table: "ComplianceNotifications",
                columns: new[] { "Id", "AlertType", "AssignedOfficerId", "ComplianceCaseId", "CreatedAt", "Description", "IsRead", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, "Violation", 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Alpha Trading Co. operating without updated license.", false, "High", "License Violation Detected" },
                    { 2, "DocumentIssue", 1, 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Forged certificate of origin found for Beta Imports shipment.", false, "Critical", "Document Fraud Alert" },
                    { 3, "SuspiciousTransaction", 1, 4, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Delta Wholesale shows unusual transaction volume.", false, "High", "Suspicious Transaction Flagged" },
                    { 5, "LicenseFlag", 1, 3, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Gamma Exports license expired, still active in system.", false, "Medium", "License Flagged – Expired" }
                });

            migrationBuilder.InsertData(
                table: "ComplianceRecords",
                columns: new[] { "Id", "ActionTaken", "ComplianceCaseId", "Details", "OfficerId", "OfficerRemarks", "RuleViolation", "Timestamp" },
                values: new object[,]
                {
                    { 1, "StatusChange", 2, "Status changed from Pending to Investigating", 1, "Reviewing submitted documents.", null, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "StatusChange", 5, "Status changed from Pending to Compliant", 1, "Inspection resolved. No issues found.", null, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "DocumentReview", 2, "Certificate of origin sent for verification.", 1, "Awaiting response from issuing authority.", null, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComplianceNotifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComplianceNotifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComplianceNotifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComplianceNotifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComplianceNotifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ComplianceRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComplianceRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComplianceRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProgramCompliances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgramCompliances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProgramCompliances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComplianceCases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComplianceCases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComplianceCases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComplianceCases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComplianceCases",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
