using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProyectoMaui.Models;
using ProyectoMaui.Services;

namespace ProyectoMaui.ViewModels
{
    public class ProveedoresViewModel : INotifyPropertyChanged
    {
        private readonly ProveedorServices _proveedorService;

        public ObservableCollection<Proveedor> Proveedores { get; set; } = new();

        public ProveedoresViewModel()
        {
            _proveedorService = new ProveedorServices();
        }

        public async Task ObtenerProveedoresAsync()
        {
            try
            {
                var proveedoresDesdeApi = await _proveedorService.ObtenerProveedoresAsync();

                await Application.Current.MainPage.DisplayAlert("Hey!", $"Se recibieron {proveedoresDesdeApi.Count} proveedores", "OK");

                Proveedores.Clear();
                foreach (var proveedor in proveedoresDesdeApi)
                {
                    Proveedores.Add(proveedor);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public async Task CrearProveedorAsync(string nombre, int telefono, string servicio)
        {
            try
            {
                var nuevoProveedor = new Proveedor
                {
                    Nombre = nombre,
                    Telefono = telefono,
                    Servicio = servicio
                };

                var exito = await _proveedorService.CrearProveedorAsync(nuevoProveedor);

                if (exito)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Proveedor creado", "OK");
                    await ObtenerProveedoresAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear el proveedor", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public async Task DeleteProveedorAsync(int id)
        {
            try
            {
                var confirmado = await Application.Current.MainPage.DisplayAlert(
                    "Confirmar",
                    $"¿Estás seguro de eliminar al proveedor con ID {id}?",
                    "Sí", "No");

                if (!confirmado)
                    return;

                var exito = await _proveedorService.DeleteProveedorAsync(id);

                if (exito)
                {
                    var proveedor = Proveedores.FirstOrDefault(p => p.Id == id);
                    if (proveedor != null)
                        Proveedores.Remove(proveedor);

                    await Application.Current.MainPage.DisplayAlert("Éxito", "Proveedor eliminado", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}