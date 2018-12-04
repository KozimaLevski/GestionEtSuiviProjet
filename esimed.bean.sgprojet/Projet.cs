﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esimed.bean.sgprojet
{
    public class Projet
    {
        public int ID { get; set; }
        public string Trigramme { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int IDResponsable { get; set; }
        public Utilisateur Responsable { get; set; }
        public List<Tache> List_Taches { get; set; }
        public List<Exigence> List_Exigences { get; set; }
        public List<Jalon> List_Jalons { get; set; }

    }
}
