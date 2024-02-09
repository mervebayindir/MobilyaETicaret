using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using System.Net.Http.Json;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class KategorilerAPIService
    {
        private readonly HttpClient _httpClient;
        public KategorilerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KategoriFotografGosterDTO>> Kategoriler()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<KategoriFotografGosterDTO>>>("Kategoriler");
            return response.Data;
        }

        [HttpPost]
        public async Task<KategoriFotografDTO> KategoriKaydet(KategoriFotografDTO kategoriEkleDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Kategoriler/add", kategoriEkleDTO);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<KategoriFotografDTO>>();
            return responseBody.Data;
        }

    }
}
