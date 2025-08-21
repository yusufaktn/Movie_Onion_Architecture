using DTO.MovieDto;

namespace WebUI.Models.ViewModels
{
    public class MovieListViewModel
    {
        public List<MovieDto> MoviesList { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
