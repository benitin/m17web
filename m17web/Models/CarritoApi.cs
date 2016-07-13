using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    public class CarritoApi
    {
        public Pedido pedido { get; set; }
        public PuntoEntrega puntoEntrega { get; set; }
        public Cliente cliente { get; set; }
        public int id { get; set; }
    }
}