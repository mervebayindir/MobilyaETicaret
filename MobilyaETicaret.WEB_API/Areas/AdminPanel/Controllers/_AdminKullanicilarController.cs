using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminKullanicilarController : Controller
    {
        private readonly KullanicilarAPİService _kullanicilarAPİService;

        public _AdminKullanicilarController(KullanicilarAPİService kullanicilarAPİService)
        {
            _kullanicilarAPİService = kullanicilarAPİService;
        }

        public async Task<IActionResult> _AdminKullanicilarIndex()
        {
            var kallanicilarList = await _kullanicilarAPİService.Kullanicilar();
            return View(kallanicilarList);
        }

        public async Task<IActionResult> _AdminKullaniciKaydetIndex()
        {
            var kallanicilarList = await _kullanicilarAPİService.Kullanicilar();
            return View(kallanicilarList);
        }

        [HttpPost]
        public async Task<IActionResult> _AdminKullaniciKaydetIndex(Kullanicilar kullanicilar)
        {
            await _kullanicilarAPİService.PersonelKullaniciKaydet(kullanicilar);
            return View("_AdminKullanicilarIndex");
        }
    }
}
