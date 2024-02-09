using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class KullanicilarController : BaseController
    {
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IMapper _mapper;

        public KullanicilarController(IKullanicilarService service, IMapper mapper)
        {
            _kullanicilarService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> KullanicilarIndex()
        {
            var kullanici = await _kullanicilarService.KullaniciVeYetkiGetirAsync();
            var kullaniciDTO = _mapper.Map<List<KullanicilarVeYetkilerDTO>>(kullanici);
            return ResultAPI(kullaniciDTO);
        }

        [HttpPost("add")]
        public async Task<IActionResult> KullaniciEkle(KullaniciEkleDTO kullaniciEkleDTO)
        {
            var kullaniciSave = await _kullanicilarService.KullaniciEkleAsync(kullaniciEkleDTO.Adi,kullaniciEkleDTO.Soyadi,kullaniciEkleDTO.KullaniciEmail, kullaniciEkleDTO.KullaniciSifre, true, 3, true, DateTime.Now);
            var kullanıcı = _mapper.Map<Kullanicilar>(kullaniciEkleDTO);
            var mapAdd = _mapper.Map<KullaniciEkleDTO>(kullanıcı);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> KullaniciGuncelle(int id, KullaniciEkleDTO kullaniciGuncelleDTO)
        {
            var kullaniciGetir = await _kullanicilarService.GetByIdAsync(id);
            if (kullaniciGetir != null)
            {
                await _kullanicilarService.UpdateAsync(_mapper.Map(kullaniciGuncelleDTO, kullaniciGetir));
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(kullaniciGuncelleDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var kullanici = await _kullanicilarService.GetByIdAsync(id);
            var kullaniciDto = _mapper.Map<KullanicilarDTO>(kullanici);
            return Ok(kullaniciDto);
        }
    }
}
