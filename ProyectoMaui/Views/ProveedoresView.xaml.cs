using ProyectoMaui.Models;
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
    
    private void OnToggleModificarProveedor(object sender, EventArgs e)
    {
        ModificarProveedorForm.IsVisible = !ModificarProveedorForm.IsVisible;
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
        string telefono = telefonoEntry.Text;
        
        if (!string.IsNullOrWhiteSpace(nombre) &&
            !string.IsNullOrWhiteSpace(nombre) &&
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
    
    private async void OnEditarInvoked(object sender, EventArgs e)
    {
        
    }

    private async void OnDeleteProveedorClicked(object sender, EventArgs e)
    {
        if (int.TryParse(idEntry.Text, out int id))
        {
            await viewModel.DeleteProveedorAsync(id);
            idEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Debes ingresar IDs válidos", "OK");
        }
    }

    private async void OnModificarProveedorClicked(object sender, EventArgs e)
    {
        try
        {
            // Validar entradas
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(telefonoEntry.Text) ||
                string.IsNullOrWhiteSpace(servicioEntry.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            // Crear objeto proveedor
            var proveedorActualizado = new Proveedor
            {
                Nombre = nombreEntryMod.Text,
                Telefono = telefonoEntryMod.Text,
                Servicio = servicioEntryMod.Text
            };

            if (!int.TryParse(idEntryMod.Text, out int proveedorId))
            {
                await DisplayAlert("Error", "ID inválido.", "OK");
                return;
            }

            bool resultado = await viewModel.ModificarProveedorAsync(proveedorId, proveedorActualizado);


            if (resultado)
            {
                await DisplayAlert("Éxito", "Proveedor actualizado correctamente.", "OK");
                // Opcional: refrescar lista
                await viewModel.ObtenerProveedoresAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el proveedor.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Excepción: {ex.Message}", "OK");
        }
    }

}
