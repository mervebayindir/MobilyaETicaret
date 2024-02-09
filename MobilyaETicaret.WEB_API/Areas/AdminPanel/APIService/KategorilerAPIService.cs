using MobilyaETicaret.Core.DTO;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class KategorilerAPIService
    {
        private readonly HttpClient _httpClient;
        public KategorilerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KategorilerDTO>> Kategoriler()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<KategorilerDTO>>>("Kategoriler");
            return response.Data;
        }
    }
}
