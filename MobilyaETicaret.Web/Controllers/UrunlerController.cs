using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Models;

namespace MobilyaETicaret.Web.Controllers
{
    public class UrunlerController : BaseController
    {
        private readonly IService<Kategoriler> _kategoriService;
		private readonly IService<Urunler> _urunService;
		private readonly IService<Fotograflar> _fotografService;

		public UrunlerController(IService<Kategoriler> kategoriService, IService<Urunler> urunService, IService<Fotograflar> fotografService)
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


		public async Task<IActionResult> UrunModal(int id)
		{
			var urunDetay = await _urunService.GetByIdAsync(id);
			return PartialView("_UrunModal", urunDetay);
		}

	}
}
