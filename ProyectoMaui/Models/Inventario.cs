using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoMaui.Models;

public class Inventario
{
    public int Id { get; set; }
    public string Ingrediente { get; set; } = string.Empty;
    public int Stock { get; set; }
}