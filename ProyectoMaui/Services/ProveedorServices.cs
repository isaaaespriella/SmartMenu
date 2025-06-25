using Newtonsoft.Json;
using System.Buffers.Text;
using ProyectoMaui.Models;
using System.Net.Http.Json;

namespace ProyectoMaui.Services
{
    public class ProveedorServices
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://7c41-177-245-247-187.ngrok-free.app/";
        //admin@techstore.com
        //admin123

        public ProveedorServices()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://7c41-177-245-247-187.ngrok-free.app/");

        }
     
        public async Task<List<Proveedor>> ObtenerProveedoresAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Proveedor>>("api/proveedores")
                   ?? new List<Proveedor>();
        }

        public async Task<bool> CrearProveedorAsync(Proveedor proveedor)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/proveedores", new
                {
                    proveedor.Nombre,
                    proveedor.Telefono,
                    proveedor.Servicio
                });

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"RESPUESTA POST: {content}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR EN POST: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteProveedorAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/proveedores/{id}");
                
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"RESPUESTA DELETE: {content}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR EN DELETE: {ex.Message}");
                return false; 
            }
        }

        public async Task<bool> ModificarProveedorAsync(int id, Proveedor proveedor)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/proveedores/{id}", proveedor);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"RESPUESTA PUT: {content}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR EN PUT: {ex.Message}");
                return false;
            }
        }

    }
}