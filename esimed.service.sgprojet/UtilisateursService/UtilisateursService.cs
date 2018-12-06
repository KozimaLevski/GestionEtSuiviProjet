using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.serviceda.sgprojet;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public class UtilisateursService : IUtilisateursService
    {

        IUtilisateursServiceDa ServiceDA = FServiceDaSgprojet.CreateUtilisateursServiceDa();

        public List<Utilisateur> GetUtilisateurs(bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetUtilisateurs(getProjets, getTaches, getExigences, getJalons);
        }
        public Utilisateur GetUtilisateur(int idUtilisateur, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetUtilisateur(idUtilisateur, getProjets, getTaches, getExigences, getJalons);
        }
        public bool CreerUtilisateur(string Nom, string Prenom, bool IsChefDeProjet)
        {

            try
            {
                ServiceDA.CreerUtilisateur(Nom, Prenom, IsChefDeProjet);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
