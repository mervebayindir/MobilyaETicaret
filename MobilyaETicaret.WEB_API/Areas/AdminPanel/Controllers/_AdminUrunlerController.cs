using Microsoft.AspNetCore.Mvc;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminUrunlerController : Controller
    {
        public IActionResult _AdminUrunlerIndex()
        {
            return View();
        }
    }
}
