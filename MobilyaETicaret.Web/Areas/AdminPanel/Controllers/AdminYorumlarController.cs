using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Service.Services;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminYorumlarController : Controller
    {
        private readonly IYorumlarService _yorumlarService;

        public AdminYorumlarController(IYorumlarService yorumlarService)
        {
            _yorumlarService = yorumlarService;
        }

        public async Task<IActionResult> AdminYorumlarIndex()
        {
            var yorumlar = await _yorumlarService.YorumVeUrunAsync();
            return View(yorumlar);
        }

        public async Task<IActionResult> AdminYorumSilIndex(int id)
        {
            var yorumGetir = await _yorumlarService.GetByIdAsync(id);
            return View(yorumGetir);
        }

        [HttpPost, ActionName("AdminYorumSilIndex")]
        public async Task<IActionResult> AdminYorumDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _yorumlarService.YorumSilAsync(id);
                ViewBag.mesaj = "Yorum Pasif Edildi";
                return RedirectToAction("AdminYorumlarIndex");
            }
            ViewBag.mesaj = "Yorum Pasif Edilemedi";
            return View();
        }
    }
}
