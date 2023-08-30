using System;

namespace ToDoConsoleBased
{
    class ToDoList
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"""
    Welcome to your personal To-Do-List!

    select from the following actions:

    1. list existing to do items
    2. create new item
    3. delete existing item
    4. exit
    """);
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("placeholder");
                        break;
                    case 2:
                        Console.WriteLine("placeholder");
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
    }
}