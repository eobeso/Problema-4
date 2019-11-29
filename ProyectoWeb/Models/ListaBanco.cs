using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class ListaBanco
    {
        [Display(Name = "CodigoBanco")]
        public int CodigoBanco { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}