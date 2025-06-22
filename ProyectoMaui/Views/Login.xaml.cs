
namespace ProyectoMaui.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
		Shell.SetNavBarIsVisible(this, false);

	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
		
	}


}