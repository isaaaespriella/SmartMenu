using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoMaui.Models;

public class Menu
{
    public int Id { get; set; }
    public string Platillo { get; set; }
    public double Precio { get; set; }
    public int Disponibilidad { get; set; }
    [JsonIgnore]
    public string DisponibilidadTexto => Disponibilidad == 1 ? "Disponible" : "No disponible";
}
   