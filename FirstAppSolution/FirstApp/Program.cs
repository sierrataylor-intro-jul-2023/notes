using FirstApp.Models;
using FirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Tacos");
            //string name = Console.ReadLine();
            //Console.WriteLine($"Hello {name}");
            Console.WriteLine("Starting up the api");
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<IProvideTheSystemStatus, RemoteStatusSservice>();
            builder.Services.AddTransient<ISystemTime, SystemTime>();

            //confugration for the API will go here
            Console.WriteLine("About the start the api");
            var app = builder.Build();
            //GET /sayhi
            app.MapGet("/sayhi", () => Results.Ok("Yep! Hello, Good To See You"));
            //GET /status
            app.MapGet("/status", ([FromServices] IProvideTheSystemStatus _statusGenerator) =>
            {
                //var response = new StatusResponseModel(DateTime.Now, "Looks good", "Operating normally");
                StatusResponseModel response = _statusGenerator.GetCurrentStatus();
                return Results.Ok(response);
            });
            //GET /todo-list
            app.MapGet("/todo-list", () =>
            {
                var response = new List<TodoItemModel>() { 
                    new TodoItemModel(Guid.NewGuid(), "Buy beer", "Later"),
                    new TodoItemModel(Guid.NewGuid(), "Mow lawn", "Waiting")
                };
                return Results.Ok(response);
            });
            app.Run();
            Console.WriteLine("API is going down. Goodbye...");
            
        }
    }
}