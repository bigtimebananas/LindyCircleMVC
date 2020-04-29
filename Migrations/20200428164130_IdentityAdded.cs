using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LindyCircleMVC.Migrations
{
    public partial class IdentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defaults",
                schema: "dbo",
                columns: table => new
                {
                    DefaultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DefaultValue = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Defaults", x => x.DefaultID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "dbo",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Inactive = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Practices",
                schema: "dbo",
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
                constraints: table => {
                    table.PrimaryKey("PK_Practices", x => x.PracticeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PunchCards",
                schema: "dbo",
                columns: table => new
                {
                    PunchCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseMemberID = table.Column<int>(nullable: false),
                    CurrentMemberID = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    PurchaseAmount = table.Column<decimal>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_PunchCards", x => x.PunchCardID);
                    table.ForeignKey(
                        name: "FK_PunchCards_CurrentMembers",
                        column: x => x.CurrentMemberID,
                        principalSchema: "dbo",
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PunchCards_PurchaseMembers",
                        column: x => x.PurchaseMemberID,
                        principalSchema: "dbo",
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PunchCardUsage",
                schema: "dbo",
                columns: table => new
                {
                    UsageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceID = table.Column<int>(nullable: false),
                    PunchCardID = table.Column<int>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_PunchCardUsage", x => x.UsageID);
                    table.ForeignKey(
                        name: "FK_PunchCardUsage_PunchCards",
                        column: x => x.PunchCardID,
                        principalSchema: "dbo",
                        principalTable: "PunchCards",
                        principalColumn: "PunchCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "dbo",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(nullable: false),
                    PracticeID = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_PunchCardUsage_Attendance",
                        column: x => x.AttendanceID,
                        principalSchema: "dbo",
                        principalTable: "PunchCardUsage",
                        principalColumn: "UsageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Members",
                        column: x => x.MemberID,
                        principalSchema: "dbo",
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Practices",
                        column: x => x.PracticeID,
                        principalSchema: "dbo",
                        principalTable: "Practices",
                        principalColumn: "PracticeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_MemberID",
                schema: "dbo",
                table: "Attendance",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PracticeID",
                schema: "dbo",
                table: "Attendance",
                column: "PracticeID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeDate",
                schema: "dbo",
                table: "Practices",
                column: "PracticeDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PracticeNumber",
                schema: "dbo",
                table: "Practices",
                column: "PracticeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PunchCards_CurrentMemberID",
                schema: "dbo",
                table: "PunchCards",
                column: "CurrentMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PunchCards_PurchaseMemberID",
                schema: "dbo",
                table: "PunchCards",
                column: "PurchaseMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PunchCardUsage_AttendanceID",
                schema: "dbo",
                table: "PunchCardUsage",
                column: "AttendanceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PunchCardUsage_PunchCardID",
                schema: "dbo",
                table: "PunchCardUsage",
                column: "PunchCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Defaults",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PunchCardUsage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Practices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PunchCards",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "dbo");
        }
    }
}
