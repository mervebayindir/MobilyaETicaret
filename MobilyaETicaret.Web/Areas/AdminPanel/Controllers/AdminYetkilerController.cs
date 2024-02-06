using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminYetkilerController : Controller
    {
        private readonly IYetkilerService _yetkilerService;
        private readonly IErisimAlanlariService _erisimAlanlariService;
        private readonly IYetkiErisimService _yetkiErisimService;

        public AdminYetkilerController(IYetkilerService yetkilerService, IErisimAlanlariService erisimAlanlariService, IYetkiErisimService yetkiErisimService)
        {
            _yetkilerService = yetkilerService;
            _erisimAlanlariService = erisimAlanlariService;
            _yetkiErisimService = yetkiErisimService;
        }

        public async Task<IActionResult> AdminYetkilerIndex()
        {
            var yetkiler = await _yetkilerService.GetAllAsyncs();
            ViewBag.erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            return View(yetkiler);
        }

        public async Task<IActionResult> AdminYetkiKaydetIndex()
        {
            var yetkiler = await _yetkilerService.GetAllAsyncs();
            ViewBag.erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            return View(yetkiler);
        }

        [HttpPost]
        public async Task<IActionResult> AdminYetkiKaydetIndex(Yetkiler yetkiler, int[] secilenSayfalar)
        {
            YetkiErisim yeniYetkiErisim = new YetkiErisim();
            if (ModelState.IsValid)
            {
                yetkiler.AktifMi = true;
                yetkiler.EklenmeTarih = DateTime.Now;
                var sonuc = await _yetkilerService.AddAsync(yetkiler);
                if (sonuc != null)
                {
                    foreach (var item in secilenSayfalar)
                    {
                        yeniYetkiErisim.YetkiId = yetkiler.Id;
                        yeniYetkiErisim.ErisimAlaniId = item;
                        yeniYetkiErisim.Aciklama = yetkiler.YetkiAdi;
                        yeniYetkiErisim.EklenmeTarihi = DateTime.Now;
                        await _yetkiErisimService.AddAsync(yeniYetkiErisim);
                    }
                    return RedirectToAction("AdminYetkilerIndex");
                }
            }
            return View();
        }
    }
}
