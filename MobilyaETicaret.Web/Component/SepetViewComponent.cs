using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Web.Models;
using MobilyaETicaret.Web.Oturum;
using System.Threading.Tasks;

public class SepetViewComponent : ViewComponent
{
    private readonly IUrunlerService _urunlerService;

    public SepetViewComponent(IUrunlerService urunlerService)
    {
        _urunlerService = urunlerService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var items = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet") ?? new List<SepetElemani>();
        var total = items.Sum(item => item.UrunAdet * item.UrunFiyat); // Toplam tutarı hesapla
        ViewBag.Total = total;
        return View(items);

    }
}
