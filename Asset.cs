namespace WMP_14_Asset_Tracking
{
    internal class Asset(string type, string brand, string model, string office, DateTime purchaseDate, decimal priceUSD, string currency, decimal localPriceToday)
    {
        public string Type { get; set; } = type;
        public string Brand { get; set; } = brand;
        public string Model { get; set; } = model;
        public string Office { get; set; } = office;
        public DateTime PurchaseDate { get; set; } = purchaseDate;
        public decimal PriceUSD { get; set; } = priceUSD;
        public string Currency { get; set; } = currency;
        public decimal LocalPriceToday { get; set; } = localPriceToday;
    }
}
