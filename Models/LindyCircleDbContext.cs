using Microsoft.EntityFrameworkCore;

namespace LindyCircleMVC.Models
{
    public class LindyCircleDbContext : DbContext
    {
        public LindyCircleDbContext(DbContextOptions<LindyCircleDbContext> options)
            : base(options) {
        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Default> Default { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<PunchCardUsage> PunchCardUsage { get; set; }
        public DbSet<PunchCard> PunchCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "dbsa");

            modelBuilder.Entity<Attendance>(entity => {
                entity.Property(e => e.AttendanceID).HasColumnName("AttendanceID");

                entity.Property(e => e.MemberID).HasColumnName("MemberID");

                entity.Property(e => e.PaymentAmount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PracticeID).HasColumnName("PracticeID");

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
                entity.HasKey(e => e.DefaultID);

                entity.Property(e => e.DefaultID).HasColumnName("DefaultID");

                entity.Property(e => e.DefaultName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValue).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Member>(entity => {
                entity.HasKey(e => e.MemberID);

                entity.Property(e => e.MemberID).HasColumnName("MemberID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Practice>(entity => {
                entity.HasKey(e => e.PracticeID);

                entity.HasIndex(e => e.PracticeDate)
                    .HasName("IX_PracticeDate")
                    .IsUnique();

                entity.HasIndex(e => e.PracticeNumber)
                    .HasName("IX_PracticeNumber")
                    .IsUnique();

                entity.Property(e => e.PracticeID).HasColumnName("PracticeID");

                entity.Property(e => e.MiscExpense).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MiscRevenue).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PracticeCost).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PracticeDate).HasColumnType("date");

                entity.Property(e => e.PracticeTopic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PunchCardUsage>(entity => {
                entity.HasKey(e => e.UsageID);

                entity.Property(e => e.UsageID).HasColumnName("UsageID");

                entity.Property(e => e.AttendanceID).HasColumnName("AttendanceID");

                entity.Property(e => e.PunchCardID).HasColumnName("PunchCardID");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.PunchCardUsages)
                    .HasForeignKey(d => d.AttendanceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchCardUsage_Attendance");

                entity.HasOne(d => d.PunchCard)
                    .WithMany(p => p.PunchCardUsages)
                    .HasForeignKey(d => d.PunchCardID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchCardUsage_PunchCards");
            });

            modelBuilder.Entity<PunchCard>(entity => {
                entity.HasKey(e => e.PunchCardID);

                entity.Property(e => e.PunchCardID).HasColumnName("PunchCardID");

                entity.Property(e => e.CurrentMemberID).HasColumnName("CurrentMemberID");

                entity.Property(e => e.PurchaseAmount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.PurchaseMemberID).HasColumnName("PurchaseMemberID");

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