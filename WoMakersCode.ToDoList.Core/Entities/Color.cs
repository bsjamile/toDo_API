using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.ToDoList.Core.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskList TaskList { get; set;}
    }
}
