using System.Diagnostics.CodeAnalysis;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };                                                      // 1. Фибоначчи

            for (int i = 0; i < fibonacci.Length; i++) 
            {
                Console.WriteLine(fibonacci[i] + " ");
            }
            Console.WriteLine();


            for (int i = 2;i <= 20; i += 2)                                                                                   // 2. Чётные числа
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(" ");

            for (int i = 1; i <= 5; i++)                                                                                      // 3. Таблица умножения
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write($"{i,2} * {j,2} = {i * j,2}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");

            string password = "qwerty";
            string userInput;

            do
            {
                Console.Write("Введите пароль: ");                                                                              // 4. Парольы                                                                               
                userInput = Console.ReadLine();
                if (userInput != password)
                {
                    Console.WriteLine("Неверный пароль! Попробуйте снова.");
                }
            } while (userInput != password);
            Console.WriteLine("Пароль верный");
        }





    }


}
