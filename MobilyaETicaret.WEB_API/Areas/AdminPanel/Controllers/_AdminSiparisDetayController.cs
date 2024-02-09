using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminSiparisDetayController : Controller
    {
        private readonly SiparisDetayAPIService _siparisDetayAPIService;

        public _AdminSiparisDetayController(SiparisDetayAPIService siparisDetayAPIService)
        {
            _siparisDetayAPIService = siparisDetayAPIService;
        }

        public async Task<IActionResult> _AdminSiparisDetayIndex()
        {
            var siparisDetay = await _siparisDetayAPIService.SiparisDetay();
            return View(siparisDetay);
        }
    }
}
