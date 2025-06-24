using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMaui.Models;
using ProyectoMaui.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ProyectoMaui.Views;
public partial class ProveedoresView : ContentPage
{
    private readonly ProveedorServices _proveedoresService = new ProveedorServices();

    public ProveedoresView()
    {
        InitializeComponent();
    }

    //aparecen los proveedores cuando cargue la view
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarProveedores();
    }
    private async Task CargarProveedores()
    {
        var lista = await _proveedoresService.GetProveedores();
        if (lista != null)
        {
            ListaProveedores.ItemsSource = lista;
        }
        else
        {
            await DisplayAlert("Error", "No se pudieron cargar los proveedores", "OK");
        }
    }
    // con esto se agregan proveedores
    private async void AgregarClicked(object? sender, EventArgs e)
    {
        string nombre = Nombre.Text?.Trim();
        string telefonoString = Telefono.Text?.Trim();
        string servicio = Servicio.Text?.Trim();

        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefonoString) || string.IsNullOrEmpty(servicio))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        if (!int.TryParse(telefonoString, out int telefono))
        {
            await DisplayAlert("Error", "El telefono debe ser valido", "OK");
            return;
        }

        bool agregado = await _proveedoresService.PostProveedor(nombre, telefono, servicio);

        if (agregado)
        {
            await DisplayAlert("Exito", "Proveedor agregado exitosamente", "OK");
            Nombre.Text = string.Empty;
            Telefono.Text = string.Empty;
            Servicio.Text = string.Empty;

            await CargarProveedores();
        }
        else
        {
            await DisplayAlert("Error", "No se pudo agregar el proveedor", "OK");
        }
    }

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
}
