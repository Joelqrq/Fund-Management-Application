using FundManagementApplication.ViewModels;
using System.Collections.Generic;

namespace FundManagementApplication.Utilities {
    public static class StaticListOfStocks {
        public static List<StockViewModel> PrestigeStaticListOfStocks { get; } = new List<StockViewModel>() {
            new StockViewModel() {
                ShareName = "Frasers Centrepoint Trust",
                Ticker = "J69U.SI",
                Sector = "Real Estate",
            },
            new StockViewModel() {
                ShareName = "AEM Holdings Ltd",
                Ticker = "AWX.SI",
                Sector = "Technology",
            },
            new StockViewModel() {
                ShareName = "Mapletree Commercial Trust",
                Ticker = "N2IU.SI",
                Sector = "Real Estate",
            },
            new StockViewModel() {
                ShareName = "Genting Singapore Limited",
                Ticker = "G13.SI",
                Sector = "Consumer Cyclical",
            },
            new StockViewModel() {
                ShareName = "SBS Transit Ltd",
                Ticker = "S61.SI",
                Sector = "Industrials",
            },
            new StockViewModel() {
                ShareName = "Far East Orchard Limited",
                Ticker = "O10.SI",
                Sector = "Real Estate",
            },
            new StockViewModel() {
                ShareName = "Chip Eng Seng Corporation Ltd ",
                Ticker = "C29.SI",
                Sector = "Real Estate",
            },
            new StockViewModel() {
                ShareName = "NSL Ltd",
                Ticker = "N02.SI",
                Sector = "Basic Materials",
            },
            new StockViewModel() {
                ShareName = "Jardine Matheson Holdings Limited",
                Ticker = "J36.SI",
                Sector = "Industrials",
            },
            new StockViewModel() {
                ShareName = "Wilmar International Limited ",
                Ticker = "F34.SI",
                Sector = "Consumer Defensive",
            },
        };

        public static List<StockViewModel> GlobalStaticListOfStocks { get; } = new List<StockViewModel>() {
            new StockViewModel() {
                ShareName = "Tesla",
                Ticker = "TSLA",
                Sector = "Consumer Cyclical",
            },
            new StockViewModel() {
                ShareName = "Nikola",
                Ticker = "NKLA",
                Sector = "Consumer Cyclical",
            },
            new StockViewModel() {
                ShareName = "Nvidia",
                Ticker = "NVDA",
                Sector = "Technology",
            },
            new StockViewModel() {
                ShareName = "Paypal",
                Ticker = "PYPL",
                Sector = "Credit Services",
            },
            new StockViewModel() {
                ShareName = "Amazon",
                Ticker = "AMZN",
                Sector = "Internet Retail",
            },
            new StockViewModel() {
                ShareName = "ebay Inc",
                Ticker = "EBAY",
                Sector = "Internet Retail",
            },
            new StockViewModel() {
                ShareName = "Regeneron Pharmaceuticals, Inc",
                Ticker = "REGN",
                Sector = "Biotechnology",
            },
            new StockViewModel() {
                ShareName = "Zoom Video Communications, Inc",
                Ticker = "ZM",
                Sector = "Telecom Services",
            },
            new StockViewModel() {
                ShareName = "Facebook, Inc.",
                Ticker = "FB",
                Sector = "Internet Content & Information",
            },
            new StockViewModel() {
                ShareName = "Shopify Inc.",
                Ticker = "SHOP",
                Sector = "Software-Application",
            },
        };
    }
}
