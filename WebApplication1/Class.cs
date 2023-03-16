using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PostaKodu
    {
        public int Plaka { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string SemtBucakBelde { get; set; }
        public string Mahalle { get; set; }
        public string PK { get; set; }
    }
    public class PostaKoduService
    {
        private readonly HttpClient _httpClient;

        public PostaKoduService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.ubilisim.com/");
        }

        public async Task<List<PostaKodu>> GetPostaKodlari(int plakaKodu)
        {
            var response = await _httpClient.GetAsync($"postakodu/il/{plakaKodu}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var postaKodlari = JsonSerializer.Deserialize<List<PostaKodu>>(jsonString);
                return postaKodlari;
            }
            throw new Exception("Başarısız");
        }
    }
}
