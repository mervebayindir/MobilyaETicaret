using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Controllers
{
    public class AnasayfaController : BaseController
    {
        private readonly IService<Kategoriler> _kategorilerServiceervice;

		public AnasayfaController(IService<Kategoriler> kategorilerServiceervice)
		{
			_kategorilerServiceervice = kategorilerServiceervice;
		}

		public async Task<IActionResult> AnasayfaIndex()
        {
            var kategoriler = await _kategorilerServiceervice.GetAllAsyncs();
			ViewBag.kategoriler = kategoriler;
			return View();
        }
    }
}
