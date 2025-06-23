using ProyectoMaui.Models;
using ProyectoMaui.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ProyectoMaui.ViewModels;

public class ClientesViewModel : INotifyPropertyChanged
{
    private readonly ClientesService _clientesService = new();

    public Usuario NuevoCliente { get; set; } = new();

    public ICommand RegistrarCommand { get; }

    public ClientesViewModel()
    {
        RegistrarCommand = new Command(async () => await RegistrarClienteAsync());
    }

    public async Task RegistrarClienteAsync()
    {
        var success = await _clientesService.RegistrarClienteAsync(NuevoCliente);

        if (success)
        {
            await Application.Current.MainPage.DisplayAlert("Éxito", "Cliente registrado correctamente", "OK");
            NuevoCliente = new Usuario(); // Reiniciar formulario
            OnPropertyChanged(nameof(NuevoCliente));
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No se pudo registrar el cliente", "OK");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}