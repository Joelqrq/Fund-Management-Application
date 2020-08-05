﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models {

    public class FundFactSheetDto {
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
        public List<string> Date { get; set; }
        /// <summary>
        /// List of performance data to be displayed.
        /// </summary>
        public List<PerformanceDto> Performances { get; set; }
    }

    public class PerformanceDto {
        public string Name { get; set; }
        //Assuming date and cumulativereturn have same count
        public List<decimal> CumulativeReturns { get; set; }
    }

    public class FundDetailsDto {
        public decimal InitialFee { get; set; }
        public DateTime InceptionDate { get; set; }
        public string FundManagerName { get; set; }
        public decimal FundSize { get; set; }
        public decimal AnnualizeReturns { get; set; }
        public string StockCurrency { get; set; }
        public string BenchmarkName { get; set; }
        public decimal TotalHoldings { get; set; }
        public string FundName { get; set; }
    }

    public class PerformanceTableDto {
        public PerformanceTableColumnDto BidToBid { get; set; }
        public PerformanceTableColumnDto OfferToBid { get; set; }
        public PerformanceTableColumnDto Benchmark { get; set; }
    }

    public class PerformanceTableColumnDto {
        public decimal OneMonth { get; set; }
        public decimal ThreeMonth { get; set; }
        public decimal SixMonth { get; set; }
        public decimal OneYear { get; set; }
        public decimal YearToDate { get; set; }
        public decimal SinceInception { get; set; }
    }
}
