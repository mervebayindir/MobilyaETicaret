using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Models;

namespace MobilyaETicaret.Web.Controllers
{
    public class UrunlerController : BaseController
    {
        private readonly IService<Kategoriler> _kategoriService;
		private readonly IService<Urunler> _urunService;
		private readonly IFotografService _fotografService;
		private readonly IYorumlarService _yorumlarService;

		public UrunlerController(IService<Kategoriler> kategoriService, IService<Urunler> urunService, IFotografService fotografService)
		{
			_kategoriService = kategoriService;
			_urunService = urunService;
			_fotografService = fotografService;
		}

		public async Task<IActionResult> UrunlerIndex()
        {
			var kategoriler = await _kategoriService.GetAllAsyncs();
			var urunler = await _urunService.GetAllAsyncs();
			var fotograflar = await _fotografService.GetAllAsyncs();

			var model = new UrunlerViewModel
			{
				Kategoriler = kategoriler,
				Urunler = urunler,
				Fotograflar = fotograflar
			};
			return View(model);
		}

        public async Task<IActionResult> UrunDetayIndex(int id)
        {
            var urun = await _urunService.GetByIdAsync(id);
			var fotograflar = await _fotografService.FotograflarByUrunIdAsync(id);
			var urunler = await _urunService.GetAllAsyncs();
			urunler = urunler.Take(10).ToList();
			var kategoriAdi = await _kategoriService.GetAllQuery(k => k.Id == urun.KategoriId).Select(k => k.KategoriAdi).SingleOrDefaultAsync();
			//var yorumlar = await _yorumlarService.YorumVeUrunAsync(id);

			var model = new UrunDetayViewModal
			{
				Urunler = urun,
				Fotograflar = fotograflar,
				UrunList = urunler.ToList(),
				KategoriAdi = kategoriAdi
                //Yorumlar = yorumlar
            };
			return View(model);
        }

   //     public async Task<IActionResult> UrunSlider(int id)
   //     {
   //         var urunler = await _urunService.GetAllAsyncs();
   //         urunler = urunler.Take(10).ToList();
   //         var fotograflar = await _fotografService.GetAllAsyncs();

			//var model = new UrunDetayViewModal
			//{
			//	UrunList = urunler.ToList(),
			//	Fotograflar = fotograflar
			//};
   //         return PartialView("_UrunSlider", model);
   //     }

        public async Task<IActionResult> UrunModal(int id)
		{
			var urunDetay = await _urunService.GetByIdAsync(id);
			return PartialView("_UrunModal", urunDetay);
		}

	}
}
