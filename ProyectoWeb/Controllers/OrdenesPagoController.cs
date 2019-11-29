using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class OrdenesPagoController : Controller
    {
        // GET: OrdenesPago
        public ActionResult Index()
        {
            OrdenesPagoServicioClient psc = new OrdenesPagoServicioClient();
            ViewBag.listOrdenesPago = psc.findAll();
            return View();
        }
    }
}