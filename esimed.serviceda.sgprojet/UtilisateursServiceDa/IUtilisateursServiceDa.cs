using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.serviceda.sgprojet
{
    public interface IUtilisateursServiceDa
    {
        List<Utilisateur> GetUtilisateurs(bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        Utilisateur GetUtilisateur(int idUtilisateur, bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        bool CreerUtilisateur(string Nom, string Prenom, bool IsChefDeProjet);
    }
}
