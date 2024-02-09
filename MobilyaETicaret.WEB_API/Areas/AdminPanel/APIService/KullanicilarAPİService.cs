using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class KullanicilarAPİService
    {
        private readonly HttpClient _httpClient;

        public KullanicilarAPİService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KullanicilarVeYetkilerDTO>> Kullanicilar()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<KullanicilarVeYetkilerDTO>>>("Kullanicilar");
            return response.Data;
        }

        public async Task<Kullanicilar> PersonelKullaniciKaydet(Kullanicilar kullanicilar)
        {
            var response = await _httpClient.PostAsJsonAsync("Kullanicilar/add", kullanicilar);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<Kullanicilar>>();
            return responseBody.Data;
        }
    }
}
