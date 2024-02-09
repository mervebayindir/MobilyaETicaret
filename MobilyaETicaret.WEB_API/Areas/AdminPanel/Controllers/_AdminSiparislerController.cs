using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminSiparislerController : Controller
    {
        private readonly SiparislerAPIService _siparislerAPIService;

        public _AdminSiparislerController(SiparislerAPIService siparislerAPIService)
        {
            _siparislerAPIService = siparislerAPIService;
        }

        public async Task<IActionResult> _AdminSiparislerIndex()
        {
            var menuList = await _siparislerAPIService.Siparisler();
            return View(menuList);
        }
    }
}
