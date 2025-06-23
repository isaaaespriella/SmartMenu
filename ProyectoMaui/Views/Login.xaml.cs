
namespace ProyectoMaui.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
		Shell.SetNavBarIsVisible(this, false);
	

	}

	private async void OnSignupClicked(object sender, EventArgs e)
		=> await Shell.Current.GoToAsync("signup");
	
	
	// solo por accesibilidad quitar cuando se haga la funcion de auth
	private async void OnLoginClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
		
	}


}