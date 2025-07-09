import java.util.Arrays;
import java.util.List;
import java.util.ArrayList;

class NumberOperations
{
    public static int add(int a, int b)
    {
        int res = a + b;
        return res;
    }

    public static int sub(int a, int b)
    {
        int res = a - b;
        return res;
    }

    public static int div(int a, int b)
    {
        if(b == 0)
        {
            //throw new ArithmeticException(null);
            throw new ArithmeticException("Деление на ноль не возможно!");
        }
        else
        {
            int res = a / b;
            return res;
        }
    }

    public static int mul(int a, int b)
    {
        int res = a * b;
        return res;
    }

}
public class NumberOperationsDemo
{
    enum Str
    {
        a1,
        b1,
        c1,
        d1
    }

    public static void main(String[] args) throws InterruptedException
    {
        int num;
        num = 123;

        String str;
        str = "hello";
        //Str str = Str.a1;
        System.out.println("Hello, World " + num);

       
        // int res1 = NumberOperations.add(10, 20);
        // int res2 = NumberOperations.sub(10, 20);
        // int res3 = NumberOperations.div(10, 0);
        // int res4 = NumberOperations.mul(10, 20);

        // System.out.println("add:"  + res1);
        // System.out.println("sub:"  + res2);
        // System.out.println("div:"  + res3);
        // System.out.println("mul:"  + res4);
        int arrInt[];
        arrInt = new int[10];

        arrInt[0] = 1;
        arrInt[1] = 9;
        arrInt[2] = 8;
        arrInt[3] = 5;

        String[] arrStr;
        arrStr = new String[10];

        arrStr[0] = "G";
        arrStr[1] = "E";
        arrStr[2] = "O";
        arrStr[3] = "R";
        arrStr[4] = "G";
        arrStr[5] = "E";

        
        // char[] arrChar = new char[]{'!', '@', '#', '$', '%', '&'};
        char[] arrChar = {'!', '@', '#', '$', '%', '&'};

        List<String> arrList = new ArrayList<>();
        arrList.add("Q");
        arrList.add("W");
        arrList.add("E");
        arrList.add("R");
        arrList.add("T");
        arrList.add("Y");


        System.out.println("Длина int массива:" + arrInt.length);
        for (int i : arrInt) 
        {
            //Thread.sleep(500);
            System.out.println(i);
        }

        System.out.println("Длина String массива:" + arrStr.length);
        for (String i : arrStr) 
        {
            System.out.println(i);
        }

        System.out.println("Длина Char массива:" + arrChar.length);
        for (char i : arrChar) 
        {
            System.out.println(i);
        }

        System.out.println("Длина List массива:" + arrList.size());
        for (String i : arrList) 
        {
            System.out.println(i);
        }

        System.out.println("Вывод 1:" + arrList);
        System.out.println("Вывод 2:" + arrStr.toString());
        System.out.println("Вывод 3:" + Arrays.toString(arrStr));
        System.out.println("Вывод 4:" + String.join(",", arrList)); 
        
        System.out.println("Проверка:" + "abc".equals(str));//false

        int abc;
        abc = 123;
    
        String res = String.valueOf(abc);
        System.out.println("Проверка:" + res);

        String abcStr;
        abcStr = "321";
        int abcInt = Integer.parseInt(abcStr);
        System.out.println("parseInt:" + abcInt);
         
        //Object abs = res; // пример с объектом
        // if(res instanceof String)
        // {
        //     System.out.println("String"); 
        // }
        // else if(res instanceof Integer)
        // {
        //     System.out.println("Int"); 
        // }

        if (abcStr instanceof String) 
        {
            System.out.println("String");
        } 
        else
        {
            System.out.println("Int");
        }

        String alphabetDemo = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        System.out.println("String:" + alphabetDemo);
        String alphabet = alphabetDemo.toLowerCase();
        //String alphabet = alphabetDemo.toUpperCase();

        String[] arrValSrtr = alphabet.split("");
        System.out.println("StringArr1:" + Arrays.toString(arrValSrtr));
        System.out.println("StringArr2:" + String.join("/", arrValSrtr));

        System.out.println("Поиск:" + alphabet.indexOf("g"));
       
        for(int i = 0; i < alphabet.length(); i++) 
        {
            System.out.println("STR:" + i + ":" + alphabet.charAt(i));
        }
    } 
}


