using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.serviceda.sgprojet;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public class TachesService : ITachesService
    {

        ITachesServiceDa ServiceDA = FServiceDaSgprojet.CreateTachesServiceDa();

        public List<Tache> GetTaches(bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetTaches(getProjet, getUtilisateur, getExigences, getJalons);
        }
        public List<Tache> GetTachesByExigence(int idExigence, bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetTachesByExigence(idExigence, getProjet, getUtilisateur, getExigences, getJalons);
        }
        public Tache GetTache(int idTache, bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetTache(idTache, getProjet, getUtilisateur, getExigences, getJalons);
        }
        public bool CreerTache(string Trigramme, string Libelle, int IDResponsable, DateTime DateDemarrageReele, DateTime DateDebutTheoriqueExe, int ChargeNbJours, int IDTachePrecedenteRequise, int IDStatutTache)
        {

            try
            {
                ServiceDA.CreerTache(Trigramme, Libelle, IDResponsable, DateDemarrageReele, DateDebutTheoriqueExe, ChargeNbJours, IDTachePrecedenteRequise, IDStatutTache);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
