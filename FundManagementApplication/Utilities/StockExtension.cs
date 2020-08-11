using FundManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Utilities {
    public static class StockExtension {

        public static IEnumerable<Stock> ConvertToPercentage(this IEnumerable<Stock> stocks, decimal totalWeight) {
            foreach(var stock in stocks) {
                stock.Weight *= 100 / totalWeight;
                yield return stock;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sws"></param>
        /// <returns></returns>
        public static IEnumerable<HoldingsDto> TurnIntoHoldingsDto(this IEnumerable<Stock> stocks) {
            foreach(var stock in stocks) {

                yield return new HoldingsDto {
                    Name = stock.Name,
                    Ticker = stock.Ticker,
                    Weight = stock.Weight.ToString("0.##")
                };
            }
        }
    }
}
