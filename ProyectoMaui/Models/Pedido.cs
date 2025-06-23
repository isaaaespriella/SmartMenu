using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMaui.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Completado { get; set; }
        
        public int UsuarioId { get; set; }
        public int PlatilloId { get; set; }
        
        public string CompletadoTexto => Completado == 1 ? "Sí" : "No";

        // relaciones
        // public Cliente Cliente { get; set; }
        // public Menu Platillo { get; set; }
    }
}