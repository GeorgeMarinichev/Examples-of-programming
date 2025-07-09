using System.Threading;
using System.Media;
using System.Drawing;

namespace MazeGame
{
    class Level_Game
    {
        // Представление лабиринта

        public static char[,] level = { };

        static char[,] level1 = new char[20, 11]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', 'L', ' ', '#', '#', ' ', '#', '#', 'K', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', 'K', ' ', '#', '#', ' ', '#', '#', 'L', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        static char[,] level2 = new char[20, 11]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', 'L', ' ', '#', '#', ' ', '#', '#', 'K', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', 'K', ' ', '#', '#', ' ', '#', '#', 'L', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
       
        // Начальные позиции игрока и монстра
        static int playerX = 1, playerY = 1; // Позиция игрока
        static int monsterX = 8, monsterY = 8; // Позиция монстра
        static int playerLife = 1; // Количество жизней
        static int keysCollected = 0; // Количество собранных ключей
        static bool isHiding = false; // Флаг для проверки, прячется ли игрок
        static bool gameOver = false; // Флаг окончания игры
    
        ///////////////////////////////////////////////////////////////////////////////////////////
  
        static void Main(string[] args)
        {
            //MediaPlayer player = new MediaPlayer();
            //player.Open(new Uri("C:\\Users\\SmartPlayer\\Desktop\\Maze\\sound\\bg-music.wav"));
            //player.Play();

            Console.Title = "Maze Game";
            //Console.WindowWidth = 500;
            //Console.WindowHeight = 600;
            //Console.BufferHeight = 30;
            //Console.BufferWidth = 30;
            Console.CursorVisible = false; // Скрыть курсор
            Console.BackgroundColor = ConsoleColor.Black;
            //level1.CopyTo(level, 0);
            Array.Copy(level1, level, 0);//

            while (!gameOver)
            {
                DrawMaze(); // Отображение лабиринта
                HandleInput(); // Обработка ввода от игрока
                MoveMonster(); // Движение монстра
                CheckCollisions(); // Проверка столкновений
                Thread.Sleep(30); // Задержка для замедления игры
                Console.Clear(); // Очистка экрана
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Игра окончена! Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

       
        //////////////////////////////////////////////////////////////////////////////////////////

        // Метод для отображения лабиринта на экране
        static void DrawMaze()
        {
            for (int y = 0; y < level.GetLength(0); y++)
            {
                for (int x = 0; x < level.GetLength(1); x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('P'); // Отображение игрока
                        //Console.ResetColor();
                    }
                    else if (x == monsterX && y == monsterY)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write('M'); // Отображение монстра
                        //Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(level[y, x]); // Отображение ячеек лабиринта
                        //Console.ResetColor();
                    }

                }
                Console.WriteLine(); // Переход на новую строку
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Ключи собраны: {keysCollected}/3");
            Console.WriteLine($"Колличество здоровье: {playerLife}");
            Console.WriteLine($"Спрятался:{isHiding}");
            Console.ResetColor();

            if (keysCollected == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Вы можете открыть портал! (нажмите 'E')");
            }
 
        }

        // Метод для обработки ввода от игрока
        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key; // Чтение нажатой клавиши
                int newX = playerX, newY = playerY; // Новые координаты игрока

                switch (key)
                {
                    case ConsoleKey.W: if (!isHiding) newY--; break; // Вверх
                    case ConsoleKey.S: if (!isHiding) newY++; break; // Вниз
                    case ConsoleKey.A: if (!isHiding) newX--; break; // Влево
                    case ConsoleKey.D: if (!isHiding) newX++; break; // Вправо
                    case ConsoleKey.E: LockOn(); break; // Открыть портал
                    case ConsoleKey.Spacebar: Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("SPACE"); ; break; // Стрельба
                    case ConsoleKey.Q: if (isHiding == false) isHiding = true; else if (isHiding == true) isHiding = false; break; // Прятаться
                }

                // Проверка на стены и передвижение
                if (level[newY, newX] != '#')
                {
                    if (level[newY, newX] == 'K') // Если игрок находит ключ
                    {
                        Console.Beep(415 * 2, 300);
                        keysCollected++;
                        level[newY, newX] = ' '; // Удаляем ключ из лабиринта
                    }
                    if (level[newY, newX] == 'L') // Если игрок находит здоровье
                    {
                        Console.Beep(415, 300);
                        playerLife++;
                        level[newY, newX] = ' '; // Удаляем здоровье из лабиринта
                    }
                    playerX = newX; // Обновление позиции игрока
                    playerY = newY;
                }
            }
        }

        // Метод для движения монстра
        static void MoveMonster()
        {
            Random rand = new Random();
            int direction = rand.Next(4); // Случайное направление
            int newX = monsterX, newY = monsterY;

            switch (direction)
            {
                case 0: newY--; break; // Вверх
                case 1: newY++; break; // Вниз
                case 2: newX--; break; // Влево
                case 3: newX++; break; // Вправо
            }

            // Проверка на стены и передвижение монстра
            if (level[newY, newX] != '#')
            {
                monsterX = newX;
                monsterY = newY;
            }
        }

        // Метод для проверки столкновений
        static void CheckCollisions()
        {
            //if(!isHiding)
            if (!isHiding && playerX == monsterX && playerY == monsterY)
            {
                // Игрок пойман монстром
                Console.Beep(262 ,600);
                Console.BackgroundColor = ConsoleColor.Red;
                if (playerLife > 1)
                {
                    playerLife--;
                }
                else if (playerLife == 1)
                {
                    playerLife--;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Вас уничтожил монстр!");
                    Thread.Sleep(1000);
                    gameOver = true;
                }

            }
        }

        //Метод статуса портала
        static void LockOn()
        {
            if (keysCollected == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Вы спаслись!");
                Thread.Sleep(1000); gameOver = true; // Открыть портал
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Вам не хватает {3 - keysCollected} ключей!");
            }
            
        }
    }
}
