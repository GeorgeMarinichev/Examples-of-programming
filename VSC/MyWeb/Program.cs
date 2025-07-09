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
            // //WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddCors();//Добавление сервисов CORS
            
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors(builder => builder.AllowAnyOrigin());//Настройка CORS (AllowAnyOrigin(); -принимаются запросы с любого адреса)
            // //app.UseCors(builder => builder.WithOrigins("http://example.com", "http://google.com"));//принимаются запросы только с определенных адресов
            // //app.UseCors(builder => builder.WithOrigins("http://localhost:5176").WithMethods("GET"));//принимать запросы любого типа (GET/POST)
            // app.Map("/",async(context)=> await context.Response.WriteAsync("Hello, METANIT.COM!"));

            // app.Run();

            ///////////////////////////////////////////////////////////////////
            /////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddCors();//Добавление сервисов CORS
            
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors(builder => builder.WithOrigins("http://localhost:5176"));//принимаются запросы только с определенных адресов

            // app.Map("/",async(context)=> 
            // {
            //     await context.Response.WriteAsync("Hello, METANIT.COM!");
            // });

            // app.Run();

            /////////////////////////////////Получение заголовков на клиенте
            // /////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddCors();//Добавление сервисов CORS
            
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors(builder => builder.WithOrigins("http://localhost:5176")//принимаются запросы только с определенных адресов
            //                             .AllowCredentials()//разрешается принимать идентификационные данные от клиента (например, куки)
            // );

            // app.Run(async(context)=> 
            // {
            //     context.Response.Headers.Add("custom-header", "1985");
            //     await context.Response.WriteAsync($"Hello, {login}!");
            // });

            // app.Run();


            // //////////////////////////Передача идентификационных данных
            // ////////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddCors();//Добавление сервисов CORS
            
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors(builder => builder.WithOrigins("http://localhost:5176")//принимаются запросы только с определенных адресов
            //                             .AllowCredentials()//разрешается принимать идентификационные данные от клиента (например, куки)
            // );

            // app.Run(async(context)=> 
            // {
            //     var login = context.Request.Cookies["login"];// получаем отправленные куки
            //     await context.Response.WriteAsync($"Hello, {login}!");
            // });

            // app.Run();

            // //////////////////////////Политики CORS
            // ////////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            //  builder.Services.AddCors((options) => options.AddPolicy("AllowLocalhost5176", builder => builder//Добавление сервисов CORS
            //                                     .WithOrigins("http://localhost:5176")//принимаются запросы только с определенных адресов
            //                                     .AllowAnyHeader()//принимаются запросы с любыми заголовками
            //                                     .AllowAnyMethod()//принимаются запросы любого типа (GET/POST)
            //                                     ));
            
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors("AllowLocalhost5176");

            // app.Run(async(context)=> await context.Response.WriteAsync($"Hello, client!"));
         
            // app.Run();

            //////////////////////////Политики CORS
            ////////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            //  builder.Services.AddCors((options) => options.AddPolicy("AllowLocalhost5176", builder => builder//Добавление сервисов CORS
            //                                     .WithOrigins("http://localhost:5176")//принимаются запросы только с определенных адресов
            //                                     .AllowAnyHeader()//принимаются запросы с любыми заголовками
            //                                     .AllowAnyMethod()//принимаются запросы любого типа (GET/POST)
            //                                     ));
            
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors("AllowLocalhost5176");

            // app.Run(async(context)=> await context.Response.WriteAsync($"Hello, client!"));
         
            // app.Run();


            //////////////////////////Глобальная настройка CORS
            // ////////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            // var builder = WebApplication.CreateBuilder(args);

            //  builder.Services.AddCors();//Добавление сервисов CORS
            // //WebApplication app = builder.Build();
            // var app = builder.Build();

            // app.UseCors(builder => builder.AllowAnyOrigin());// глобальная настройка CORS для всех ресурсов

            // app.MapGet("/", async(context)=> await context.Response.WriteAsync("Hello, World!"));
            // app.MapGet("/home", async(context)=> await context.Response.WriteAsync("Home Page"));

            // //app.Run(async(context)=> await context.Response.WriteAsync($"Hello, client!"));
         
            // app.Run();
            
            ///////////////////////Локальная настройка CORS
            ////////WebApplicationBuilder builder = WebApplication.CreateBuilder();
            var builder = WebApplication.CreateBuilder(args);

             builder.Services.AddCors((options)=>
             {
                options.AddPolicy("AllowTestSite", builder => builder
                .WithOrigins("https://localhost:5176")
                .AllowAnyHeader()
                .AllowAnyMethod());

                options.AddPolicy("AllowNormSite", builder => builder
                .WithOrigins("https://localhost.com")
                .AllowAnyHeader()
                .AllowAnyMethod());
             });//Добавление сервисов CORS
            //WebApplication app = builder.Build();
            var app = builder.Build();

        
            app.UseCors();//Локальная настройка CORS для всех ресурсов

            app.MapGet("/", async(context)=> await context.Response.WriteAsync("Hello, World!"))
                .RequireCors(options => options.AllowAnyOrigin());

            app.MapGet("/home", async(context)=> await context.Response.WriteAsync("Home Page"))
                .RequireCors("AllowNormSite");

            app.MapGet("/about", async(context)=> await context.Response.WriteAsync("About Page"))
                .RequireCors("AllowTestSite");

            //app.Run(async(context)=> await context.Response.WriteAsync($"Hello, client!"));
         
            app.Run();
            

        }
    }
}

