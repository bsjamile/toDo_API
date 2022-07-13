using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Application.UseCases;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Abstractions;
using WoMakersCode.ToDoList.Core.DTOs;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.Controllers
{
    [ApiController]
    [Route("api/todolist")]
    public class ToDoListController : ControllerBase
    {

        private readonly ILogger<ToDoListController> _logger;
        private readonly IUseCaseAsync<TaskListInsertRequest, TaskListResponse> _insertUseCase;
        private readonly IUseCaseAsync<GetFilter, TaskListResponse> _getUseCase;
        private readonly IUseCaseAsync<TaskRequest, TaskResponse> _insertTaskDetailUseCase;
        private readonly IUseCaseAsync<string, WeatherDTO> _getWeatherForecastUseCase;
        private readonly IUseCaseAsync<TaskListRequest, TaskListResponse> _updateUseCase;

        public ToDoListController(ILogger<ToDoListController> logger,
            IUseCaseAsync<TaskListInsertRequest, TaskListResponse> insertUseCase,
            IUseCaseAsync<GetFilter, TaskListResponse> getUseCase,
            IUseCaseAsync<TaskRequest, TaskResponse> insertTaskDetailUseCase,
            IUseCaseAsync<string, WeatherDTO> getWeatherForecastUseCase,
            IUseCaseAsync<TaskListRequest, TaskListResponse> updateUseCase)
        {
            _logger = logger;
            _insertUseCase = insertUseCase;
            _getUseCase = getUseCase;
            _insertTaskDetailUseCase = insertTaskDetailUseCase;
            _getWeatherForecastUseCase = getWeatherForecastUseCase;
            _updateUseCase = (UpdateTaskListUseCase)updateUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<TaskListResponse>> Get([FromQuery]GetFilter filter)
        {
            var response = await _getUseCase.ExecuteAsync(filter);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<TaskListResponse> Post([FromBody]TaskListInsertRequest request)
        {
            return await _insertUseCase.ExecuteAsync(request);
        }

        [HttpPost("task")]
        public async Task<TaskResponse> PostTask([FromBody] TaskRequest request)
        {
            return await _insertTaskDetailUseCase.ExecuteAsync(request);
        }

        [HttpGet("weatherforcast")]
        public async Task<ActionResult<WeatherDTO>> GetWeatherForcast()
        {
            var response = await _getWeatherForecastUseCase.ExecuteAsync(string.Empty);

            return new OkObjectResult(response);
        }

        [HttpPut]
        public async Task<TaskListResponse> Put([FromBody] TaskListRequest request)
        {
            return await _updateUseCase.ExecuteAsync(request);
        }
    }
}
