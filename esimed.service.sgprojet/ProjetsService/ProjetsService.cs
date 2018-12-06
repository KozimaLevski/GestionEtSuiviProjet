using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.serviceda.sgprojet;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public class ProjetsService : IProjetsService
    {

        IProjetsServiceDa ServiceDA = FServiceDaSgprojet.CreateProjetsServiceDa();

        public List<Projet> GetProjets(bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetProjets(getUtilisateur, getTaches, getExigences, getJalons);
        }
        public List<Projet> GetProjetsByResponsable(int IDResponsable, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetProjetsByResponsable(IDResponsable, getUtilisateur, getTaches, getExigences, getJalons);
        }
        public Projet GetProjet(int idProjet, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetProjet(idProjet, getUtilisateur, getTaches, getExigences, getJalons);
        }
        public bool CreerProjet(string Trigramme, string Nom, string Description, int IDResponsable)
        {

            try
            {
                ServiceDA.CreerProjet(Trigramme, Nom, Description, IDResponsable);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
