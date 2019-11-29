using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios
{
    public class OrdenesPago
    {
        public int CodigoPago {get;set;}
        public decimal Monto { get; set; }
        public int Moneda { get; set; }
        public int Estado { get; set; }
        public string Moneda_des { get; set; }
        public string Estado_des { get; set; }
        public DateTime FechaPago { get; set; }
        public int CodigoSucursales { get; set; }
        public string Sucursales { get; set; }
        public string Id_Cliente { get; set; }
    }
}