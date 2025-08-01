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
            var reponse = await client.GetAsync("https://localhost:7269/api/Movies");
            if (reponse.IsSuccessStatusCode)
            {
                var jsondata = await reponse.Content.ReadAsStringAsync();
                var value =  JsonConvert.DeserializeObject<List<ResponseMovieDto>>(jsondata);
                return View(value);
            }
            return View();
        }
    }
}
