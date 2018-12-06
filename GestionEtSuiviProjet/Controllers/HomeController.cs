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
                ViewBag.IDProjet = IDProjet;

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


                // Récupération des taches du projet
                List<Tache> ListeTaches = ProjetSelect.List_Taches;

                if (Request.Params["tachesorderby"] != null)
                {
                    int tachesorderby = Convert.ToInt32(Request.Params["tachesorderby"]);

                    switch (tachesorderby)
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
                ViewBag.ListeTaches = ListeTaches;
            }


            return View();
        }

        public ActionResult Jalon()
        {
            return View();
        }
        public ActionResult Tache()
        {

            if (Request.Params["idProjet"] != null)
            {
                int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(IDProjet, true, true, true, true);
                ViewBag.ProjetSelect = ProjetSelect;


                ITachesService SerticeTaches = FServiceSgprojet.CreateTachesService();
                int idTache = 0;
                if (Request.Params["idTache"] != null)
                {
                    idTache = Convert.ToInt32(Request.Params["idTache"]);
                }
                // Récupération de la tache sélectionné
                Tache Tache = SerticeTaches.GetTache(idTache, false, true, false, false);

                // Récupération de la tache requise pour la tache sélectionné
                if(Tache.IDTachePrecedenteRequise != 0)
                {
                    Tache TacheRequise = SerticeTaches.GetTache(Tache.IDTachePrecedenteRequise, false, true, false, false);
                    ViewBag.TacheRequise = TacheRequise;
                }


                // Récupération des exigences du projet
                List<Exigence> ListeExigences = ProjetSelect.List_Exigences;

                if (Request.Params["exigencesorderby"] != null)
                {
                    int exigencesorderby = Convert.ToInt32(Request.Params["exigencesorderby"]);

                    switch (exigencesorderby)
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

                ViewBag.ListeExigences = ListeExigences;
                ViewBag.Tache = Tache;
            }
            return View();
        }
        public ActionResult Exigence()
        {
            return View();
        }
        public ActionResult Jalons()
        {

            if (Request.Params["idProjet"] != null)
            {
                int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(IDProjet, true, true, true, true);
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
        public ActionResult Taches()
        {

            if (Request.Params["idProjet"] != null)
            {
                int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(IDProjet, true, true, true, true);
                ViewBag.ProjetSelect = ProjetSelect;

                // Récupération des taches du projet
                List<Tache> ListeTaches = ProjetSelect.List_Taches;

                if (Request.Params["tachesorderby"] != null)
                {
                    int tachesorderby = Convert.ToInt32(Request.Params["tachesorderby"]);

                    switch (tachesorderby)
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

                ViewBag.ListeTaches = ListeTaches;
            }
            return View();
        }
        public ActionResult Exigences()
        {

            if (Request.Params["idProjet"] != null)
            {
                int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(IDProjet, true, true, true, true);
                ViewBag.ProjetSelect = ProjetSelect;

                // Récupération des exigences du projet
                List<Exigence> ListeExigences = ProjetSelect.List_Exigences;

                if (Request.Params["exigencesorderby"] != null)
                {
                    int exigencesorderby = Convert.ToInt32(Request.Params["exigencesorderby"]);

                    switch (exigencesorderby)
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

                ViewBag.ListeExigences = ListeExigences;
            }
            return View();
        }
        public ActionResult NouvelleExigence()
        {

            if(Request.Form != null)
            {
                //Request.Form["companyname"];

                IExigencesService ServiceExigences = FServiceSgprojet.CreateExigencesService();
                //ServiceExigences.CreerExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet)


            }
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