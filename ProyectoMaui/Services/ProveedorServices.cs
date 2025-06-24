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
        
        /*

        public async Task<List<Proveedor>> GetProveedores()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/api/proveedores");//cambiar

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(responseContent);

                return proveedores;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }

        public async Task<bool> PostProveedor(string nombre, int telefono, string servicio)
        {
            try
            {
                var requestData = new Proveedor
                {
                    Nombre = nombre,
                    Telefono = telefono,
                    Servicio = servicio
                };

                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BaseUrl}/proveedores", content); //cambiar

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> PutProveedor(int id, string nombre, int telefono, string servicio)
        {
            try
            {
                var requestData = new Proveedor
                {
                    Id = id,
                    Nombre = nombre,
                    Telefono = telefono,
                    Servicio = servicio
                };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{BaseUrl}/proveedores/{id}", content); //cambiar
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(responseContent);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en PutProveedor: {ex.Message}");
                throw;
            }
        }*/
        
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

        public async Task<bool> DeleteProveedor(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/proveedores/{id}"); //cambiar
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(responseContent);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteProveedor: {ex.Message}");
                throw;
            }
        }


    }
}