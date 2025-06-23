using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoMaui.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    [JsonPropertyName("Usuario")]
    public string NombreUsuario { get; set; }
    public string Contrasena { get; set; }
    public string Tipo { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    
    public List<Usuario> Clientes { get; set; } = new();

    public ICommand CargarTodosCommand { get; }
}