using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Exigence
    {
        public int ID { get; set; }
        public string Trigramme { get; set; }
        public string Description { get; set; }
        public bool IsTypeFonctionnelle { get; set; }
        public int IDTypeNonFonctionnelle  { get; set; }
        public int IDProjet { get; set; }
        public Projet Projet { get; set; }
        public TypeNonFonctionnelle TypeNonFonctionnelle { get; set; }
        public List<Tache> List_Taches { get; set; }
        
    }
}

