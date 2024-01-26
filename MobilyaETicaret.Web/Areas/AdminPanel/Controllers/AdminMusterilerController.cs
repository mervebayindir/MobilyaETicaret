using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminMusterilerController : Controller
    {
        private readonly IMusterilerService _musterilerService;

        public AdminMusterilerController(IMusterilerService musterilerService)
        {
            _musterilerService = musterilerService;
        }

        public async Task<IActionResult> AdminMusterilerIndex()
        {
            var musteriler = await _musterilerService.MusterilerVeSiparisler();
            return View(musteriler);
        }

        public async Task<IActionResult> AdminMusteriKaydetIndex()
        {
          
            return View();
        }

    }
}
