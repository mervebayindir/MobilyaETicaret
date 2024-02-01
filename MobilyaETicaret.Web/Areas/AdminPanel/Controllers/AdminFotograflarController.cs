using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminFotograflarController : Controller
    {
        private readonly IFotografService _fotografService;
        private readonly IMapper _mapper;

        public AdminFotograflarController(IFotografService fotografService, IMapper mapper)
        {
            _fotografService = fotografService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminFotograflarIndex()
        {
            var fotograflar = await _fotografService.FotografVeUrunGetir();
            return View(fotograflar);
        }

        public async Task<IActionResult> AdminFotografGuncelleIndex(int id)
        {
            var fotograflar = await _fotografService.FotografVeUrunGetir(id);
            return View(fotograflar);
        }

        [HttpPost]
        public async Task<IActionResult> AdminFotografGuncelleIndex(Fotograflar fotograflar)
        {
            var fotograf = _mapper.Map<FotograflarVeUrunlerDTO>(fotograflar);
            if (ModelState.IsValid)
            {
                var mevcutFotograf = await _fotografService.GetByIdAsync(fotograf.Id);
                mevcutFotograf.AktifMi = true;
                mevcutFotograf.EklenmeTarih = fotograf.EklenmeTarih;
                mevcutFotograf.FotografYolu = fotograf.FotografYolu;
                mevcutFotograf.FotografSirasi = fotograf.FotografSirasi;
                mevcutFotograf.FotografAdi = fotograf.FotografAdi;
                mevcutFotograf.GuncellenmeTarih = DateTime.Now;
                mevcutFotograf.UrunId = fotograf.UrunId;
                await _fotografService.UpdateAsync(_mapper.Map<Fotograflar>(mevcutFotograf));
                TempData["mesaj"] = "Güncelleme başarılı";
                return RedirectToAction("AdminFotograflarIndex");
            }
            TempData["mesaj"] = "Güncelleme başarısız";
            return View();
        }


        public async Task<IActionResult> AdminFotografSilIndex(int id)
        {       
            return View();
        }

        [HttpPost, ActionName("AdminFotografSilIndex")]
        public async Task<IActionResult> AdminFotografDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _fotografService.FotografSilAsync(id);
                TempData["mesaj"] = "Fotograf Pasif Edildi";
                return RedirectToAction("AdminFotograflarIndex");
            }
            TempData["mesaj"] = "Fotograf Pasif Edilemedi";
            return View();
        }
    }
}
