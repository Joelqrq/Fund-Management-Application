using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FundManagementApplication.Controllers {
    public class HomeController : Controller {

        public IActionResult FactSheetHtml() {
            FundFactSheetDto model = new FundFactSheetDto() {
                Holdings = new List<HoldingsDto>() { new HoldingsDto() {
                    Name = "Test", Ticker = "TestTicker", Weight = "TestWeight" },
                    new HoldingsDto() {
                    Name = "Test1", Ticker = "TestTicker1", Weight = "TestWeight1" } },
                Sectors = new List<SectorDto>() { new SectorDto() {
                    Name = "TestSector",
                    Percentage = "TestPercentage"
                }},
                PerformanceCharts = new List<PerformanceChartDto>() {

                },
                FundDetails = new FundDetailsDto() {

                },
                PerformanceTable = new PerformanceTableDto() {
                    BidToBid = new PerformanceTableColumnDto(),
                    OfferToBid = new PerformanceTableColumnDto(),
                    Benchmark = new PerformanceTableColumnDto()
                }
            };

            return View("FactSheet", model);
        }


        public IActionResult FactSheetPDF() {
            FundFactSheetDto model = new FundFactSheetDto() {
                Holdings = new List<HoldingsDto>() { new HoldingsDto() {
                    Name = "Test", Ticker = "TestTicker", Weight = "TestWeight" },
                    new HoldingsDto() {
                    Name = "Test1", Ticker = "TestTicker1", Weight = "TestWeight1" } },
                Sectors = new List<SectorDto>() { new SectorDto() {
                    Name = "TestSector",
                    Percentage = "TestPercentage"
                }},
                PerformanceCharts = new List<PerformanceChartDto>() {

                },
                FundDetails = new FundDetailsDto() {

                },
                PerformanceTable = new PerformanceTableDto() {
                    BidToBid = new PerformanceTableColumnDto(),
                    OfferToBid = new PerformanceTableColumnDto(),
                    Benchmark = new PerformanceTableColumnDto()
                }
            };

            return new ViewAsPdf("FactSheet", model);
        }
    }
}
