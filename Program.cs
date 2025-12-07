using System.Runtime.InteropServices;
using System.Security.Cryptography;

class Program
{

    static void Main(string[] args)
    {
        

        if (!Int32.TryParse(Console.ReadLine(), out var a))                 // проверка на ввод числа
        {
            Console.WriteLine("Not a number!");
            return;
        }

        if (!Int32.TryParse(Console.ReadLine(), out var b))                 // проверка на ввод числа 2
        {
            Console.WriteLine("Not a number!");
            return;
        }

        var s = Console.ReadLine();
        int result = 0;
        string operation = "";

        switch (s[0])
        {
            case '&':
                result = a & b;
                operation = "&";
                Console.WriteLine($"Result of {a} {operation} {b} = {result}" );                  //операции
                break;
            case '|':
                result = a | b;
                operation = "|";
                Console.WriteLine($"Result of {a} {operation} {b} = {result}");                
                break;
            case '^':
                result = a ^ b;
                operation = "^";
                Console.WriteLine($"Result of {a} {operation} {b} = {result}");
                break;
            default:
                Console.WriteLine("Wrong sign");                              // коректность оператора
                break;

        }


        Console.WriteLine($"Десятичная система счисления: {result}");
        Console.WriteLine($"Двоичная система счисления: {Convert.ToString(result, 2)}");                                // вывод разных счислений
        Console.WriteLine($"Шестнадцатеричнаяч система счисления: {Convert.ToString(result, 16)}");








        //    if (!Int32.TryParse(Console.ReadLine(), out var a))
        //    {
        //        Console.WriteLine("Not number!");
        //        return;
        //    }

        //    if (!Int32.TryParse(Console.ReadLine(), out var b))
        //    {
        //        Console.WriteLine("Not number!");
        //        return;
        //    }
        //    var s = Console.ReadLine();
        //    var boolVar = true;
        //    if (s.Length == 0 || s.Length > 1 && !boolVar) 
        //    {
        //        Console.WriteLine("Wrong sign");
        //        return;
        //    }
        //    switch (s[0])
        //    {
        //        case '+':
        //            Console.WriteLine("Result of {0} + {1} = {2} ", a, b, a + b);
        //            break;
        //        case '-':
        //            Console.WriteLine("Result of {0} - {1} = {2} ", a, b, a - b);              //жалко было удалять
        //            break;
        //        case '*':
        //            Console.WriteLine("Result of {0} * {1} = {2} ", a, b, a * b);
        //            break;
        //        case '/':
        //            Console.WriteLine("Result of {0} / {1} = {2} ", a, b, a / b);
        //            break;
        //        case '%':
        //            Console.WriteLine("Result of {0} % {1} = {2} ", a, b, a % b);
        //            break;
        //        default:
        //            Console.WriteLine("Wrong sign");
        //            break;

        //    }








    }
}