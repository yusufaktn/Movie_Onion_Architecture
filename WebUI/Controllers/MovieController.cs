using DTO.ExternalApiDto.Movie;
using DTO.MovieDto;
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
                var value =  JsonConvert.DeserializeObject<List<MovieDto>>(jsondata);
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> GetMoviesByGenres(string genreIds)
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Filtrelenmiş Filmler";

            var client = _httpClientFactory.CreateClient();

            // Kendi API'nizde tür ID'lerine göre filtreleme yapan yeni bir endpoint olduğunu varsayıyoruz.
            // Bu endpoint'i sizin API projenizde oluşturmanız gerekiyor.
            var url = $"https://localhost:7269/api/Movies/FilterByGenres?genreIds={genreIds}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<MovieDto>>(jsonData);
                return View("MovieList", value); // Sonucu MovieList view'ına gönderiyoruz
            }

            return View("MovieList", new List<MovieDto>());
        }

    }
}
