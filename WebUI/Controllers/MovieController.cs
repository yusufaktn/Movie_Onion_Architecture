using DTO.MovieDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.ViewModels;


namespace WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //==============================================================
        // 1. PUBLIC METOT: TÜM FİLMLERİ LİSTELEME
        //==============================================================
        public async Task<IActionResult> MovieList(int pageNumber = 1, int pageSize = 5)
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";

            // Ağır işi yardımcı metoda devret, genreIds olarak boş liste gönder
            return await CreateMovieListViewModelAsync(new List<int>(), pageNumber, pageSize);
        }

        //==============================================================
        // 2. PUBLIC METOT: FİLTRELENMİŞ FİLMLERİ LİSTELEME
        //==============================================================
        public async Task<IActionResult> GetMoviesByGenres(List<int> genreIds, int pageNumber = 1, int pageSize = 5)
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Filtrelenmiş Filmler";

            // Ağır işi yardımcı metoda devret, formdan gelen genreIds'leri gönder
            return await CreateMovieListViewModelAsync(genreIds, pageNumber, pageSize);
        }

        //==============================================================
        // YARDIMCI (PRIVATE) METOTLAR
        //==============================================================
        private async Task<IActionResult> CreateMovieListViewModelAsync(List<int> genreIds, int pageNumber, int pageSize)
        {
            var allMovies = await GetMoviesFromApi(genreIds);

            var totalMovieCount = allMovies.Count;
            var moviesForCurrentPage = allMovies
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new MovieListViewModel
            {
                MoviesList = moviesForCurrentPage,
                TotalCount = totalMovieCount,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalMovieCount / (double)pageSize)
            };

            return View("MovieList", viewModel);
        }

        private async Task<List<MovieDto>> GetMoviesFromApi(List<int> genreIds)
        {
            var client = _httpClientFactory.CreateClient();
            string apiUrl;


            if (genreIds == null || !genreIds.Any())
            {
                apiUrl = "https://localhost:7269/api/Movies";
            }
            else
            {
                var queryString = string.Join("&", genreIds.Select(id => $"genre_id={id}"));
                apiUrl = $"https://localhost:7269/api/Movies/GetMovieByGenre?{queryString}";
            }

            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<MovieDto>>(jsonData);
            }
            return new List<MovieDto>();
        }




        
        public async Task<IActionResult> MovieDetail(int id)
        {
            Console.WriteLine($"Gelen id:{id}");
            var movie = await GetMovieByIdFromApi(id);
            return View(movie);
        }


        private async Task<MovieDto> GetMovieByIdFromApi(int id)
        {
            var client = _httpClientFactory.CreateClient();

            string apiUrl = $"https://localhost:7269/api/Movies/GetMovieById/{id}";

            try
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var movie = JsonConvert.DeserializeObject<MovieDto>(jsonData);
                    return movie;
                }
                else
                {

                    Console.WriteLine($"API çağrısı başarısız: {response.StatusCode} - {apiUrl}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {

                Console.WriteLine($"HTTP Hatası: {httpEx.Message} - {apiUrl}");
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Genel Hata: {ex.Message} - {apiUrl}");
                return null;
            }
        }

    }
}