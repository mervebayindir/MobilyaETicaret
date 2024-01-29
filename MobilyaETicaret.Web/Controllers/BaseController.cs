using Microsoft.AspNetCore.Mvc;

namespace MobilyaETicaret.Web.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
