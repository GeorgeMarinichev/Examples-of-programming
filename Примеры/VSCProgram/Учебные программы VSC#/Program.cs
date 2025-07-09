namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Таблица умножения");
            for(int a=1; a<10; a++)
            {
                for(int b=1; b<10; b++)
                {
                    Console.Write($"{a*b}\t");
                }
                Console.WriteLine();
            }



        }
    }
}


//Console.WriteLine("Введите слово:");
//string name1 = Console.ReadLine();
//Console.WriteLine(name1);