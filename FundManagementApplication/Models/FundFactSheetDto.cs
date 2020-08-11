using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models {

    public class FundFactSheetDto {
        public string FundProfile { get; set; }
        public IEnumerable<HoldingsDto> Holdings { get; set; }
        public IEnumerable<SectorDto> Sectors { get; set; }
        public PerformanceChartDto PerformanceCharts { get; set; }
        public FundDetailsDto FundDetails { get; set; }
        public PerformanceTableDto PerformanceTable { get; set; }
    }

    public class HoldingsDto {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Weight { get; set; }
    }

    public class SectorDto {
        public string Name { get; set; }
        public string Percentage { get; set; }
    }

    public class PerformanceChartDto {
        public List<DateTime> Date { get; set; }
        /// <summary>
        /// List of performance data to be displayed.
        /// </summary>
        public List<PerformanceDto> Performances { get; set; }
    }

    public class PerformanceDto {
        public string Name { get; set; }
        //Assuming date and cumulativereturn have same count
        public List<string> CumulativeReturns { get; set; }
    }

    public class FundDetailsDto {
        public string InitialFee { get; set; }
        public DateTime InceptionDate { get; set; }
        public string FundManagerName { get; set; }
        public decimal FundSize { get; set; }
        public string AnnualizeReturns { get; set; }
        public string StockCurrency { get; set; }
        public List<string> BenchmarkNames { get; set; }
        public decimal TotalHoldings { get; set; }
        public string FundName { get; set; }
    }

    public class PerformanceTableDto {
        public List<PerformanceTableColumnDto> Performances { get; set; }
    }

    public class PerformanceTableColumnDto {
        public string Name { get; set; }
        public string OneMonth { get; set; }
        public string ThreeMonth { get; set; }
        public string SixMonth { get; set; }
        public string OneYear { get; set; }
        public string YearToDate { get; set; }
        public string SinceInception { get; set; }
    }
}
