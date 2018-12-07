using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;
using esimed.serviceda.sgprojet.Data;
using esimed.serviceda.sgprojet.Data.Dst_Suivi_ProjetTableAdapters;

namespace esimed.serviceda.sgprojet
{
    public class TachesServiceDa : ITachesServiceDa
    {

        #region FromBeanToBean
        private Tache FromDBToBean(Dst_Suivi_Projet.TachesRow p_row, bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons)
        {
            Tache v_ressource = new Tache();

            v_ressource.ID = p_row.ID;
            v_ressource.Trigramme = p_row.Trigramme;
            v_ressource.Libelle = p_row.Libelle;
            v_ressource.DateDemarrageReele = p_row.DateDemarrageReele;
            v_ressource.DateDebutTheoriqueExe = p_row.DateDebutTheoriqueExe;
            v_ressource.ChargeNbJours = p_row.ChargeNbJours;
            v_ressource.IDResponsable = p_row.IDResponsable;
            v_ressource.IDTachePrecedenteRequise = p_row.IDTachePrecedenteRequise;
            v_ressource.IDStatutTache = p_row.IDStatutTache;
            v_ressource.IDProjet = p_row.IDProjet;

            if (getProjet)
            {
                v_ressource.Projet = FServiceDaSgprojet.CreateProjetsServiceDa().GetProjet(v_ressource.IDProjet,false,false,false,false);
            }
            if (getUtilisateur)
            {
                v_ressource.Responsable = FServiceDaSgprojet.CreateUtilisateursServiceDa().GetUtilisateur(v_ressource.IDResponsable, false, false, false, false);
            }
            if (getExigences)
            {
                v_ressource.List_Exigences = FServiceDaSgprojet.CreateExigencesServiceDa().GetExigencesByTache(v_ressource.ID, false, false, false, false);
            }
            if (getJalons)
            {
                // v_ressource.List_Jalons = FServiceDaSgprojet.
            }

            return v_ressource;
        }
        #endregion


        public List<Tache> GetTaches(bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons)
        {
            List<Tache> list_Taches = new List<Tache>();
            foreach (Dst_Suivi_Projet.TachesRow dr in new TachesTableAdapter().GetTaches())
            {
                list_Taches.Add(FromDBToBean(dr, getProjet, getUtilisateur, getExigences, getJalons));
            }
            return list_Taches;
        }
        //public List<Tache> GetTachesByResponsable(int IDResponsable, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        //{
        //    List<Tache> list_Taches = new List<Tache>();
        //    foreach (Dst_Suivi_Projet.TachesRow dr in new TachesTableAdapter().GetTachesByResponsable(IDResponsable))
        //    {
        //        list_Taches.Add(FromDBToBean(dr, getUtilisateur, getTaches, getExigences, getJalons));
        //    }
        //    return list_Taches;
        //}

        public List<Tache> GetTachesByExigence(int idExigence, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Tache> list_Taches = new List<Tache>();
            foreach (Dst_Suivi_Projet.TachesRow dr in new TachesTableAdapter().GetTachesByExigence(idExigence))
            {
                list_Taches.Add(FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons));
            }
            return list_Taches;
        }
        public Tache GetTache(int idTache, bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons)
        {
            Tache projet = new Tache();
            foreach (Dst_Suivi_Projet.TachesRow dr in new TachesTableAdapter().GetTache(idTache))
            {
                projet = FromDBToBean(dr, getProjet, getUtilisateur, getExigences, getJalons);
            }
            return projet;
        }
        public bool CreerTache(string Trigramme, string Libelle, int IDResponsable, DateTime DateDemarrageReele, DateTime DateDebutTheoriqueExe, int ChargeNbJours, int IDTachePrecedenteRequise, int IDStatutTache)
        {
            try
            {
                new TachesTableAdapter().InsertTache(Trigramme, Libelle, IDResponsable, DateDemarrageReele, DateDebutTheoriqueExe, ChargeNbJours, IDTachePrecedenteRequise, IDStatutTache);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
