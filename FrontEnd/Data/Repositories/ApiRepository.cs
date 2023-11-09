using FrontEnd.Data.Models;
using System.Text.Json;

namespace FrontEnd.Data.Repositories
{
    public class ApiRepository
    {

        private readonly HttpClient _httpClient;

        public ApiRepository(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("RepositoryApiHttp");
        }

        public async Task<ICollection<Banche>> GetBanche()
        {
            Uri url = new Uri(_httpClient.BaseAddress, "Banche");

            HttpResponseMessage res = await _httpClient.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }

            return JsonSerializer.Deserialize<List<Banche>>(await res.Content.ReadAsStringAsync());
        }

        public async Task<Banche> GetBanca(int id)
        {
            Uri url = new Uri(_httpClient.BaseAddress, $"Banche/{id}");

            HttpResponseMessage res = await _httpClient.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }

            return JsonSerializer.Deserialize<Banche>(await res.Content.ReadAsStringAsync());
        }

        public async Task<ICollection<Funzionalita>> GetFunzionalita()
        {
            Uri url = new Uri(_httpClient.BaseAddress, "Funzionalita");

            HttpResponseMessage res = await _httpClient.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }

            return JsonSerializer.Deserialize<List<Funzionalita>>(await res.Content.ReadAsStringAsync());
        }

        public async Task<ICollection<BancheFunzionalita>> GetBancheFunzionalita()
        {
            Uri url = new Uri(_httpClient.BaseAddress, "BancheFunzionalita");

            HttpResponseMessage res = await _httpClient.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }

            return JsonSerializer.Deserialize<List<BancheFunzionalita>>(await res.Content.ReadAsStringAsync());
        }


        public Task GetUtenti()
        {
            throw new NotImplementedException();
        }
        public Task PostUtenti()
        {
            throw new NotImplementedException();
        }
        public Task PutUtenti()
        {
            throw new NotImplementedException();
        }
        public Task DeleteUtenti()
        {
            throw new NotImplementedException();
        }
    }
}
