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
    public class UtilisateursServiceDa : IUtilisateursServiceDa
    {

        #region FromBeanToBean
        private Utilisateur FromDBToBean(Dst_Suivi_Projet.UtilisateursRow p_row, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            Utilisateur v_ressource = new Utilisateur();

            v_ressource.ID = p_row.ID;
            v_ressource.Nom = p_row.Nom;
            v_ressource.Prenom = p_row.Prenom;
            v_ressource.IsChefDeProjet  = p_row.IsChefDeProjet;

            if (getProjets)
            {
                v_ressource.List_Projets = FServiceDaSgprojet.CreateProjetsServiceDa().GetProjetsByResponsable(v_ressource.ID, true, true, true, true);
            }
            if (getTaches)
            {
                // v_ressource.List_Taches = FServiceDaSgutilisateur.CreateTachesServiceDa().GetTache(p_row.);
            }
            if (getExigences)
            {
                // v_ressource.List_Exigences = FServiceDaSgutilisateur.
            }
            if (getJalons)
            {
                // v_ressource.List_Jalons = FServiceDaSgutilisateur.
            }

            return v_ressource;
        }
        #endregion


        public List<Utilisateur> GetUtilisateurs(bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Utilisateur> list_Utilisateurs = new List<Utilisateur>();
            foreach (Dst_Suivi_Projet.UtilisateursRow dr in new  UtilisateursTableAdapter().GetUtilisateurs())
            {
                list_Utilisateurs.Add(FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons));
            }
            return list_Utilisateurs;
        }
        public Utilisateur GetUtilisateur(int idUtilisateur, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            Utilisateur utilisateur = new Utilisateur();
            foreach (Dst_Suivi_Projet.UtilisateursRow dr in new UtilisateursTableAdapter().GetUtilisateur(idUtilisateur))
            {
                utilisateur = FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons);
            }
            return utilisateur;
        }
        public bool CreerUtilisateur(string Nom, string Prenom, bool IsChefDeProjet)
        {
            try
            {
                new UtilisateursTableAdapter().InsertUtilisateur(Nom, Prenom, IsChefDeProjet);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
