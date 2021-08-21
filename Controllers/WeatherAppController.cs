using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WeatherAppModels;
using WeatherApp.OpenWeatherModels;
using WeatherApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    public class WeatherAppController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;

        // Dependency Injection
        public WeatherAppController(IWeatherRepository weatherAppRepo)
        {
            _weatherRepository = weatherAppRepo;
        }

        // GET: WeatherApp/SearchCity
        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        // POST: WeatherApp/SearchCity
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherApp", new { city = model.CityName });
            }
            return View(model);
        }

        // GET: WeatherApp/City
        public IActionResult City(string city)
        {
            // Consume the OpenWeatherAPI bring Weather data in.
            WeatherResponse weatherResponse = _weatherRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);
        }
    }
}