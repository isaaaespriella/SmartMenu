using System.Collections.ObjectModel;
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
    public Usuario ClienteEncontrado { get; set; } = new();

    private string _clienteIdBuscar;
    public string ClienteIdBuscar
    {
        get => _clienteIdBuscar;
        set
        {
            if (_clienteIdBuscar != value)
            {
                _clienteIdBuscar = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<Pedido> HistorialPedidos { get; set; } = new();

    public ICommand RegistrarCommand { get; }
    public ICommand BuscarCommand { get; }
    public ICommand BuscarHistorialPedidosCommand { get; }
    public ICommand CargarTodosCommand { get; }

    public List<Usuario> Clientes { get; set; } = new();

    public ClientesViewModel()
    {
        RegistrarCommand = new Command(async () => await RegistrarClienteAsync());
        BuscarHistorialPedidosCommand = new Command(async () => await BuscarHistorialPedidosAsync());
        CargarTodosCommand = new Command(async () => await CargarTodosClientesAsync());
    }

    public async Task RegistrarClienteAsync()
    {
        var success = await _clientesService.RegistrarClienteAsync(NuevoCliente);

        if (success)
        {
            await Application.Current.MainPage.DisplayAlert("Éxito", "Cliente registrado", "OK");
            NuevoCliente = new Usuario();
            OnPropertyChanged(nameof(NuevoCliente));
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No se pudo registrar", "OK");
        }
    }

    public async Task BuscarHistorialPedidosAsync()
    {
        if (int.TryParse(ClienteIdBuscar, out int id))
        {
            var pedidos = await _clientesService.ObtenerPedidosPorClienteIdAsync(id);
            if (pedidos != null)
            {
                HistorialPedidos.Clear();
                foreach (var pedido in pedidos)
                    HistorialPedidos.Add(pedido);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No encontrado", "No se encontraron pedidos para el cliente", "OK");
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "ID inválido", "OK");
        }
    }

    public async Task CargarTodosClientesAsync()
    {
        var clientes = await _clientesService.ObtenerTodosLosClientesAsync();
        if (clientes != null)
        {
            Clientes = clientes;
            OnPropertyChanged(nameof(Clientes));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
