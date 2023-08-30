using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_ConsoleBased
{
    internal class JsonHandler
    {
        string _jsonTitle = "data.json";
        string _jsonInnerTitle = "ToDoItems";
        string _itemTitle;
        int _priority;
        bool _done = false;

        public JsonHandler(string? title, int priority)
        {
            this._itemTitle = title;
            this._priority = priority;
            Console.WriteLine($"You have created '{_itemTitle}' with priority {_priority}, which is done = {_done}");
            Console.ReadLine();
        }
    }
}
