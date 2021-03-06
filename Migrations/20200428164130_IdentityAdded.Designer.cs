﻿// <auto-generated />
using System;
using LindyCircleMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LindyCircleMVC.Migrations
{
    [DbContext(typeof(LindyCircleDbContext))]
    [Migration("20200428164130_IdentityAdded")]
    partial class IdentityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbsa")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LindyCircleMVC.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AttendanceID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemberID")
                        .HasColumnName("MemberID")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnName("PaymentAmount")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<int>("PaymentType")
                        .HasColumnName("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("PracticeID")
                        .HasColumnName("PracticeID")
                        .HasColumnType("int");

                    b.HasKey("AttendanceID")
                        .HasName("PK_Attendance");

                    b.HasIndex("MemberID")
                        .HasName("IX_Attendance_MemberID");

                    b.HasIndex("PracticeID")
                        .HasName("IX_Attendance_PracticeID");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("LindyCircleMVC.Models.Default", b =>
                {
                    b.Property<int>("DefaultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DefaultID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DefaultName")
                        .IsRequired()
                        .HasColumnName("DefaultName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("DefaultValue")
                        .HasColumnName("DefaultValue")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("DefaultID")
                        .HasName("PK_Defaults");

                    b.ToTable("Defaults");
                });

            modelBuilder.Entity("LindyCircleMVC.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MemberID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("Inactive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Inactive")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("MemberID")
                        .HasName("PK_Members");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LindyCircleMVC.Models.Practice", b =>
                {
                    b.Property<int>("PracticeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PracticeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("MiscExpense")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MiscExpense")
                        .HasColumnType("decimal(5, 2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("MiscRevenue")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MiscRevenue")
                        .HasColumnType("decimal(5, 2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("PracticeCost")
                        .HasColumnName("PracticeCost")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("PracticeDate")
                        .HasColumnName("PracticeDate")
                        .HasColumnType("date");

                    b.Property<int>("PracticeNumber")
                        .HasColumnName("PracticeNumber")
                        .HasColumnType("int");

                    b.Property<string>("PracticeTopic")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("PracticeID")
                        .HasName("PK_Practices");

                    b.HasIndex("PracticeDate")
                        .IsUnique()
                        .HasName("IX_PracticeDate");

                    b.HasIndex("PracticeNumber")
                        .IsUnique()
                        .HasName("IX_PracticeNumber");

                    b.ToTable("Practices");
                });

            modelBuilder.Entity("LindyCircleMVC.Models.PunchCard", b =>
                {
                    b.Property<int>("PunchCardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PunchCardID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentMemberID")
                        .HasColumnName("CurrentMemberID")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchaseAmount")
                        .HasColumnName("PurchaseAmount")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnName("PurchaseDate")
                        .HasColumnType("date");

                    b.Property<int>("PurchaseMemberID")
                        .HasColumnName("PurchaseMemberID")
                        .HasColumnType("int");

                    b.HasKey("PunchCardID")
                        .HasName("PK_PunchCards");

                    b.HasIndex("CurrentMemberID")
                        .HasName("IX_PunchCards_CurrentMemberID");

                    b.HasIndex("PurchaseMemberID")
                        .HasName("IX_PunchCards_PurchaseMemberID");

                    b.ToTable("PunchCards");
                });

            modelBuilder.Entity("LindyCircleMVC.Models.PunchCardUsage", b =>
                {
                    b.Property<int>("UsageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UsageID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceID")
                        .HasColumnName("AttendanceID")
                        .HasColumnType("int");

                    b.Property<int>("PunchCardID")
                        .HasColumnName("PunchCardID")
                        .HasColumnType("int");

                    b.HasKey("UsageID")
                        .HasName("PK_PunchCardUsage");

                    b.HasIndex("AttendanceID")
                        .IsUnique()
                        .HasName("IX_PunchCardUsage_AttendanceID");

                    b.HasIndex("PunchCardID")
                        .HasName("IX_PunchCardUsage_PunchCardID");

                    b.ToTable("PunchCardUsage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LindyCircleMVC.Models.Attendance", b =>
                {
                    b.HasOne("LindyCircleMVC.Models.PunchCardUsage", "PunchCardUsage")
                        .WithOne("Attendance")
                        .HasForeignKey("LindyCircleMVC.Models.Attendance", "AttendanceID")
                        .HasConstraintName("FK_PunchCardUsage_Attendance")
                        .IsRequired();

                    b.HasOne("LindyCircleMVC.Models.Member", "Member")
                        .WithMany("Attendances")
                        .HasForeignKey("MemberID")
                        .HasConstraintName("FK_Attendance_Members")
                        .IsRequired();

                    b.HasOne("LindyCircleMVC.Models.Practice", "Practice")
                        .WithMany("Attendances")
                        .HasForeignKey("PracticeID")
                        .HasConstraintName("FK_Attendance_Practices")
                        .IsRequired();
                });

            modelBuilder.Entity("LindyCircleMVC.Models.PunchCard", b =>
                {
                    b.HasOne("LindyCircleMVC.Models.Member", "CurrentMember")
                        .WithMany("PunchCardsHeld")
                        .HasForeignKey("CurrentMemberID")
                        .HasConstraintName("FK_PunchCards_CurrentMembers")
                        .IsRequired();

                    b.HasOne("LindyCircleMVC.Models.Member", "PurchaseMember")
                        .WithMany("PunchCardsPurchased")
                        .HasForeignKey("PurchaseMemberID")
                        .HasConstraintName("FK_PunchCards_PurchaseMembers")
                        .IsRequired();
                });

            modelBuilder.Entity("LindyCircleMVC.Models.PunchCardUsage", b =>
                {
                    b.HasOne("LindyCircleMVC.Models.PunchCard", "PunchCard")
                        .WithMany("PunchCardUsages")
                        .HasForeignKey("PunchCardID")
                        .HasConstraintName("FK_PunchCardUsage_PunchCards")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
