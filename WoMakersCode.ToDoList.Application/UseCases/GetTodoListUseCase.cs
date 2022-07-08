using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class GetTodoListUseCase : IUseCaseAsync<GetFilter, TaskListResponse>
    {
        private readonly IRepository _todoListRepository;
        private readonly IMapper _mapper;
        public GetTodoListUseCase(IRepository todoListRepository, IMapper mapper)
        {
            _todoListRepository = todoListRepository;
            _mapper = mapper;
        }

        public Task<TaskListResponse> ExecuteAsync(GetFilter request)
        {
            var resposta =  _todoListRepository.GetTaskList(request).Result;

            var response = (TaskListResponse) null;

            if (resposta != null)
            {
                response = _mapper.Map<TaskListResponse>(resposta);
            }

            return Task.FromResult(response);
        }
    }
}
