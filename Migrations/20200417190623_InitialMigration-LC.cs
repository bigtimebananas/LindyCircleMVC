using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LindyCircleMVC.Migrations
{
    public partial class InitialMigrationLC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbsa");

            migrationBuilder.CreateTable(
                name: "Defaults",
                schema: "dbsa",
                columns: table => new
                {
                    DefaultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DefaultValue = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defaults", x => x.DefaultID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "dbsa",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Inactive = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Practices",
                schema: "dbsa",
                columns: table => new
                {
                    PracticeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeDate = table.Column<DateTime>(type: "date", nullable: false),
                    PracticeNumber = table.Column<int>(type: "int", nullable: false),
                    PracticeCost = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    MiscExpense = table.Column<decimal>(type: "decimal(5, 2)", nullable: false, defaultValue: 0m),
                    MiscRevenue = table.Column<decimal>(type: "decimal(5, 2)", nullable: false, defaultValue: 0m),
                    PracticeTopic = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.PracticeID);
                });

            migrationBuilder.CreateTable(
                name: "PunchCards",
                schema: "dbsa",
                columns: table => new
                {
                    PunchCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseMemberID = table.Column<int>(nullable: false),
                    CurrentMemberID = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    PurchaseAmount = table.Column<decimal>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchCards", x => x.PunchCardID);
                    table.ForeignKey(
                        name: "FK_PunchCards_CurrentMembers",
                        column: x => x.CurrentMemberID,
                        principalSchema: "dbsa",
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PunchCards_PurchaseMembers",
                        column: x => x.PurchaseMemberID,
                        principalSchema: "dbsa",
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "dbsa",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(nullable: false),
                    PracticeID = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendance_Members",
                        column: x => x.MemberID,
                        principalSchema: "dbsa",
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Practices",
                        column: x => x.PracticeID,
                        principalSchema: "dbsa",
                        principalTable: "Practices",
                        principalColumn: "PracticeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PunchCardUsage",
                schema: "dbsa",
                columns: table => new
                {
                    UsageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceID = table.Column<int>(nullable: false),
                    PunchCardID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchCardUsage", x => x.UsageID);
                    table.ForeignKey(
                        name: "FK_PunchCardUsage_Attendance",
                        column: x => x.AttendanceID,
                        principalSchema: "dbsa",
                        principalTable: "Attendance",
                        principalColumn: "AttendanceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PunchCardUsage_PunchCards",
                        column: x => x.PunchCardID,
                        principalSchema: "dbsa",
                        principalTable: "PunchCards",
                        principalColumn: "PunchCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_MemberID",
                schema: "dbsa",
                table: "Attendance",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PracticeID",
                schema: "dbsa",
                table: "Attendance",
                column: "PracticeID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeDate",
                schema: "dbsa",
                table: "Practices",
                column: "PracticeDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PracticeNumber",
                schema: "dbsa",
                table: "Practices",
                column: "PracticeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PunchCards_CurrentMemberID",
                schema: "dbsa",
                table: "PunchCards",
                column: "CurrentMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PunchCards_PurchaseMemberID",
                schema: "dbsa",
                table: "PunchCards",
                column: "PurchaseMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PunchCardUsage_AttendanceID",
                schema: "dbsa",
                table: "PunchCardUsage",
                column: "AttendanceID");

            migrationBuilder.CreateIndex(
                name: "IX_PunchCardUsage_PunchCardID",
                schema: "dbsa",
                table: "PunchCardUsage",
                column: "PunchCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defaults",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "PunchCardUsage",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "PunchCards",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Practices",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "dbsa");
        }
    }
}
