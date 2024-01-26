using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MusterilerController : BaseController
    {
        private readonly IMusterilerService _musterilerService;
        private readonly IMapper _mapper;

        public MusterilerController(IMusterilerService musterilerService, IMapper mapper)
        {
            _musterilerService = musterilerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MusterilerIndex()
        {
            var musteri = await _musterilerService.MusterilerVeSiparisler();
            return ResultAPI(musteri);
        }


        [HttpPost("add")]
        public async Task<IActionResult> MusteriEkle(MusteriEkleDTO musteriler)
        {

            var musteriSave = await _musterilerService.AddAsync(_mapper.Map<Musteriler>(musteriler));
            var mapAdd = _mapper.Map<MusteriEkleDTO>(musteriSave);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> MusteriGuncelle(int id, MusterilerDTO musteriDTO)
        {
            var musteriGetir = await _musterilerService.GetByIdAsync(id);
            if (musteriGetir != null)
            {
                _mapper.Map(musteriDTO, musteriGetir);
                await _musterilerService.UpdateAsync(musteriGetir);
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(musteriDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var musteri = await _musterilerService.GetByIdAsync(id);
            var musteriDTO = _mapper.Map<MusterilerDTO>(musteri);
            return ResultAPI(musteriDTO);
        }
    }
}
