using ProyectoMaui.Models;
using ProyectoMaui.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ProyectoMaui.ViewModels
{
    public class ReportesViewModel : INotifyPropertyChanged
    {
        private readonly ReporteService _reporteService = new();

        public ObservableCollection<Reportes> Reportes { get; set; } = new();
        public ObservableCollection<Reportes> ReportesFiltrados { get; set; } = new();

        public string NuevaFecha { get; set; }
        public string NuevoTotal { get; set; }
        public string NuevoResponsable { get; set; }

        private string busqueda;
        public string Busqueda
        {
            get => busqueda;
            set
            {
                if (busqueda != value)
                {
                    busqueda = value;
                    OnPropertyChanged();
                    FiltrarReportes();
                }
            }
        }

        public ICommand EliminarCommand => new Command<Reportes>(EliminarReporte);
        public ICommand AgregarCommand => new Command(async () => await AgregarReporte());

        public ReportesViewModel()
        {
            _ = CargarReportesAsync();
        }

        private async Task CargarReportesAsync()
        {
            var lista = await _reporteService.ObtenerReportesAsync();
            Reportes.Clear();
            foreach (var item in lista)
                Reportes.Add(item);

            FiltrarReportes();
        }

        private async Task AgregarReporte()
        {
            var nuevo = new Reportes
            {
                Fecha = NuevaFecha,
                Total = NuevoTotal,
                Responsable = NuevoResponsable
            };

            bool exito = await _reporteService.AgregarReporteAsync(nuevo);
            if (exito)
            {
                Reportes.Add(nuevo);
                FiltrarReportes();
            }
        }

        public async Task AgregarReporteDesdeVista()
        {
            await AgregarReporte();
        }

        private void FiltrarReportes()
        {
            var filtro = busqueda?.ToLower() ?? string.Empty;
            var filtrados = Reportes.Where(r =>
                r.Fecha.ToLower().Contains(filtro) ||
                r.Responsable.ToLower().Contains(filtro)).ToList();

            ReportesFiltrados.Clear();
            foreach (var reporte in filtrados)
                ReportesFiltrados.Add(reporte);
        }

        private void EliminarReporte(Reportes reporte)
        {
            Reportes.Remove(reporte);
            ReportesFiltrados.Remove(reporte);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
