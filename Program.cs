/*
#Asset Tracking.

This project is the start of an Asset Tracking database. 
It should have input possibilities from a user and print out functionality of user data.
Asset Tracking is a way to keep track of the company assets, like Laptops, Stationary computers, Phones and so
on...
All assets have an end of life which for simplicity reasons is 3 years.

*** Classes ***

Assets <- parent class.
Computers (obj: Macbook, Asus, Lenovo....)
Phones (obj: Iphone, Samsung, Nokia....)

*** Props *** 
*
*/
using WMP_14_Asset_Tracking;

Console.SetWindowSize(140, 20);
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


DisplayAssets(assetList);
static void DisplayAssets(List<Asset> assetList)
{
    int padding = 15;
    DateOnly endDate = DateOnly.FromDateTime(DateTime.Today);
    Console.WriteLine("Type".PadRight(padding) + "Brand".PadRight(padding) + "Model".PadRight(padding) + "Office".PadRight(padding) + "Purchase Date".PadRight(padding) + "Price in USD".PadRight(padding) + "Currency".PadRight(padding) + "Local price today");
    Console.WriteLine("----".PadRight(padding) + "-----".PadRight(padding) + "-----".PadRight(padding) + "------".PadRight(padding) + "-------------".PadRight(padding) + "------------".PadRight(padding) + "--------".PadRight(padding) + "-----------------");
    foreach (var asset in assetList)
    {
        if (asset.PurchaseDate.AddYears(3) < endDate)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{asset.Type}".PadRight(padding) + $"{asset.Brand}".PadRight(padding) + $"{asset.Model}".PadRight(padding) + $"{asset.Office}".PadRight(padding) + $"{asset.PurchaseDate}".PadRight(padding) + $"{asset.PriceUSD}".PadRight(padding) + $"{asset.Currency}".PadRight(padding) + $"{asset.LocalPriceToday}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"{asset.Type}".PadRight(padding) + $"{asset.Brand}".PadRight(padding) + $"{asset.Model}".PadRight(padding) + $"{asset.Office}".PadRight(padding) + $"{asset.PurchaseDate}".PadRight(padding) + $"{asset.PriceUSD}".PadRight(padding) + $"{asset.Currency}".PadRight(padding) + $"{asset.LocalPriceToday}");
        }
    }

}


//for (int i = 0; i < 10; i++)
//{

//    // Call the method to generate a random date
//    DateOnly randomDate = GenerateRandomDate(startDate, endDate);



//    if (randomDate.AddYears(3) < endDate) {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"{randomDate:yyyy-MM-dd}");
//        Console.ForegroundColor = ConsoleColor.Green;
//    }
//    else
//    {
//    // Output the random date
//    Console.WriteLine($"{randomDate:yyyy-MM-dd}");
//    }
//}


//static DateOnly GenerateRandomDate(DateOnly startDate, DateOnly endDate)
//{
//    // Convert DateOnly to DateTime for arithmetic operations
//    DateTime startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day);
//    DateTime endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day);

//    // Create an instance of Random class
//    Random random = new Random();

//    // Generate a random number of days to add to the start date
//    int range = (int)(endDateTime - startDateTime).TotalDays;
//    DateTime randomDateTime = startDateTime.AddDays(random.Next(range));

//    // Convert random DateTime back to DateOnly
//    DateOnly randomDate = new DateOnly(randomDateTime.Year, randomDateTime.Month, randomDateTime.Day);

//    return randomDate;
//}