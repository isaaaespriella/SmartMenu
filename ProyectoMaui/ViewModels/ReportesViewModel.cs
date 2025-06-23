using ProyectoMaui.Models;
using ProyectoMaui.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ProyectoMaui.ViewModels
{
    public class ReportesViewModel : INotifyPropertyChanged
    {
        private readonly ReporteService _reporteService = new();

        public ObservableCollection<Reportes> Reportes { get; set; } = new();

        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        public ReportesViewModel()
        {
            _ = CargarReportesAsync();
        }

        private async Task CargarReportesAsync()
        {
            IsLoading = true;
            var lista = await _reporteService.ObtenerReportesAsync();
            Reportes.Clear();
            foreach (var item in lista)
                Reportes.Add(item);
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nombre) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}