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

        public ActionResult ConfUser() {
            ViewBag.Title = "Conferindo Usuário";
            return View();
        }

        public ActionResult Att_Aluga() {
            ViewBag.Title = "Atualização Alugel";
            return View();
        }

        public ActionResult Att_Cadastro() {
            ViewBag.Title = "Cadastro de Cliente";
            return View();
        }

        public ActionResult Desaluga_infoCliente() {
            ViewBag.Title = "Desalugando";
            return View();
        }

        public ActionResult Att_infoCliente() {
            ViewBag.Title = "Atualizando info. Cliente";
            return View();
        }

        public ActionResult Login_Admin() {
            ViewBag.Title = "Área do ADM";
            return View();
        }

        public ActionResult Deletando_Filme() {
            ViewBag.Title = "Deletando Filme";
            return View();
        }

        public ActionResult Cad_Filme() {
            ViewBag.Title = "Cadastrando Filme";
            return View();
        }

    }
}