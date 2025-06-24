using ProyectoMaui.ViewModels;

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
}