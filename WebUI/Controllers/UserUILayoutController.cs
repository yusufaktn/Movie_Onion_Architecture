using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserUILayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
