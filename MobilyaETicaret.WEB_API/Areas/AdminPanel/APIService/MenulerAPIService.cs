using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class MenulerAPIService
    {
        private readonly HttpClient _httpClient;

        public MenulerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MenulerVeErisimAlaniDTO>> Menuler()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<MenulerVeErisimAlaniDTO>>>("Menuler");
            return response.Data;
        }

        public async Task<MenuEkleDTO> MenuKaydet(MenuEkleDTO menuEkleDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Menuler/add", menuEkleDTO);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<MenuEkleDTO>>();
            return responseBody.Data;
        }
    }
}
