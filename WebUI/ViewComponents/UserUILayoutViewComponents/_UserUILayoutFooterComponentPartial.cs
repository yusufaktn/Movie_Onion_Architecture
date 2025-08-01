using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUILayoutViewComponents
{
    public class _UserUILayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
