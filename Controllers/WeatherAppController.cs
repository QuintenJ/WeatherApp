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
            City viewModel = new City();
            return View(viewModel);
        }
    }
}