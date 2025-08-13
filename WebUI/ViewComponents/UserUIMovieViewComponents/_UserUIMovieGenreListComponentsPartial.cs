using DTO.ExternalApiDto.Genre;
using DTO.GenreDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.UserUIMovieViewComponents
{
    public class _UserUIMovieGenreListComponentsPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserUIMovieGenreListComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =  _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7269/api/Genre/GetGenreList");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<GenreDto>>(json);

                return View(value);
            }
            return View(new List<GenreDto>());
        }
    }
}
