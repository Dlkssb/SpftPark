
using UI.Models;
using System.Net.Http.Json;
using UI.Interfaces;

namespace UI.Services
{
    public class CustomerServices : ICustomerServices
    {
       private readonly HttpClient _httpClient;
        public CustomerServices(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Guid> Create(Customer entity)
        {
          return  await _httpClient.PostAsJsonAsync<Customer>("https://localhost:7068/AddCustomer", entity).Result.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task Delete(Guid Id)
        {
             await _httpClient.DeleteAsync("https://localhost:7068/DeleteCustomer");
        }

        public async Task Edit(Customer entity)
        {
             await _httpClient.PutAsJsonAsync<Customer>("https://localhost:7068/EditCustomer",entity);
        }

      

        public async Task<Customer> GetAsync(Guid Id)
        {
        
            return await _httpClient.GetFromJsonAsync<Customer>($"https://localhost:7068/GetCustomer?CustomerId={Id}");
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("https://localhost:7068/GetCustomers");
        }
    }
}
