using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUIMovieDetailViewComponents
{
    public class _MovieDetailOverviewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
