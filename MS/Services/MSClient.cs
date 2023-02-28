using MS.Shared.Entities;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MS.Services
{
    public class MSClient : IMSClient
    {
        private readonly HttpClient httpClient;

        public MSClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("https://localhost:7257");
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Machine>?> GetAllAsync()  // kontroll gått bra/dåligt
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Machine>>("api/machines");
        }

        public async Task<Machine>? GetAsync(string id)  // kontroll gått bra/dåligt
        {
            return await httpClient.GetFromJsonAsync<Machine>($"api/machines/{id}");
        }

        public async Task<Machine?> PostAsync(CreateMachine createMachine)
        {
            var response = await httpClient.PostAsJsonAsync("api/machines", createMachine);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Machine>() : null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return (await httpClient.DeleteAsync($"api/machines/{id}")).IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(Machine machine)
        {
            return (await httpClient.PutAsJsonAsync($"api/machines/{machine.Id}", machine)).IsSuccessStatusCode;
        }
    }
}
