﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace To_Do_ConsoleBased
{
    internal class JsonHandler
    {
        private static readonly string JsonFileName = Path.Combine(Directory.GetCurrentDirectory(), "data.json");

        public static List<ToDoItem> ReadItems()
        {
            List<ToDoItem> items;
            if (File.Exists(JsonFileName))
            {
                string json = File.ReadAllText(JsonFileName);
                items = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
            }
            else
            {
                items = new List<ToDoItem>();
            }
            return items;
        }

        public static void WriteItems(List<ToDoItem> items)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(JsonFileName, json);
        }
        public static void RemoveItems(List<ToDoItem> items, string id = "*")
        {
            if (id == "*")
            {
                File.WriteAllText(JsonFileName, "");
            }
            else
            {
                foreach (ToDoItem item in items)
                {
                    if (item.ID == id)
                    {
                        items.Remove(item);
                    }
                }
            }
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(JsonFileName, json);
        }
    }
    internal class ToDoItem
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public bool Done { get; set; }
    }
}
