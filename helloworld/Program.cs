// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, vbcbcvbWorld!");

// string[] myGroceryArray = new string[2];
// myGroceryArray[0] = "cheese";
// myGroceryArray[1] = "ice cream";

// Console.WriteLine(myGroceryArray[0]);
// Console.WriteLine(myGroceryArray[1]);
// // Console.WriteLine(myGroceryArray[2]);

// string[] myOtherGroceryArray = {"meat","apples"};

// List<string> myGroceryList = new List<string> {"Milk", "Ananas"};


// Console.WriteLine(myGroceryList[0]);
// Console.WriteLine(myGroceryList[1]);

// myGroceryList.Add("Oranges");
// Console.WriteLine(myGroceryList[2]);

// IEnumerable<string> myGroceryIEnumerable = myGroceryList;
// Console.WriteLine(myGroceryIEnumerable.First());
// string[,] myTwoDimensionalArray = new string[,]
// {
//     {"meat","apples"},
//     {"Milk", "Angggganas"}
// };

// Console.WriteLine(myTwoDimensionalArray[1,1]);

// Dictionary<string, string[]> myGroceryDictionaries = new Dictionary<string, string[]>()
// {
//     {"Meat", new string[]{"Pork","Horses","Chicken"}},
//     {"Cheese", new string[] {"Emmental","Gruyere"}}
// };

//    Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>();

//             // Set the prices for "cheese" and "carrots"
//             itemPrices["cheese"] = 5.99m;
//             itemPrices["carrots"] = 2.99m;

//             // Printing out the prices (optional)
//             Console.WriteLine("Price of cheese: " + itemPrices["cheese"]);
//             Console.WriteLine("Price of carrots: " + itemPrices["carrots"]);

using System.Data;
using System.Runtime.CompilerServices;
using Dapper;
using helloworld.Models;
using Microsoft.Data.SqlClient;
using System.Globalization;
using helloworld.Data;



internal class Program
{
    private static void Main(string[] args)
    {
        DataContextDapper dapper = new DataContextDapper();
        DataContextEF entityFramework = new DataContextEF();

        string sqlCommand = "SELECT GETDATE()";

        DateTime rigtNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

        Console.WriteLine(rigtNow);

        Computer myComputer = new Computer()
        {
            Motherboard = "Z23567",
            HasWifi = true,
            HasLTE = true,
            ReleaseDate = DateTime.Now,
            Price = 2346.43m,
            VideoCard = "RTX 32323"
        };

        entityFramework.Add(myComputer);
        entityFramework.SaveChanges();

        string formattedReleaseDate = myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss");
        string formattedPrice = myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture);

        string sql = @"INSERT INTO TutorialAppSchema.Computer
        (
            Motherboard,
            HasWifi,
            HasLTE,
            ReleaseDate,
            Price,
            VideoCard
        ) VALUES ('" + myComputer.Motherboard
        + "','" + myComputer.HasWifi
        + "','" + myComputer.HasLTE
        + "','" + formattedReleaseDate
        + "','" + formattedPrice
        + "','" + myComputer.VideoCard
        + "')";

        bool resultRow = dapper.ExecuteSql(sql);
        Console.WriteLine(resultRow);

        string sqlSelect = @"
        SELECT 
            Computer.Motherboard,
            Computer.HasWifi,
            Computer.HasLTE,
            Computer.ReleaseDate,
            Computer.Price,
            Computer.VideoCard
        FROM TutorialAppSchema.Computer";

        IEnumerable<Computer> Computers = dapper.LoadData<Computer>(sqlSelect);


        foreach (Computer OneComputer in Computers)
        {
            Console.WriteLine
            ("'" + OneComputer.ComputerId
        + "','" + OneComputer.Motherboard  
        + "','" + OneComputer.HasWifi
        + "','" + OneComputer.HasLTE
        + "','" + formattedReleaseDate
        + "','" + formattedPrice
        + "','" + OneComputer.VideoCard
        + "'");
        }

        IEnumerable<Computer>? ComputersEf = entityFramework.Computer?.ToList<Computer>();

        if (ComputersEf != null) {
        foreach (Computer OneComputer in ComputersEf)
        {
            Console.WriteLine
               ("'" + OneComputer.ComputerId
        + "','" + OneComputer.Motherboard 
        + "','" + OneComputer.HasWifi
        + "','" + OneComputer.HasLTE
        + "','" + formattedReleaseDate
        + "','" + formattedPrice
        + "','" + OneComputer.VideoCard
        + "'");
        }
        }





        // myComputer.HasWifi =false;
        // Console.WriteLine(myComputer.CPUCores);
        // Console.WriteLine(myComputer.Motherboard);
        // Console.WriteLine(myComputer.HasWifi);
        // Console.WriteLine(myComputer.HasLTE);
        // Console.WriteLine(myComputer.Price);
        // Console.WriteLine(myComputer.VideoCard);
    }
}
