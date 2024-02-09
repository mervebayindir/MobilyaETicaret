using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class ErisimAlanlariController : BaseController
	{
		private readonly IErisimAlanlariService _erisimAlanlariService;
		private readonly IMapper _mapper;

		public ErisimAlanlariController(IErisimAlanlariService erisimAlanlariService, IMapper mapper)
		{
			_erisimAlanlariService = erisimAlanlariService;
			_mapper = mapper;
		}

		public async Task<IActionResult> ErisimAlanlari()
		{
			var erisimAlanlari = await _erisimAlanlariService.GetAllAsyncs();
			var erisimAlaniDTO = _mapper.Map<List<ErisimAlanlari>>(erisimAlanlari);
			return ResultAPI(erisimAlaniDTO);
		}
	}
}
