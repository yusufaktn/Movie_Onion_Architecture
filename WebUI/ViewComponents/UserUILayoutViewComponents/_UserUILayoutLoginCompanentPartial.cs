using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUILayoutViewComponents
{
    public class _UserUILayoutLoginCompanentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
