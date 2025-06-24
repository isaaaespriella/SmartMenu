using System.Net.Http.Json;
using ProyectoMaui.Models;

namespace ProyectoMaui.Services;

public class InventarioService
{
    private readonly HttpClient _httpClient;

    public InventarioService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://b8c8-177-245-253-133.ngrok-free.app/");
    }

    public async Task<List<Inventario>> ObtenerInventarioAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Inventario>>("api/inventario")
               ?? new List<Inventario>();
    }

    public async Task<bool> AgregarInventarioAsync(Inventario nuevo)
    {
        var response = await _httpClient.PostAsJsonAsync("api/inventario", nuevo);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarInventarioAsync(int id, Inventario actualizado)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/inventario/{id}", actualizado);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarInventarioAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/inventario/{id}");
        return response.IsSuccessStatusCode;
    }
}