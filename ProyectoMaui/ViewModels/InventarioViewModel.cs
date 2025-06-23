using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProyectoMaui.Models;
using ProyectoMaui.Services;

namespace ProyectoMaui.ViewModels;

public class InventarioViewModel : INotifyPropertyChanged
{
    private readonly InventarioService _inventarioService;
    
    public ObservableCollection<Inventario> Inventario { get; set; } = new();

    public InventarioViewModel()
    {
        _inventarioService = new InventarioService();
    }

    public async Task ObtenerInventarioAsync()
    {
        try
        {
            var inventarioDesdeApi = await _inventarioService.ObtenerInventarioAsync();

            await Application.Current.MainPage.DisplayAlert("Hey!", $"Se recibieron {inventarioDesdeApi.Count} insumos", "OK");

            Inventario.Clear();
            foreach (var inventario in inventarioDesdeApi)
            {
                Inventario.Add(inventario);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
    
    // public async Task PruebaAgregarNuevo()
    // {
    //     var nuevo = new Inventario { Ingrediente = "Sal", Stock = 20 };
    //
    //     bool exito = await _inventarioService.AgregarInventarioAsync(nuevo);
    //
    //     if (exito)
    //     {
    //         await ObtenerInventarioAsync(); // Recargar datos
    //     }
    // }

    public async Task<bool> AgregarInventarioAsync(Inventario nuevo)
    {
        return await _inventarioService.AgregarInventarioAsync(nuevo);
    }

    public async Task<bool> ActualizarInventarioAsync(int id, Inventario actualizado)
    {
        return await _inventarioService.ActualizarInventarioAsync(id, actualizado);
    }

    public async Task<bool> EliminarInventarioAsync(int id)
    {
        return await _inventarioService.EliminarInventarioAsync(id);
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}