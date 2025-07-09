namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Программа сравнение двух чисел...)");
            Console.WriteLine("Введите первое число:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine($" {a} больше чем {b}");
            }
            else if (a < b)
            {
                Console.WriteLine($"{a} меньше чем {b}");
            }
            else if (a == b)
            {
                Console.WriteLine($" {a} ровно {b}");
            }
            else
            {
                Console.WriteLine("Не известное значение!");
            }




        }
    }
}
