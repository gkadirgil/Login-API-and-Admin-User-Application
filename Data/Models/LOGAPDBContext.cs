using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LOGIN.DATA.Models
{
    public partial class LOGAPDBContext : DbContext
    {
        public LOGAPDBContext()
        {
        }

        public LOGAPDBContext(DbContextOptions<LOGAPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<MailModel> MailModels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=GGULSEN\\SQLEXPRESS;Database=LOGAPDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MailModel>(entity =>
            {
                entity.HasKey(e => e.MailId);

                entity.ToTable("MailModel");

                entity.Property(e => e.MailId).HasColumnName("MailID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FromMail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MailContent)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.MailSubject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ToMail)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.RegisterTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.Property(e => e.AdminDescription).HasMaxLength(2000);

                entity.Property(e => e.AdminDetail).HasMaxLength(50);

                entity.Property(e => e.DocumentPath).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Request Date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.UserDescription).HasMaxLength(2000);

                entity.Property(e => e.VerificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Verification Date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClaims_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
