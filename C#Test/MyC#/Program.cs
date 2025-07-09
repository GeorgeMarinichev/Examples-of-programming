
public class Program
{
    public static void Main(string[] args)
    {
        int[] arrInt;
        arrInt = new int[10];

        arrInt[0] = 1;
        arrInt[1] = 9;
        arrInt[2] = 8;
        arrInt[3] = 5;

        string[] arrStr;
        arrStr = new string[10];

        arrStr[0] = "G";
        arrStr[1] = "E";
        arrStr[2] = "O";
        arrStr[3] = "R";
        arrStr[4] = "G";
        arrStr[5] = "E";

        //char[] arrChar = new char[]{'!', '@', '#', '$', '%', '&'};
        char[] arrChar = {'!', '@', '#', '$', '%', '&'};

        List<string> arrList = new List<string>();
        arrList.Add("Q");
        arrList.Add("W");
        arrList.Add("E");
        arrList.Add("R");
        arrList.Add("T");
        arrList.Add("Y");

        Console.WriteLine("Длина int массива:" + arrInt.Length);
        foreach (int i in arrInt) 
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Длина String массива:" + arrStr.Length);
        foreach  (var i in arrStr) 
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Длина Char массива:" + arrChar.Length);
        foreach (char i in arrChar) 
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Длина List массива:" + arrList.Count);
        foreach (String i in arrList) 
        {
            Console.WriteLine(i);
        }

    }
}
