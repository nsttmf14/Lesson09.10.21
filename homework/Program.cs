using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace homework
{
    class Program
    {
        static int GetCountVowels(string reader)//список для гласных букв(6.1)
        {
            int lowelscount = 0;
            List<char> vowels = new List<char>() { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            for (int i = 0; i < reader.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (reader[i] == vowels[j])
                    {
                        lowelscount++;
                    }
                }
            }
            return lowelscount;
        }
        static int GetCountConsonans(string reader)//список для согласных букв(6.1)
        {
            int consonanscount = 0;
            List<char> consonans = new List<char>() { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ъ' };
            for (int i = 0; i < reader.Length; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    if (reader[i] == consonans[j])
                    {
                        consonanscount++;
                    }
                }
            }
            return consonanscount;
        }
        static void Print(LinkedList<int> Array1, LinkedList<int> Array2)//печать матриц
        {
            Console.WriteLine("1ая матрица:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(Array1.First() + " ");
                if (i == 1 || i == 3)
                {
                    Console.WriteLine();
                }
                Array1.RemoveFirst();
            }
            Console.WriteLine("2ая матрица:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(Array2.First() + " ");
                if (i == 1)
                {
                    Console.WriteLine();
                }
                Array2.RemoveFirst();
            }
        }
        static void Multiplication(LinkedList<int> matrix1, LinkedList<int> matrix2)//перемножение матриц
        {
            int a11, a12, a21, a22;
            a11 = matrix1.ElementAt(0) * matrix2.ElementAt(0) + matrix1.ElementAt(1) * matrix2.ElementAt(2);
            a12 = matrix1.ElementAt(0) * matrix2.ElementAt(1) + matrix1.ElementAt(1) * matrix2.ElementAt(3);
            a21 = matrix1.ElementAt(2) * matrix2.ElementAt(0) + matrix1.ElementAt(3) * matrix2.ElementAt(2);
            a22 = matrix1.ElementAt(2) * matrix2.ElementAt(1) + matrix1.ElementAt(3) * matrix2.ElementAt(3);
            Console.WriteLine(a11 + " " + a12 + "\n" + a21 + " " + a22);
        }

        static void AverageTemperature(int numberofmonth, double sum, Dictionary<int, double> months)//средняя температура
        {
            months[numberofmonth] = Math.Round(sum / 30, 2);
            Console.WriteLine($"в {numberofmonth + 1} месяце выпало примерно осадков: " + months[numberofmonth]);
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

            Console.WriteLine("Task 6.1");
            string reader = (File.ReadAllText("C:\\Windows\\задание 6.1.txt"));
            Console.WriteLine($"Количество гласных: {GetCountVowels(reader)}\nКоличество согласных: {GetCountConsonans(reader)}");

            Console.WriteLine("\nTask 6.2");
            LinkedList<int> matrix1 = new LinkedList<int>();
            LinkedList<int> matrix2 = new LinkedList<int>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine($"Введите a({i + 1},{j + 1}) для 1ой и 2ой матрицы:");
                    matrix1.AddLast(Convert.ToInt32(Console.ReadLine()));
                    matrix2.AddLast(Convert.ToInt32(Console.ReadLine()));

                }
            }
            Console.WriteLine("1 - печать матриц\n2 - умножение матриц\nВыберите: ");
            try
            {
            start:
                int todo = Convert.ToInt32(Console.ReadLine());
                if (todo == 1)
                {
                    Print(matrix1, matrix2);
                }
                else if (todo == 2)
                {
                    Multiplication(matrix1, matrix2);
                }
                else
                {
                    Console.WriteLine("Ошибка: введеное неверное число. Повторите ввод: ");
                    goto start;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введён неверный формат.");
            }

            Console.WriteLine("\nTask 6.3");
            Random rnd = new Random();
            Dictionary<int, double> months = new Dictionary<int, double>(12);
            double sum; int numberofmonth = 0;
            double[] temperature = new double[30];
            for (int m = 0; m < 12; m++) //заполнение месяцей и дней температурами
            {
                sum = 0;
                for (int i = 0; i < 30; i++)
                {
                    temperature[i] = rnd.Next(120, 300) / 10;
                    sum += temperature[i];
                }
                AverageTemperature(numberofmonth, sum, months); //метод для нахождения средних температур в каждом месяце
                numberofmonth++; //прибавление для метода
            }
            for (int k = 0; k < 12; k++) //сортировка массива средних температур
            {
                for (int l = 0; l < 12; l++)
                {
                    if (months[k] < months[l])
                    {
                        double buffer = months[k];
                        months[k] = months[l];
                        months[l] = buffer;
                    }
                }
            }
            Console.Write("Отсортированный массив: ");
            foreach (var celsium in months)
                Console.Write(celsium.Value + ", ");

            Console.WriteLine("Task6.1");
            string[] passarray = new string[] { "password123", "админ", "пользователя admin1" };
            Console.WriteLine(decode(passarray, "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

            Console.WriteLine("Task6.2");

            string stR = "aa AAAA ffff какдпдкид";
            string[] words = stR.Split(new char[] { ' ' });
            string word1 = words[0];
            string word2 = words[1];
            string word3 = words[2];
            string word4 = words[3];
            string alfavit = "АЕЁИОУЫЭЮЯ";
            for (int i = 0; i < 4; i++)
            {

                words[i] = words[i].ToUpper();
                words[i] = words[i] + "!!!!";
                words[i] = words[i].Replace("А", "@");
                foreach (var k in alfavit)
                {
                    words[i] = words[i].Replace(k, '*');
                }

            }
            for (int i = 0; i < 4; i++)
            {
                Console.Write(words[i]);
            }









            Console.WriteLine("долг, задание с графом");
            int verticesCount = 10;
            int[,] adjacency = new int[verticesCount, verticesCount];
            rnd = new Random();

            // Псевдослучайное заполнение матрицы смежности
            for (int row = 0; row < verticesCount - 1; row++)
                for (int col = row + 1; col < verticesCount; col++)
                    if (rnd.Next(3) < 1)
                    {
                        adjacency[row, col] = 1;
                        adjacency[col, row] = 1;
                    }

            Console.WriteLine("***************************************");
            Console.WriteLine("Обход графа в глубину с печатью вершин.");
            PrintDeep(adjacency);

            Console.WriteLine("***************************************");
            Console.WriteLine("Обход графа в ширину с печатью вершин.");
            PrintWidth(adjacency);
        }

        static bool IsVerifyGraf(int[,] adjacency)//проверка на ошибки
        {
            int verticesCount = adjacency.GetLength(0);
            if (verticesCount != adjacency.GetLength(1))
            {
                Console.WriteLine("Ошибка! Матрица смежности неверной размерности!");
                return false;
            }
            bool error = false;
            for (int row = 0; row < verticesCount; row++)
            {
                if (adjacency[row, row] != 0)
                    error = true;
                for (int col = row + 1; col < verticesCount; col++)
                    if (adjacency[row, col] != adjacency[col, row])
                    {
                        error = true;
                        break;
                    }
                if (error)
                    break;
            }
            if (error)
            {
                Console.WriteLine("Ошибка! Матрица смежности ошибочна!");
                return false;
            }
            return true;
        }

        static void PrintVert(int Vert, int[,] adjacency)//построение вершин
        {
            if (!IsVerifyGraf(adjacency))
                return;
            Console.Write($"Вершина {Vert}. Смежна с вершинами:");
            int verticesCount = adjacency.GetLength(0);
            for (int col = 0; col < verticesCount; col++)
                if (adjacency[Vert, col] != 0)
                    Console.Write($"  {col}");
        }

        static void PrintDeep(int[,] adjacency)//обход в глубину(смежные)
        {
            if (!IsVerifyGraf(adjacency))
                return;

            int verticesCount = adjacency.GetLength(0);

            List<int> vertList = new List<int>();
            Stack<int> vertStack = new Stack<int>();

            for (int vert = 0; vert < verticesCount; vert++)
            {
                //if (vertList.IndexOf(vert) >= 0)
                //    continue;

                int vertCurr = vert;
                while (true)
                {
                    if (vertList.IndexOf(vertCurr) < 0)
                    {
                        PrintVert(vertCurr, adjacency);
                        Console.WriteLine();
                        vertList.Add(vertCurr);

                        for (int col = 0; col < verticesCount; col++)
                            if (adjacency[vertCurr, col] != 0 && vertList.IndexOf(col) < 0)
                                vertStack.Push(col);
                    }

                    if (vertStack.Count == 0)
                        break;

                    vertCurr = vertStack.Pop();
                }

            }

        }

        static void PrintWidth(int[,] adjacency)//обход в ширину(смежные)
        {
            if (!IsVerifyGraf(adjacency))
                return;

            int verticesCount = adjacency.GetLength(0);

            List<int> vertList = new List<int>();
            Queue<int> vertQueue = new Queue<int>();

            for (int vert = 0; vert < verticesCount; vert++)
            {
                //if (vertList.IndexOf(vert) >= 0)
                //    continue;

                int vertCurr = vert;
                while (true)
                {
                    if (vertList.IndexOf(vertCurr) < 0)
                    {
                        PrintVert(vertCurr, adjacency);
                        Console.WriteLine();
                        vertList.Add(vertCurr);

                        for (int col = 0; col < verticesCount; col++)
                            if (adjacency[vertCurr, col] != 0 && vertList.IndexOf(col) < 0)
                                vertQueue.Enqueue(col);
                    }

                    if (vertQueue.Count == 0)
                        break;

                    vertCurr = vertQueue.Dequeue();
                }

            }

        }
    }
}
