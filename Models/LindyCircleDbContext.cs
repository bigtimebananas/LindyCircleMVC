using Microsoft.EntityFrameworkCore;

namespace LindyCircleMVC.Models
{
    public class LindyCircleDbContext : DbContext
    {
        public LindyCircleDbContext(DbContextOptions<LindyCircleDbContext> options)
            : base(options) {
        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Default> Defaults { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<PunchCardUsage> PunchCardUsage { get; set; }
        public DbSet<PunchCard> PunchCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "dbsa");

            modelBuilder.Entity<Attendance>(entity => {
                entity.HasKey(e => e.AttendanceID)
                    .HasName("PK_Attendance");

                entity.HasIndex(e => e.MemberID)
                    .HasName("IX_Attendance_MemberID");

                entity.HasIndex(e => e.PracticeID)
                    .HasName("IX_Attendance_PracticeID");

                entity.Property(e => e.AttendanceID)
                    .HasColumnName("AttendanceID");

                entity.Property(e => e.MemberID)
                    .HasColumnName("MemberID")
                    .IsRequired();

                entity.Property(e => e.PracticeID)
                    .HasColumnName("PracticeID")
                    .IsRequired();

                entity.Property(e => e.PaymentType)
                    .HasColumnName("PaymentType")
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("PaymentAmount")
                    .IsRequired()
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.MemberID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Members");

                entity.HasOne(d => d.Practice)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.PracticeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Practices");
            });

            modelBuilder.Entity<Default>(entity => {
                entity.HasKey(e => e.DefaultID)
                    .HasName("PK_Defaults");

                entity.Property(e => e.DefaultID)
                    .HasColumnName("DefaultID");

                entity.Property(e => e.DefaultName)
                    .HasColumnName("DefaultName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("DefaultValue")
                    .IsRequired()
                    .HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Member>(entity => {
                entity.HasKey(e => e.MemberID)
                    .HasName("PK_Members");

                entity.Property(e => e.MemberID)
                    .HasColumnName("MemberID");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Inactive)
                    .HasColumnName("Inactive")
                    .IsRequired()
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Practice>(entity => {
                entity.HasKey(e => e.PracticeID)
                    .HasName("PK_Practices");

                entity.HasIndex(e => e.PracticeDate)
                    .HasName("IX_PracticeDate")
                    .IsUnique();

                entity.HasIndex(e => e.PracticeNumber)
                    .HasName("IX_PracticeNumber")
                    .IsUnique();

                entity.Property(e => e.PracticeID)
                    .HasColumnName("PracticeID");

                entity.Property(e => e.PracticeDate)
                    .HasColumnName("PracticeDate")
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.PracticeNumber)
                    .HasColumnName("PracticeNumber")
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.PracticeCost)
                    .HasColumnName("PracticeCost")
                    .IsRequired()
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MiscExpense)
                    .HasColumnName("MiscExpense")
                    .IsRequired()
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValue(0M);

                entity.Property(e => e.MiscRevenue)
                    .HasColumnName("MiscRevenue")
                    .IsRequired()
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValue(0M);

                entity.Property(e => e.PracticeTopic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PunchCardUsage>(entity => {
                entity.HasKey(e => e.UsageID)
                    .HasName("PK_PunchCardUsage");

                entity.HasIndex(e => e.AttendanceID)
                    .HasName("IX_PunchCardUsage_AttendanceID")
                    .IsUnique();

                entity.HasIndex(e => e.PunchCardID)
                    .HasName("IX_PunchCardUsage_PunchCardID");

                entity.Property(e => e.UsageID)
                    .HasColumnName("UsageID");

                entity.Property(e => e.AttendanceID)
                    .HasColumnName("AttendanceID")
                    .IsRequired();

                entity.Property(e => e.PunchCardID)
                    .HasColumnName("PunchCardID")
                    .IsRequired();

                entity.HasOne(d => d.Attendance)
                    .WithOne(p => p.PunchCardUsage)
                    .HasForeignKey<Attendance>(d => d.AttendanceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchCardUsage_Attendance");

                entity.HasOne(d => d.PunchCard)
                    .WithMany(p => p.PunchCardUsages)
                    .HasForeignKey(d => d.PunchCardID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchCardUsage_PunchCards");
            });

            modelBuilder.Entity<PunchCard>(entity => {
                entity.HasKey(e => e.PunchCardID)
                    .HasName("PK_PunchCards");

                entity.HasIndex(e => e.CurrentMemberID)
                    .HasName("IX_PunchCards_CurrentMemberID");

                entity.HasIndex(e => e.PurchaseMemberID)
                    .HasName("IX_PunchCards_PurchaseMemberID");

                entity.Property(e => e.PunchCardID)
                    .HasColumnName("PunchCardID");

                entity.Property(e => e.PurchaseMemberID)
                    .HasColumnName("PurchaseMemberID")
                    .IsRequired();

                entity.Property(e => e.CurrentMemberID)
                    .HasColumnName("CurrentMemberID")
                    .IsRequired();

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("PurchaseDate")
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.PurchaseAmount)
                    .HasColumnName("PurchaseAmount")
                    .IsRequired()
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.CurrentMember)
                    .WithMany(p => p.PunchCardsHeld)
                    .HasForeignKey(d => d.CurrentMemberID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchCards_CurrentMembers");

                entity.HasOne(d => d.PurchaseMember)
                    .WithMany(p => p.PunchCardsPurchased)
                    .HasForeignKey(d => d.PurchaseMemberID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchCards_PurchaseMembers");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}