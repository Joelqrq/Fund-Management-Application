using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FundManagementApplication.Models;

namespace FundManagementApplication.DataAccess
{
    public partial class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DowJonesBidToBid> DowJonesBidToBid { get; set; }
        public virtual DbSet<FundManager> FundManager { get; set; }
        public virtual DbSet<Funds> Funds { get; set; }
        public virtual DbSet<GlobalBidToBid> GlobalBidToBid { get; set; }
        public virtual DbSet<GlobalDailyMovement> GlobalDailyMovement { get; set; }
        public virtual DbSet<GlobalOfferToBid> GlobalOfferToBid { get; set; }
        public virtual DbSet<GlobalPerformanceChart> GlobalPerformanceChart { get; set; }
        public virtual DbSet<GlobalR> GlobalR { get; set; }
        public virtual DbSet<Investor> Investor { get; set; }
        public virtual DbSet<NasdaqBidToBid> NasdaqBidToBid { get; set; }
        public virtual DbSet<PrestigeBidToBid> PrestigeBidToBid { get; set; }
        public virtual DbSet<PrestigeDailyMovement> PrestigeDailyMovement { get; set; }
        public virtual DbSet<PrestigeOfferToBid> PrestigeOfferToBid { get; set; }
        public virtual DbSet<PrestigePerformanceChart> PrestigePerformanceChart { get; set; }
        public virtual DbSet<PrestigeR> PrestigeR { get; set; }
        public virtual DbSet<StiBidToBid> StiBidToBid { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Search> Search { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DowJonesBidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__DowJones__2FB9939D5B9B12BE");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<FundManager>(entity =>
            {
                entity.HasKey(e => e.PkFundManagerId)
                    .HasName("PK__Fund_Man__CEDE3E8F1E6901A5");

                entity.Property(e => e.PkFundManagerId).IsUnicode(false);

                entity.Property(e => e.FundManagerEmail).IsUnicode(false);

                entity.Property(e => e.FundManagerName).IsUnicode(false);

                entity.Property(e => e.FundManagerPassword).IsUnicode(false);
            });

            modelBuilder.Entity<Funds>(entity =>
            {
                entity.HasKey(e => e.PkFundId)
                    .HasName("PK__Funds__C09F6E2C024DCA67");

                entity.Property(e => e.PkFundId).IsUnicode(false);

                entity.Property(e => e.FundManagerId).IsUnicode(false);

                entity.Property(e => e.FundName).IsUnicode(false);

                entity.Property(e => e.FundProfile).IsUnicode(false);

                entity.Property(e => e.Currency).IsUnicode(false);

                entity.HasOne(d => d.FundManager)
                    .WithMany(p => p.Funds)
                    .HasForeignKey(d => d.FundManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funds_FundManager_ID");
            });

            modelBuilder.Entity<GlobalBidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_B__983F096E50161DE3");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GlobalDailyMovement>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_D__839134E6D4584340");
            });

            modelBuilder.Entity<GlobalOfferToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_O__1DCBD916C9E49E3F");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GlobalPerformanceChart>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_P__8C2394DECF5A74D5");
            });

            modelBuilder.Entity<GlobalR>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.HasKey(e => e.PkId)
                    .HasName("PK__Investor__F4A24BC2B4865146");

                entity.Property(e => e.PkId).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FundManagerId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.FundManager)
                    .WithMany(p => p.Investor)
                    .HasForeignKey(d => d.FundManagerId)
                    .HasConstraintName("FK_Investor_FundManager_ID");
            });

            modelBuilder.Entity<NasdaqBidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Nasdaq_B__BF65DEEF2A931A5F");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<PrestigeBidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__F16452F7661515F0");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PrestigeDailyMovement>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__784CD4C94B55FEC7");
            });

            modelBuilder.Entity<PrestigeOfferToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__5E254DD1A86BAAC8");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PrestigePerformanceChart>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__97EA99433D352804");
            });

            modelBuilder.Entity<PrestigeR>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<StiBidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__STI_BidT__7323883B3C2F3C8A");

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Currency).IsUnicode(false);

                entity.Property(e => e.FundId).IsUnicode(false);

                entity.Property(e => e.Industry).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.Fund)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.FundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Funds");
            });

            modelBuilder.Entity<Search>(entity =>
            {
                entity.Property(e => e.ExchangeMarket).IsUnicode(false);

                entity.Property(e => e.Industry).IsUnicode(false);

                entity.Property(e => e.StockName).IsUnicode(false);

                entity.Property(e => e.Ticker).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
