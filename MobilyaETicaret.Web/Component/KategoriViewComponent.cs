using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Component
{
    public class KategoriViewComponent : ViewComponent
    {
        private readonly IService<Kategoriler> _kategorilerService;

        public KategoriViewComponent(IService<Kategoriler> kategorilerService)
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
