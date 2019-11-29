using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class OrdenesPago
    {
        [Display(Name = "CodigoPago")]
        public int CodigoPago {get;set;}
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }
        [Display(Name = "Moneda")]
        public int Moneda { get; set; }
        [Display(Name = "Estado")]
        public int Estado { get; set; }
        [Display(Name = "Moneda_des")]
        public string Moneda_des { get; set; }
        [Display(Name = "Estado_des")]
        public string Estado_des { get; set; }
        [Display(Name = "FechaPago")]
        public DateTime FechaPago { get; set; }
        [Display(Name = "CodigoSucursales")]
        public int CodigoSucursales { get; set; }

        [Display(Name = "Sucursales")]
        public string Sucursales { get; set; }
        [Display(Name = "Id_Cliente")]
        public string Id_Cliente { get; set; }
    }
}