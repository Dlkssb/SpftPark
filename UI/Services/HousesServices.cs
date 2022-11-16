using System.Net.Http.Json;
using UI.Interfaces;
using UI.Models;

namespace UI.Services
{
    public class HousesServices : IHouseServices
    {
        private readonly HttpClient _httpClient;
        public HousesServices(HttpClient httpClient) => _httpClient = httpClient;
        public Task<Guid> Create(House entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(House entity)
        {
            throw new NotImplementedException();
        }

        public Task<House> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<House>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<House>>("https://localhost:7068/GetHouses");
        }
    }
}
