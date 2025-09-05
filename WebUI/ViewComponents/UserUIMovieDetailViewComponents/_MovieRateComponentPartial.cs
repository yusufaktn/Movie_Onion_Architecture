using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUIMovieDetailViewComponents
{
    public class _MovieRateComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
