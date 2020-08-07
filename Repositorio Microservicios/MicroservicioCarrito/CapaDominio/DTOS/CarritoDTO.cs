using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.DTOS
{
    public class CarritoDTO
    {
        private int iD;
        private int clienteID;

        public int ID { get => iD; set => iD = value; }
        public int ClienteID { get => clienteID; set => clienteID = value; }
    }
}
