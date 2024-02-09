using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class SiparislerAPIService
    {
        private readonly HttpClient _httpClient;

        public SiparislerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SiparislerDTO>> Siparisler()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<SiparislerDTO>>>("Siparisler");
            return response.Data;
        }
    }
}
