using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class KategorilerController : BaseController
    {
        private readonly IService<Kategoriler> _service;
        private readonly IMapper _mapper;

        public KategorilerController(IService<Kategoriler> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> KategorilerIndex()
        {
            var kategoriler = await _service.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategorilerDTO>>(kategoriler);
            return ResultAPI(kategoriDTO);
        }

        [HttpPost("add")]
        public async Task<IActionResult> KategoriEkle(KategoriEkleDTO kategoriEkleDTO)
        {
            var kategoriSave = await _service.AddAsync(_mapper.Map<Kategoriler>(kategoriEkleDTO));
            var mapAdd = _mapper.Map<KategoriEkleDTO>(kategoriSave);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> KategoriGuncelle(int id, KategoriFotografDTO updateDTO)
        {
            var kategoriGetir = await _service.GetByIdAsync(id);
            if (kategoriGetir != null)
            {
                _mapper.Map(updateDTO, kategoriGetir);

                await _service.UpdateAsync(kategoriGetir);
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(updateDTO);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var kategori = await _service.GetByIdAsync(id);
            var kategoriDto = _mapper.Map<KategoriGuncelleDTO>(kategori);
            return Ok(kategoriDto);
        }
    }
}
