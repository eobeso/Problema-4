using ProyectoWeb.Models;
using ProyectoWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class SucursalesController : Controller
    {
        // GET: Sucursales
        public ActionResult Index()
        {
            SucursalesServicioClient psc = new SucursalesServicioClient();
            ViewBag.listSucursales = psc.findAll();
            return View();
        }

        public ActionResult ListaBanco()
        {
            SucursalesServicioClient psc = new SucursalesServicioClient();
            ViewBag.listBancos = psc.findAllBanco();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(SucursalesViewModel svm)
        {
            var selectedValue = Request["Items"];
            svm.Sucursales.CodBanco = Convert.ToInt32(selectedValue);
            SucursalesServicioClient psc = new SucursalesServicioClient();
            psc.create(svm.Sucursales);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CodigoSucursal)
        {
            SucursalesServicioClient psc = new SucursalesServicioClient();
            psc.delete(CodigoSucursal);
            return RedirectToAction("Index");
        }
    }
}