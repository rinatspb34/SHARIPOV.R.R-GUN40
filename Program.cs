using System.Diagnostics.CodeAnalysis;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new[] { 0, 1, 1, 2, 3, 5, 8, 13 };                                                          // 1.Фибоначчи


            string[] munth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }; // 2.Месяцы 


            int[,] d2 = new int[3, 3] {
                { 3, 3, 4 }, { 2, 3, 4 }, { 2, 3, 4 }                                                                     // 3.Двумерный массив
            };
            


            double[][] array4 = new double[3][]; 
            array4[0] = new double[] { 1, 2, 3, 4, 5 };                                                                   // 4.Ломанный массив
            array4[1] = new double[] { Math.E, Math.PI };
            array4[2] = new double[] {Math.Log(1, 10), Math.Log(10,10), Math.Log(100,10), Math.Log(1000, 10) };
            ;


            int[] array = new int[] { 0, 1, 2, 3, 4, 5 };
            int[] array2 = new int[] { 7, 8, 9, 10, 11, 12, 13 };                                                         // 5. Копирование элементов из одгого в другой
            Array.Copy(array, array2, 3);
            Console.Write("");
            foreach (int num in array2)
            {
                Console.WriteLine(num + " ");

            }
            Console.WriteLine();


            //string[] sample = { " ", " " };
            Array.Resize(ref array, array.Length + 5);                                                                    // 6. +5 Элементов в первом массиве
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0}", i, array[i]);
            }


        }



    }




}
