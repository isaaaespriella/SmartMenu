using ProyectoMaui.Views;

namespace ProyectoMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registra todas las rutas que usarás en la app
        Routing.RegisterRoute("login", typeof(Login));
        Routing.RegisterRoute("signup", typeof(SignupView));
        Routing.RegisterRoute("menu", typeof(MenuView));
        Routing.RegisterRoute("inicio", typeof(MainPage));
        Routing.RegisterRoute("pedidos", typeof(PedidosView));
        Routing.RegisterRoute("clientes", typeof(ClientesView));
        Routing.RegisterRoute("inventario", typeof(InventarioView));
        Routing.RegisterRoute("proveedores", typeof(ProveedoresView));
        Routing.RegisterRoute("reportes", typeof(ReportesView));

        // Al iniciar, muestra el login
        CargarLogin();
    }

    // Método para cargar sólo el Login
    public void CargarLogin()
    {
        Items.Clear();
        Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(typeof(Login)),
            Route = "login"
        });
    }

    // Método para cargar menú cliente (solo menú)
    public void CargarMenuCliente()
    {
        Items.Clear();
        Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(typeof(MenuView)),
            Route = "menu"
        });
    }

    // Método para cargar menú empleado (main + demás vistas)
    public void CargarMenuEmpleado()
    {
        Items.Clear();
        Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(typeof(MainPage)),
            Route = "inicio"
        });
    }
}