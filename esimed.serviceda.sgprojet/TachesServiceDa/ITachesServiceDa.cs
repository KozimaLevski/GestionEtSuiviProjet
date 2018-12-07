using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.serviceda.sgprojet
{
    public interface ITachesServiceDa
    {
        List<Tache> GetTaches(bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons);
        //List<Tache> GetTachesByResponsable(int IDResponsable, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons);
        Tache GetTache(int idTache, bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons);
        List<Tache> GetTachesByExigence(int idExigence, bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        bool CreerTache(string Trigramme, string Libelle, int IDResponsable, DateTime DateDemarrageReele, DateTime DateDebutTheoriqueExe, int ChargeNbJours, int IDTachePrecedenteRequise, int IDStatutTache);
    }
}
