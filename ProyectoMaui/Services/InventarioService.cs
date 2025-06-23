using System.Net.Http.Json;
using ProyectoMaui.Models;

namespace ProyectoMaui.Services;

public class InventarioService
{
    private readonly HttpClient _httpClient;

    public InventarioService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://342d-177-245-248-9.ngrok-free.app/");
    }

    // GET
    public async Task<List<Inventario>> ObtenerInventarioAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Inventario>>("api/inventario")
               ?? new List<Inventario>();
    }

    // POST 
    public async Task<bool> AgregarInventarioAsync(Inventario nuevo)
    {
        var response = await _httpClient.PostAsJsonAsync("api/inventario", nuevo);
        return response.IsSuccessStatusCode;
    }

    // PUT 
    public async Task<bool> ActualizarInventarioAsync(int id, Inventario actualizado)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/inventario/{id}", actualizado);
        return response.IsSuccessStatusCode;
    }

    // DELETE 
    public async Task<bool> EliminarInventarioAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/inventario/{id}");
        return response.IsSuccessStatusCode;
    }
}
