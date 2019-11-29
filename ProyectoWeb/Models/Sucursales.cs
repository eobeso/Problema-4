using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Sucursales
    {
        [Display(Name = "CodigoSucursales")]
        public int CodigoSucursales { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Display(Name = "FechaRegistro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Banco")]
        public string Banco { get; set; }
        [Display(Name = "CodBanco")]
        public int CodBanco { get; set; }
    }
}