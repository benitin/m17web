using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    
    public class Producto
    {
        /*
         * create table Producto(
	            id 			int 		  not null auto_increment,
	            idCategoria int 		  not null,
	            descripcion varchar(50)   not null,
	            precio 		decimal(14,7) not null,
	            stock		decimal(14,7) not null,
	            costo		decimal(14,7) not null,
	            primary key(id)
            );
         */
        public int id { get; set; }
        public int idCategoria { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public decimal stock { get; set; }
        public decimal costo { get; set; }

        /*override
        public string ToString()
        {
            return descripcion;
        }*/
    }
}