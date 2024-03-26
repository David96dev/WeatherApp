namespace WeatherApp_V3.Models
{

    // [JSON].name
    //[JSON].main.temp_max
    //[JSON].weather.[0].icon

    public class WeatherData
    {
        public CurrentMain main { get; set; }
        public CurrentWind wind { get; set; }

        public string name { get; set; }
        public List<CurrentWeather> weather { get; set; }
        
        //Accesing to the new url: 

        //public List<Datum> list { get; set; }

        // Constructor to initialize the list
        public WeatherData()
        {
            weather = new List<CurrentWeather>();
            //list = new List<Datum>();
        }
    }

    
    public class CurrentMain
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int humidity { get; set; }
        public double temp_max { get; set; }
        public double temp_min { get; set; }
    }

    public class CurrentWind
    {
        public double speed { get; set; }
    }

    public class CurrentWeather
    {
        public string icon { get; set; }
    }

    //public class Datum
    //{
    //    public string dt { get; set; }
    //}
}