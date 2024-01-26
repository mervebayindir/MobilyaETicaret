using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminMusterilerController : Controller
    {
        private readonly IMusterilerService _musterilerService;
        private readonly IMapper _mapper;

        public AdminMusterilerController(IMusterilerService musterilerService, IMapper mapper)
        {
            _musterilerService = musterilerService;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> AdminMusteriKaydetIndex(Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                musteriler.AktifMi = true;
                musteriler.EklenmeTarih = DateTime.Now;
                musteriler.KullaniciId = 1;
                var sonuc = await _musterilerService.AddAsync(musteriler);
                if (sonuc != null)
                {
                    TempData["mesaj"] = "Ekleme başarılı";
                    return RedirectToAction("AdminMusterilerIndex");
                }
            }
            TempData["mesaj"] = "Ekleme başarısız";
            return View();
        }

        public async Task<IActionResult> AdminMusteriGuncelleIndex(int id)
        {
            var musteriGetir = await _musterilerService.GetByIdAsync(id);
            return View(musteriGetir);
        }

        [HttpPost]
        public async Task<IActionResult> AdminMusteriGuncelleIndex(Musteriler musteriler)
        {
            var musteriDTO = _mapper.Map<MusterilerDTO>(musteriler);

            if (ModelState.IsValid)
            {
                var mevcutMusteri = await _musterilerService.GetByIdAsync(musteriDTO.Id);
                mevcutMusteri.GuncellenmeTarih = DateTime.Now;
                mevcutMusteri.KullaniciId = 1;
                mevcutMusteri.AktifMi = true;
                mevcutMusteri.Adi = musteriDTO.Adi;
                mevcutMusteri.Soyadi = musteriDTO.Soyadi;
                mevcutMusteri.DogumTarihi = musteriDTO.DogumTarihi;
                mevcutMusteri.Meslek = musteriDTO.Meslek;
                mevcutMusteri.Cinsiyet = musteriDTO.Cinsiyet;
                mevcutMusteri.Telefonu = musteriDTO.Telefonu;
                await _musterilerService.UpdateAsync(mevcutMusteri);
                TempData["mesaj"] = "Güncelleme başarılı";
                return RedirectToAction("AdminMusterilerIndex");
            }
            TempData["mesaj"] = "Güncelleme başarısız";
            return RedirectToAction("AdminMusteriGuncelleIndex", musteriler.Id);
        }

        public async Task<IActionResult> AdminMusteriSilIndex(int id)
        {
            var musteriGetir = await _musterilerService.GetByIdAsync(id);
            return View(musteriGetir);
        }

        [HttpPost,ActionName("AdminMusteriSilIndex")]
        public async Task<IActionResult> AdminMusteriDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _musterilerService.MusteriSilAsync(id);
                TempData["mesaj"] = "Müşteri Pasif Edildi";
                return RedirectToAction("AdminMusterilerIndex");
            }
            TempData["mesaj"] = "Müşteri Pasif Edilemedi";
            return View();
        }
    }
}
