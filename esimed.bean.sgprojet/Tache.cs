using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Tache
    {
        public int ID { get; set; }
        public string Trigramme { get; set; }
        public string Libelle { get; set; }
        public DateTime DateDebutTheoriqueExe { get; set; }
        public DateTime DateDemarrageReele { get; set; }
        public int ChargeNbJours { get; set; }
        public int IDStatutTache { get; set; }
        public int IDResponsable { get; set; }
        public int IDTachePrecedenteRequise { get; set; }
        public int IDProjet { get; set; }
        public Projet Projet { get; set; }
        public StatutTache StatutTache { get; set; }
        public Utilisateur Responsable { get; set; }
        public Tache TachePrecedenteRequise { get; set; }
        public List<Exigence> List_Exigences { get; set; }
    }
}
