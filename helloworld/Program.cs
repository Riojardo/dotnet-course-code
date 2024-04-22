

// Importations des espaces de noms requis
using System.Data;
using System.Runtime.CompilerServices;
using Dapper;
using helloworld.Models;
using Microsoft.Data.SqlClient;
using System.Globalization;
using helloworld.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.Diagnostics;


// Déclaration de la classe du programme
internal class Program
{
    // Méthode principale du programme
    static void Main(string[] args)
    {
        // Configuration de l'application à partir du fichier appsettings.json
        IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

        // Initialisation des contextes de données Dapper et EF
        DataContextDapper dapper = new DataContextDapper(config);

        // Exemple d'exécution d'une requête SQL pour obtenir la date actuelle
        // string sqlCommand = "SELECT GETDATE()";
        // DateTime rigtNow = dapper.LoadDataSingle<DateTime>(sqlCommand);
        // Console.WriteLine(rigtNow);

        // // Création d'un objet Computer avec des valeurs arbitraires
        // Computer myComputer = new Computer()
        // {
        //     Motherboard = "Z23567",
        //     HasWifi = true,
        //     HasLTE = true,
        //     ReleaseDate = DateTime.Now,
        //     Price = 2346.43m,
        //     VideoCard = "RTX 32323"
        // };



        // // Formatage de la date et du prix pour une insertion SQL
        // string formattedReleaseDate = myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss");
        // string formattedPrice = myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture);

        // // Construction de la requête SQL d'insertion
        // string sql = @"INSERT INTO TutorialAppSchema.Computer
        // (
        //     Motherboard,
        //     HasWifi,
        //     HasLTE,
        //     ReleaseDate,
        //     Price,
        //     VideoCard
        // ) VALUES ('" + myComputer.Motherboard
        // + "','" + myComputer.HasWifi
        // + "','" + myComputer.HasLTE
        // + "','" + formattedReleaseDate
        // + "','" + formattedPrice
        // + "','" + myComputer.VideoCard
        // + "')";

        // File.WriteAllText("log.txt", "\n" + sql + "\n");
        // using StreamWriter openFile = new("log.txt", append: true);
        // openFile.WriteLine("\n" + sql + "\n");
        // openFile.Close();
        // string fileText = File.ReadAllText("log.txt");
        // Console.WriteLine(fileText);

        string computerJson = File.ReadAllText("computersSnake.json");
        // Console.WriteLine(computerJson);

        // Mapper mapper = new Mapper(new MapperConfiguration((cfg) => {
        //     cfg.CreateMap<ComputerSnake, Computer>()
        //     .ForMember(destination => destination.ComputerId, options =>
        //     options.MapFrom(Source => Source.computer_id))
        //       .ForMember(destination => destination.Motherboard, options =>
        //     options.MapFrom(Source => Source.motherboard))
        //       .ForMember(destination => destination.CPUCores, options =>
        //     options.MapFrom(Source => Source.cpu_cores))
        //       .ForMember(destination => destination.HasWifi, options =>
        //     options.MapFrom(Source => Source.has_Wifi))
        //       .ForMember(destination => destination.HasLTE, options =>
        //     options.MapFrom(Source => Source.has_LTE))
        //       .ForMember(destination => destination.ReleaseDate, options =>
        //     options.MapFrom(Source => Source.release_Date))
        //       .ForMember(destination => destination.Price, options =>
        //     options.MapFrom(Source => Source.price))
        //       .ForMember(destination => destination.VideoCard, options =>
        //     options.MapFrom(Source => Source.video_card));          
        // }));

        // JsonSerializerOptions options = new JsonSerializerOptions()
        // {
        //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        // };

//          IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computerJson);

        
// if (computersSystem != null)
// {
//     IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);

//     foreach (Computer Computer in computerResult)
//     {
//         Console.WriteLine(Computer.Motherboard);
//     }
// }



        // Deserialize the JSON string into an IEnumerable<Computer> object
       IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computerJson);
if (computersSystem != null)
{


    foreach (Computer Computer in computersSystem)
    {
        Console.WriteLine(Computer.Motherboard);
    }
}
//         IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computerJson);

        
        
//         // Check if deserialization was successful
//         if (computersNewtonSoft != null)
//         {
            
//             // Iterate over each computer in the collection and print its Motherboard property
//      foreach (Computer computer in computersNewtonSoft)
//                 {
//                     // Console.WriteLine(computer.Motherboard);
//                     string sql = @"INSERT INTO TutorialAppSchema.Computer (
//                         Motherboard,
//                         HasWifi,
//                         HasLTE,
//                         ReleaseDate,
//                         Price,
//                         VideoCard
//                     ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
//                             + "','" + computer.HasWifi
//                             + "','" + computer.HasLTE
//                             + "','" + computer.ReleaseDate?.ToString("yyyy-MM-dd")
//                             + "','" + computer.Price.ToString("0.00", CultureInfo.InvariantCulture)
//                             + "','" + EscapeSingleQuote(computer.VideoCard)
//                     + "')";

//         dapper.ExecuteSql(sql);
//             }

//          JsonSerializerSettings settings = new JsonSerializerSettings()
// {
//     ContractResolver = new CamelCasePropertyNamesContractResolver()
// };

//             string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonSoft);
//             File.WriteAllText("computersCopyNewtonsoft.txt", "\n" + computersCopyNewtonsoft + "\n");
//             string computerCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem);
//             File.WriteAllText("computersCopySystem.txt", "\n" + computerCopySystem + "\n");

//         }
//         static string EscapeSingleQuote(string input)
//         {
//             string output = input.Replace("'","''");

//             return output;
//         }
    }
}