using ProyectoMaui.Models;
using System.Net.Http.Json;

namespace ProyectoMaui.Services
{
    public class PedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://b8c8-177-245-253-133.ngrok-free.app/");
        }

        public async Task<List<Pedido>> ObtenerPedidosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Pedido>>("api/pedidos")
                   ?? new List<Pedido>();
        }
    }
}