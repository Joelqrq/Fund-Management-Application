using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class GlobalPerformanceChart
    {
        public DateTime GlobalPerformanceChartDate { get; set; }
        public decimal GlobalPerformanceChartGlobalCr { get; set; }
        public decimal GlobalPerformanceChartNasdaqCr { get; set; }
        public decimal GlobalPerformanceChartDowJonesCr { get; set; }
    }
}
