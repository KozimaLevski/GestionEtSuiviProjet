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
    public class JalonsServiceDa : IJalonsServiceDa
    {

        #region FromBeanToBean
        private Jalon FromDBToBean(Dst_Suivi_Projet.JalonsRow p_row, bool getProjet, bool getTaches, bool getExigences)
        {
            Jalon v_ressource = new Jalon();

            v_ressource.ID = p_row.ID;
            v_ressource.Libelle = p_row.Libelle;
            v_ressource.DateLivraisonPrevue = p_row.DateLivraisonPrevue;
            v_ressource.DateLivraisonReele = p_row.DateLivraisonReele;
            v_ressource.IDResponsable = p_row.IDResponsable;
            v_ressource.IDProjet = p_row.IDProjet;

            if (getProjet)
            {
                v_ressource.Projet = FServiceDaSgprojet.CreateProjetsServiceDa().GetProjet(v_ressource.IDProjet, true, true, true, true);
            }
            if (getTaches)
            {
                // v_ressource.List_Taches = FServiceDaSgjalon.CreateTachesServiceDa().GetTache(p_row.);
            }
            if (getExigences)
            {
                // v_ressource.List_Exigences = FServiceDaSgjalon.
            }

            return v_ressource;
        }
        #endregion


        public List<Jalon> GetJalons(bool getProjet, bool getTaches, bool getExigences)
        {
            List<Jalon> list_Jalons = new List<Jalon>();
            foreach (Dst_Suivi_Projet.JalonsRow dr in new  JalonsTableAdapter().GetJalons())
            {
                list_Jalons.Add(FromDBToBean(dr, getProjet, getTaches, getExigences));
            }
            return list_Jalons;
        }
        public Jalon GetJalon(int idJalon, bool getProjet, bool getTaches, bool getExigences)
        {
            Jalon jalon = new Jalon();
            foreach (Dst_Suivi_Projet.JalonsRow dr in new JalonsTableAdapter().GetJalon(idJalon))
            {
                jalon = FromDBToBean(dr, getProjet, getTaches, getExigences);
            }
            return jalon;
        }
        public bool CreerJalon(string Libelle, DateTime DateLivraisonPrevue, DateTime DateLivraisonReele, int IDResponsable, int IDProjet)
        {
            try
            {
                new JalonsTableAdapter().InsertJalon(Libelle, DateLivraisonPrevue, DateLivraisonReele, IDResponsable, IDProjet);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
