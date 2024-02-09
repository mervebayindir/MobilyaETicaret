using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminKategorilerController : Controller
    {
        private readonly IKategorilerService _kategoriService;
        private readonly IKategoriFotograflariService _kategoriFotograflariService;
        private readonly IMapper _mapper;

        public AdminKategorilerController(IKategorilerService kategoriService, IKategoriFotograflariService kategoriFotograflariService, IMapper mapper)
        {
            _kategoriService = kategoriService;
            _kategoriFotograflariService = kategoriFotograflariService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminKategorilerIndex()
        {
            var kategoriler = await _kategoriService.GetAllAsyncs();

            var kategoriFotografDTO = _mapper.Map<List<KategoriFotografGosterDTO>>(kategoriler);

            foreach (var kategori in kategoriFotografDTO)
            {
                //var fotoKategori = await _kategoriFotograflariService.GetByIdAsync(kategori.Id);
                var resimKategori = await _kategoriFotograflariService.KategoriveFotografGetir(kategori.Id);
                if (resimKategori != null)
                {
                    kategori.FotografYolu = resimKategori.FotografYolu;
                }
            }
            return View(kategoriFotografDTO);
        }

        public async Task<IActionResult> AdminKategoriKaydetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminKategoriKaydetIndex(KategoriFotografDTO kategorilerDTO)
        {
            Kategoriler kategoriler = new Kategoriler();

            if (ModelState.IsValid)
            {
                kategoriler.AktifMi = true;
                kategoriler.EklenmeTarih = DateTime.Now;
                kategoriler.KategoriAdi = kategorilerDTO.KategoriAdi;
                kategoriler.Aciklama = kategorilerDTO.Aciklama;
                if (kategorilerDTO.FotografId != null)
                {
                    var uzanti = Path.GetExtension(kategorilerDTO.FotografId.FileName);
                    var yeniFotografAdi = Guid.NewGuid() + uzanti;
                    var lokasyon = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", yeniFotografAdi);
                    using (var akis = new FileStream(lokasyon, FileMode.Create))
                    {
                        await kategorilerDTO.FotografId.CopyToAsync(akis);
                    }
                    kategoriler.KategoriFotograflari = new KategoriFotograflari
                    {
                        FotografYolu = yeniFotografAdi,
                        AktifMi = true,
                        EklenmeTarih = DateTime.Now,
                        KategoriId = kategoriler.Id
                    };
                }
                var sonuc = await _kategoriService.AddAsync(kategoriler);
                if (sonuc != null)
                {
                    ViewBag.mesaj = "Ekleme Başarılı";
                    return RedirectToAction("AdminKategorilerIndex");
                }
            }
            ViewBag.mesaj = "Ekleme başarısız";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AdminKategoriGuncelleIndex(int id)
        {
            var kategoriGetir = await _kategoriService.GetByIdAsync(id);
            var kategoriDTO = _mapper.Map<KategoriFotografDTO>(kategoriGetir);
            return View(kategoriDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AdminKategoriGuncelleIndex(Kategoriler kategori)
        {
            var kategoriDTO = _mapper.Map<KategoriFotografDTO>(kategori);
            if (ModelState.IsValid)
            {
                var mevcutKategori = await _kategoriService.GetByIdAsync(kategoriDTO.Id);
                mevcutKategori.AktifMi = true;
                mevcutKategori.GuncellenmeTarih = DateTime.Now;
                //if (kategori.KategoriFotograflari.FotografYolu != null || kategori.KategoriFotograflari.FotografYolu == null)
                //{
                //    var uzanti = Path.GetExtension(kategoriDTO.FotografId.FileName);
                //    var yeniFotografAdi = Guid.NewGuid() + uzanti;
                //    var lokasyon = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", yeniFotografAdi);
                //    using (var akis = new FileStream(lokasyon, FileMode.Create))
                //    {
                //        await kategoriDTO.FotografId.CopyToAsync(akis);
                //    }
                //    mevcutKategori.KategoriFotograflari.FotografYolu = yeniFotografAdi; // Güncellenmiş fotoğraf yolunu kaydedin
                //}
                await _kategoriService.UpdateAsync(_mapper.Map<Kategoriler>(mevcutKategori));
                ViewBag.mesaj = "Güncelleme başarılı";
                return RedirectToAction("AdminKategorilerIndex");
            }
            ViewBag.mesaj = "Güncelleme başarısız";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminKategoriSilIndex(int id)
        {
            var kategoriGetir = await _kategoriService.GetByIdAsync(id);
            return View(kategoriGetir);
        }

        [HttpPost, ActionName("AdminKategoriSilIndex")]
        public async Task<IActionResult> AdminKategoriDeleteIndex(int id)
        {
            var kategori = await _kategoriService.GetByIdAsync(id);
            if (id != 0)
            {
                kategori.GuncellenmeTarih = DateTime.Now;
                await _kategoriService.KategoriSilAsync(id);
                ViewBag.mesaj = "Kategori Pasif Edildi";
                return RedirectToAction("AdminKategorilerIndex");
            }
            ViewBag.mesaj = "Kategori Pasif Edilemedi";
            return View();
        }



        //public async Task<string> KategoriIdGetir()
        //{
        //    var kategoriler = await _kategoriService.GetAllAsyncs();
        //    string resimYolu = null;
        //    foreach (var kategori in kategoriler)
        //    {
        //        resimYolu = await _kategoriFotograflariService.KategoriveFotografGetir(kategori.Id);                
        //    }
        //    return resimYolu;
        //}

    }
}
