using System.Net.Http.Json;
using SettingsProxy;
using TestCachedList;
using TestCachedList.Model;


//await TestCachedList();
//await TestRefreshList();


static async Task TestRefreshList()
{ 
    RefreshList<DateTime> refreshList = new RefreshList<DateTime>(5, async () => 
    { 
        var result = await _client.GetFromJsonAsync<WeatherModel>(
            "https://formattedweather.azurewebsites.net/FormattedWeather?latitude=45.2&longitude=9.2799&current_weather=true&hourly=temperature_2m,windspeed_10m&daily=weathercode,temperature_2m_max,temperature_2m_min,precipitation_probability_max,windspeed_10m_max&timeformat=unixtime&timezone=auto"); 
        return new List<DateTime>() { result.LastUpdate }; 
    });
    
    await Task.Delay(3000); //Deve fare la richiesta async
    
    while (true)
    {
        Console.WriteLine(refreshList[0]);
        await Task.Delay(1000);
    }
}

static async Task TestCachedList()
{
    CachedMap<int, WeatherModel?> cachedMap = new CachedMap<int, WeatherModel?>(
        async (pos) =>
        {
            Console.WriteLine("Riprendo i dati siccome si sono eliminati");
            return await _client.GetFromJsonAsync<WeatherModel>(
                $"https://formattedweather.azurewebsites.net/FormattedWeather?latitude=45.2&longitude=9.2799&current_weather=true&hourly=temperature_2m,windspeed_10m&daily=weathercode,temperature_2m_max,temperature_2m_min,precipitation_probability_max,windspeed_10m_max&forecast_days={pos}&timeformat=unixtime&timezone=auto");
        }, 10);

    while (true)
    {
        Console.WriteLine(cachedMap[1].LastUpdate);
        await Task.Delay(1000);
    }
}





    partial class Program
{
    private static HttpClient _client = new HttpClient();
}