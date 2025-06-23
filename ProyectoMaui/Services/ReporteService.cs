using ProyectoMaui.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
                BaseAddress = new Uri("https://tudominio.com/api/") // <-- CAMBIA ESTA RUTA
            };
        }

        public async Task<List<Reportes>> ObtenerReportesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("reportes"); // <-- CAMBIA A TU ENDPOINT REAL
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Reportes>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reportes: {ex.Message}");
                return new List<Reportes>();
            }
        }
    }
}