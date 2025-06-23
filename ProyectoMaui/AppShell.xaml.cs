namespace ProyectoMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("menu", typeof(Views.MenuView));
        Routing.RegisterRoute("pedidos", typeof(Views.PedidosView));
        Routing.RegisterRoute("clientes", typeof(Views.ClientesView));
        Routing.RegisterRoute("inventario", typeof(Views.InventarioView));
        Routing.RegisterRoute("proveedores", typeof(Views.ProveedoresView));
        Routing.RegisterRoute("reportes", typeof(Views.ReportesView));
        Routing.RegisterRoute("signup", typeof(Views.SignupView));
        Routing.RegisterRoute("login", typeof(Views.Login));

    }
}