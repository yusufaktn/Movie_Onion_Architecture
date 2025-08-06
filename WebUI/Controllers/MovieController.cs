using DTO.MovieDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7269/api/Movies");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var value =  JsonConvert.DeserializeObject<List<ResponseMovieDto>>(jsondata);
                return View(value);
            }
            return View();
        }

        //public async Task<IActionResult> GetGenreList()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var response = await client.GetAsync("https://localhost:7269/api/GetGenres");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsondata = await response.Content.ReadAsStringAsync();
        //        var value = JsonConvert.DeserializeObject<List<ResponseMovieDto>>(jsondata);
        //        return View(value);
        //    }
        //    return View();
        //}
    }
}
