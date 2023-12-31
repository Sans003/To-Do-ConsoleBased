﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
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
                List<ToDoItem> items = JsonHandler.ReadItems();
                Console.Clear();
                Console.Write(@"
                Welcome to your personal To-Do-List!
                ");
                foreach (ToDoItem item in items)
                {
                    if (item.Done == false)
                    {
                        Console.WriteLine(@$"
                        ID: {item.ID}
                        Title: {item.Title}
                        Priority: {item.Priority}
                        Done?: {item.Done}"
                        );
                    }
                };
                Console.Write(@" 
                select from the following actions:

                1. create new item
                2. remove existing item  syntax: 2 <ItemID> or * for all
                3. edit existing item    syntax: 3 <ItemID> <ItemAttribute> <change> (Attributes: title, priority, done)
                4. exit                                 
                ");
                string? input = Console.ReadLine();
                if (input.Length > 1 && input[0] == '2' || input[0] == '3')
                {
                    string arguments = input[2..];
                    char response = input[0];
                    Console.WriteLine();
                    switch (response)
                    {
                        case '2':
                            removeItem(arguments);
                            break;
                        case '3':
                            editItem(arguments);
                            break;
                        case '4':
                            Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("no statement please try again");
                            break;
                    }
                }
                else if (input.Length == 1 && input[0] == '1')
                {
                    char response = input[0];
                    switch (response)
                    {
                        case '1':
                            createItem();
                            break;
                        default:
                            Console.WriteLine("no statement please try again");
                            break;
                    }
                }
                else if (input.Length == 1 && input[0] == '4')
                {
                    char response = input[0];
                    switch (response)
                    {
                        case '4':
                            Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("no statement please try again");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error: no argument has been given");
                }
            }
        }

        private static void editItem(string arguments)
        {
            List<ToDoItem> items = JsonHandler.ReadItems();
            string[] args = SplitArguments(arguments);

            if (args.Length < 3 && args[1] != "done")
            {
                Console.WriteLine("Invalid number of arguments. Expected at least 3.");
                return;
            }

            int argg = int.Parse(args[0]);
            string arg2 = args[1];
            foreach (ToDoItem item in items)
            {
                if (item.ID == argg)
                {
                    Console.WriteLine(arg2, args[2]);
                    if (arg2 == "title")
                    {
                        item.Title = args[2];
                        break;
                    }
                    else if (arg2 == "priority")
                    {
                        item.Priority = int.Parse(args[2]);
                        break;
                    }
                    else if (arg2 == "done")
                    {
                        item.Done = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ItemAttribute please try again");
                        break;
                    }
                }
            }
            JsonHandler.WriteItems(items);
        }

        private static string[] SplitArguments(string input)
        {
            List<string> arguments = new List<string>();
            Regex regex = new Regex(@"[^\s""]+|""[^""]*""");

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                string argument = match.Value;
                if (argument.StartsWith("\"") && argument.EndsWith("\""))
                {
                    arguments.Add(argument.Trim('"'));
                }
                else
                {
                    arguments.Add(argument);
                }
            }

            return arguments.ToArray();
        }

        public static void removeItem(string arguments)
    {
        string[] args = arguments.Split();
        foreach (string arg in args)
        {
            char argg = char.Parse(arg);
            if (argg == '*')
            {
                JsonHandler.RemoveItems();
            }
            else if (char.IsDigit(argg))
            {
                JsonHandler.RemoveItems(Convert.ToString(argg));
            }
        }

    }
    public static void createItem()
    {
        int veryCoolId = 0;
        List<ToDoItem> items = JsonHandler.ReadItems();
        Console.WriteLine("What do you want to do?");
        string title = Console.ReadLine();
        Console.WriteLine($"What priority does '{title}' have? (1-3)");
        int priority = GetValidPriority();
        if (items.Count > 0)
        {
            veryCoolId = items.Max(x => x.ID) + 1;
        }
        items.Add(new ToDoItem { ID = veryCoolId, Title = title, Priority = priority, Done = false });
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