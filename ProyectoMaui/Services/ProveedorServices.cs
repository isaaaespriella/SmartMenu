using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Buffers.Text;
using ProyectoMaui.Models;

namespace ProyectoMaui.Services
{
    public class ProveedorServices
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://342d-177-245-248-9.ngrok-free.app/";
        //admin@techstore.com
        //admin123

        public ProveedorServices()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

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
