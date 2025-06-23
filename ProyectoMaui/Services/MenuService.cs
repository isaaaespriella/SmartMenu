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
            _httpClient.BaseAddress = new Uri("https://342d-177-245-248-9.ngrok-free.app/"); // Usa tu URL
        }

        public async Task<List<Menu>> ObtenerPlatillosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Menu>>("api/menu")
                   ?? new List<Menu>();
        }
    } 
}