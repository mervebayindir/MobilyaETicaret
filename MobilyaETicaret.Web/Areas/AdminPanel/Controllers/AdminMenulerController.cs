using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminMenulerController : Controller
    {
        private readonly IMenulerService _menulerService;

        public AdminMenulerController(IMenulerService menulerService)
        {
            _menulerService = menulerService;
        }

        public async Task<IActionResult> AdminMenulerIndex()
        {
            var menuler = await _menulerService.MenulerVeErisimAlanlariAsync();
            return View(menuler);
        }
    }
}
