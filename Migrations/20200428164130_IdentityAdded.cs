using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LindyCircleMVC.Migrations
{
    public partial class IdentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbsa");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbsa",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbsa",
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                schema: "dbsa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbsa",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbsa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbsa",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbsa",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbsa",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbsa",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbsa",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbsa",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbsa",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbsa",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_PunchCardUsage_PunchCards",
                        column: x => x.PunchCardID,
                        principalSchema: "dbsa",
                        principalTable: "PunchCards",
                        principalColumn: "PunchCardID",
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
                        name: "FK_PunchCardUsage_Attendance",
                        column: x => x.AttendanceID,
                        principalSchema: "dbsa",
                        principalTable: "PunchCardUsage",
                        principalColumn: "UsageID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbsa",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbsa",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbsa",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbsa",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbsa",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbsa",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbsa",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                column: "AttendanceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PunchCardUsage_PunchCardID",
                schema: "dbsa",
                table: "PunchCardUsage",
                column: "PunchCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Defaults",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "PunchCardUsage",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Practices",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "PunchCards",
                schema: "dbsa");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "dbsa");
        }
    }
}
