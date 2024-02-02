using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminSiparisDetayController : Controller
    {
        private readonly ISiparisDetayService _siparisDetayService;

        public AdminSiparisDetayController(ISiparisDetayService siparisDetayService)
        {
            _siparisDetayService = siparisDetayService;
        }

        public async Task<IActionResult> AdminSiparisDetayIndex(int siparisId)
        {
            var siparisDetay = await _siparisDetayService.SiparisDetayBilgileriGetirAsync(siparisId);
            return View(siparisDetay);
        }
    }
}
