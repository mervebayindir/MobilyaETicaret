using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.WEB_API.Models;

namespace MobilyaETicaret.WEB_API.Controllers
{
    public class AnasayfaController : Controller
    {
		private readonly IService<Kategoriler> _kategoriService;
		private readonly IService<Urunler> _urunService;
		private readonly IService<Fotograflar> _fotografService;

		public AnasayfaController(IService<Kategoriler> kategoriService, IService<Urunler> urunService, IService<Fotograflar> fotografService)
		{
			_kategoriService = kategoriService;
			_urunService = urunService;
			_fotografService = fotografService;
		}

		public async Task<IActionResult> AnasayfaIndex()
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
	}
}
