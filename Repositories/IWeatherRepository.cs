using WeatherApp.OpenWeatherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Repositories
{
    public interface IWeatherRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
