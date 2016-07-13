using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    public class Pedido
    {

        /*
         * create table Pedido(
	            id 			int   			not null auto_increment,
	            idCliente	int 			not null,
	            idPuntoEntrega int 			not null,
	            fechaLimite	datetime 		not null,
	            latitud     decimal(14,10)  not null,
	            longitud    decimal(14,10)  not null,
	            idEstado	int 		    not null,
                 * cantidad    int             not null,
	        precio      decimal(14,10)  not null,
	            primary key(id)
            );
         */
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idPuntoEntrega { get; set; }
        public DateTime fechaLimite { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public int idEstado { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }

        public List<DetallePedido> detalle { get; set; }

        public Carrito IniciarCompra(Cliente cliente)
        {
            Carrito carrito = new Carrito();
            List<Producto> productos = ApiRestModel.RestApiGet<List<Producto>>("producto/");
            List<PuntoEntrega> pentrega = ApiRestModel.RestApiGet<List<PuntoEntrega>>("cliente/puntosentrega/" + cliente.id);

            List<Item> items = new List<Item>();
            foreach (Producto p in productos)
            {
                items.Add(new Item { 
                    producto = p,
                    cantidad = 0,
                    seleccionado = false
                });
            }
            carrito.puntosEntrega = pentrega;
            carrito.items = items;
            carrito.cliente = cliente;

            return carrito;
        }

        public int Guardar(CarritoApi carrito)
        {
            /*Pedido pedido = new Pedido
            {
                id = 0,
                idCliente = carrito.cliente.id,
                idPuntoEntrega = carrito.puntoEntrega.id,
                idEstado = 1,
                fechaLimite = carrito.fechaLimite,
                idProducto = 0,
                precio = 0
            };*/
            return ApiRestModel.RestApiPost<CarritoApi, int>("pedido", carrito);
        }

    }
}