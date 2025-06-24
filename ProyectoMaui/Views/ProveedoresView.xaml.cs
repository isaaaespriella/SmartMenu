using ProyectoMaui.ViewModels;
using ProyectoMaui.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ProyectoMaui.Views;
public partial class ProveedoresView : ContentPage
{
    private readonly ProveedorServices _proveedoresService = new ProveedorServices();
    private ProveedoresViewModel viewModel;
    

    public ProveedoresView()
    {
        InitializeComponent();
        viewModel = new ProveedoresViewModel();
        BindingContext = viewModel;
        Shell.SetNavBarIsVisible(this, false);    
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerProveedoresAsync();
    }
    
    private async void OnCrearProveedorClicked(object sender, EventArgs e)
    {
        string nombre = nombreEntry.Text;
        string servicio = servicioEntry.Text;
        
        if (!string.IsNullOrWhiteSpace(nombre) &&
            int.TryParse(telefonoEntry.Text, out int telefono) &&
            !string.IsNullOrWhiteSpace(servicio))
        {
            await viewModel.CrearProveedorAsync(nombre, telefono, servicio);
            nombreEntry.Text = string.Empty;
            telefonoEntry.Text = string.Empty;
            servicioEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Debes ingresar IDs válidos", "OK");
        }
    }

    /*
    //se eliminan al v
    private async void EliminarClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(IdElim.Text, out int id))
        {
            await DisplayAlert("Error", "Debes ingresar un ID numérico válido.", "OK");
            return;
        }

        bool eliminado = await _proveedoresService.DeleteProveedor(id);

        if (eliminado)
        {
            await DisplayAlert("Éxito", $"Proveedor con ID {id} eliminado correctamente.", "OK");
            await CargarProveedores();
            IdElim.Text = string.Empty; // Limpia el entry
        }
        else
        {
            await DisplayAlert("Error", $"No se pudo eliminar el proveedor con ID {id}.", "OK");
        }
    }
    */
}
