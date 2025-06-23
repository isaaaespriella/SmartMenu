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
            _httpClient.BaseAddress = new Uri("https://342d-177-245-248-9.ngrok-free.app/");
        }

        public async Task<List<Pedido>> ObtenerPedidosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Pedido>>("api/pedidos")
                   ?? new List<Pedido>();
        }
    }
}