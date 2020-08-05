using System.Collections.Generic;
using System.Threading.Tasks;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                PerformanceCharts = new PerformanceChartDto() {
                    Date = new List<string>() {
                        "02-03-1992",
                        "03-23-1903",
                        "02-03-2000",
                        "03-23-2001",
                        "02-03-2005",
                        "03-23-2008"
                    },
                    Performances = new List<PerformanceDto>() {
                        new PerformanceDto() {
                            Name = "Global",
                            CumulativeReturns = new List<decimal>(){
                                300, 2000, 30, 1510, 5000, 3000,
                            }
                        },
                        new PerformanceDto() {
                            Name = "BenchmarkA",
                            CumulativeReturns = new List<decimal>(){
                                500, 6000, 5550, 60, 250, 8000
                            }
                        },
                        new PerformanceDto() {
                            Name = "BenchmarkB",
                            CumulativeReturns = new List<decimal>(){
                                200, 8700, 2000, 5500, 2005, 87,
                            }
                        },
                        new PerformanceDto() {
                            Name = "BenchmarkC",
                            CumulativeReturns = new List<decimal>(){
                                200, 1000, 200000, 55000, 20005, 807,
                            }
                        }
                    }
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
    }
}