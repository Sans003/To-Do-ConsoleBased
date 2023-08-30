using System;
using System.Reflection;
using Newtonsoft.Json;
using To_Do_ConsoleBased;

namespace ToDoConsoleBased
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoList.MainMenu();
        }
    }
    class ToDoList
    {
        public string title;
        public int priority;
        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"
                Welcome to your personal To-Do-List!

                select from the following actions:

                1. list existing to do items
                2. create new item
                3. delete existing item
                4. exit
                ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("placeholder");
                        break;
                    case 2:
                        createItem();
                        break;
                    case 3:
                        Console.WriteLine("another placeholder");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("no statement please try again");
                        break;
                }
            }
        }
        public static void createItem()
        {
            Console.WriteLine("What do you want to do?");
            string title = Console.ReadLine();
            Console.WriteLine($"What priority does '{title}' have? (1-3)");
            var choice = Console.ReadLine();
            bool priorityCheck = false;
            int priority = 0;
            while (priorityCheck == false) {
                switch (choice)
                {
                    case "1":
                    case "2":
                    case "3":
                        priority = Convert.ToInt32(choice);
                        priorityCheck = true;
                        break;
                    default:
                        Console.WriteLine("please enter a valid integer.");
                        choice = Console.ReadLine();
                        break;
                    }
            JsonHandler jsonItem = new(title, priority);
            }

        }
    }
}