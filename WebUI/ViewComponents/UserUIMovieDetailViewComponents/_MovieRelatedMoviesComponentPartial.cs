using DTO.MovieDto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUIMovieDetailViewComponents
{
    public class _MovieRelatedMoviesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(MovieDto movieDto)
        {
            return View(movieDto);
        }
    }
}