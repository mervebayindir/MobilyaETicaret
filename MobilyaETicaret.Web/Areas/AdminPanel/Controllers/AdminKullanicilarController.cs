using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Service.Services;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminKullanicilarController : Controller
    {
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IMapper _mapper;
        private readonly IYetkilerService _yetkilerService;

        public AdminKullanicilarController(IKullanicilarService kullanicilarService, IMapper mapper, IYetkilerService yetkilerService)
        {
            _kullanicilarService = kullanicilarService;
            _mapper = mapper;
            _yetkilerService = yetkilerService;
        }

        public async Task<IActionResult> AdminKullanicilarIndex()
        {
            var kullanicilar = await _kullanicilarService.KullaniciVeYetkiGetirAsync();
            return View(kullanicilar);
        }

        public async Task<IActionResult> AdminKullaniciGuncelleIndex(int id)
        {
            var kullaniciGetir = await _kullanicilarService.KullaniciVeYetkiGetirAsync(id);
            var kullanici = kullaniciGetir;
            var yetki = await _yetkilerService.GetAllAsyncs();
            var yetkiler = yetki.ToList();

            var model = new Tuple<List<Yetkiler>, KullanicilarVeYetkilerDTO>(yetkiler, kullanici);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminKullaniciGuncelleIndex(Kullanicilar kullanicilar)
        {
            var kullaniciDTO = _mapper.Map<KullanicilarVeYetkilerDTO>(kullanicilar);
            if (ModelState.IsValid)
            {
                var mevcutKullanici = await _kullanicilarService.GetByIdAsync(kullaniciDTO.Id);
                mevcutKullanici.AktifMi = true;
                mevcutKullanici.PersonelMi = kullanicilar.PersonelMi;
                mevcutKullanici.GuncellenmeTarih = DateTime.Now;
                mevcutKullanici.Adi = kullanicilar.Adi;
                mevcutKullanici.Soyadi = kullanicilar.Soyadi;
                mevcutKullanici.KullaniciEmail = kullanicilar.KullaniciEmail;
                mevcutKullanici.YetkiId = kullanicilar.YetkiId;
                await _kullanicilarService.UpdateAsync(mevcutKullanici);
				TempData["mesaj"] = "Güncelleme başarılı";
				return RedirectToAction("AdminKullanicilarIndex");
			}
			TempData["mesaj"] = "Güncelleme başarısız";
			return RedirectToAction("AdminKullaniciGuncelleIndex", kullanicilar.Id);
        }

		public async Task<IActionResult> AdminKullaniciSilIndex(int id)
		{
            var kullaniciGetir = await _kullanicilarService.GetByIdAsync(id);
            return View(kullaniciGetir);
        }
        [HttpPost, ActionName("AdminKullaniciSilIndex")]
		public async Task<IActionResult> AdminKullaniciDeletelIndex(int id)
		{
            if (id != 0)
            {
                await _kullanicilarService.KullaniciSilAsync(id);
                TempData["mesaj"] = "Kullanici Pasif Edildi";
                return RedirectToAction("AdminKullanicilarIndex");
            }
            TempData["mesaj"] = "Kullanici Pasif Edilemedi";
            return View(); ;
		}
	}
}
