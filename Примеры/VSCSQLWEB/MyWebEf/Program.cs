using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;//Логгирование

namespace Space
{
    [Table("Person")]//Переименование таблицы
    public class User//Тип владелец
    {
        //public string Id { get; set; }=Guid.NewGuid().ToString();//Для явной установки уникального значения Id //NOT NULL
        public int Id { get; set; }//NOT NULL
        public string? Name { get; set; }//Не обязательное свойство допускающие значение null(nullable-тип)
        public int? Age {get; set;}//Не обязательное свойство допускающие значение null(nullable-тип)

        public string? Discriminator {get; set;}//Столбец Discriminator на уровне БД установлен как readonly(не обязательно!)

        //Навигационные свойства
        
        //Промежуточная таблица
    }

    [Table("Employees")]////Для подхода TPT
    public class Employee: User
    {
        public int Solary {get; set;}//NOT NULL
    }

    [Table("Managers")]//Для подхода TPT
    public class Manager: User
    {
        public string? Departament {get; set;}//Не обязательное свойство допускающие значение null(nullable-тип)
    }

 
    public class ApplicationContext: DbContext//Класс контекст данных
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        //Чтобы включить все классы из иерархии наследования в базу данных, 
        //в контексте данных для каждого типа должен быть определен набор DbSet.
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Manager> Managers { get; set; } = null!;

