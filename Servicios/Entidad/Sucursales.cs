using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios
{
    public class Sucursales
    {
        public int CodigoSucursales { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Banco { get; set; }
        public int CodBanco { get; set; }
    }
}