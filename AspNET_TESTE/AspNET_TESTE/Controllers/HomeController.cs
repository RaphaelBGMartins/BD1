using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNET_TESTE.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Home() {
            ViewBag.Title = "Home";
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Cad_Cliente() {
            ViewBag.Title = "Cadastro de Cliente";
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Info_Filme() {
            ViewBag.Title = "Filme";
            //ViewBag.Message = "Your application description page."
            return View();
        }

        public ActionResult Info_Cliente() {
            ViewBag.Title = "Cliente";
            //ViewBag.Message = "Your application description page."
            return View();
        }

        public ActionResult Administrador() {
            ViewBag.Title = "Administrador";
            //ViewBag.Message = "Your application description page."
            return View();
        }

    }
}