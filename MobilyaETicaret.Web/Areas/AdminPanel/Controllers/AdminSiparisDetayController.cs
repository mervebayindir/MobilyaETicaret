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

        public async Task<IActionResult> AdminSiparisDetayIndex(int Id)
        {
            var siparisDetay = await _siparisDetayService.SiparisBilgileriGetir(Id);
            return View(siparisDetay);
        }
    }
}
