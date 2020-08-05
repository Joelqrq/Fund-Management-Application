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
                        "02-01-2019",
                        "02-02-2019",
                        "04-03-2019",
                        "05-04-2019",
                        "06-03-2019",
                        "07-23-2019",
                        "08-23-2019",
                        "09-23-2019",
                        "10-23-2019",
                        "11-23-2019"

                    },
                    Performances = new List<PerformanceDto>() {
                        new PerformanceDto() {
                            Name = "Global",
                            CumulativeReturns = new List<decimal>(){
                                300, 2000, 300000, 1510, 5000, 3000,2000,1000,1500,4000
                            }
                        },
                        new PerformanceDto() {
                            Name = "BenchmarkA",
                            CumulativeReturns = new List<decimal>(){
                                500, 6000, 15550, 60, 250, 8000,2000,1000,1500,5000
                            }
                        },
                        new PerformanceDto() {
                            Name = "BenchmarkB",
                            CumulativeReturns = new List<decimal>(){
                                200, 8700, 100000, 5500, 2005, 87,2000,1000,1500,7000
                            }
                        },
                        new PerformanceDto() {
                            Name = "BenchmarkC",
                            CumulativeReturns = new List<decimal>(){
                                200, 1000, 200000, 55000, 20005, 807,2000,1000,1500,8000
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