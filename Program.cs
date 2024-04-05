using WMP_14_Asset_Tracking;


Console.Title = "Asset Tracker";
Console.SetWindowSize(130, 15);
Console.ForegroundColor = ConsoleColor.White;

decimal usdToSek = 10.68m;
decimal usdToEur = 0.92m;

List<Asset> assetList = new List<Asset>
{
//                  type,       brand,          model,              office,     purchaseDate,                   priceUSD,   currency,   localPriceToday);
    new Computer(   "Computer", "ASUS ROG",     "B550-F",           "Sweden",   new DateOnly(2020, 11, 24),     243,        "SEK",      243 * usdToSek),
    new Computer(   "Computer", "HP",           "14S-FQ1010NO",     "USA",      new DateOnly(2022, 01, 30),     679,        "USD",      679),
    new Phone(      "Computer", "Samsung",      "S20 Plus",         "Sweden",   new DateOnly(2020, 09, 12),     1500,       "SEK",      1500 * usdToSek),
    new Phone(      "Phone",    "Sony Xperia",  "10 III",           "USA",      new DateOnly(2020, 03, 06),     800,        "USD",      800),
    new Phone(      "Phone",    "Iphone",       "10",               "Greece",   new DateOnly(2018, 11, 25),     951,        "EUR",      951 * usdToEur),
    new Computer(   "Computer", "HP",           "Elitebook",        "Greece",   new DateOnly(2021, 08, 30),     2234,       "EUR",      2234 * usdToEur),
    new Computer(   "Computer", "HP",           "Elitebook",        "Sweden",   new DateOnly(2020, 07, 30),     2234,       "SEK",      2234 * usdToSek)
};

static void DisplayAssets(List<Asset> assetList)
{
    int padding = 15;
    DateOnly dateToday = DateOnly.FromDateTime(DateTime.Today);
    assetList = assetList.OrderBy(asset => asset.Type).ThenBy(asset => asset.PurchaseDate).ToList();

    Console.WriteLine("    Type".PadRight(padding) + "Brand".PadRight(padding) + "Model".PadRight(padding) + "Office".PadRight(padding) + "Purchase Date".PadRight(padding) + "Price in USD".PadRight(padding) + "Currency".PadRight(padding) + "Local price today");
    Console.WriteLine("    ----".PadRight(padding) + "-----".PadRight(padding) + "-----".PadRight(padding) + "------".PadRight(padding) + "-------------".PadRight(padding) + "------------".PadRight(padding) + "--------".PadRight(padding) + "-----------------");

    foreach (var asset in assetList)
    {
        var ThreeMonthsBeforeExpired = asset.PurchaseDate.AddYears(2).AddMonths(9);
        var SixMonthsBeforeExpired = asset.PurchaseDate.AddYears(2).AddMonths(6);

        if (dateToday > SixMonthsBeforeExpired && dateToday < ThreeMonthsBeforeExpired)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (ThreeMonthsBeforeExpired < dateToday)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine($"    {asset.Type}".PadRight(padding) + $"{asset.Brand}".PadRight(padding) + $"{asset.Model}".PadRight(padding) + $"{asset.Office}".PadRight(padding) + $"{asset.PurchaseDate}".PadRight(padding) + $"{asset.PriceUSD}".PadRight(padding) + $"{asset.Currency}".PadRight(padding) + $"{asset.LocalPriceToday}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    UserFeedback("\n    Press any key to Continue", false);
    Console.ReadLine();
    ShowMainMenu(assetList);
}

static void AddAssetMenu(List<Asset> assetList)
{
    Console.WriteLine("Enter asset type: ");
    Console.WriteLine("1-Computer");
    Console.WriteLine("2-Phone");
    Console.WriteLine("0-Quit");
    Console.Write("\nEnter a Number: ");
    string userInput = Console.ReadLine();
    Console.Clear();

    switch (userInput)
    {
        case "1":
            AddAsset(assetList, true);
            break;
        case "2":
            AddAsset(assetList, false);
            break;
        case "0":
            UserFeedback("\nThank you for using this application", false);
            break;
        default:
            UserFeedback("Invalid Selection");
            ShowMainMenu(assetList);
            break;
    }
}

static void AddAsset(List<Asset> assetList, bool isComputer)
{
    string brand;
    string model;
    string office;
    DateOnly purchaseDate = default;
    decimal priceUSD;
    string currency;
    decimal localPriceToday = 0;
    decimal usdToSek = 10.68m;
    decimal usdToEur = 0.92m;

    while (true)
    {
        Console.Write("Enter a Brand: ");
        brand = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(brand))
        {
            UserFeedback("Please enter a Brand");
        }
        else
        {
            break;
        }
    }

    while (true)
    {
        Console.Write("Enter a Model: ");
        model = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(model))
        {
            UserFeedback("Please enter a Model");
        }
        else
        {
            break;
        }
    }

    while (true)
    {
        Console.Write("Enter an Office: ");
        office = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(office))
        {
            UserFeedback("Please enter an Office");
        }
        else
        {
            break;
        }
    }
    while (true)
    {
        Console.Write("Enter a Date (yyyy-MM-dd): ");
        string inputDate = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputDate))
        {
            UserFeedback("Please enter a date, ex: 2020-01-01");
        }
        else if (DateOnly.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out purchaseDate))
        {
            break;
        }
        else
        {
            UserFeedback("Invalid date format. Please enter a valid date in the format yyyy-MM-dd");
        }
    }
    while (true)
    {
        Console.Write("Enter a Price in USD: ");
        if (!decimal.TryParse(Console.ReadLine(), out priceUSD))
        {
            UserFeedback("Invalid price format. Please enter a valid decimal number.");
        }
        else
        {
            break;
        }
    }
    while (true)
    {
        Console.Write("Enter a Currency (SEK,USD,EUR): ");
        currency = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(currency))
        {
            UserFeedback("Please enter your local Currency");
        }
        else
        {
            break;
        }
    }

    switch (currency)
    {
        case "SEK":
            localPriceToday = priceUSD * usdToSek;
            break;
        case "EUR":
            localPriceToday = priceUSD * usdToEur;
            break;
        case "USD":
            localPriceToday = priceUSD;
            break;
    }

    if (isComputer)
    {// brand,model,office,purchaseDate,priceUSD,currency,localPriceToday);
        string type = "Computer";
        Asset asset = new Computer(type, brand, model, office, purchaseDate, priceUSD, currency, localPriceToday);
        assetList.Add(asset);
    }
    else
    {
        string type = "Phone";
        Asset asset = new Phone(type, brand, model, office, purchaseDate, priceUSD, currency, localPriceToday);
        assetList.Add(asset);
    }
    UserFeedback("Your Asset was successfully added", false);
    UserFeedback("\nPress any key to Continue", false);
    Console.ReadLine();
    ShowMainMenu(assetList);
}
static void ShowMainMenu(List<Asset> assetList)
{
    Console.Clear();
    Console.WriteLine("1-Add an Asset");
    Console.WriteLine("2-List Products");
    Console.WriteLine("0-Quit");
    Console.Write("\nEnter a Number: ");
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.Clear();
            AddAssetMenu(assetList);
            break;
        case "2":
            Console.Clear();
            DisplayAssets(assetList);
            break;
        case "0":
            Console.Clear();
            UserFeedback("\nThank you for using this application", false);
            break;
        default:
            UserFeedback("Invalid Selection");
            ShowMainMenu(assetList);
            break;
    }

}
static void UserFeedback(string msg, bool errorMsg = true)
{
    if (errorMsg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

}

ShowMainMenu(assetList);
