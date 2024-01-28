using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Controllers
{
    public class KategoriMenuViewComponent : ViewComponent
    {
        private readonly IService<Kategoriler> _kategorilerService;

        public KategoriMenuViewComponent(IService<Kategoriler> kategorilerService)
        {
            _kategorilerService = kategorilerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var kategoriler = await _kategorilerService.GetAllAsyncs();
            return View(kategoriler);
        }
    }
}
