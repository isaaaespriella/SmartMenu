using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoMaui.Models;

namespace ProyectoMaui.Services;

public class AuthServices
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://b8c8-177-245-253-133.ngrok-free.app/api/usuarios"; // Cambia si usas IP externa

    public AuthServices()
    {
        _httpClient = new HttpClient();
    }

    public async Task<LoginResponse?> LoginAsync(string usuario, string contrasena)
    {
        var data = new { usuario, contrasena };
        var json = JsonConvert.SerializeObject(data); // Usamos Newtonsoft aquí
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{BaseUrl}/login", content);
        if (!response.IsSuccessStatusCode)
            return null;

        var responseBody = await response.Content.ReadAsStringAsync();

        // También usamos Newtonsoft aquí
        return JsonConvert.DeserializeObject<LoginResponse>(responseBody);
    }
}