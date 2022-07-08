using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class UpdateTaskListUseCase : IUseCaseAsync<TaskListRequest, TaskListResponse>
    {
        private readonly IRepository _todoListRepository;
        private readonly IMapper _mapper;
        public UpdateTaskListUseCase(IRepository todoListRepository, IMapper mapper)
        {
            _todoListRepository = todoListRepository;
            _mapper = mapper;
        }
        public Task<TaskListResponse> ExecuteAsync(TaskListRequest request)
        {
            var req = _mapper.Map<TaskList>(request);
            _todoListRepository.UpdateTaskList(req);

            return Task.FromResult(new TaskListResponse());
        }
    }
}
