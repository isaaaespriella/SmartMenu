using ProyectoMaui.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ProyectoMaui.Services;

public class ClientesService
{
    private readonly HttpClient _httpClient;

    public ClientesService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://b8c8-177-245-253-133.ngrok-free.app/api/")
        };
    }

    public async Task<bool> RegistrarClienteAsync(Usuario cliente)
    {
        try
        {
            cliente.Tipo = "cliente";

            var json = JsonSerializer.Serialize(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("usuarios", content);

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar cliente: {ex.Message}");
            return false;
        }
    }

    public async Task<List<Pedido>?> ObtenerPedidosPorClienteIdAsync(int clienteId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"pedidos/cliente/{clienteId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Pedido>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener pedidos del cliente: {ex.Message}");
        }

        return null;
    }

    public async Task<List<Usuario>?> ObtenerTodosLosClientesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("usuarios/clientes");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Usuario>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener lista de clientes: {ex.Message}");
        }

        return null;
    }

}