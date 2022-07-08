using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.ToDoList.Application.Models
{
    public class TaskListRequest
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public int IdColor { get; set; }
    }
}
