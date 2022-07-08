using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.DTOs;
using WoMakersCode.ToDoList.Core.Services;

namespace WoMakersCode.ToDoList.Infra.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<WeatherDTO> ReadWeather()
        {
            using var httpClient = new HttpClient();
            var result = await httpClient
                .GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=17c2084724ab40b0404d728b45c50859");

            var response = new WeatherDTO();
            if (result.IsSuccessStatusCode)
            {
                var responseString = await result.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<WeatherDTO>(responseString);
            }

            return response;
        }
    }
}
