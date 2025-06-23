namespace ProyectoMaui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
	}

	private async void OnMenuClicked(object sender, EventArgs e)
    => await Shell.Current.GoToAsync("menu");

    private async void OnPedidosClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("pedidos");

    private async void OnClientesClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("clientes");

    private async void OnInventarioClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("inventario");

    private async void OnProveedoresClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("proveedores");
    
    private async void OnReportesClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("reportes");
}