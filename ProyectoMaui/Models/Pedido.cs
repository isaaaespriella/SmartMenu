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
        public bool Completado { get; set; }
        public int ClienteId { get; set; }
        public int PlatilloId { get; set; }

        // relaciones
        // public Cliente Cliente { get; set; }
        // public Menu Platillo { get; set; }
    }
}