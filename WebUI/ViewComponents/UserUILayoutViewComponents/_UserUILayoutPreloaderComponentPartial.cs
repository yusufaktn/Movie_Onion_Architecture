using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUILayoutViewComponents
{
    public class _UserUILayoutPreloaderComponentPartial:ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
