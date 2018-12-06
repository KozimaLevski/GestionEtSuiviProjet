using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public interface IUtilisateursService
    {
        List<Utilisateur> GetUtilisateurs(bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        Utilisateur GetUtilisateur(int idUtilisateur, bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        bool CreerUtilisateur(string Nom, string Prenom, bool IsChefDeProjet);
    }
}
