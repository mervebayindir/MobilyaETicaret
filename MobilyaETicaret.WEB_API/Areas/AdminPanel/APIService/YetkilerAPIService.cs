using MobilyaETicaret.Core.DTO;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
	public class YetkilerAPIService
	{
		private readonly HttpClient _httpClient;

		public YetkilerAPIService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<YetkiGuncelleDTO>> Yetkiler()
		{
			var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<YetkiGuncelleDTO>>>("Yetkiler");
			return response.Data;
		}

        public async Task<YetkiGuncelleDTO> YetkiKaydet(YetkiGuncelleDTO urunEkleDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Yetkiler/add", urunEkleDTO);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<YetkiGuncelleDTO>>();
            return responseBody.Data;
        }
    }
}
