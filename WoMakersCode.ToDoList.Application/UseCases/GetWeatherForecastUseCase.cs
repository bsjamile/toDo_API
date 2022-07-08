using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.DTOs;
using WoMakersCode.ToDoList.Core.Services;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class GetWeatherForecastUseCase : IUseCaseAsync<string, WeatherDTO>
    {
        public readonly IWeatherService _weatherService;

        public GetWeatherForecastUseCase(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<WeatherDTO> ExecuteAsync(string request)
        {
            return await _weatherService.ReadWeather();
        }
    }
}
