using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace ClarissaJoy.PrelimExam.Pages
{
    public class IndexModel : PageModel
    {
       

        public class FormModel : PageModel
        {

            public WeatherData? Data { get; set; }
            public async Task<IActionResult> OnGet()
            {
                var client = new RestClient("https://fcc-weather-api.glitch.me/api/");

                var request = new RestRequest("current", Method.Get);

                RestResponse response = client.Execute(request);
                request.AddQueryParameter("lat", 14.8781);
                request.AddQueryParameter("lon", 120.4546);
                var content = response.Content;

                var area = JsonConvert.DeserializeObject<WeatherData>(content);

                return Page();
            }
            public class WeatherData
            {
                public List<WeatherDetails>? Weather { get; set; }
                public WeatherMain? Main { get; set; }
            }
            public class WeatherMain
            {
                public string? Temp { get; set; }
                public string? FeelsLike { get; set; }
                public string? Humidity { get; set; }
                public string? Pressure { get; set; }

            }

            public class WeatherDetails
            {
                public string? Main { get; set; }
                public string? Description { get; set; }
                public string? Icon { get; set; }
            }
        }
        public void OnPost()
        {

        }
    }
}