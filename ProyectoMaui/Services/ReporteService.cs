using ProyectoMaui.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoMaui.Services
{
    public class ReporteService
    {
        private readonly HttpClient _httpClient;

        public ReporteService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://b8c8-177-245-253-133.ngrok-free.app/api/")
            };
        }

        public async Task<List<Reportes>> ObtenerReportesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("reportes");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Reportes>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reportes: {ex.Message}");
                return new List<Reportes>();
            }
        }

        public async Task<bool> AgregarReporteAsync(Reportes nuevo)
        {
            try
            {
                var json = JsonSerializer.Serialize(nuevo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("reportes", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar reporte: {ex.Message}");
                return false;
            }
        }
    }
} 