using ProyectoMaui.Models;
using ProyectoMaui.Services;

namespace ProyectoMaui.Views;

public partial class Login : ContentPage
{
    private readonly AuthServices _authService = new();

    public Login()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var usuario = UsuarioEntry.Text;
        var contrasena = ContrasenaEntry.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            await DisplayAlert("Error", "Debes ingresar usuario y contraseña", "OK");
            return;
        }

        var loginResponse = await _authService.LoginAsync(usuario, contrasena);

        if (loginResponse == null || !loginResponse.success)
        {
            await DisplayAlert("Error", "Credenciales inválidas", "OK");
            return;
        }

        var tipo = loginResponse.user.Tipo?.ToLower();

        if (Application.Current.MainPage is AppShell shell)
        {
            if (tipo == "cliente")
            {
                shell.CargarMenuCliente();
                await Shell.Current.GoToAsync("//menu");
            }
            else if (tipo == "empleado" || tipo == "administrador")
            {
                shell.CargarMenuEmpleado();
                await Shell.Current.GoToAsync("//inicio");
            }
            else
            {
                await DisplayAlert("Error", "Tipo de usuario no reconocido", "OK");
                return;
            }
        }
    }

    private async void OnSignupClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//signup");
    }
}