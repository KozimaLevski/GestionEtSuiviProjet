using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Realiser_Exigence_Tache
    {
        public int IDExigence { get; set; }
        public Exigence Exigence { get; set; }
        public int IDTache { get; set; }
        public Tache Tache { get; set; }
    }
}
