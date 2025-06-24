using ProyectoMaui.ViewModels;
using ProyectoMaui.Models;
namespace ProyectoMaui.Views;

public partial class MenuView : ContentPage
{
    private MenuViewModel viewModel;

    public MenuView()
    {
        InitializeComponent();
        viewModel = new MenuViewModel();
        BindingContext = viewModel;
        Shell.SetNavBarIsVisible(this, false);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerPlatillosAsync(); // IMPORTANTE: Llama al método de carga
    }
    
    private async void OnAgregarPlatillo(object sender, EventArgs e)
    {
        string platillo = await DisplayPromptAsync("Nuevo Platillo", "Nombre del platillo:");
        string precioStr = await DisplayPromptAsync("Nuevo PLatillo", "precio del platillo:");
        string disponibilidadStr = await DisplayPromptAsync("Nuevo Platillo", "Disponibilidad 0 o 1:");
        

        if (string.IsNullOrWhiteSpace(platillo) || !double.TryParse(precioStr, out double precio) || !int.TryParse(disponibilidadStr, out int disponibilidad)) return;

        var nuevo = new Menupost { Platillo = platillo, Precio = precio, Disponibilidad = disponibilidad};

        var vm = BindingContext as MenuViewModel;
        if (await vm.AgregarPlatilloAsync(nuevo))
        {
            await vm.ObtenerPlatillosAsync();
        }
    }
}