

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
    static async Task Main(string[] args)
    {
            Task firstTask = new Task(() => 
            {
                Thread.Sleep(111);
                Console.WriteLine("Task 1");
            });
        firstTask.Start();

        Task secondTask = ConsoleAfterDelayAsync("Task 2", 166);

        ConsoleAfterDelay("delay", 1175);

        Task thirdTask = ConsoleAfterDelayAsync("Task 3", 36);
        
        await firstTask;
        Console.WriteLine("After the tasks was created");
        await secondTask;
        await thirdTask;
               
    }

    static void ConsoleAfterDelay(string text, int delayTime)
    {
        Thread.Sleep(delayTime);
        Console.WriteLine(text);
    }

    static async Task ConsoleAfterDelayAsync(string text, int delayTime)
    {
        await Task.Delay(delayTime);
        Console.WriteLine(text);
    }
}