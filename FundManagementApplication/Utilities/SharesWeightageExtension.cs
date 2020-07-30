using FundManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Utilities {
    public static class SharesWeightageExtension {

        public static IEnumerable<SharesWeightage> ConvertToPercentage(this IEnumerable<SharesWeightage> sharesWeightages, decimal totalWeight) {
            foreach(SharesWeightage sw in sharesWeightages) {
                sw.SharesWeightageWeight *= 100 / totalWeight;
                yield return sw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sws"></param>
        /// <returns></returns>
        public static IEnumerable<HoldingsDto> TurnIntoHoldingsDto(this IEnumerable<SharesWeightage> sws) {
            foreach(SharesWeightage sw in sws) {

                yield return new HoldingsDto {
                    Name = sw.SharesWeightageStockName,
                    Ticker = sw.SharesWeightageTicker,
                    Weight = sw.SharesWeightageWeight
                };
            }
        }
    }
}
