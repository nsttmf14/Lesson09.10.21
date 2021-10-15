using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labs6
{
    class Program
    {
        
        static void Print(int[,] Array1, int[,] Array2)//печать матриц(6.2)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(Array1[i, j] + " ");
                    if (j == 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(Array2[i, j] + " ");
                    if (j == 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        static void Multiplication(int[,] matrix1, int[,] matrix2)//умножение матриц(6.2)
        {
            int a11, a12, a21, a22;
            a11 = matrix1[0, 0] * matrix2[0, 0] + matrix1[0, 1] * matrix2[1, 0];
            a12 = matrix1[0, 0] * matrix2[0, 1] + matrix1[0, 1] * matrix2[1, 1];
            a21 = matrix1[1, 0] * matrix2[0, 0] + matrix1[1, 1] * matrix2[1, 0];
            a22 = matrix1[1, 0] * matrix2[0, 1] + matrix1[1, 1] * matrix2[1, 1];
            Console.WriteLine(a11 + " " + a12 + "\n" + a21 + " " + a22);
        }
        static void AverageTemperature(int numberofmonth, int sum, int[] months)//6.3
        {
            months[numberofmonth] = sum / 30;
            Console.WriteLine($"в {numberofmonth + 1} месяце примерно выпало осадков: " + months[numberofmonth]);
        }

        static string decode(string[] passarray, string str)
        {
            char[] array = str.ToLower().ToCharArray();
            str = str.Replace(" ", string.Empty);
            int numOfBytes = str.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                string oneBinaryByte = str.Substring(8 * i, 8);
                bytes[i] = Convert.ToByte(oneBinaryByte, 2);
            }
            byte[] bytesOfNewString = bytes;
            string password = Encoding.UTF8.GetString(bytesOfNewString);


            for (int i = 0; i < passarray.Length; i++)
            {
                if (password == passarray[i])
                {
                    return passarray[i];
                }

            }
            return "неверно";
        }

        static void Main(string[] args)
        {


            Console.WriteLine("\nTask 6.2");
            int[,] matrix1 = new int[2, 2];
            int[,] matrix2 = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine($"Введите a({i + 1},{j + 1}) для 1ой и 2ой матрицы:");
                    matrix1[i, j] = int.Parse(Console.ReadLine());
                    matrix2[i, j] = int.Parse(Console.ReadLine());

                }
            }
            Console.WriteLine("1 - напечатать матрицы\n2 - перемножить матрицы\nВыберите необходимую операцию: ");
            try
            {
            start:
                int operation = int.Parse(Console.ReadLine());
                if (operation == 1)
                {
                    Print(matrix1, matrix2);
                }
                else if (operation == 2)
                {
                    Multiplication(matrix1, matrix2);
                }
                else
                {
                    Console.WriteLine("Ошибка: введено неверное число. Повторите ввод, введите число из представленных на экране: ");
                    goto start;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введён неверный формат.");
            }

            Console.WriteLine("\nTask 6.3");
            int sum, numberofmonth = 0;
            Random rnd = new Random();
            int[] temperature = new int[30];
            int[] months = new int[12];
            for (int m = 0; m < 12; m++) 
            {
                sum = 0;
                for (int i = 0; i < 30; i++)//заполнение массива
                {
                    temperature[i] = rnd.Next(12, 30);
                    sum += temperature[i];
                }
                AverageTemperature(numberofmonth, sum, months); //метод для нахождения средних температур в каждом месяце
                numberofmonth++; //прибавление для метода
            }
            for (int k = 0; k < 12; k++) //сортировка полученного массива
            {
                for (int m = 0; m < 12; m++)
                {
                    if (months[k] < months[m])
                    {
                        int temp = months[k];
                        months[k] = months[m];
                        months[m] = temp;
                    }
                }
            }
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", months));

           

           
            Console.ReadKey();

        }
    }
    
}
