using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.serviceda.sgprojet
{
    public interface IJalonsServiceDa
    {
        List<Jalon> GetJalons(bool getProjet, bool getTaches, bool getExigences);
        Jalon GetJalon(int idJalon, bool getProjet, bool getTaches, bool getExigences);
        bool CreerJalon(string Libelle, DateTime DateLivraisonPrevue, DateTime DateLivraisonReele, int IDResponsable, int IDProjet);
    }
}
