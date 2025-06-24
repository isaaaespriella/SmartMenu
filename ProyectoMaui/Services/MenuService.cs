using ProyectoMaui.Models;
using System.Net.Http.Json;

namespace ProyectoMaui.Services
{
    public class MenuService
    {
        private readonly HttpClient _httpClient;

        public MenuService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://b8c8-177-245-253-133.ngrok-free.app/"); // Usa tu URL
        }

        public async Task<List<Menu>> ObtenerPlatillosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Menu>>("api/menu")
                   ?? new List<Menu>();
        }
        
        public async Task<bool> AgregarPlatilloAsync(Menupost nuevo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/menu", nuevo);
            return response.IsSuccessStatusCode;
        }
    } 
}