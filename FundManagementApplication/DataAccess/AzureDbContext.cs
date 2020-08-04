using Microsoft.EntityFrameworkCore;
using FundManagementApplication.Models;

namespace FundManagementApplication.DataAccess
{
    public partial class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<C> C { get; set; }
        public virtual DbSet<C31Si> C31Si { get; set; }
        public virtual DbSet<C52Si> C52Si { get; set; }
        public virtual DbSet<C6lSi> C6lSi { get; set; }
        public virtual DbSet<Cc3Si> Cc3Si { get; set; }
        public virtual DbSet<D05Si> D05Si { get; set; }
        public virtual DbSet<DowJonesBidToBid> DowJonesBidToBid { get; set; }
        public virtual DbSet<F> F { get; set; }
        public virtual DbSet<FundManager> FundManager { get; set; }
        public virtual DbSet<Funds> Funds { get; set; }
        public virtual DbSet<FundsAndFundManager> FundsAndFundManager { get; set; }
        public virtual DbSet<Ge> Ge { get; set; }
        public virtual DbSet<GlobalBidToBid> GlobalBidToBid { get; set; }
        public virtual DbSet<GlobalDailyMovement> GlobalDailyMovement { get; set; }
        public virtual DbSet<GlobalOfferToBid> GlobalOfferToBid { get; set; }
        public virtual DbSet<GlobalPerformanceChart> GlobalPerformanceChart { get; set; }
        public virtual DbSet<Gm> Gm { get; set; }
        public virtual DbSet<Goog> Goog { get; set; }
        public virtual DbSet<Ibm> Ibm { get; set; }
        public virtual DbSet<Investor> Investor { get; set; }
        public virtual DbSet<InvestorAndFunds> InvestorAndFunds { get; set; }
        public virtual DbSet<Jpm> Jpm { get; set; }
        public virtual DbSet<Msft> Msft { get; set; }
        public virtual DbSet<NasdaqBidToBid> NasdaqBidToBid { get; set; }
        public virtual DbSet<O39Si> O39Si { get; set; }
        public virtual DbSet<PrestigeBidToBid> PrestigeBidToBid { get; set; }
        public virtual DbSet<PrestigeDailyMovement> PrestigeDailyMovement { get; set; }
        public virtual DbSet<PrestigeOfferToBid> PrestigeOfferToBid { get; set; }
        public virtual DbSet<PrestigePerformanceChart> PrestigePerformanceChart { get; set; }
        public virtual DbSet<SharesWeightage> SharesWeightage { get; set; }
        public virtual DbSet<StiBidToBid> StiBidToBid { get; set; }
        public virtual DbSet<StocksOverview> StocksOverview { get; set; }
        public virtual DbSet<T39Si> T39Si { get; set; }
        public virtual DbSet<U11Si> U11Si { get; set; }
        public virtual DbSet<Uber> Uber { get; set; }
        public virtual DbSet<V03Si> V03Si { get; set; }
        public virtual DbSet<Wmt> Wmt { get; set; }
        public virtual DbSet<Z74Si> Z74Si { get; set; }
        public virtual DbSet<_5edji> _5edji { get; set; }
        public virtual DbSet<_5eixic> _5eixic { get; set; }
        public virtual DbSet<_5esti3fp3d5esti> _5esti3fp3d5esti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_CitiGroup_Date");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitiGroup_Ticker");
            });

            modelBuilder.Entity<C31Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Capitaland_Date");

                entity.ToTable("C31.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C31Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Capitaland_Ticker");
            });

            modelBuilder.Entity<C52Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_ComfortDelgro_Date");

                entity.ToTable("C52.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C52Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComfortDelgro_Ticker");
            });

            modelBuilder.Entity<C6lSi>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_SIA_Date");

                entity.ToTable("C6L.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C6lSi)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIA_Ticker");
            });

            modelBuilder.Entity<Cc3Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Starhub_Date");

                entity.ToTable("CC3.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Cc3Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Starhub_Ticker");
            });

            modelBuilder.Entity<D05Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_DBS_Date");

                entity.ToTable("D05.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.D05Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DBS_Ticker");
            });

            modelBuilder.Entity<DowJonesBidToBid>(entity =>
            {
                entity.HasKey(e => e.DowJonesBidToBidDate)
                    .HasName("PK__DowJones__2FB9939D5B9B12BE");

                entity.ToTable("DowJones_BidToBid");

                entity.Property(e => e.DowJonesBidToBidDate)
                    .HasColumnName("DowJones_BidToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DowJonesBidToBidFundId)
                    .IsRequired()
                    .HasColumnName("DowJones_BidToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DowJonesBidToBidOneMonth)
                    .HasColumnName("DowJones_BidToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.DowJonesBidToBidOneYear)
                    .HasColumnName("DowJones_BidToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.DowJonesBidToBidPrice)
                    .HasColumnName("DowJones_BidToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.DowJonesBidToBidSinceInception)
                    .HasColumnName("DowJones_BidToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.DowJonesBidToBidSixMonth)
                    .HasColumnName("DowJones_BidToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.DowJonesBidToBidThreeMonth)
                    .HasColumnName("DowJones_BidToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.DowJonesBidToBidYearToDate)
                    .HasColumnName("DowJones_BidToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<F>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_FordMotor_Date");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.F)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FordMotor_Ticker");
            });

            modelBuilder.Entity<FundManager>(entity =>
            {
                entity.HasKey(e => e.PkFundManagerId)
                    .HasName("PK__Fund_Man__CEDE3E8F1E6901A5");

                entity.ToTable("Fund_Manager");

                entity.Property(e => e.PkFundManagerId)
                    .HasColumnName("PK_FundManager_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundManagerEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FundManagerName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FundManagerPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funds>(entity =>
            {
                entity.HasKey(e => e.PkFundId)
                    .HasName("PK__Funds__C09F6E2C024DCA67");

                entity.Property(e => e.PkFundId)
                    .HasColumnName("PK_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundFee).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.FundManagerId)
                    .IsRequired()
                    .HasColumnName("FundManager_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FundsAndFundManager>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Funds_and_Fund_Manager");

                entity.Property(e => e.FundsAndFundManagerFundId)
                    .IsRequired()
                    .HasColumnName("Funds_and_Fund_Manager_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundsAndFundManagerFundManagerId)
                    .IsRequired()
                    .HasColumnName("Funds_and_Fund_Manager_FundManager_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FundsAndFundManagerFund)
                    .WithMany()
                    .HasForeignKey(d => d.FundsAndFundManagerFundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Funds_and__Funds__47A6A41B");

                entity.HasOne(d => d.FundsAndFundManagerFundManager)
                    .WithMany()
                    .HasForeignKey(d => d.FundsAndFundManagerFundManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Funds_and__Funds__59063A47");
            });

            modelBuilder.Entity<Ge>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_GeneralElectric_Date");

                entity.ToTable("GE");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Ge)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralElectric_Ticker");
            });

            modelBuilder.Entity<GlobalBidToBid>(entity =>
            {
                entity.HasKey(e => e.GlobalBidToBidDate)
                    .HasName("PK__Global_B__983F096E50161DE3");

                entity.ToTable("Global_BidToBid");

                entity.Property(e => e.GlobalBidToBidDate)
                    .HasColumnName("Global_BidToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlobalBidToBidFundId)
                    .IsRequired()
                    .HasColumnName("Global_BidToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GlobalBidToBidOneMonth)
                    .HasColumnName("Global_BidToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalBidToBidOneYear)
                    .HasColumnName("Global_BidToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalBidToBidPrice)
                    .HasColumnName("Global_BidToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.GlobalBidToBidSinceInception)
                    .HasColumnName("Global_BidToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalBidToBidSixMonth)
                    .HasColumnName("Global_BidToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalBidToBidThreeMonth)
                    .HasColumnName("Global_BidToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalBidToBidYearToDate)
                    .HasColumnName("Global_BidToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<GlobalDailyMovement>(entity =>
            {
                entity.HasKey(e => e.GlobalDailyMovementDate)
                    .HasName("PK__Global_D__839134E6D4584340");

                entity.ToTable("Global_DailyMovement");

                entity.Property(e => e.GlobalDailyMovementDate)
                    .HasColumnName("Global_DailyMovement_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlobalDailyMovementGlobalDr)
                    .HasColumnName("Global_DailyMovement_GlobalDR")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<GlobalOfferToBid>(entity =>
            {
                entity.HasKey(e => e.GlobalOfferToBidDate)
                    .HasName("PK__Global_O__1DCBD916C9E49E3F");

                entity.ToTable("Global_OfferToBid");

                entity.Property(e => e.GlobalOfferToBidDate)
                    .HasColumnName("Global_OfferToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlobalOfferToBidFundId)
                    .IsRequired()
                    .HasColumnName("Global_OfferToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GlobalOfferToBidOneMonth)
                    .HasColumnName("Global_OfferToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalOfferToBidOneYear)
                    .HasColumnName("Global_OfferToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalOfferToBidPrice)
                    .HasColumnName("Global_OfferToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.GlobalOfferToBidPriceAfterAdmin)
                    .HasColumnName("Global_OfferToBid_Price_AfterAdmin")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.GlobalOfferToBidSinceInception)
                    .HasColumnName("Global_OfferToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalOfferToBidSixMonth)
                    .HasColumnName("Global_OfferToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalOfferToBidThreeMonth)
                    .HasColumnName("Global_OfferToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalOfferToBidYearToDate)
                    .HasColumnName("Global_OfferToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<GlobalPerformanceChart>(entity =>
            {
                entity.HasKey(e => e.GlobalPerformanceChartDate)
                    .HasName("PK__Global_P__8C2394DECF5A74D5");

                entity.ToTable("Global_Performance_Chart");

                entity.Property(e => e.GlobalPerformanceChartDate)
                    .HasColumnName("Global_Performance_Chart_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlobalPerformanceChartDowJonesCr)
                    .HasColumnName("Global_Performance_Chart_DowJonesCR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalPerformanceChartGlobalCr)
                    .HasColumnName("Global_Performance_Chart_GlobalCR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.GlobalPerformanceChartNasdaqCr)
                    .HasColumnName("Global_Performance_Chart_NasdaqCR")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<Gm>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_GeneralMotors_Date");

                entity.ToTable("GM");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Gm)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralMotors_Ticker");
            });

            modelBuilder.Entity<Goog>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Google_Date");

                entity.ToTable("GOOG");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Goog)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Google_Ticker");
            });

            modelBuilder.Entity<Ibm>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_IBM_Date");

                entity.ToTable("IBM");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Ibm)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IBM_Ticker");
            });

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.HasKey(e => e.PkInvestorId)
                    .HasName("PK_Investor_ID");

                entity.Property(e => e.PkInvestorId)
                    .HasColumnName("PK_Investor_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InvestorDate).HasColumnType("datetime");

                entity.Property(e => e.InvestorEmail)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.InvestorName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InvestorAndFunds>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Investor_and_Funds");

                entity.Property(e => e.InvestorAndFundsFundId)
                    .IsRequired()
                    .HasColumnName("Investor_and_Funds_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InvestorAndFundsInvestorId)
                    .IsRequired()
                    .HasColumnName("Investor_and_Funds_Investor_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.InvestorAndFundsFund)
                    .WithMany()
                    .HasForeignKey(d => d.InvestorAndFundsFundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Investor___Inves__498EEC8D");

                entity.HasOne(d => d.InvestorAndFundsInvestor)
                    .WithMany()
                    .HasForeignKey(d => d.InvestorAndFundsInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Investor_ID");
            });

            modelBuilder.Entity<Jpm>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_JPMorgan_Date");

                entity.ToTable("JPM");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Jpm)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JPMorgan_Ticker");
            });

            modelBuilder.Entity<Msft>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Microsoft_Date");

                entity.ToTable("MSFT");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Msft)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Microsoft_Ticker");
            });

            modelBuilder.Entity<NasdaqBidToBid>(entity =>
            {
                entity.HasKey(e => e.NasdaqBidToBidDate)
                    .HasName("PK__Nasdaq_B__BF65DEEF2A931A5F");

                entity.ToTable("Nasdaq_BidToBid");

                entity.Property(e => e.NasdaqBidToBidDate)
                    .HasColumnName("Nasdaq_BidToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.NasdaqBidToBidFundId)
                    .IsRequired()
                    .HasColumnName("Nasdaq_BidToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NasdaqBidToBidOneMonth)
                    .HasColumnName("Nasdaq_BidToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.NasdaqBidToBidOneYear)
                    .HasColumnName("Nasdaq_BidToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.NasdaqBidToBidPrice)
                    .HasColumnName("Nasdaq_BidToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.NasdaqBidToBidSinceInception)
                    .HasColumnName("Nasdaq_BidToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.NasdaqBidToBidSixMonth)
                    .HasColumnName("Nasdaq_BidToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.NasdaqBidToBidThreeMonth)
                    .HasColumnName("Nasdaq_BidToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.NasdaqBidToBidYearToDate)
                    .HasColumnName("Nasdaq_BidToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<O39Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_OCBC_Date");

                entity.ToTable("O39.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.O39Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OCBC_Ticker");
            });

            modelBuilder.Entity<PrestigeBidToBid>(entity =>
            {
                entity.HasKey(e => e.PrestigeBidToBidDate)
                    .HasName("PK__Prestige__F16452F7661515F0");

                entity.ToTable("Prestige_BidToBid");

                entity.Property(e => e.PrestigeBidToBidDate)
                    .HasColumnName("Prestige_BidToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrestigeBidToBidFundId)
                    .IsRequired()
                    .HasColumnName("Prestige_BidToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrestigeBidToBidOneMonth)
                    .HasColumnName("Prestige_BidToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeBidToBidOneYear)
                    .HasColumnName("Prestige_BidToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeBidToBidPrice)
                    .HasColumnName("Prestige_BidToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.PrestigeBidToBidSinceInception)
                    .HasColumnName("Prestige_BidToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeBidToBidSixMonth)
                    .HasColumnName("Prestige_BidToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeBidToBidThreeMonth)
                    .HasColumnName("Prestige_BidToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeBidToBidYearToDate)
                    .HasColumnName("Prestige_BidToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<PrestigeDailyMovement>(entity =>
            {
                entity.HasKey(e => e.PrestigeDailyMovementDate)
                    .HasName("PK__Prestige__784CD4C94B55FEC7");

                entity.ToTable("Prestige_DailyMovement");

                entity.Property(e => e.PrestigeDailyMovementDate)
                    .HasColumnName("Prestige_DailyMovement_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrestigeDailyMovementPrestigeDr)
                    .HasColumnName("Prestige_DailyMovement_PrestigeDR")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<PrestigeOfferToBid>(entity =>
            {
                entity.HasKey(e => e.PrestigeOfferToBidDate)
                    .HasName("PK__Prestige__5E254DD1A86BAAC8");

                entity.ToTable("Prestige_OfferToBid");

                entity.Property(e => e.PrestigeOfferToBidDate)
                    .HasColumnName("Prestige_OfferToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrestigeOfferToBidFundId)
                    .IsRequired()
                    .HasColumnName("Prestige_OfferToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrestigeOfferToBidOneMonth)
                    .HasColumnName("Prestige_OfferToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeOfferToBidOneYear)
                    .HasColumnName("Prestige_OfferToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeOfferToBidPrice)
                    .HasColumnName("Prestige_OfferToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.PrestigeOfferToBidPriceAfterAdmin)
                    .HasColumnName("Prestige_OfferToBid_Price_AfterAdmin")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.PrestigeOfferToBidSinceInception)
                    .HasColumnName("Prestige_OfferToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeOfferToBidSixMonth)
                    .HasColumnName("Prestige_OfferToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeOfferToBidThreeMonth)
                    .HasColumnName("Prestige_OfferToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigeOfferToBidYearToDate)
                    .HasColumnName("Prestige_OfferToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<PrestigePerformanceChart>(entity =>
            {
                entity.HasKey(e => e.PrestigePerformanceChartDate)
                    .HasName("PK__Prestige__97EA99433D352804");

                entity.ToTable("Prestige_Performance_Chart");

                entity.Property(e => e.PrestigePerformanceChartDate)
                    .HasColumnName("Prestige_Performance_Chart_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrestigePerformanceChartPrestigeCr)
                    .HasColumnName("Prestige_Performance_Chart_PrestigeCR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.PrestigePerformanceChartSticr)
                    .HasColumnName("Prestige_Performance_Chart_STICR")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<SharesWeightage>(entity =>
            {
                entity.HasKey(e => e.SharesWeightageTicker)
                    .HasName("PK_Shares_Weightage_Ticker");

                entity.ToTable("Shares_Weightage");

                entity.Property(e => e.SharesWeightageTicker)
                    .HasColumnName("Shares_Weightage_Ticker")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SharesWeightageFundId)
                    .IsRequired()
                    .HasColumnName("Shares_Weightage_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SharesWeightageStockName)
                    .IsRequired()
                    .HasColumnName("Shares_Weightage_StockName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SharesWeightageWeight)
                    .HasColumnName("Shares_Weightage_Weight")
                    .HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.SharesWeightageTickerNavigation)
                    .WithOne(p => p.SharesWeightage)
                    .HasForeignKey<SharesWeightage>(d => d.SharesWeightageTicker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shares_Weightage_Ticker");
            });

            modelBuilder.Entity<StiBidToBid>(entity =>
            {
                entity.HasKey(e => e.StiBidToBidDate)
                    .HasName("PK__STI_BidT__7323883B3C2F3C8A");

                entity.ToTable("STI_BidToBid");

                entity.Property(e => e.StiBidToBidDate)
                    .HasColumnName("STI_BidToBid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StiBidToBidFundId)
                    .IsRequired()
                    .HasColumnName("STI_BidToBid_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StiBidToBidOneMonth)
                    .HasColumnName("STI_BidToBid_OneMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.StiBidToBidOneYear)
                    .HasColumnName("STI_BidToBid_OneYear")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.StiBidToBidPrice)
                    .HasColumnName("STI_BidToBid_Price")
                    .HasColumnType("decimal(13, 10)");

                entity.Property(e => e.StiBidToBidSinceInception)
                    .HasColumnName("STI_BidToBid_SinceInception")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.StiBidToBidSixMonth)
                    .HasColumnName("STI_BidToBid_SixMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.StiBidToBidThreeMonth)
                    .HasColumnName("STI_BidToBid_ThreeMonth")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.StiBidToBidYearToDate)
                    .HasColumnName("STI_BidToBid_YearToDate")
                    .HasColumnType("decimal(11, 10)");
            });

            modelBuilder.Entity<StocksOverview>(entity =>
            {
                entity.HasKey(e => e.StocksOverviewTicker)
                    .HasName("PK_Stocks_Overview_Ticker");

                entity.ToTable("Stocks_Overview");

                entity.Property(e => e.StocksOverviewTicker)
                    .HasColumnName("Stocks_Overview_Ticker")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StocksOverviewCurrency)
                    .IsRequired()
                    .HasColumnName("Stocks_Overview_Currency")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StocksOverviewFundId)
                    .IsRequired()
                    .HasColumnName("Stocks_Overview_Fund_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StocksOverviewIndustry)
                    .IsRequired()
                    .HasColumnName("Stocks_Overview_Industry")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StocksOverviewStockName)
                    .IsRequired()
                    .HasColumnName("Stocks_Overview_StockName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.StocksOverviewFund)
                    .WithMany(p => p.StocksOverview)
                    .HasForeignKey(d => d.StocksOverviewFundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stocks_Overview_Ticker");
            });

            modelBuilder.Entity<T39Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_SPH_Date");

                entity.ToTable("T39.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.T39Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPH_Ticker");
            });

            modelBuilder.Entity<U11Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_UOB_Date");

                entity.ToTable("U11.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.U11Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UOB_Ticker");
            });

            modelBuilder.Entity<Uber>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Uber_Date");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Uber)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uber_Ticker");
            });

            modelBuilder.Entity<V03Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_VentureCorp_Date");

                entity.ToTable("V03.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.V03Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureCorp_Ticker");
            });

            modelBuilder.Entity<Wmt>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Walmart_Date");

                entity.ToTable("WMT");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Wmt)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Walmart_Ticker");
            });

            modelBuilder.Entity<Z74Si>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Singtel_Date");

                entity.ToTable("Z74.SI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Z74Si)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Singtel_Ticker");
            });

            modelBuilder.Entity<_5edji>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__DowJones__37EED330E1347647");

                entity.ToTable("%5EDJI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<_5eixic>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Nasdaq__3837F6603AC76081");

                entity.ToTable("%5EIXIC");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<_5esti3fp3d5esti>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__STI__570959A13332F9DF");

                entity.ToTable("%5ESTI%3FP%3D%5ESTI");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dr)
                    .HasColumnName("DR")
                    .HasColumnType("decimal(11, 10)");

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
