using m17web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m17web.Controllers
{
    public class PedidoController : Controller
    {

        private int IDCliente()
        {
            Cliente cliente = (Cliente)Session["cliente"];
            return cliente.id;
        }

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            
            Cliente cliente = (Cliente)Session["cliente"];
            ViewBag.nombre = cliente.nombre;
            
            Pedido pedido = new Pedido();
            Carrito carrito = pedido.IniciarCompra(cliente);

            Session["carrito"] = carrito;

            return View(carrito);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Carrito carrito = (Carrito)Session["carrito"];
            CarritoApi capi = new CarritoApi();

            Pedido pedido = new Pedido();
            Item item = null;
            List<Item> deta = new List<Item>();
            List<DetallePedido> detalle = new List<DetallePedido>();

            string[] cantidades = form["item.cantidad"].Split(',');

            for (int i = 0; i < cantidades.Length; i++)
            {
                int cantidad = Convert.ToInt32( cantidades[i]);
                if (cantidad > 0) {
                    item = carrito.items.ElementAt(i);
                    item.cantidad = cantidad;
                    pedido.cantidad += cantidad;
                    pedido.precio += item.producto.precio * cantidad;
                    detalle.Add(new DetallePedido { 
                        id = 0,
                        idPedido = 0,
                        idProducto = item.producto.id,
                        cantidad = cantidad,
                        precioUnitario = item.producto.precio
                    });
                }
            }
            pedido.detalle = detalle;

            int puntoEntrega = Convert.ToInt32(form["puntoEntrega"]);
            foreach (PuntoEntrega punto in carrito.puntosEntrega){
                if (punto.id == puntoEntrega)
                {
                    capi.puntoEntrega = punto;
                    pedido.latitud = punto.latitud;
                    pedido.longitud = punto.longitud;
                    pedido.idPuntoEntrega = punto.id;
                    break;
                }
            }
            pedido.idCliente = carrito.cliente.id;
            pedido.idProducto = 0;
            pedido.idEstado = 1;
            pedido.fechaLimite = Convert.ToDateTime(form["fechaLimite"]);
            
            capi.pedido = pedido;
            capi.cliente = carrito.cliente;
            pedido.Guardar(capi);

            return RedirectToAction("Index", "Pedido");
        }


    }
}
