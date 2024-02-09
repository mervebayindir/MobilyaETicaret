using MobilyaETicaret.Core.DTO;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class YetkiErisimAPIService
    {
        private readonly HttpClient _httpClient;

        public YetkiErisimAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<YetkiErisimDTO>> YetkiErisim()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<YetkiErisimDTO>>>("YetkiErisim");
            return response.Data;
        }

        public async Task<YetkiErisimDTO> YetkiErisimKaydet(YetkiErisimDTO yetkiErisimDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("YetkiErisim/add", yetkiErisimDTO);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<YetkiErisimDTO>>();
            return responseBody.Data;
        }
    }
}
