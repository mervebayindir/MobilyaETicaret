using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Controllers
{
    public class AnasayfaController : BaseController
    {   
		public IActionResult AnasayfaIndex()
		{		
			return View();
		}
	}
}
