////////////////////////////CORS и доменные запросы
///Подключение CORS в приложении
///
using System;
using Microsoft.AspNetCore.Authorization;//Деректива для аутентификации
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;


namespace Space
{

    class Program
    {
        static void Main(string[] args)
        {
            // WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // //var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddCors();//Добавление сервисов CORS
            
            // WebApplication app = builder.Build();
            // //var app = builder.Build();

            // app.UseCors(builder => builder.AllowAnyOrigin());//Настройка CORS
            // app.Map("/",async(context)=> await context.Response.WriteAsync("Hello, METANIT.COM!"));

            // app.Run();

            ////////////////////////////"http://localhost:5176/" "http://localhost:5072/"
            //WebApplicationBuilder builder = WebApplication.CreateBuilder();
            var builder = WebApplication.CreateBuilder(args);
            //WebApplication app = builder.Build();
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run();

        }
    }
}

