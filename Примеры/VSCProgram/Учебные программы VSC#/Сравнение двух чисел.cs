// Программа сравнение числа между 5 и 10
Console.WriteLine("Программа сравнение числа между 5 и 10...)");
Console.WriteLine("Введите число:");
int a = int.Parse(Console.ReadLine());

//bool a > 5 & a < 10
//Console.WriteLine("Введите второе число:");
//int b = int.Parse(Console.ReadLine());

Console.WriteLine(a > 5 && a < 10 ? "больше 5 и меньше 10": "Не известное число!");

