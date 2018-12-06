using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public interface ITachesService
    {
        List<Tache> GetTaches(bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons);
        Tache GetTache(int idTache, bool getProjet, bool getUtilisateur, bool getExigences, bool getJalons);
        bool CreerTache(string Trigramme, string Libelle, int IDResponsable, DateTime DateDemarrageReele, DateTime DateDebutTheoriqueExe, int ChargeNbJours, int IDTachePrecedenteRequise, int IDStatutTache);
    }
}
