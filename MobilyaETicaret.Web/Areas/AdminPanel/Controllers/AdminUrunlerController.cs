using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Service.Services;
using MobilyaETicaret.Web.Areas.AdminPanel.Models;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminUrunlerController : Controller
    {
        private readonly IUrunlerService _urunlerService;
        private readonly IKategorilerService _kategorilerService;
        private readonly IMapper _mapper;
        private readonly IFotografService _fotograflarService;

        public AdminUrunlerController(IUrunlerService urunlerService, IKategorilerService kategorilerService, IMapper mapper, IFotografService fotografService)
        {
            _urunlerService = urunlerService;
            _kategorilerService = kategorilerService;
            _mapper = mapper;
            _fotograflarService = fotografService;
        }

        public async Task<IActionResult> AdminUrunlerIndex()
        {
            var urunler = await _urunlerService.UrunlerVeKategoriGetir();
            return View(urunler);
        }

        public async Task<IActionResult> AdminUrunKaydetIndex()

        {
            var kategoriList = await _kategorilerService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategorilerDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminUrunKaydetIndex(Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                urunler.AktifMi = true;
                urunler.EklenmeTarih = DateTime.Now;
                var sonuc = await _urunlerService.AddAsync(urunler);
                if (sonuc != null)
                {
                    ViewBag.mesaj = "Ekleme Başarılı";
                    return RedirectToAction("AdminUrunlerIndex");
                }
            }
            ViewBag.mesaj = "Ekleme başarısız";
            var kategoriList = await _kategorilerService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategorilerDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminUrunGuncelleIndex(int id)
        {
            var getirUrun = await _urunlerService.UrunlerVeKategoriGetir(id);
            var kategoriList = await _kategorilerService.GetAllAsyncs();
            var kategoriler = kategoriList.ToList();
            var urun = getirUrun;
            var model = new Tuple<List<Kategoriler>, UrunlerveKategoriDTO>(kategoriler, urun);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminUrunGuncelleIndex(Urunler urunler)
        {
            var urunDTO = _mapper.Map<UrunlerveKategoriDTO>(urunler);
            if (ModelState.IsValid)
            {
                var mevcutUrun = await _urunlerService.GetByIdAsync(urunDTO.Id);
                mevcutUrun.AktifMi = true;
                mevcutUrun.GuncellenmeTarih = DateTime.Now;
                await _urunlerService.UpdateAsync(_mapper.Map<Urunler>(mevcutUrun));
                ViewBag.mesaj = "Güncelleme başarılı";
                return RedirectToAction("AdminUrunlerIndex");
            }
            ViewBag.mesaj = "Güncelleme başarısız";
            return RedirectToAction("UrunGuncelleIndex", urunler.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AdminUrunSilIndex(int id)
        {
            var adresGetir = await _urunlerService.GetByIdAsync(id);
            return View(adresGetir);
        }

        [HttpPost, ActionName("AdminUrunSilIndex")]
        public async Task<IActionResult> AdminUrunDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _urunlerService.UrunSilAsync(id);
                ViewBag.mesaj = "Ürün Pasif Edildi";
                return RedirectToAction("AdminUrunlerIndex");
            }
            ViewBag.mesaj = "Ürün Pasif Edilemedi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResimYukle(IFormFile file, int id)
        {
            try
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resimler");

                if (file.Length > 0)
                {
                    var createGuid = Guid.NewGuid().ToString();
                    string dosyaUzantisi = Path.GetExtension(file.FileName);
                    string resimAdi = $"urunId={id}_{createGuid.Substring(0, 7)}{dosyaUzantisi}";

                    var filePath = Path.Combine(uploads, resimAdi);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

					int fotografSirasi = await _fotograflarService.UrunFotografSayisiGetir(id) + 1;

					var kaydetSonuc = await _fotograflarService.FotografEkleAsync(resimAdi, file.FileName, "", fotografSirasi, id, true, DateTime.Now);
                    var imageId = kaydetSonuc;

                    var webPath = $"/resimler/{resimAdi}";

                    return Json(new { success = true, filePath = webPath, imageId = imageId });
                }

                return Json(new { success = false, message = "Dosya boş veya yüklenemedi." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Yükleme sırasında bir hata oluştu: " + ex.Message });
            }
        }



        public async Task<IActionResult> UrunResimYukle(int id)
        {
            try
            {
                var urun = await _urunlerService.GetByIdAsync(id);
                var resimler = await _fotograflarService.GetAllQueryAsync(k => k.UrunId == id);

                // AutoMapper kullanarak DTO'ya dönüştürme
                var urunDto = _mapper.Map<UrunGuncelleDTO>(urun);
                var fotograflarDto = _mapper.Map<List<FotograflarDTO>>(resimler);

                var viewModel = new UrunVeFotograflarViewModel
                {
                    Urun = urunDto,
                    Fotograflar = fotograflarDto,
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResimSil(int imageId)
        {

            try
            {
                var fotograf = await _fotograflarService.GetByIdAsync(imageId);
                if (fotograf != null)
                {
                    await _fotograflarService.FotografSilAsync(fotograf.Id);

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Fotograf bulunamadı" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}

