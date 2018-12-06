using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Utilisateur
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool IsChefDeProjet { get; set; }
        public List<Projet> List_Projets { get; set; }
        public List<Tache> List_Taches { get; set; }
        public List<Exigence> List_Exigences { get; set; }
        public List<Jalon> List_Jalons { get; set; }
    }
}
