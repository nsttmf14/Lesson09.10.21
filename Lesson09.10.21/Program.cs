using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Lesson09._10._21
{
    class Program
    {
        struct Student//структура для студентов
        {
            public string name;
            public string surname;
            public ushort YearOfBirth;
            public string subjectBase;
            public ushort scores;
        }
        static List<Student> SortList(List<Student> list)//создание листа с баллами студентов
        {
            int left = 0, right = list.Count() - 1;
            Student a, b;
            if (left >= right)
            {
                return list;
            }
            var fundation = left - 1;
            for (var i = left; i < right; i++)
            {
                if (list[i].scores < list[right].scores)
                {
                    fundation++;
                    a = list[fundation];
                    b = list[i];
                    Swap(ref a, ref b);
                }
            }
            return list;
        }
        static void Swap(ref Student x, ref Student y)//сортировка студентов
        {
            var t = x;
            x = y;
            y = t;
        }
        
            static void Main(string[] args)
        {



                   Console.WriteLine("Task 1");
            int count;
            Console.Write("Введите количество викингов в каждой команде:");
            count = Convert.ToInt32(Console.ReadLine());
            int[] BavarianBeerBears = new int[count];
            int[] ScandinavianSchollers = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{i + 1} викинг из \"Bavarian Beer Bears\" показал: ");
                BavarianBeerBears[i] = Convert.ToByte(Console.ReadLine());
            }
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{i + 1} викинг из \"Scandinavian Schollers\" показал: ");
                ScandinavianSchollers[i] = Convert.ToByte(Console.ReadLine());
            }
            var BavariansFive = BavarianBeerBears.Count(x => x == 5);
            Console.WriteLine("Количество пятёрок в \"Bavarian Beer Bear\": " + BavariansFive);
            var SchollersFive = ScandinavianSchollers.Count(x => x == 5);
            Console.WriteLine("Количество пятёрок в \"Bavarian Beer Bear\": " + SchollersFive);
            if (BavariansFive == SchollersFive)
            {
                Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
            }
            else
            {
                Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива!");
            }


                   Console.WriteLine("\nTask 3");
            string StringOfFile;
            int numberString = 1;
            StreamReader reader = new StreamReader("C:\\Windows\\список группы.txt");
            List<Student> students = new List<Student>();

            while ((StringOfFile = reader.ReadLine()) != null) //пока строка не окажется пустой, т.е. пока не закончится список студентов
            {
                string[] dateStudent = StringOfFile.Split();
                Student studentNew;
                studentNew.name = dateStudent[0];
                studentNew.surname = dateStudent[1];
                studentNew.subjectBase = dateStudent[3];
                numberString++;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("* * * Меню * * *\n1.Новый студент\n2.Удалить студента\n3.Сортировать имеющиеся данные\nВыберите необходимую операцию: ");
                byte choice = Convert.ToByte(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Student studentNew;//в этом случае воздаст нового студента
                        Console.Write("Введите имя нового студента: ");
                        studentNew.name = Console.ReadLine();
                        Console.Write("Введите фамилию: ");
                        studentNew.surname = Console.ReadLine();
                        Console.Write("Введите год рождения: ");
                        studentNew.YearOfBirth = Convert.ToUInt16(Console.ReadLine());
                        Console.Write("Введите предмет: ");
                        studentNew.subjectBase = Console.ReadLine();
                        Console.Write("Введите количество баллов: ");
                        studentNew.scores = Convert.ToUInt16(Console.ReadLine());
                        students.Add(studentNew);
                        break;
                    case 2:
                        Console.Write("Введите фамилию студента: ");//в этом случае найдет нужного студента в списке
                        string SurnameRemove = Console.ReadLine();
                        Console.Write("Введите имя студента: ");
                        string NameRemove = Console.ReadLine();
                        foreach (Student student in students)
                        {
                            if (student.name.Equals(NameRemove) && student.surname.Equals(SurnameRemove))
                            {
                                students.Remove(student);//найдет и удалит
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: совпадений не найдено.");
                            }
                        }
                        break;
                    case 3:
                        SortList(students);//в этом случае отсортирует студентов
                        break;
                    default:
                        flag = false;
                        Console.WriteLine("Ошибка: введено неверное число.");
                        break;
                }
            }
           
        }
    }
}
