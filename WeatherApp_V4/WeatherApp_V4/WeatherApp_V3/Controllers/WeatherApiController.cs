using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using WeatherApp_V3.Models;

namespace WeatherApp_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private readonly string _apiKey = "b2d3ffa681763c6b3031bde24550a6b1";
        [HttpGet]
        public async Task<IActionResult> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("Please provide a city name.");
            }

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        WeatherData weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
                        return Ok(weatherData);
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Error retrieving weather data.");
                    }
                }
                catch (HttpRequestException ex)
                {
                    return StatusCode(500, $"Error: {ex.Message}");
                }
            }
        }
    }
}
