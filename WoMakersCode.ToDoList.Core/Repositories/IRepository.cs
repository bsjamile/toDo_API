using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.Core.Repositories
{
    public interface IRepository
    {
        Task Inserir(TaskList taskList);
        Task<TaskList> GetTaskList(GetFilter filter);
        Task InserirTask(TaskDetail taskDetail);
        Task UpdateTaskList(TaskList taskList) ;
    }
}
