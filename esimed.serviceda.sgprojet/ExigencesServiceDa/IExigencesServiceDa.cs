using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.bean.sgprojet;

namespace esimed.serviceda.sgprojet
{
    public interface IExigencesServiceDa
    {
        List<Exigence> GetExigences(bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        Exigence GetExigence(int idExigence, bool getProjets, bool getTaches, bool getExigences, bool getJalons);
        bool CreerExigence(string Trigramme, string Description, bool IsTypeFonctionnelle, int IDTypeNonFonctionnelle, int IDProjet);
    }
}
