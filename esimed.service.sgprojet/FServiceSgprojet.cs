using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.service.sgprojet;

namespace esimed.service.sgprojet
{
    public class FServiceSgprojet
    {
        public static IProjetsService CreateProjetsService()
        {
            return new ProjetsService();
        }
        public static ITachesService CreateTachesService()
        {
            return new TachesService();
        }
        public static IUtilisateursService CreateUtilisateursService()
        {
            return new UtilisateursService();
        }
        public static IExigencesService CreateExigencesService()
        {
            return new ExigencesService();
        }
        public static IJalonsService CreateJalonsService()
        {
            return new JalonsService();
        }
    }
}
