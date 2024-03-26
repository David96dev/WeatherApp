namespace WeatherApp_V3.Models
{

    // [JSON].list.[0].main.temp_min
    //[JSON].list.[0].main.temp_min
    //[JSON].list.[0].wind.speed
    //[JSON].city.name
    //[JSON].list.[0].dt_txt
    public class WeatherForecastData
    {
        //public string Cod { get; set; }
        //public int Message { get; set; }
        //public int Cnt { get; set; }
        public List<ForecastItem> list { get; set; }
        public City city { get; set; }
    }

    public class ForecastItem
    {
        //public long dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        //public Clouds Clouds { get; set; }
        public Wind wind { get; set; }

        public string dt_txt { get; set; }

        //public int Visibility { get; set; }
        //public string DtTxt { get; set; }
        //public Rain Rain { get; set; }
        
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int humidity { get; set; }
    }

    public class Weather
    {
        //public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    //public class Clouds
    //{
    //    public int all { get; set; }
    //}

    public class Wind
    {
        public double speed { get; set; }
    }

    //public class Rain
    //{
    //    public double ThreeH { get; set; }
    //}

    public class City
    {
       public string name { get; set; }
    }

    //public class Coord
    //{
    //    public double lat { get; set; }
    //    public double lon { get; set; }
    //}
}