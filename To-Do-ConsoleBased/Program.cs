using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using To_Do_ConsoleBased;

namespace To_Do_ConsoleBased
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

        public static List<ToDoItem> items = JsonHandler.ReadItems();
        public string title;
        public int priority;
        public static string id = "*";

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
                3. remove existing item
                4. edit existing item
                5. remove all
                6. exit
                ");
                char response = Console.ReadLine()[0];
                Console.WriteLine();
                switch (response)
                {
                    case '1':
                        List<ToDoItem> items = JsonHandler.ReadItems();
                        foreach (ToDoItem item in items)
                        {
                            if (item.Done == false) { 
                            Console.WriteLine(@$"
                            Title: {item.Title}
                            Priority: {item.Priority}
                            Done?: {item.Done}");
                            }
                        }
                        Console.ReadLine();
                        break;
                    case '2':
                        createItem();
                        break;
                    case '3':
                        Console.WriteLine("another placeholder");
                        break;
                    case '4':
                        Console.WriteLine("another placeholder");
                        break;
                    case '5':
                        JsonHandler.RemoveItems(id);
                        break;
                    case '6':
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
            int priority = GetValidPriority();

            List<ToDoItem> items = JsonHandler.ReadItems();
            items.Add(new ToDoItem { Title = title, Priority = priority, Done = false });
            JsonHandler.WriteItems(items);
            Console.WriteLine($"Created '{title}' with priority {priority}.");
        }

        public static int GetValidPriority()
        {
            int priority;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out priority) && priority >= 1 && priority <= 3)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid priority (1-3).");
            }
            return priority;
        }
    }
}