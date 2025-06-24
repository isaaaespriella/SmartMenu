using Microsoft.Maui.Controls;
using ProyectoMaui.ViewModels;

namespace ProyectoMaui.Views
{
    public partial class ReportesView : ContentPage
    {
        private readonly ReportesViewModel vm;

        public ReportesView()
        {
            InitializeComponent();
            vm = new ReportesViewModel();
            BindingContext = vm;
        }

        private async void OnAgregarReporte(object sender, EventArgs e)
        {
            string fecha = await DisplayPromptAsync("Fecha", "Introduce la fecha (YYYY-MM-DD):");
            string total = await DisplayPromptAsync("Total", "Introduce el total de la venta:");
            string responsable = await DisplayPromptAsync("Responsable", "Introduce el nombre del responsable:");

            if (!string.IsNullOrWhiteSpace(fecha) &&
                !string.IsNullOrWhiteSpace(total) &&
                !string.IsNullOrWhiteSpace(responsable))
            {
                vm.NuevaFecha = fecha;
                vm.NuevoTotal = total;
                vm.NuevoResponsable = responsable;
                await vm.AgregarReporte();
            }
            else
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            }
        }
    }
}


