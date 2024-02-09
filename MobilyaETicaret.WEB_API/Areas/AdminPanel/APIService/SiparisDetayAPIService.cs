using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.SP_DTO;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class SiparisDetayAPIService
    {
        private readonly HttpClient _httpClient;

        public SiparisDetayAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Sp_SiparisBilgileriDTO>> SiparisDetay()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<Sp_SiparisBilgileriDTO>>>("SiparisDetay");
            return response.Data;
        }
    }
}
