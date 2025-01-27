using MauiApp8_weatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp8_weatherApp.Services
{
    public static class Api_service
    {
        public  static async Task<Root> GetApi(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=182b604b2700ccbb9f0f5dc32a75614f", latitude, longitude));
            return JsonConvert.DeserializeObject<Root>(response);
        }
        public static async Task<Root> GetWeatherByCity(string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid=f2de4bda98a8aa42055ac068ff0e6876", city));
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
