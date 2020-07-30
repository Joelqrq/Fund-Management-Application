using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Services {
    public class FundFactSheetGenerator {

        public FundFactSheetGenerator() {

        }

        public async Task<FundFactSheetDto> GenerateFactSheet(AzureDbContext azureDb, string fund, string date) {

            FundFactSheetDto fundFactSheetModel = new FundFactSheetDto();

            //Retrieve information in database according to given date.
            fundFactSheetModel.Holdings = await ArrangeHoldings(azureDb.SharesWeightage, fund);
            fundFactSheetModel.Sectors = await ArrangeSectors(azureDb.StocksOverview, fund);

            return null;
        }

        private async Task<IEnumerable<HoldingsDto>> ArrangeHoldings(DbSet<SharesWeightage> sharesWeightage, string fund) {

            //Retrieve from database
            var weightages = await sharesWeightage.AsNoTracking()
                                                  .Where(sw => sw.SharesWeightageFundId == fund)
                                                  .ToListAsync();

            //Sum total weight with retrieved list
            var totalWeight = weightages.Select(sw => sw.SharesWeightageWeight)
                                        .Sum();

            //Sort them by weight in descending order and convert weight into percentage
            return weightages.OrderByDescending(sw => sw.SharesWeightageWeight)
                             .ConvertToPercentage(totalWeight)
                             .TurnIntoHoldingsDto();
        }

        private async Task<IEnumerable<SectorDto>> ArrangeSectors(DbSet<StocksOverview> stocksOverviews, string fund) {

            var industryList = await stocksOverviews.AsNoTracking()
                                                    .Where(so => so.StocksOverviewFundId == fund)
                                                    .ToListAsync();

            return industryList.GroupBy(so => so.StocksOverviewIndustry, (key, result) => new SectorDto {
                Name = key,
                Percentage = result.Count() * 100 / industryList.Count()
            }).OrderByDescending(so => so.Percentage);
        }
    }
}
