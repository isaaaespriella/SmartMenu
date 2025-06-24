using Microsoft.Maui.Controls;
using ProyectoMaui.ViewModels;

namespace ProyectoMaui.Views
{
    public partial class ReportesView : ContentPage
    {
        public ReportesView()
        {
            InitializeComponent();
        }

        private async void OnAgregarReporte(object sender, EventArgs e)
        {
            string fecha = await DisplayPromptAsync("Fecha", "Introduce la fecha (YYYY-MM-DD):");
            string total = await DisplayPromptAsync("Total", "Introduce el total de la venta:");
            string responsable = await DisplayPromptAsync("Responsable", "Introduce el nombre del responsable:");

            if (BindingContext is ReportesViewModel vm)
            {
                vm.NuevaFecha = fecha;
                vm.NuevoTotal = total;
                vm.NuevoResponsable = responsable;
                await vm.AgregarReporteDesdeVista(); 
            }
        }
    }
}

