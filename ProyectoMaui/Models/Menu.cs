using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMaui.Models;

public class Menu
{
    public int Id { get; set; }
    public string Platillo { get; set; }
    public double Precio { get; set; }
    public bool Disponibilidad { get; set; }
}