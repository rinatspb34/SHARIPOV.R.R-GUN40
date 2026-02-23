

using System.Runtime.CompilerServices;

namespace HomeWork
{
    internal class Program
    {
        // Задание 1: Работа со списком строк
        private class ListTask
        {
            private readonly List<string> _listOfStrings;

            public ListTask()
            {
                _listOfStrings = new List<string> { "Яблоко", "Банан", "Апельсин", "Груша" };
            }

            public void TaskLoop()
            {
                Console.WriteLine("=== Задание 1: Работа со списком строк ===");
                Console.WriteLine("Для выхода введите 'exit'");

                Console.WriteLine("\nИсходный список:");
                PrintList();

                // Добавление строки в конец списка
                Console.WriteLine("\nВведите новую строку для добавления в конец списка:");
                string input = Console.ReadLine();

                if (CheckExit(input))
                {
                    return;
                }

                _listOfStrings.Add(input);
                Console.WriteLine("Список после добавления в конец:");
                PrintList();

                // Добавление строки в середину списка
                Console.WriteLine("\nВведите ещё одну строку для добавления в середину списка:");
                input = Console.ReadLine();

                if (CheckExit(input)) 
                {
                    return;
                }

                int middleIndex = _listOfStrings.Count / 2;
                _listOfStrings.Insert(middleIndex, input);

                Console.WriteLine("Список после добавления в середину:");
                PrintList();

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }

            private void PrintList()
            {
                for (int i = 0; i < _listOfStrings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_listOfStrings[i]}");
                }
            }

            private bool CheckExit(string input)
            {
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Выход из задания...");
                    return true;
                }
                return false;
            }
        }

        // Задание 2: Словарь с оценками студентов
        private class DictionaryTask
        {
            private readonly Dictionary<string, double> _studentGrades;

            public DictionaryTask()
            {
                _studentGrades = new Dictionary<string, double>();
            }

            public void TaskLoop()
            {
                Console.WriteLine("=== Задание 2: Словарь с оценками студентов ===");
                Console.WriteLine("Для выхода введите 'exit' в любой момент");

                // Добавление студентов
                Console.WriteLine("\nДобавление студентов (минимум 3 студента для наглядности):");

                for (int i = 0; i < 3; i++)
                {
                    if (!AddStudent()) return;
                }

                // Добавление дополнительных студентов по желанию
                Console.WriteLine("\nХотите добавить ещё студентов? (да/нет)");
                string answer = Console.ReadLine();

                while (answer.ToLower() == "да" || answer.ToLower() == "yes" || answer.ToLower() == "y")
                {
                    if (!AddStudent()) return;

                    Console.WriteLine("Хотите добавить ещё студентов? (да/нет)");
                    answer = Console.ReadLine();
                }

                // Поиск студента по имени
                SearchStudent();

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }

            private bool AddStudent()
            {
                Console.Write("Введите имя студента: ");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                { 
                return false;
                }

                if (_studentGrades.ContainsKey(name))
                {
                    Console.WriteLine("Студент с таким именем уже существует!");
                    return true;


                }

                double grade;
                bool validGrade = false;

                do
                {
                    Console.Write("Введите среднюю оценку (от 2 до 5): ");
                    string gradeInput = Console.ReadLine();

                    if (gradeInput.ToLower() == "exit")
                    { 
                    return false;
                    }

                    if (double.TryParse(gradeInput, out grade))
                    {
                        if (grade >= 2 && grade <= 5)
                        {
                            validGrade = true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: оценка должна быть от 2 до 5!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите корректное число!");
                    }
                } while (!validGrade);

                _studentGrades.Add(name, grade);
                Console.WriteLine($"Студент {name} добавлен с оценкой {grade}");
                return true;
            }

            private void SearchStudent()
            {
                Console.WriteLine("\n=== Поиск студента ===");

                while (true)
                {
                    Console.Write("Введите имя студента для поиска (или 'exit' для выхода из поиска): ");
                    string name = Console.ReadLine();

                    if (name.ToLower() == "exit")
                    { 
                        break;
                    }

                    if (_studentGrades.ContainsKey(name))
                    {
                        Console.WriteLine($"Студент {name} имеет среднюю оценку: {_studentGrades[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Студента с именем '{name}' не существует!");
                    }
                }
            }
        }

        // Задание 3: Двусвязный список
        private class LinkedListTask
        {
            private class Node
            {
                public string Data { get; set; }
                public Node Next { get; set; }
                public Node Previous { get; set; }

                public Node(string data)
                {
                    Data = data;
                    Next = null;
                    Previous = null;
                }
            }

            private Node _head;
            private Node _tail;

            public void TaskLoop()
            {
                Console.WriteLine("=== Задание 3: Двусвязный список ===");
                Console.WriteLine("Для выхода введите 'exit'");

                // Создание списка
                Console.WriteLine("Создание двусвязного списка (от 3 до 6 элементов)");

                int count = 0;
                bool validCount = false;

                do
                {
                    Console.Write("Сколько элементов вы хотите добавить (3-6)? ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit") return;

                    if (int.TryParse(input, out count) && count >= 3 && count <= 6)
                    {
                        validCount = true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите число от 3 до 6!");
                    }
                } while (!validCount);

                // Добавление элементов
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Введите элемент {i + 1}: ");
                    string data = Console.ReadLine();

                    if (data.ToLower() == "exit") return;

                    AddNode(data);
                }

                // Вывод списка в прямом порядке
                Console.WriteLine("\nСписок в прямом порядке:");
                PrintForward();

                // Вывод списка в обратном порядке
                Console.WriteLine("\nСписок в обратном порядке:");
                PrintBackward();


                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }

            private void AddNode(string data)
            {
                Node newNode = new Node(data);

                if (_head == null)
                {
                    _head = newNode;
                    _tail = newNode;
                }
                else
                {
                    _tail.Next = newNode;
                    newNode.Previous = _tail;
                    _tail = newNode;
                }
            }

            private void PrintForward()
            {
                Node current = _head;
                int index = 1;

                while (current != null)
                {
                    Console.WriteLine($"{index}. {current.Data}");
                    current = current.Next;
                    index++;
                }
            }

            private void PrintBackward()
            {
                Node current = _tail;
                int index = 1;

                while (current != null)
                {
                    Console.WriteLine($"{index}. {current.Data}");
                    current = current.Previous;
                    index++;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("== Выберите задание для выполнения: ==");
                Console.WriteLine("1 - Работа со списком строк");
                Console.WriteLine("2 - Словарь с оценками студентов");
                Console.WriteLine("3 - Двусвязный список");
                Console.WriteLine("0 - Выход из программы");

                Console.Write("\nВаш выбор: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int task))
                {
                    switch (task)
                    {
                        case 0:
                            Console.WriteLine("Программа завершена.");
                            return;
                        case 1:
                            CheckTaskFirst();
                            break;
                        case 2:
                            CheckTaskSecond();
                            break;
                        case 3:
                            CheckTaskThird();
                            break;
                        default:
                            Console.WriteLine("Неверный номер задания! Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }
    }
}