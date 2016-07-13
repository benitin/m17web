using m17web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m17web.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string password)
        {
            Cliente cliente = new Cliente();
            if (cliente.Login(login, password))
            {
                Session["cliente"] = cliente;
                return Redirect("Pedido");
            }
            else
                return Redirect("Cliente"); //RedirectToAction("Index", "Pedido");
        }
    }
}
