using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMaui.ViewModels;

namespace ProyectoMaui.Views;

public partial class PedidosView : ContentPage
{
    private PedidosViewModel viewModel;

    public PedidosView()
    {
        InitializeComponent();
        viewModel = new PedidosViewModel();
        BindingContext = viewModel;
        Shell.SetNavBarIsVisible(this, false);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.ObtenerPedidosAsync(); //  IMPORTANTE: este método debe ejecutarse
    }
}
