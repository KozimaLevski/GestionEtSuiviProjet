using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.serviceda.sgprojet
{
    public interface IProjetsServiceDa
    {
        List<Projet> GetProjets(bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons);
        List<Projet> GetProjetsByResponsable(int IDResponsable, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons);
        Projet GetProjet(int idProjet, bool getUtilisateur, bool getTaches, bool getExigences, bool getJalons);
        bool CreerProjet(string Trigramme, string Nom, string Description, int IDResponsable);
    }
}
