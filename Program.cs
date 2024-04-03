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

DateOnly startDate = new DateOnly(2020, 1, 1);
DateOnly endDate = DateOnly.FromDateTime(DateTime.Today);

decimal usdToSek = 10.68m;
decimal usdToEur = 0.92m;
decimal amount = 124;
decimal dollarToEuro = amount * usdToEur;
decimal dollarToSek = amount * usdToSek;

Console.WriteLine(amount + " USD is : " + dollarToEuro + " EUR");
Console.WriteLine(amount + " USD is : " + dollarToSek + " SEK");

for (int i = 0; i < 10; i++)
{

    // Call the method to generate a random date
    DateOnly randomDate = GenerateRandomDate(startDate, endDate);


    
    if (randomDate.AddYears(3) < endDate) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{randomDate:yyyy-MM-dd}");
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else
    {
    // Output the random date
    Console.WriteLine($"{randomDate:yyyy-MM-dd}");
    }
}


static DateOnly GenerateRandomDate(DateOnly startDate, DateOnly endDate)
{
    // Convert DateOnly to DateTime for arithmetic operations
    DateTime startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day);
    DateTime endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day);

    // Create an instance of Random class
    Random random = new Random();

    // Generate a random number of days to add to the start date
    int range = (int)(endDateTime - startDateTime).TotalDays;
    DateTime randomDateTime = startDateTime.AddDays(random.Next(range));

    // Convert random DateTime back to DateOnly
    DateOnly randomDate = new DateOnly(randomDateTime.Year, randomDateTime.Month, randomDateTime.Day);

    return randomDate;
}