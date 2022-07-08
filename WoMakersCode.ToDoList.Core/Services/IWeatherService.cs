using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.DTOs;

namespace WoMakersCode.ToDoList.Core.Services
{
    public interface IWeatherService
    {
        Task<WeatherDTO> ReadWeather();
    }
}
