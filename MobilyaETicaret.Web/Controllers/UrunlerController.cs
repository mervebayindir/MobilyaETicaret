using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Models;

namespace MobilyaETicaret.Web.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly IService<Kategoriler> _kategoriService;

		public UrunlerController(IService<Kategoriler> kategoriService)
		{
			_kategoriService = kategoriService;
		}

		public async Task<IActionResult> UrunlerIndex()
        {
			var model = new UrunlerViewModel
			{
				Kategoriler = await _kategoriService.GetAllAsyncs(),
				//Urunler = await _urunService.GetAllAsyncs() 
															
			};
			return View(model);
		}	

	}
}
