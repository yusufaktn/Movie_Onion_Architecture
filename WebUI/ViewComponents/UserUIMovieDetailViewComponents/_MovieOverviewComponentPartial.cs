using DTO.MovieDto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUIMovieDetailViewComponents
{
    public class _MovieOverviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(MovieDto dto)
        {
            return View(dto);
        }
    }
}