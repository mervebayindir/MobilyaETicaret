using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Models;

namespace MobilyaETicaret.Web.Controllers
{
    public class AnasayfaController : BaseController
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

        public IActionResult HakkimizdaIndex()
        {
            return View();
        }

        public IActionResult IletisimIndex()
        {
            return View();
        }

        public IActionResult BlogIndex()
        {
            return View();
        }

    }
}
