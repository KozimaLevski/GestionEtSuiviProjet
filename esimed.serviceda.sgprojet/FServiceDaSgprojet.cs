using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using esimed.serviceda.sgprojet;

namespace esimed.serviceda.sgprojet
{
    public class FServiceDaSgprojet
    {
        public static IProjetsServiceDa CreateProjetsServiceDa()
        {
            return new ProjetsServiceDa();
        }
        public static ITachesServiceDa CreateTachesServiceDa()
        {
            return new TachesServiceDa();
        }
    }
}
