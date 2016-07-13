using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    public class DetallePedido
    {
        /*
         * create table DetallePedido(
        	id 			int   not null auto_increment,
	        idPedido	int   not null,
	        idProducto  int   not null,
	        cantidad	int   not null,
	        precioUnitario decimal(14,7) not null,
	        primary key(id)
        );
         */
        public int id { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
    }
}