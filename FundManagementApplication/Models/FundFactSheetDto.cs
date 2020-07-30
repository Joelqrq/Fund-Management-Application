using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models {

    public class FundFactSheetDto {
        public IEnumerable<HoldingsDto> Holdings { get; set; }
        public IEnumerable<SectorDto> Sectors { get; set; }
    }

    public class HoldingsDto {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal Weight { get; set; }
    }

    public class SectorDto {
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }
}
