using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pradeepm.Models.DB
{
    public partial class therisingstarContext : DbContext
    {
        public therisingstarContext()
        {
        }

        public therisingstarContext(DbContextOptions<therisingstarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountUsers> AccountUsers { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Closing> Closing { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Magicclub> Magicclub { get; set; }
        public virtual DbSet<Masters> Masters { get; set; }
        public virtual DbSet<NominiDetails> NominiDetails { get; set; }
        public virtual DbSet<Otps> Otps { get; set; }
        public virtual DbSet<Payout> Payout { get; set; }
        public virtual DbSet<PinOrders> PinOrders { get; set; }
        public virtual DbSet<Pins> Pins { get; set; }
        public virtual DbSet<PinTransfers> PinTransfers { get; set; }
        public virtual DbSet<PrasnalDetails> PrasnalDetails { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<TreeRelation> TreeRelation { get; set; }
        public virtual DbSet<UserBankDetails> UserBankDetails { get; set; }
        public virtual DbSet<UserClosing> UserClosing { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<Websitedetails> Websitedetails { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("data source=5.189.148.31,1415;initial catalog=therisingstar;persist security info=True;user id=sa;password =P@ssw0rd@123; multipleactiveresultsets=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountUsers>(entity =>
            {
                entity.HasIndex(e => new { e.FatherId, e.Side })
                    .HasName("UC_fatherside")
                    .IsUnique();

                entity.Property(e => e.Activate).HasDefaultValueSql("((1))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.SuperUser).HasDefaultValueSql("((0))");

                entity.Property(e => e.Topup).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AccountUsers)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Products_AccountUser");
            });

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasIndex(e => e.BankId)
                    .HasName("IX_FK_Branch_Branch");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Branch_Branch");
            });

            modelBuilder.Entity<Closing>(entity =>
            {
                entity.HasIndex(e => e.ClosgingDate)
                    .HasName("IX_Closingdate")
                    .IsUnique();
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Income)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_Income_AccountUsers");
            });

            modelBuilder.Entity<Magicclub>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Masters>(entity =>
            {
                entity.Property(e => e.MasterKey).ValueGeneratedNever();
            });

            modelBuilder.Entity<NominiDetails>(entity =>
            {
                entity.HasIndex(e => e.AccountUserId)
                    .HasName("IX_FK_NominiDetails_AccountUser");

                entity.HasOne(d => d.AccountUser)
                    .WithMany(p => p.NominiDetails)
                    .HasForeignKey(d => d.AccountUserId)
                    .HasConstraintName("FK_NominiDetails_AccountUser");
            });

            modelBuilder.Entity<Otps>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_FK_OTP_AccountUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Otps)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_OTP_AccountUser");
            });

            modelBuilder.Entity<Payout>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payout)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_payout_AccountUsers");
            });

            modelBuilder.Entity<PinOrders>(entity =>
            {
                entity.HasIndex(e => e.OrderByUserId)
                    .HasName("IX_FK_PinOrder_AccountUser");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_FK_PinOrder_Product");

                entity.HasOne(d => d.OrderByUser)
                    .WithMany(p => p.PinOrders)
                    .HasForeignKey(d => d.OrderByUserId)
                    .HasConstraintName("FK_PinOrder_AccountUser");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PinOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PinOrder_Product");
            });

            modelBuilder.Entity<Pins>(entity =>
            {
                entity.HasIndex(e => e.ForUser)
                    .HasName("IX_FK_Pins_AccountUser");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_FK_Pins_PinOrder");

                entity.HasIndex(e => e.UsedBy)
                    .HasName("IX_FK_Pins_AccountUser1");

                entity.HasOne(d => d.ForUserNavigation)
                    .WithMany(p => p.PinsForUserNavigation)
                    .HasForeignKey(d => d.ForUser)
                    .HasConstraintName("FK_Pins_AccountUsers");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pins)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pins_PinOrder");

                entity.HasOne(d => d.UsedByNavigation)
                    .WithMany(p => p.PinsUsedByNavigation)
                    .HasForeignKey(d => d.UsedBy)
                    .HasConstraintName("FK_Pins_AccountUsers1");
            });

            modelBuilder.Entity<PinTransfers>(entity =>
            {
                entity.HasIndex(e => e.FromUserId)
                    .HasName("IX_FK_PinTransfer_AccountUser");

                entity.HasIndex(e => e.ToUserId)
                    .HasName("IX_FK_PinTransfer_AccountUser1");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.PinTransfersFromUser)
                    .HasForeignKey(d => d.FromUserId)
                    .HasConstraintName("FK_PinTransfer_AccountUser");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.PinTransfersToUser)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PinTransfer_AccountUser1");
            });

            modelBuilder.Entity<PrasnalDetails>(entity =>
            {
                entity.HasIndex(e => e.AccountUserId)
                    .HasName("IX_FK_PrasnalDetails_AccountUser");

                entity.HasOne(d => d.AccountUser)
                    .WithMany(p => p.PrasnalDetails)
                    .HasForeignKey(d => d.AccountUserId)
                    .HasConstraintName("FK_PrasnalDetails_AccountUser");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserBankDetails>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Udate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AccountUser)
                    .WithMany(p => p.UserBankDetails)
                    .HasForeignKey(d => d.AccountUserId)
                    .HasConstraintName("FK_UserBankDetails_AccountUsers");
            });

            modelBuilder.Entity<UserClosing>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClosing)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserClosing_AccountUsers");
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasIndex(e => e.AccountUserId)
                    .HasName("IX_FK_UserLogins_AccountUser");

                entity.HasOne(d => d.AccountUser)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.AccountUserId)
                    .HasConstraintName("FK_UserLogins_AccountUser");
            });
        }
    }
}
