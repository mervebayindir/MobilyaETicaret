using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
	public class ErisimAlanlariAPIService
	{
		private readonly HttpClient _httpClient;

		public ErisimAlanlariAPIService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ErisimAlanlari>> ErisimAlanlari()
		{
			var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<ErisimAlanlari>>>("ErisimAlanlari");
			return response.Data;
		}
	}
}
