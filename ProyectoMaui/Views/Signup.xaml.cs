using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMaui.Views;

public partial class SignupView : ContentPage
{
    public SignupView()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
    }
    
    private async void OnSignupClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("signup");
    private async void OnLoginViewClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("login");
}