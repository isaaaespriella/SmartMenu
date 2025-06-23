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
            BaseAddress = new Uri("https://342d-177-245-248-9.ngrok-free.app/api/")
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

    public async Task<Usuario?> ObtenerClientePorIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"usuarios/cliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Usuario>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener cliente: {ex.Message}");
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