using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Jalon
    {
        public string ID { get; set; }
        public string Libelle { get; set; }
        public DateTime DateLivraisonPrevue { get; set; }
        public DateTime DateLivraisonReele { get; set; }
        public int IDResponsable { get; set; }
        public int IDProjet { get; set; }
        public Utilisateur Responsable { get; set; }
        public Projet Projet { get; set; }
        public List<Tache> List_Taches { get; set; }

    }
}
