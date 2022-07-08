
using System.Collections.Generic;

namespace WoMakersCode.ToDoList.Core.DTOs
{
    public class WeatherDTO
    {
        public List<Weather> weather { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
    }
}