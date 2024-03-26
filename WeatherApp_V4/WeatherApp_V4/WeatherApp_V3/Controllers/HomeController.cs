using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp_V3.Models;

namespace WeatherApp_V3.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiKey = "b2d3ffa681763c6b3031bde24550a6b1";

        public IActionResult Index()
        {
            return View();
        }
        //------------------------ FETCHING THE TWO MODELS -------------------

        [HttpGet]
        public async Task<IActionResult> GetWeatherData(double latitude, double longitude)
        {
            var viewModel = new WeatherViewModel();

            // Fetch current weather data
            viewModel.CurrentWeather = await GetWeatherByLocation(latitude, longitude);

            // Fetch weather forecast data
            viewModel.ForecastWeather = await GetWeatherForecastByLocation(latitude, longitude);

            return Ok(viewModel);
        }



        // ------------------------ CURRENT WEATHER -----------------------

        [HttpGet]
        public async Task<WeatherData> GetWeatherByLocation(double latitude, double longitude)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Construct the OpenWeatherMap API URL
                    string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_apiKey}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON directly to a WeatherData object
                        WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonString);

                        if (weatherData != null)
                        {
                            return weatherData;
                        }
                        else
                        {
                            // Handle the case when weatherData is null
                            throw new Exception("Error retrieving weather data.");
                        }
                    }
                    else
                    {
                        // Handle the case when the response is not successful
                        throw new Exception($"Error retrieving weather data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }
        // ----------------------- WEATHER FORECAST ------------------------

        [HttpGet]
        public async Task<WeatherForecastData> GetWeatherForecastByLocation(double latitude, double longitude)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Construct the OpenWeatherMap API URL for forecast
                    string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&appid={_apiKey}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON directly to a WeatherForecastData object
                        WeatherForecastData forecastData = JsonSerializer.Deserialize<WeatherForecastData>(jsonString);

                        if (forecastData != null)
                        {
                            return forecastData;
                        }
                        else
                        {
                            // Handle the case when forecastData is null
                            throw new Exception("Error retrieving weather forecast data.");
                        }
                    }
                    else
                    {
                        // Handle the case when the response is not successful
                        throw new Exception($"Error retrieving weather forecast data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }


        [HttpGet]
        public IActionResult Forecast()
        {
            return View();
        }

    }
    
}