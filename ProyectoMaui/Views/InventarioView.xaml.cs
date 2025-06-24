using ProyectoMaui.Models;
using ProyectoMaui.ViewModels;

namespace ProyectoMaui.Views;

public partial class InventarioView : ContentPage
{
	private readonly InventarioViewModel _viewModel;
	public InventarioView()
	{
		InitializeComponent();
		Shell.SetNavBarIsVisible(this, false);
		_viewModel = new InventarioViewModel();
		BindingContext = _viewModel;

		_ = _viewModel.ObtenerInventarioAsync();
	}
	
	private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
	{
		var item = e.CurrentSelection.FirstOrDefault() as Inventario;

		if (item == null)
			return;

		await DisplayAlert("Detalle del insumo", $"Ingrediente: {item.Ingrediente}\nStock: {item.Stock}", "OK");

		if (item.Stock < 5)
		{
			await DisplayAlert("¡Atención!", $"El stock del ingrediente '{item.Ingrediente}' es muy bajo ({item.Stock}).", "Revisar");
		}

		((CollectionView)sender).SelectedItem = null;
	}
	
	private async void OnEliminarInvoked(object sender, EventArgs e)
	{
		var swipeItem = sender as SwipeItem;
		var inventario = swipeItem?.BindingContext as Inventario;

		if (inventario == null) return;

		bool confirmar = await DisplayAlert("Eliminar", $"¿Eliminar '{inventario.Ingrediente}'?", "Sí", "No");
		if (confirmar)
		{
			var vm = BindingContext as InventarioViewModel;
			if (await vm.EliminarInventarioAsync(inventario.Id))
			{
				await vm.ObtenerInventarioAsync();
			}
		}
	}

	private async void OnEditarInvoked(object sender, EventArgs e)
	{
		var swipeItem = sender as SwipeItem;
		var inventario = swipeItem?.BindingContext as Inventario;

		if (inventario == null) return;

		string nuevoStock = await DisplayPromptAsync("Editar", $"Nuevo stock para {inventario.Ingrediente}:", initialValue: inventario.Stock.ToString());

		if (int.TryParse(nuevoStock, out int nuevoValor))
		{
			inventario.Stock = nuevoValor;

			var vm = BindingContext as InventarioViewModel;
			if (await vm.ActualizarInventarioAsync(inventario.Id, inventario))
			{
				await vm.ObtenerInventarioAsync();
			}
		}
	}

	private async void OnAgregarInsumo(object sender, EventArgs e)
	{
		string ingrediente = await DisplayPromptAsync("Nuevo insumo", "Nombre del ingrediente:");
		string stockStr = await DisplayPromptAsync("Nuevo insumo", "Cantidad en stock:");

		if (string.IsNullOrWhiteSpace(ingrediente) || !int.TryParse(stockStr, out int stock)) return;

		var nuevo = new Inventario { Ingrediente = ingrediente, Stock = stock };

		var vm = BindingContext as InventarioViewModel;
		if (await vm.AgregarInventarioAsync(nuevo))
		{
			await vm.ObtenerInventarioAsync();
		}
	}
}