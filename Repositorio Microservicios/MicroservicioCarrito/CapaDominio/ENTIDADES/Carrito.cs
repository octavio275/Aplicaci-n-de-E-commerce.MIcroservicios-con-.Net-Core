using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDominio.ENTIDADES
{
    public class Carrito
    {
  
        private int iD;
        private int clienteID;

        public int ID { get => iD; set => iD = value; }
        public int ClienteID { get => clienteID; set => clienteID = value; }
    }
}
