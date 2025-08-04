using DTO.ExternalMovieDto;
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

        public async Task<List<ExternalGenreDto>> GetMovieList() 
        {
            try
            {             
                var response = await _httpClient.GetAsync("genre/movie/list?language=tr");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var genreResponse = JsonConvert.DeserializeObject<ExternelGenreResponseDto>(json);
                    return genreResponse?.genres ?? new List<ExternalGenreDto>();
                }

                // API çağrısı başarısız olursa log yaz ve boş liste döndür
                return new List<ExternalGenreDto>();
            }
            catch (Exception ex)
            {
                // Hata durumunda log yaz
                // _logger.LogError(ex, "Error fetching movie genres");
                return new List<ExternalGenreDto>();
            }
        }
    }
}
