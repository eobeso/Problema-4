using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using ProyectoWeb.ViewModels;

namespace ProyectoWeb.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            BancoServicioClient psc = new BancoServicioClient();
            ViewBag.listBancos = psc.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(BancoViewModel bcm)
        {
            BancoServicioClient psc = new BancoServicioClient();
            psc.create(bcm.Bancos);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CodigoBanco)
        {
            BancoServicioClient psc = new BancoServicioClient();
            psc.delete(CodigoBanco);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int CodigoBanco)
        {
            BancoServicioClient psc = new BancoServicioClient();
            BancoViewModel bvm = new BancoViewModel();
            bvm.Bancos = psc.find(CodigoBanco);
            return View("Edit", bvm);
        }

        [HttpPost]
        public ActionResult Edit(BancoViewModel bcm)
        {
            BancoServicioClient psc = new BancoServicioClient();
            psc.edit(bcm.Bancos);
            return RedirectToAction("Index");
        }
    }
}