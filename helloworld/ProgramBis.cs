// // // See https://aka.ms/new-console-template for more information
// // Console.WriteLine("Hello, vbcbcvbWorld!");

// // string[] myGroceryArray = new string[2];
// // myGroceryArray[0] = "cheese";
// // myGroceryArray[1] = "ice cream";

// // Console.WriteLine(myGroceryArray[0]);
// // Console.WriteLine(myGroceryArray[1]);
// // // Console.WriteLine(myGroceryArray[2]);

// // string[] myOtherGroceryArray = {"meat","apples"};

// // List<string> myGroceryList = new List<string> {"Milk", "Ananas"};


// // Console.WriteLine(myGroceryList[0]);
// // Console.WriteLine(myGroceryList[1]);

// // myGroceryList.Add("Oranges");
// // Console.WriteLine(myGroceryList[2]);

// // IEnumerable<string> myGroceryIEnumerable = myGroceryList;
// // Console.WriteLine(myGroceryIEnumerable.First());
// // string[,] myTwoDimensionalArray = new string[,]
// // {
// //     {"meat","apples"},
// //     {"Milk", "Angggganas"}
// // };

// // Console.WriteLine(myTwoDimensionalArray[1,1]);

// // Dictionary<string, string[]> myGroceryDictionaries = new Dictionary<string, string[]>()
// // {
// //     {"Meat", new string[]{"Pork","Horses","Chicken"}},
// //     {"Cheese", new string[] {"Emmental","Gruyere"}}
// // };

// //    Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>();

// //             // Set the prices for "cheese" and "carrots"
// //             itemPrices["cheese"] = 5.99m;
// //             itemPrices["carrots"] = 2.99m;

// //             // Printing out the prices (optional)
// //             Console.WriteLine("Price of cheese: " + itemPrices["cheese"]);
// //             Console.WriteLine("Price of carrots: " + itemPrices["carrots"]);

// // Importations des espaces de noms requis
// using System.Data;
// using System.Runtime.CompilerServices;
// using Dapper;
// using helloworld.Models;
// using Microsoft.Data.SqlClient;
// using System.Globalization;
// using helloworld.Data;
// using Microsoft.Extensions.Configuration;

// // Déclaration de la classe du programme
// internal class ProgramBis
// {
//    // Méthode principale du programme
//    static void Main(string[] args)
//     {
//         // Configuration de l'application à partir du fichier appsettings.json
//         IConfiguration config = new ConfigurationBuilder()
//         .AddJsonFile("appsettings.json")
//         .Build();
    
//         // Initialisation des contextes de données Dapper et EF
//         DataContextDapper dapper = new DataContextDapper(config);
//         DataContextEF entityFramework = new DataContextEF(config);

//         // Exemple d'exécution d'une requête SQL pour obtenir la date actuelle
//         string sqlCommand = "SELECT GETDATE()";
//         DateTime rigtNow = dapper.LoadDataSingle<DateTime>(sqlCommand);
//         Console.WriteLine(rigtNow);

//         // Création d'un objet Computer avec des valeurs arbitraires
//         Computer myComputer = new Computer()
//         {
//             Motherboard = "Z23567",
//             HasWifi = true,
//             HasLTE = true,
//             ReleaseDate = DateTime.Now,
//             Price = 2346.43m,
//             VideoCard = "RTX 32323"
//         };

//         // Ajout d'un nouvel ordinateur à la base de données via Entity Framework
//         entityFramework.Add(myComputer);
//         entityFramework.SaveChanges();

//         // Formatage de la date et du prix pour une insertion SQL
//         string formattedReleaseDate = myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss");
//         string formattedPrice = myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture);

//         // Construction de la requête SQL d'insertion
//         string sql = @"INSERT INTO TutorialAppSchema.Computer
//         (
//             Motherboard,
//             HasWifi,
//             HasLTE,
//             ReleaseDate,
//             Price,
//             VideoCard
//         ) VALUES ('" + myComputer.Motherboard
//         + "','" + myComputer.HasWifi
//         + "','" + myComputer.HasLTE
//         + "','" + formattedReleaseDate
//         + "','" + formattedPrice
//         + "','" + myComputer.VideoCard
//         + "')";

//         // Exécution de la requête SQL d'insertion via Dapper
//         bool resultRow = dapper.ExecuteSql(sql);
//         Console.WriteLine(resultRow);

//         // Construction de la requête SQL de sélection
//         string sqlSelect = @"
//         SELECT 
//             Computer.Motherboard,
//             Computer.HasWifi,
//             Computer.HasLTE,
//             Computer.ReleaseDate,
//             Computer.Price,
//             Computer.VideoCard
//         FROM TutorialAppSchema.Computer";

//         // Récupération de la liste des ordinateurs à partir de la base de données via Dapper
//         IEnumerable<Computer> Computers = dapper.LoadData<Computer>(sqlSelect);

//         // Affichage des ordinateurs récupérés
//         foreach (Computer OneComputer in Computers)
//         {
//             Console.WriteLine
//             ("'" + OneComputer.ComputerId
//         + "','" + OneComputer.Motherboard  
//         + "','" + OneComputer.HasWifi
//         + "','" + OneComputer.HasLTE
//         + "','" + formattedReleaseDate
//         + "','" + formattedPrice
//         + "','" + OneComputer.VideoCard
//         + "'");
//         }

//         // Récupération des ordinateurs à partir de la base de données via Entity Framework
//         IEnumerable<Computer>? ComputersEf = entityFramework.Computer?.ToList<Computer>();

//         // Affichage des ordinateurs récupérés via Entity Framework
//         if (ComputersEf != null) {
//         foreach (Computer OneComputer in ComputersEf)
//         {
//             Console.WriteLine
//                ("'" + OneComputer.ComputerId
//         + "','" + OneComputer.Motherboard 
//         + "','" + OneComputer.HasWifi
//         + "','" + OneComputer.HasLTE
//         + "','" + formattedReleaseDate
//         + "','" + formattedPrice
//         + "','" + OneComputer.VideoCard
//         + "'");
//         }
//         }

//         // Commentaires supplémentaires
//         // myComputer.HasWifi =false;
//         // Console.WriteLine(myComputer.CPUCores);
//         // Console.WriteLine(myComputer.Motherboard);
//         // Console.WriteLine(myComputer.HasWifi);
//         // Console.WriteLine(myComputer.HasLTE);
//         // Console.WriteLine(myComputer.Price);
//         // Console.WriteLine(myComputer.VideoCard);
//     }
// }