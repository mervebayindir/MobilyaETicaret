using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Service.Services;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminSiparislerController : Controller
    {
        private readonly ISiparislerService _siparislerService;

        public AdminSiparislerController(ISiparislerService siparislerService)
        {
            _siparislerService = siparislerService;
        }

        public async Task<IActionResult> AdminSiparisIndex()
        {
            var siparisBilgileri = await _siparislerService.SiparisVeMusteriGetirAsync();
            return View(siparisBilgileri);
        }

        public async Task<IActionResult> AdminSiparisSilIndex(int id)
        {
            var siparisBilgileri = await _siparislerService.GetByIdAsync(id);
            return View(siparisBilgileri);
        }

        [HttpPost, ActionName("AdminSiparisSilIndex")]
        public async Task<IActionResult> AdminSiparisDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _siparislerService.SiparisSilAsync(id);
                TempData["mesaj"] = "Sipariş Pasif Edildi";
                return RedirectToAction("AdminSiparisIndex");
            }
            TempData["mesaj"] = "Sipariş Pasif Edilemedi";
            return View(); ;
        }

    }
}
