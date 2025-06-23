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
    public int Disponibilidad { get; set; }
    
    public string DisponibilidadTexto => Disponibilidad == 1 ? "Disponible" : "No disponible";
}