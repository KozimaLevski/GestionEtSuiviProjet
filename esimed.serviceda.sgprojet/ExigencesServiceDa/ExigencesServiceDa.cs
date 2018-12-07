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
    public class ExigencesServiceDa : IExigencesServiceDa
    {

        #region FromBeanToBean
        private Exigence FromDBToBean(Dst_Suivi_Projet.ExigencesRow p_row, bool getProjet, bool getTaches, bool getExigences, bool getJalons)
        {
            Exigence v_ressource = new Exigence();

            v_ressource.ID = p_row.ID;
            v_ressource.Trigramme = p_row.Trigramme;
            v_ressource.Description = p_row.Description;
            v_ressource.IsTypeFonctionnelle = p_row.IsTypeFonctionnelle;
            if(v_ressource.IsTypeFonctionnelle == true)
            {
                v_ressource.IDTypeNonFonctionnelle = p_row.IDTypeNonFonctionnelle;
            }
            v_ressource.IDProjet = p_row.IDProjet;

            if (getProjet)
            {
                v_ressource.Projet = FServiceDaSgprojet.CreateProjetsServiceDa().GetProjet(v_ressource.IDProjet, false, false, false, false);
            }
            if (getTaches)
            {
                v_ressource.List_Taches = FServiceDaSgprojet.CreateTachesServiceDa().GetTachesByExigence(v_ressource.ID, false, false, false, false);
            }
            if (getExigences)
            {
                // v_ressource.List_Exigences = FServiceDaSgexigence.
            }
            if (getJalons)
            {
                // v_ressource.List_Jalons = FServiceDaSgexigence.
            }

            return v_ressource;
        }
        #endregion


        public List<Exigence> GetExigences(bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Exigence> list_Exigences = new List<Exigence>();
            foreach (Dst_Suivi_Projet.ExigencesRow dr in new ExigencesTableAdapter().GetExigences())
            {
                list_Exigences.Add(FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons));
            }
            return list_Exigences;
        }
        public List<Exigence> GetExigencesByProjet(int idProjet, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Exigence> list_Exigences = new List<Exigence>();
            foreach (Dst_Suivi_Projet.ExigencesRow dr in new ExigencesTableAdapter().GetExigencesByProjet(idProjet))
            {
                list_Exigences.Add(FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons));
            }
            return list_Exigences;
        }
        public List<Exigence> GetExigencesByTache(int idTache, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            List<Exigence> list_Exigences = new List<Exigence>();
            foreach (Dst_Suivi_Projet.ExigencesRow dr in new ExigencesTableAdapter().GetExigencesByTache(idTache))
            {
                list_Exigences.Add(FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons));
            }
            return list_Exigences;
        }
        
        public Exigence GetExigence(int idExigence, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            Exigence exigence = new Exigence();
            foreach (Dst_Suivi_Projet.ExigencesRow dr in new ExigencesTableAdapter().GetExigence(idExigence))
            {
                exigence = FromDBToBean(dr, getProjets, getTaches, getExigences, getJalons);
            }
            return exigence;
        }
        public bool CreerExigence(string Trigramme, string Description, bool IsTypeFonctionnelle, int IDTypeNonFonctionnelle, int IDProjet)
        {
            try
            {
                new ExigencesTableAdapter().InsertExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
