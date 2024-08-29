using MauiApp8_weatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp8_weatherApp.Services
{
    public class Api_service
    {
        public  async Task<Root> GetApi(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}", latitude, longitude));
            return JsonConvert.DeserializeObject<Root>(response); 
        }
    }
}
