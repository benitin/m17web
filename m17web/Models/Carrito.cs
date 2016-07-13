using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    public class Carrito
    {
        public List<Item> items { get; set; }
        public List<PuntoEntrega> puntosEntrega { get; set; }
        public PuntoEntrega puntoEntrega { get; set; }
        public Cliente cliente { get; set; }
        public DateTime fechaLimite { get; set; }
    }

    public class Item
    {
        public Producto producto { get; set; }
        public bool seleccionado { get; set; }
        public int cantidad { get; set; }
    }
}