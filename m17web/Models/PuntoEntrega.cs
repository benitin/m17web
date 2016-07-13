using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    public class PuntoEntrega
    {
        /*
        * create table PuntoEntrega(
               id			int not null auto_increment,
               idCliente	int not null,
               nombre		varchar(50)    not null,
               direccion	varchar(100)   not null,
               latitud     decimal(14,10) not null,
               longitud    decimal(14,10) not null,
               primary key(id)
           );
        */
        public int id { get; set; }
        public int idCliente { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}