        // public ApplicationContext()//Конструктор
        // {
        //     //Пересоздание БД
        //     Database.EnsureDeleted();//Очистка БД
        //     Database.EnsureCreated();//Создание БД
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ////////optionsBuilder.UseSqlite("Data Source=helloapp.db");//Подключение SQLite
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloapp.db;Trusted_Connection=True;");//Подключение SQLServer
            //optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=helloapp.db");//Подключение LazyLoading
            //optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });//Логгирование
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//FluentAPI 
        {
            //modelBuilder.Entity<User>().UseTphMappingStrategy();//Явное указание что это стратегия TPH(не обязательно указывать!)
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //modelBuilder.Entity<Employee>().ToTable("Employees");//Явное указание что это стратегия TPT(не обязательно указывать!)
            //modelBuilder.Entity<Manager>().ToTable("Managers");//Явное указание что это стратегия TPT(не обязательно указывать!)
            //или
            modelBuilder.Entity<User>().UseTptMappingStrategy();//Явное указание что это стратегия TPT
            //////////////////////////////////////////////////////////////////////////////////////////////
            // modelBuilder.Entity<User>().UseTpcMappingStrategy();//Явное указание что это стратегия TPC
            // modelBuilder.Entity<User>().ToTable("User", tb => tb.Property(e => e.Id).UseIdentityColumn(1, 1));
            // modelBuilder.Entity<Employee>().ToTable("Employees", tb => tb.Property(e => e.Id).UseIdentityColumn(10000, 1));
            // modelBuilder.Entity<Manager>().ToTable("Managers", tb => tb.Property(e => e.Id).UseIdentityColumn(20000, 1));

        }
    }

    class Program//Основной класс точки входа
    {
        // static void CreateData()//Создание данных
        // {
        //     using (ApplicationContext db = new ApplicationContext())//Ввод данных
        //     {
        //         //Пересоздание БД
        //         db.Database.EnsureDeleted();//Очистка БД
        //         db.Database.EnsureCreated();//Создание БД

        //         //Добавление начальных данных
        //         User tom = new User {Name = "Tom", Age = 45};
        //         User sam = new User {Name = "Sam", Age = 55};
        //         User bob = new User {Name = "Bob", Age = 60};

        //         db.Users.AddRange(tom, sam, bob);

        //         //Добавление начальных данных
        //         Employee emp1 = new Employee{Name = "Eva", Solary = 100};
        //         Employee emp2 = new Employee{Name = "Bob", Solary = 200};
        //         db.Employees.AddRange(emp1, emp2);
                
        //         //Добавление данных
        //         Manager man1 = new Manager{Name = "Alice", Departament = "IT"};
        //         Manager man2 = new Manager{Name = "Sam", Departament = "RBT"};
        //         Manager man3 = new Manager{Name = "Bob", Departament = "Games"};
        //         db.Managers.AddRange(man1, man2, man3);

        //         //Сохранение данных
        //         db.SaveChanges();
        //     }
        // }

        // static void ReadData()//Чтение данных
        // {
        //     using (ApplicationContext db = new ApplicationContext())//Получение данных
        //     {
        //         Console.WriteLine($"=========================Base===============================");
        //         Console.WriteLine("Все пользователи");
        //         var user1 = db.Users.ToList();// получаем все пункты меню из БД
        //         foreach (var i in user1)
        //         {
        //             Console.WriteLine($"Id:{i.Id} Name:{i.Name} Age:{i.Age} \n {i.Discriminator}");
        //             Console.WriteLine("--------------------------------------");
        //         }

        //         Console.WriteLine($"=========================Under===============================");
        //         Console.WriteLine("\n Все работники");
        //         var employee = db.Employees.ToList();// получаем определенный пункт меню с подменю   
        //         foreach (var i in employee)
        //         {
        //             Console.WriteLine($"Name:{i.Name} Solary:{i.Solary}");
        //             Console.WriteLine("++++++++++++++++++++++++++++++++++");


        //         }

        //         Console.WriteLine($"=========================Under2===============================");
        //         Console.WriteLine("\nВсе менеджеры");
        //         var manager = db.Managers.ToList();// получаем определенный пункт меню с подменю
        //         foreach (var i in manager)
        //         {
        //             Console.WriteLine($"Name:{i.Name} Departament:{i.Departament}");
        //             Console.WriteLine("++++++++++++++++++++++++++++++++++");
        //         }
        //     }
        // }

        // static void UpdateData()//Редактирование данных
        // {
        //     //Изменение данных
        //     using (ApplicationContext db = new ApplicationContext())//Редактирование данных
        //         {
        //             User? user1 = db.Users.FirstOrDefault(u => u.Name == "Tom");//изменение имени пользователя
        //             if (user1 != null)
        //             {
        //                 user1.Name = "Том";
        //                 db.SaveChanges();
        //             }
        //         }
        // }

        // static void DeleteData()//Удаление данных
        // {
        //     using (ApplicationContext db = new ApplicationContext())
        //     {
        //         User? user1 = db.Users.FirstOrDefault(m => m.Id == 2);
        //         if (user1 != null)
        //         {
        //             db.Users.Remove(user1);
        //             db.SaveChanges();
        //         }
        //     }
        // }



        static void InitializeDatabase(ApplicationContext db)
        {
            //Пересоздание БД
            db.Database.EnsureDeleted();//Очистка БД
            db.Database.EnsureCreated();//Создание БД

            //Добавление начальных данных
            User tom = new User {Name = "Tom", Age = 45};
            User sam = new User {Name = "Sam", Age = 55};
            User bob = new User {Name = "Bob", Age = 60};

            db.Users.AddRange(tom, sam, bob);

            //Добавление начальных данных
            Employee emp1 = new Employee{Name = "Eva", Solary = 100};
            Employee emp2 = new Employee{Name = "Bob", Solary = 200};
            db.Employees.AddRange(emp1, emp2);
                
            //Добавление данных
            Manager man1 = new Manager{Name = "Alice", Departament = "IT"};
            Manager man2 = new Manager{Name = "Sam", Departament = "RBT"};
            Manager man3 = new Manager{Name = "Bob", Departament = "Games"};
            db.Managers.AddRange(man1, man2, man3);

            //Сохранение данных
            db.SaveChanges();
        }


        static void Main(string[] args)//Метод как точка входа
        {

            //CreateData();//
            //Console.WriteLine("Метод вывода до изменений:");
            //ReadData();//1
            //UpdateData();//
            //Console.WriteLine("Метод вывода после изменений:");
            //ReadData();//2
            //DeleteData();//
            //Console.WriteLine("Метод вывода после удаления:");
            //ReadData();//3
            //////////////////////////////////////////////////////
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=helloapp.db"));//Контекст данных добавлен в качестве сервиса
            var app = builder.Build();

            // Важно: сначала подключаем отдачу статических файлов и default files (index.html)
            app.UseDefaultFiles();  //Попытка найти index.html и вернуть его при заходе на "/"
            app.UseStaticFiles();   //Отдача статических файлов из wwwroot
            
            // Создаём scope, чтобы получить ApplicationContext и инициализировать базу
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                InitializeDatabase(db);
            }

            //Методы для определения конечных точек
            app.MapGet("/api/users", async (ApplicationContext db) => await db.Users.ToListAsync());//Чтение всего списка из БД
            app.MapGet("/api/users/{id:int}", async (int id, ApplicationContext db) => //Получение одного обьекта по id 
            {
                //Получаем пользователя по id
                User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                //Если не найден, отправляем статус код и сообщение об ошибке
                if (user == null)
                {
                    return Results.NotFound(new { message = "Пользователь не найден!" });//Статусный код ошибка 404, с сообщением в формате Json
                }
                //Если пользователь найден, отправляем его
                return Results.Json(user);
            });

            app.MapDelete("/api/users/{id:int}", async (int id, ApplicationContext db) =>
            {
                //Получаем пользователя по id
                User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                //Если не найден, отправляем статус код и сообщение об ошибке
                if (user == null)
                {
                    return Results.NotFound(new { message = "Пользователь не найден!" });//Статусный код ошибка 404, с сообщением в формате Json
                }
                //Если пользователь найден, удаляем его
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.Json(user);
            });

            app.MapPost("/api/users", async (User user, ApplicationContext db) =>
            {
                //Добавляем пользователя в массив
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                return user;
            });

            app.MapPut("/api/users", async (User userData, ApplicationContext db) =>
            {
                //Получаем пользователя по id
                User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);
                //Если не найден, отправляем статус код и сообщение об ошибке
                if (user == null)
                {
                    return Results.NotFound(new { message = "Пользователь не найден!" });//Статусный код ошибка 404, с сообщением в формате Json
                }
                //Если пользователь найден, изменяем его данные и отправляем обратно клиенту
                user.Age = userData.Age;
                user.Name = userData.Name;
                await db.SaveChangesAsync();
                return Results.Json(user);
            });

            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/", async(ApplicationContext db) => await db.Users.ToListAsync());
            //app.MapGet("/", () => "API is running");

            app.Run();
        }
    }
}

