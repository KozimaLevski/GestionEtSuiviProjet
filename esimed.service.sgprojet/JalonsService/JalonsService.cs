using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.serviceda.sgprojet;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public class JalonsService : IJalonsService
    {

        IJalonsServiceDa ServiceDA = FServiceDaSgprojet.CreateJalonsServiceDa();

        public List<Jalon> GetJalons(bool getProjet, bool getTaches, bool getExigences)
        {
            return ServiceDA.GetJalons(getProjet, getTaches, getExigences);
        }
        public Jalon GetJalon(int idJalon, bool getProjet, bool getTaches, bool getExigences)
        {
            return ServiceDA.GetJalon(idJalon, getProjet, getTaches, getExigences);
        }
        public bool CreerJalon(string Libelle, DateTime DateLivraisonPrevue, DateTime DateLivraisonReele, int IDResponsable, int IDProjet)
        {

            try
            {
                ServiceDA.CreerJalon(Libelle, DateLivraisonPrevue, DateLivraisonReele, IDResponsable, IDProjet);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
