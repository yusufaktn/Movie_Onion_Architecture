using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUILayoutViewComponents
{
    public class _UserUILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
