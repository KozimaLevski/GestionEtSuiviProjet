using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using esimed.service.sgprojet;
using esimed.bean.sgprojet;

namespace GestionEtSuiviProjet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

            // Récupération de la liste des projets
            List<Projet> ListeDesProjets =  ServiceDA.GetProjets(true, true, true, true);
            ViewBag.ListeDesProjets = ListeDesProjets;

            return View();
        }

        public ActionResult NouveauProjet()
        {
            return View();
        }

        public ActionResult NouvelUtilisateur()
        {
            return View();
        }

        public ActionResult SuiviProjet()
        {
            return View();
        }

        public ActionResult Jalon()
        {
            return View();
        }
        public ActionResult Tache()
        {
            return View();
        }
        public ActionResult Exigence()
        {
            return View();
        }
        public ActionResult Jalons()
        {
            return View();
        }
        public ActionResult Taches()
        {
            return View();
        }
        public ActionResult Exigences()
        {
            return View();
        }
        public ActionResult NouvelleExigence()
        {
            return View();
        }
        public ActionResult NouvelleTache()
        {
            return View();
        }
        public ActionResult NouveauJalon()
        {
            return View();
        }

    }
}