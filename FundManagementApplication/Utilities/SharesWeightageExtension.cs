using FundManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Utilities {
    public static class SharesWeightageExtension {

        public static IEnumerable<Shares_Weightage> ConvertToPercentage(this IEnumerable<Shares_Weightage> sharesWeightages, decimal totalWeight) {
            foreach(var sw in sharesWeightages) {
                sw.Shares_Weightage_Weight *= 100 / totalWeight;
                yield return sw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sws"></param>
        /// <returns></returns>
        public static IEnumerable<HoldingsDto> TurnIntoHoldingsDto(this IEnumerable<Shares_Weightage> sws) {
            foreach(var sw in sws) {

                yield return new HoldingsDto {
                    Name = sw.Shares_Weightage_StockName,
                    Ticker = sw.Shares_Weightage_Ticker,
                    Weight = sw.Shares_Weightage_Weight.ToString("0.##")
                };
            }
        }
    }
}
