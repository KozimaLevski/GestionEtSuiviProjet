using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Terminer_Tache_Jalon
    {
        public int IDTache { get; set; }
        public Tache Tache { get; set; }
        public int IDJalon { get; set; }
        public Jalon Jalon { get; set; }
    }
}
