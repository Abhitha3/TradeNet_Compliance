using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeNet11.Migrations
{
    /// <inheritdoc />
    public partial class Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplianceOfficers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceOfficers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedOfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceCases_ComplianceOfficers_AssignedOfficerId",
                        column: x => x.AssignedOfficerId,
                        principalTable: "ComplianceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramCompliances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EligibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundUsageSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMisuseFlag = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedByOfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCompliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramCompliances_ComplianceOfficers_ReviewedByOfficerId",
                        column: x => x.ReviewedByOfficerId,
                        principalTable: "ComplianceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Findings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChecklistJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedOfficerId = table.Column<int>(type: "int", nullable: true),
                    ComplianceCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_ComplianceCases_ComplianceCaseId",
                        column: x => x.ComplianceCaseId,
                        principalTable: "ComplianceCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Audits_ComplianceOfficers_AssignedOfficerId",
                        column: x => x.AssignedOfficerId,
                        principalTable: "ComplianceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplianceCaseId = table.Column<int>(type: "int", nullable: true),
                    AssignedOfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceNotifications_ComplianceCases_ComplianceCaseId",
                        column: x => x.ComplianceCaseId,
                        principalTable: "ComplianceCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComplianceNotifications_ComplianceOfficers_AssignedOfficerId",
                        column: x => x.AssignedOfficerId,
                        principalTable: "ComplianceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficerRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuleViolation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplianceCaseId = table.Column<int>(type: "int", nullable: false),
                    OfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceRecords_ComplianceCases_ComplianceCaseId",
                        column: x => x.ComplianceCaseId,
                        principalTable: "ComplianceCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplianceRecords_ComplianceOfficers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "ComplianceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ComplianceOfficers",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Username" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "officer1@tradenet.com", "Default Compliance Officer", true, "AQAAAAIAAYagAAAAEA==", "officer1" });

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AssignedOfficerId",
                table: "Audits",
                column: "AssignedOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_ComplianceCaseId",
                table: "Audits",
                column: "ComplianceCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceCases_AssignedOfficerId",
                table: "ComplianceCases",
                column: "AssignedOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceNotifications_AssignedOfficerId",
                table: "ComplianceNotifications",
                column: "AssignedOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceNotifications_ComplianceCaseId",
                table: "ComplianceNotifications",
                column: "ComplianceCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceRecords_ComplianceCaseId",
                table: "ComplianceRecords",
                column: "ComplianceCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceRecords_OfficerId",
                table: "ComplianceRecords",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramCompliances_ReviewedByOfficerId",
                table: "ProgramCompliances",
                column: "ReviewedByOfficerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "ComplianceNotifications");

            migrationBuilder.DropTable(
                name: "ComplianceRecords");

            migrationBuilder.DropTable(
                name: "ProgramCompliances");

            migrationBuilder.DropTable(
                name: "ComplianceCases");

            migrationBuilder.DropTable(
                name: "ComplianceOfficers");
        }
    }
}
