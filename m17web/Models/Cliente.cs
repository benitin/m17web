using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m17web.Models
{
    public class Cliente
    {
        /* 
         create table Cliente(
	        id	   		int not null auto_increment,
	        nombre		varchar(100) not null,
	        login		varchar(25)  not null,
	        password	varchar(100) not null,
	        direccion	varchar(100) not null,
	        telefono	varchar(15)  not null,
	        estado		int 	not null,
	        primary key(id)
        );
         */

        public int id { get; set; }
        public string nombre { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int estado { get; set; }


        public bool Login(string login, string password)
        {

            //ApiRestModel.RestApiPost<Pedido, int>("pedido", pedido);
            Cliente cliente = new Cliente
            {
                login = login,
                password = password
            };
            cliente = ApiRestModel.RestApiPost<Cliente, Cliente>("login", cliente);
            this.id = cliente.id;
            this.login = cliente.login;
            this.password = cliente.password;
            this.nombre = cliente.nombre;
            this.telefono = cliente.telefono;
            this.direccion = cliente.direccion;
            this.estado = cliente.estado;
            return (cliente.id > 0);
        }
    }
}