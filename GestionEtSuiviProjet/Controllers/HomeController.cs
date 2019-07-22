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
            string error = "";
            string nom = "";
            string trigramme = "";
            string description = "";
            int idresponsable = 0;

            try
            {
                if (Request.Form["trigramme"].Length > 0)
                {
                    nom = Request.Form["nomprojet"];
                    description = Request.Form["description"];
                    idresponsable = Convert.ToInt32(Request.Form["idresponsable"]);
                    if (Request.Form["trigramme"].Length != 3)
                    {
                        error = "Le trigramme doit être composé de trois lettres.";
                    }
                    else
                    {
                        trigramme = Request.Form["trigramme"];
                    }

                    IProjetsService ServiceProjets = FServiceSgprojet.CreateProjetsService();
                    if (error == "")
                    {
                        ServiceProjets.CreerProjet(trigramme, nom, description, idresponsable);
                    }
                    //ServiceExigences.CreerExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet)

                }
            }
            catch(Exception)
            {

            }

            
            ViewBag.Utilisateurs = FServiceSgprojet.CreateUtilisateursService().GetUtilisateurs(false,false,false,false);


            ViewBag.Error = error;
            return View();
        }

        public ActionResult NouvelUtilisateur()
        {

            string error = "";
            string nom = "";
            string prenom = "";
            string trigramme = "";
            bool estchefdeprojet = false;

            try
            {
                if (Request.Form["trigramme"].Length > 0)
                {
                    nom = Request.Form["nomutilisateur"];
                    prenom = Request.Form["prenomutilisateur"];
                    if (Request.Form["estchefdeprojet"] != null)
                    {
                        estchefdeprojet = true;
                    }
                    if (Request.Form["trigramme"].Length != 3)
                    {
                        error = "Le trigramme doit être composé de trois lettres.";
                    }
                    else
                    {
                        trigramme = Request.Form["trigramme"];
                    }

                    IUtilisateursService ServiceUtilisateurs = FServiceSgprojet.CreateUtilisateursService();
                    if (error == "")
                    {
                        ServiceUtilisateurs.CreerUtilisateur(nom, prenom, estchefdeprojet);
                    }
                    //ServiceExigences.CreerExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet)

                }
            }
            catch (Exception)
            {

            }
            
            ViewBag.Error = error;
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


            if (Request.Params["idProjet"] != null)
            {
                int idProjet = Convert.ToInt32(Request.Params["idProjet"]);
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(idProjet, true, true, true, true);
                ViewBag.ProjetSelect = ProjetSelect;
                ViewBag.idProjet = idProjet;

                int idExigence = Convert.ToInt32(Request.Params["idExigence"]);                

                // Récupération des exigences du projet
                IExigencesService ServiceExigences = FServiceSgprojet.CreateExigencesService();
                Exigence Exigence = ServiceExigences.GetExigence(idExigence, false, true, false, false);
                ViewBag.Exigence = Exigence;

                // Récupération des taches associés                
                ITachesService ServiceTaches = FServiceSgprojet.CreateTachesService();
                List<Tache> ListeTachesAssocies = ServiceTaches.GetTachesByExigence(idExigence, false, true, false, false);
                ViewBag.ListeTachesAssocies = ListeTachesAssocies;

            }
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
                ViewBag.IDProjet = IDProjet;
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
                ViewBag.IDProjet = IDProjet;
                IProjetsService ServiceDA = FServiceSgprojet.CreateProjetsService();

                // Récupération du projet sélectionné
                Projet ProjetSelect = ServiceDA.GetProjet(IDProjet, true, true, true, true);
                ViewBag.ProjetSelect = ProjetSelect;

                // Récupération des exigences du projet
                IExigencesService ServiceExigences = FServiceSgprojet.CreateExigencesService();                
                List<Exigence> ListeExigences = ServiceExigences.GetExigencesByProjet(IDProjet, false, true, false, false);

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
            string error = "";
            string trigramme = "";
            string description = "";
            bool isFonctionnelle = false;
            int idTypeFonctionnel = 0;

            if (Request.Params["idProjet"] != null)
            {
                int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
                ViewBag.IDProjet = IDProjet;

                try
                {
                    if (Request.Form["trigramme"].Length > 0)
                    {
                        //Request.Form["companyname"];

                        idTypeFonctionnel = Convert.ToInt32(Request.Form["typesnonfonctionnel"]);
                        description = Request.Form["description"];
                        if(Request.Form["boolfonctionnelle"] == null)
                        {
                            isFonctionnelle = false;
                        }
                        if (Request.Form["trigramme"].Length != 3)
                        {
                            error = "Le trigramme doit être composé de trois lettres.";
                        }
                        else
                        {
                            trigramme = Request.Form["trigramme"];
                        }

                        IExigencesService ServiceExigences = FServiceSgprojet.CreateExigencesService();
                        if (error == "")
                        {
                            if(!ServiceExigences.CreerExigence(trigramme, description, isFonctionnelle, idTypeFonctionnel, IDProjet))
                            {
                                // Erreur lors de l'insertion de l'exigence.
                                // On affiche le message dans la page du formulaire
                                // TODO : Remplir lles champs avec les valeurs précédement reçues.
                                return Redirect("~/Home/NouvelleExigence?idProjet=" + IDProjet + "&err=Erreur lors de l'insertion de l'exigence.");
                            }
                        }
                        //ServiceExigences.CreerExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet)


                    }
                }
                catch (Exception)
                {
                    
                }

            }

            ViewBag.Error = error;
            return View();
        }

        public ActionResult NouvelleTache()
        {


            string error = "";

            #region comms
            //////string Libelle = "";
            //////DateTime datelivraisonprevue = new DateTime();
            //////DateTime datelivraisonreele = new DateTime();
            //////int idprojet = 0;
            //////int idresponsable = 0;

            //////if (Request.Params["idProjet"] != null)
            //////{
            //////    int IDProjet = Convert.ToInt32(Request.Params["idProjet"]);
            //////    ViewBag.IDProjet = IDProjet;

            //////    try
            //////    {
            //////        if (Request.Form["trigramme"].Length > 0)
            //////        {
            //////            //Request.Form["companyname"];

            //////            idTypeFonctionnel = Convert.ToInt32(Request.Form["typesnonfonctionnel"]);
            //////            description = Request.Form["description"];
            //////            if (Request.Form["boolfonctionnelle"] == null)
            //////            {
            //////                isFonctionnelle = false;
            //////            }
            //////            if (Request.Form["trigramme"].Length != 3)
            //////            {
            //////                error = "Le trigramme doit être composé de trois lettres.";
            //////            }
            //////            else
            //////            {
            //////                trigramme = Request.Form["trigramme"];
            //////            }

            //////            ITachesService ServiceExigences = FServiceSgprojet.CreateTachesService();
            //////            if (error == "")
            //////            {
            //////                ServiceExigences.CreerExigence(trigramme, description, isFonctionnelle, idTypeFonctionnel, IDProjet);
            //////            }
            //////            //ServiceExigences.CreerExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet)


            //////        }
            //////    }
            //////    catch (Exception)
            //////    {

            //////    }

            //////}

            #endregion comms

            ViewBag.Utilisateurs = FServiceSgprojet.CreateUtilisateursService().GetUtilisateurs(false,false,false,false);

            ViewBag.Error = error;
            return View();
        }
        public ActionResult NouveauJalon()
        {
            return View();
        }

    }
}