using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProyectoMaui.Models;
using ProyectoMaui.Services;

namespace ProyectoMaui.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private readonly MenuService _menuService;

        public ObservableCollection<Menu> Platillos { get; set; } = new();

        public MenuViewModel()
        {
            _menuService = new MenuService();
        }

        public async Task ObtenerPlatillosAsync()
        {
            try
            {
                var platillosDesdeApi = await _menuService.ObtenerPlatillosAsync();

                await Application.Current.MainPage.DisplayAlert("Éxito", 
                    $"Se cargaron {platillosDesdeApi.Count} platillos", "OK");

                Platillos.Clear();
                foreach (var platillo in platillosDesdeApi)
                {
                    Platillos.Add(platillo);
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