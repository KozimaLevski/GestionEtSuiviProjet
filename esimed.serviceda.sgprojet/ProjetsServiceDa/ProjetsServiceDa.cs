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
    public class ProjetsServiceDa : IProjetsServiceDa
    {

        #region FromBeanToBean
        private Projet FromDBToBean(Dst_Suivi_Projet.ProjetsRow p_row, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            Projet v_ressource = new Projet();

            v_ressource.ID = p_row.ID;
            v_ressource.Trigramme = p_row.Trigramme;
            v_ressource.Nom = p_row.Nom;
            v_ressource.Description = p_row.Description;
            v_ressource.IDResponsable  = p_row.IDResponsable;

            if (getUtilisateur)
            {
                v_ressource.Responsable = FServiceDaSgprojet.CreateUtilisateursServiceDa().GetUtilisateur(v_ressource.IDResponsable,false,false,false,false);
            }
            if (getTaches)
            {
                // v_ressource.List_Taches = FServiceDaSgprojet.CreateTachesServiceDa().GetTache(p_row.);
            }
            if (getExigences)
            {
                // v_ressource.List_Exigences = FServiceDaSgprojet.
            }
            if (getJalons)
            {
                // v_ressource.List_Jalons = FServiceDaSgprojet.
            }

            return v_ressource;
        }
        #endregion


        public List<Projet> GetProjets(bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Projet> list_Projets = new List<Projet>();
            foreach (Dst_Suivi_Projet.ProjetsRow dr in new  ProjetsTableAdapter().GetProjets())
            {
                list_Projets.Add(FromDBToBean(dr, getUtilisateur, getTaches, getExigences, getJalons));
            }
            return list_Projets;
        }
        public List<Projet> GetProjetsByResponsable(int IDResponsable, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Projet> list_Projets = new List<Projet>();
            foreach (Dst_Suivi_Projet.ProjetsRow dr in new ProjetsTableAdapter().GetProjetsByResponsable(IDResponsable))
            {
                list_Projets.Add(FromDBToBean(dr, getUtilisateur, getTaches, getExigences, getJalons));
            }
            return list_Projets;
        }
        public Projet GetProjet(int idProjet, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            Projet projet = new Projet();
            foreach (Dst_Suivi_Projet.ProjetsRow dr in new ProjetsTableAdapter().GetProjet(idProjet))
            {
                projet = FromDBToBean(dr, getUtilisateur, getTaches, getExigences, getJalons);
            }
            return projet;
        }
        public bool CreerProjet(string Trigramme, string Nom, string Description, int IDResponsable)
        {
            try
            {
                new ProjetsTableAdapter().InsertProjet(Trigramme, Nom, Description, IDResponsable);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
