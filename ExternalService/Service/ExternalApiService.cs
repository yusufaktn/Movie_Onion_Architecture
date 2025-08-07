using DTO.ExternalApiDto.Genre;
using DTO.ExternalApiDto.Movie;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExternalService.Service
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public ExternalApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = configuration["TMDB:ApiKey"];

            // Base URL'i ayarla
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");

            // Default headers'ı ayarla
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<List<ExternalGenreDto>> GetGenreList()
        {
            try
            {
                // TMDB API'sinden film türlerini almak için GET isteği gönderiyoruz
                var response = await _httpClient.GetAsync("genre/movie/list?language=tr");

                // Eğer API isteği başarılıysa
                if (response.IsSuccessStatusCode)
                {
                    // API'den dönen JSON verisini string olarak okuyoruz
                    var json = await response.Content.ReadAsStringAsync();

                    // JSON verisini ExternelGenreResponseDto tipine deserialize ediyoruz
                    var genreResponse = JsonConvert.DeserializeObject<ExternelGenreResponseDto>(json);

                    // Eğer genreResponse null değilse tür listesini, null ise boş bir liste döndürüyoruz
                    return genreResponse?.genres ?? new List<ExternalGenreDto>();
                }

                // API çağrısı başarısız olursa log yazabiliriz ve boş liste döndürüyoruz
                return new List<ExternalGenreDto>();
            }
            catch (Exception ex)
            {
                // Hata durumunda log yazabiliriz ve boş liste döndürüyoruz              
                return new List<ExternalGenreDto>();
            }
        }

        public async Task<List<ExternalMovieDto>> GetMovieList(int page)
        {
            try
            {
                var response = await _httpClient.GetAsync($"movie/top_rated?language=tr-TR&page={page}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<ExternalMovieResponseDto>(json);
                    return value?.results ?? new List<ExternalMovieDto>();
                }
                return new List<ExternalMovieDto>();
            }
            catch (Exception ex)
            {
                throw new Exception("Hata",ex);
                return new List<ExternalMovieDto>();
            }
        }
    }
}
