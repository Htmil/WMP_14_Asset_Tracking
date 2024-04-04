namespace WMP_14_Asset_Tracking
{
    internal class Asset(string type, string brand, string model, string office, DateOnly purchaseDate, decimal priceUSD, string currency, decimal localPriceToday)
    {
        public string Type { get; set; } = type;
        public string Brand { get; set; } = brand;
        public string Model { get; set; } = model;
        public string Office { get; set; } = office;
        public DateOnly PurchaseDate { get; set; } = purchaseDate;
        public decimal PriceUSD { get; set; } = priceUSD;
        public string Currency { get; set; } = currency;
        public decimal LocalPriceToday { get; set; } = localPriceToday;
    }

    internal class Computer : Asset
    {
        public Computer(string type, string brand, string model, string office, DateOnly purchaseDate, decimal priceUSD, string currency, decimal localPriceToday) : base(type, brand, model, office, purchaseDate, priceUSD, currency, localPriceToday)
        {
        }
    }
    internal class Phone : Asset
    {
        public Phone(string type, string brand, string model, string office, DateOnly purchaseDate, decimal priceUSD, string currency, decimal localPriceToday) : base(type, brand, model, office, purchaseDate, priceUSD, currency, localPriceToday)
        {
        }
    }
}
