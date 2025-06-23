using ProyectoMaui.ViewModels;

namespace ProyectoMaui.Views;

public partial class PedidosView : ContentPage
{
    private PedidosViewModel viewModel;

    public PedidosView()
    {
        InitializeComponent();
        viewModel = new PedidosViewModel();
        BindingContext = viewModel;
        Shell.SetNavBarIsVisible(this, false);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerPedidosAsync();
    }

    private async void OnCrearPedidoClicked(object sender, EventArgs e)
    {
        if (int.TryParse(usuarioEntry.Text, out int usuarioId) &&
            int.TryParse(platilloEntry.Text, out int platilloId))
        {
            await viewModel.CrearPedidoAsync(usuarioId, platilloId);
            usuarioEntry.Text = string.Empty;
            platilloEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Debes ingresar IDs válidos", "OK");
        }
    }
}