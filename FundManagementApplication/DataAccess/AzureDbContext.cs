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
        public virtual DbSet<C31_SI> C31_SI { get; set; }
        public virtual DbSet<C52_SI> C52_SI { get; set; }
        public virtual DbSet<C6L_SI> C6L_SI { get; set; }
        public virtual DbSet<CC3_SI> CC3_SI { get; set; }
        public virtual DbSet<D05_SI> D05_SI { get; set; }
        public virtual DbSet<DowJones_BidToBid> DowJones_BidToBid { get; set; }
        public virtual DbSet<F> F { get; set; }
        public virtual DbSet<Fund_Manager> Fund_Manager { get; set; }
        public virtual DbSet<Funds> Funds { get; set; }
        public virtual DbSet<Funds_and_Fund_Manager> Funds_and_Fund_Manager { get; set; }
        public virtual DbSet<GE> GE { get; set; }
        public virtual DbSet<GM> GM { get; set; }
        public virtual DbSet<GOOG> GOOG { get; set; }
        public virtual DbSet<Global_BidToBid> Global_BidToBid { get; set; }
        public virtual DbSet<Global_DailyMovement> Global_DailyMovement { get; set; }
        public virtual DbSet<Global_OfferToBid> Global_OfferToBid { get; set; }
        public virtual DbSet<Global_Performance_Chart> Global_Performance_Chart { get; set; }
        public virtual DbSet<IBM> IBM { get; set; }
        public virtual DbSet<Investor> Investor { get; set; }
        public virtual DbSet<Investor_and_Funds> Investor_and_Funds { get; set; }
        public virtual DbSet<JPM> JPM { get; set; }
        public virtual DbSet<MSFT> MSFT { get; set; }
        public virtual DbSet<Nasdaq_BidToBid> Nasdaq_BidToBid { get; set; }
        public virtual DbSet<O39_SI> O39_SI { get; set; }
        public virtual DbSet<Prestige_BidToBid> Prestige_BidToBid { get; set; }
        public virtual DbSet<Prestige_DailyMovement> Prestige_DailyMovement { get; set; }
        public virtual DbSet<Prestige_OfferToBid> Prestige_OfferToBid { get; set; }
        public virtual DbSet<Prestige_Performance_Chart> Prestige_Performance_Chart { get; set; }
        public virtual DbSet<STI_BidToBid> STI_BidToBid { get; set; }
        public virtual DbSet<Shares_Weightage> Shares_Weightage { get; set; }
        public virtual DbSet<Stocks_Overview> Stocks_Overview { get; set; }
        public virtual DbSet<T39_SI> T39_SI { get; set; }
        public virtual DbSet<U11_SI> U11_SI { get; set; }
        public virtual DbSet<Uber> Uber { get; set; }
        public virtual DbSet<V03_SI> V03_SI { get; set; }
        public virtual DbSet<WMT> WMT { get; set; }
        public virtual DbSet<Z74_SI> Z74_SI { get; set; }
        public virtual DbSet<_5EDJI> _5EDJI { get; set; }
        public virtual DbSet<_5EIXIC> _5EIXIC { get; set; }
        public virtual DbSet<_5ESTI_3FP_3D_5ESTI> _5ESTI_3FP_3D_5ESTI { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Auto generated
            modelBuilder.Entity<C>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_CitiGroup_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitiGroup_Ticker");
            });

            modelBuilder.Entity<C31_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Capitaland_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C31_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Capitaland_Ticker");
            });

            modelBuilder.Entity<C52_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_ComfortDelgro_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C52_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComfortDelgro_Ticker");
            });

            modelBuilder.Entity<C6L_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_SIA_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.C6L_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIA_Ticker");
            });

            modelBuilder.Entity<CC3_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Starhub_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.CC3_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Starhub_Ticker");
            });

            modelBuilder.Entity<D05_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_DBS_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.D05_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DBS_Ticker");
            });

            modelBuilder.Entity<DowJones_BidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__DowJones__2FB9939D5B9B12BE");

                entity.Property(e => e.Fund_ID).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<F>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_FordMotor_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.F)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FordMotor_Ticker");
            });

            modelBuilder.Entity<Fund_Manager>(entity =>
            {
                entity.HasKey(e => e.PK_FundManager_ID)
                    .HasName("PK__Fund_Man__CEDE3E8F1E6901A5");

                entity.Property(e => e.PK_FundManager_ID).IsUnicode(false);

                entity.Property(e => e.FundManagerEmail).IsUnicode(false);

                entity.Property(e => e.FundManagerName).IsUnicode(false);

                entity.Property(e => e.FundManagerPassword).IsUnicode(false);
            });

            modelBuilder.Entity<Funds>(entity =>
            {
                entity.HasKey(e => e.PK_Fund_ID)
                    .HasName("PK__Funds__C09F6E2C024DCA67");

                entity.Property(e => e.PK_Fund_ID).IsUnicode(false);

                entity.Property(e => e.FundManager_ID).IsUnicode(false);

                entity.Property(e => e.FundName).IsUnicode(false);
            });

            modelBuilder.Entity<Funds_and_Fund_Manager>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Funds_and_Fund_Manager_FundManager_ID).IsUnicode(false);

                entity.Property(e => e.Funds_and_Fund_Manager_Fund_ID).IsUnicode(false);

                entity.HasOne(d => d.Funds_and_Fund_Manager_FundManager_)
                    .WithMany()
                    .HasForeignKey(d => d.Funds_and_Fund_Manager_FundManager_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Funds_and__Funds__59063A47");

                entity.HasOne(d => d.Funds_and_Fund_Manager_Fund_)
                    .WithMany()
                    .HasForeignKey(d => d.Funds_and_Fund_Manager_Fund_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Funds_and__Funds__47A6A41B");
            });

            modelBuilder.Entity<GE>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_GeneralElectric_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.GE)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralElectric_Ticker");
            });

            modelBuilder.Entity<GM>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_GeneralMotors_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.GM)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralMotors_Ticker");
            });

            modelBuilder.Entity<GOOG>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Google_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.GOOG)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Google_Ticker");
            });

            modelBuilder.Entity<Global_BidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_B__983F096E50161DE3");

                entity.Property(e => e.Fund_ID).IsUnicode(false);
            });

            modelBuilder.Entity<Global_DailyMovement>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_D__839134E6D4584340");
            });

            modelBuilder.Entity<Global_OfferToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_O__1DCBD916C9E49E3F");

                entity.Property(e => e.Fund_ID).IsUnicode(false);
            });

            modelBuilder.Entity<Global_Performance_Chart>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Global_P__8C2394DECF5A74D5");
            });

            modelBuilder.Entity<IBM>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_IBM_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.IBM)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IBM_Ticker");
            });

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.HasKey(e => e.PK_Investor_ID)
                    .HasName("PK_Investor_ID");

                entity.Property(e => e.PK_Investor_ID).IsUnicode(false);

                entity.Property(e => e.InvestorEmail).IsUnicode(false);

                entity.Property(e => e.InvestorName).IsUnicode(false);
            });

            modelBuilder.Entity<Investor_and_Funds>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Investor_and_Funds_Fund_ID).IsUnicode(false);

                entity.Property(e => e.Investor_and_Funds_Investor_ID).IsUnicode(false);

                entity.HasOne(d => d.Investor_and_Funds_Fund_)
                    .WithMany()
                    .HasForeignKey(d => d.Investor_and_Funds_Fund_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Investor___Inves__498EEC8D");

                entity.HasOne(d => d.Investor_and_Funds_Investor_)
                    .WithMany()
                    .HasForeignKey(d => d.Investor_and_Funds_Investor_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Investor_ID");
            });

            modelBuilder.Entity<JPM>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_JPMorgan_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.JPM)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JPMorgan_Ticker");
            });

            modelBuilder.Entity<MSFT>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Microsoft_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.MSFT)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Microsoft_Ticker");
            });

            modelBuilder.Entity<Nasdaq_BidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Nasdaq_B__BF65DEEF2A931A5F");

                entity.Property(e => e.Fund_ID).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<O39_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_OCBC_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.O39_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OCBC_Ticker");
            });

            modelBuilder.Entity<Prestige_BidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__F16452F7661515F0");

                entity.Property(e => e.Fund_ID).IsUnicode(false);
            });

            modelBuilder.Entity<Prestige_DailyMovement>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__784CD4C94B55FEC7");
            });

            modelBuilder.Entity<Prestige_OfferToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__5E254DD1A86BAAC8");

                entity.Property(e => e.Fund_ID).IsUnicode(false);
            });

            modelBuilder.Entity<Prestige_Performance_Chart>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Prestige__97EA99433D352804");
            });

            modelBuilder.Entity<STI_BidToBid>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__STI_BidT__7323883B3C2F3C8A");

                entity.Property(e => e.Fund_ID).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Shares_Weightage>(entity =>
            {
                entity.HasKey(e => e.Shares_Weightage_Ticker)
                    .HasName("PK_Shares_Weightage_Ticker");

                entity.Property(e => e.Shares_Weightage_Ticker).IsUnicode(false);

                entity.Property(e => e.Shares_Weightage_Fund_ID).IsUnicode(false);

                entity.Property(e => e.Shares_Weightage_StockName).IsUnicode(false);

                entity.HasOne(d => d.Shares_Weightage_TickerNavigation)
                    .WithOne(p => p.Shares_Weightage)
                    .HasForeignKey<Shares_Weightage>(d => d.Shares_Weightage_Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shares_Weightage_Ticker");
            });

            modelBuilder.Entity<Stocks_Overview>(entity =>
            {
                entity.HasKey(e => e.Stocks_Overview_Ticker)
                    .HasName("PK_Stocks_Overview_Ticker");

                entity.Property(e => e.Stocks_Overview_Ticker).IsUnicode(false);

                entity.Property(e => e.Stocks_Overview_Currency).IsUnicode(false);

                entity.Property(e => e.Stocks_Overview_Fund_ID).IsUnicode(false);

                entity.Property(e => e.Stocks_Overview_Industry).IsUnicode(false);

                entity.Property(e => e.Stocks_Overview_StockName).IsUnicode(false);

                entity.HasOne(d => d.Stocks_Overview_Fund_)
                    .WithMany(p => p.Stocks_Overview)
                    .HasForeignKey(d => d.Stocks_Overview_Fund_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stocks_Overview_Ticker");
            });

            modelBuilder.Entity<T39_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_SPH_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.T39_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPH_Ticker");
            });

            modelBuilder.Entity<U11_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_UOB_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.U11_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UOB_Ticker");
            });

            modelBuilder.Entity<Uber>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Uber_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Uber)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uber_Ticker");
            });

            modelBuilder.Entity<V03_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_VentureCorp_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.V03_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureCorp_Ticker");
            });

            modelBuilder.Entity<WMT>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Walmart_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.WMT)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Walmart_Ticker");
            });

            modelBuilder.Entity<Z74_SI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_Singtel_Date");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.HasOne(d => d.TickerNavigation)
                    .WithMany(p => p.Z74_SI)
                    .HasForeignKey(d => d.Ticker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Singtel_Ticker");
            });

            modelBuilder.Entity<_5EDJI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__DowJones__37EED330E1347647");

                entity.Property(e => e.Ticker).IsUnicode(false);
            });

            modelBuilder.Entity<_5EIXIC>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Nasdaq__3837F6603AC76081");

                entity.Property(e => e.Ticker).IsUnicode(false);
            });

            modelBuilder.Entity<_5ESTI_3FP_3D_5ESTI>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__STI__570959A13332F9DF");

                entity.Property(e => e.Ticker).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
