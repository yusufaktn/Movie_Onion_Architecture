using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UserUILayoutViewComponents
{
    public class _UserUILayoutRegisterComponentPartial:ViewComponent
    {     
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
