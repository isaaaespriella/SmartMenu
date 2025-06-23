using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProyectoMaui.Models;
using ProyectoMaui.Services;

namespace ProyectoMaui.ViewModels
{
    public class PedidosViewModel : INotifyPropertyChanged
    {
        private readonly PedidoService _pedidoService;

        public ObservableCollection<Pedido> Pedidos { get; set; } = new();

        public PedidosViewModel()
        {
            _pedidoService = new PedidoService();
        }

        public async Task ObtenerPedidosAsync()
        {
            try
            {
                var pedidosDesdeApi = await _pedidoService.ObtenerPedidosAsync();

                await Application.Current.MainPage.DisplayAlert("Hey!", $"Se recibieron {pedidosDesdeApi.Count} pedidos", "OK");

                Pedidos.Clear();
                foreach (var pedido in pedidosDesdeApi)
                {
                    Pedidos.Add(pedido);
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