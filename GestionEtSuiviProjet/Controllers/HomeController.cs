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
            if(Request.Params["idProjet"] != null)
            {
                int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(IDProjet,true, true, true, true);
                ViewBag.ProjetSelect = ProjetSelect;


                // Récupération des jalons du projet
                List<Jalon> ListeJalons = ProjetSelect.List_Jalons;

                if (Request.Params["jalonsorderby"] != null)
                {
                    int jalonsorderby = Convert.ToInt32(Request.Params["jalonsorderby"]);

                    switch (jalonsorderby)
                    {
                        case 1:
                            // Jalons terminés
                            Console.WriteLine("Case 1");
                            break;
                        case 2:
                            //Jalons en cours
                            Console.WriteLine("Case 2");
                            break; 
                        case 3:
                            // Jalons en attente
                            Console.WriteLine("Case 3");
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                }

                ViewBag.ListeJalons = ListeJalons;
            }


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