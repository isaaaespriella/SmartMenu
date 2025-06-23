using ProyectoMaui.ViewModels;

namespace ProyectoMaui.Views;

public partial class ClientesView : ContentPage
{ public ClientesView()
		{
			InitializeComponent();
			BindingContext = new ClientesViewModel(); 
			Shell.SetNavBarIsVisible(this, false);
		}
}