using MobilyaETicaret.Core.DTO;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class UrunlerAPIService
    {
        private readonly HttpClient _httpClient;
        public UrunlerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UrunlerveKategoriDTO>> Urunler()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<UrunlerveKategoriDTO>>>("Urunler");
            return response.Data;
        }

        public async Task<UrunEkleDTO> UrunKaydet(UrunEkleDTO urunEkleDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Urunler/add", urunEkleDTO);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<UrunEkleDTO>>();
            return responseBody.Data;
        }
    }
}
