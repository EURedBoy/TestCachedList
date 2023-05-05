using System.Text.Json.Serialization;

namespace TestCachedList.Model;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class CurrentWeather
    {
        [JsonPropertyName("Temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("Windspeed")]
        public double Windspeed { get; set; }

        [JsonPropertyName("Winddirection")]
        public int Winddirection { get; set; }

        [JsonPropertyName("Weathercode")]
        public int Weathercode { get; set; }

        [JsonPropertyName("IsDay")]
        public int IsDay { get; set; }

        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }
    }

    public class Hour
    {
        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("Temperature2m")]
        public double Temperature2m { get; set; }

        [JsonPropertyName("Windspeed10m")]
        public double Windspeed10m { get; set; }
    }

    public class WeatherModel
    {
        [JsonPropertyName("Note")]
        public string Note { get; set; }

        [JsonPropertyName("LastUpdate")]
        public DateTime LastUpdate { get; set; }

        [JsonPropertyName("TimeLapseMs")]
        public int TimeLapseMs { get; set; }

        [JsonPropertyName("Timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("UtcOffsetSeconds")]
        public int UtcOffsetSeconds { get; set; }

        [JsonPropertyName("CurrentWeather")]
        public CurrentWeather CurrentWeather { get; set; }

        [JsonPropertyName("WeekDays")]
        public List<WeekDay> WeekDays { get; set; }
    }

    public class WeekDay
    {
        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("Weathercode")]
        public int Weathercode { get; set; }

        [JsonPropertyName("Temperature2mMin")]
        public double Temperature2mMin { get; set; }

        [JsonPropertyName("PrecipitationProbabilityMax")]
        public int PrecipitationProbabilityMax { get; set; }

        [JsonPropertyName("Windspeed10mMax")]
        public double Windspeed10mMax { get; set; }

        [JsonPropertyName("Hours")]
        public List<Hour> Hours { get; set; }
    }

