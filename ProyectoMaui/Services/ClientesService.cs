using ProyectoMaui.Models;
using System.Net.Http;
using System.Net.Http.Json;
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
            BaseAddress = new Uri("https://342d-177-245-248-9.ngrok-free.app/") 
        };
    }

    public async Task<bool> RegistrarClienteAsync(Usuario cliente)
    {
        try
        {
            cliente.Rol = "cliente";

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
}