using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Infra.Database;

namespace WoMakersCode.ToDoList.Infra.Repositories
{
    public class ToDoListRepository : IRepository
    {
        private readonly ApplicationContext _context;

        public ToDoListRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TaskList> GetTaskList(GetFilter filter)
        {
            var result = _context
                .TaskLists
                .Include(id => id.Details)
                .AsQueryable();

            if(filter.Id != 0)
            {
                result = result.Where(w => w.Id == filter.Id);
            }
            if (!string.IsNullOrEmpty(filter.Pesquisa))
            {
                result = result.Where(w => w.ListName.Contains(filter.Pesquisa));
            }
            
            return await result
                .AsNoTracking()
                .FirstOrDefaultAsync(); //Vai no banco e busca = materializacao de busca
        }

        public Task Inserir(TaskList taskList)
        {
            _context.Add(taskList);

            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task InserirTask(TaskDetail taskDetail)
        {
            _context.Add(taskDetail);

            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task UpdateTaskList(TaskList taskList)
        {
            _context.Update(taskList);

            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
