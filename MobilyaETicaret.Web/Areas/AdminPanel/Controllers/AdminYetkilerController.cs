using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminYetkilerController : Controller
    {
        private readonly IYetkilerService _yetkilerService;
        private readonly IErisimAlanlariService _erisimAlanlariService;

        public AdminYetkilerController(IYetkilerService yetkilerService, IErisimAlanlariService erisimAlanlariService)
        {
            _yetkilerService = yetkilerService;
            _erisimAlanlariService = erisimAlanlariService;
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
            var yetkilerList = await _yetkilerService.GetAllAsyncs();
            ViewBag.erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            return View(yetkiler);
        }
    }
}
