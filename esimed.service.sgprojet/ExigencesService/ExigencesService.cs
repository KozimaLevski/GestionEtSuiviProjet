using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.serviceda.sgprojet;
using esimed.bean.sgprojet;

namespace esimed.service.sgprojet
{
    public class ExigencesService : IExigencesService
    {

        IExigencesServiceDa ServiceDA = FServiceDaSgprojet.CreateExigencesServiceDa();

        public List<Exigence> GetExigences(bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetExigences(getProjets, getTaches, getExigences, getJalons);
        }
        public List<Exigence> GetExigencesByProjet(int idProjet, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetExigencesByProjet(idProjet, getProjets, getTaches, getExigences, getJalons);
        }
        public Exigence GetExigence(int idExigence, bool getProjets, bool getTaches, bool getExigences, bool getJalons)
        {
            return ServiceDA.GetExigence(idExigence, getProjets, getTaches, getExigences, getJalons);
        }
        public bool CreerExigence(string Trigramme, string Description, bool IsTypeFonctionnelle, int IDTypeNonFonctionnelle, int IDProjet)
        {

            try
            {
                ServiceDA.CreerExigence(Trigramme, Description, IsTypeFonctionnelle, IDTypeNonFonctionnelle, IDProjet);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
