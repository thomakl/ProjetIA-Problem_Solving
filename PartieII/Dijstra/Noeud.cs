using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra {

    abstract public class Noeud {
        //ATTRIBUTS ET PROPRIETES
        public FormDijkstra FormD { get; set; }         //Form auquel est rattaché le noeud
        public double CoutInit { get; set; }            //coût du chemin du noeud initial jusqu'à ce noeud
        public double CoutHFin { get; set; }            //estimation heuristique du coût pour atteindre le noeud final
        public double CoutTotal { get; set; }           //coût total (g+h)
        public List<Noeud> Enfants { get; set; }        // noeuds enfants
        protected Noeud noeudParent;                    // noeud parent


        //CONSTRUCTEUR
        public Noeud(FormDijkstra f) {
            noeudParent = null;
            Enfants = new List<Noeud>();
            FormD = f;
        }
        
        
        
        //METHODES
        public Noeud GetNoeudParent() {
            return noeudParent;
        }

        public void SetNoeudParent(Noeud n) {
            noeudParent = n;
            n.Enfants.Add(this);
        }

        public void Supprime_Liens_Parent() {
            if (noeudParent == null) return;
            noeudParent.Enfants.Remove(this);
            noeudParent = null;
        }

        public void CalculCoutTotal() {
            CoutHFin = CalculeCoutHFin();
            CoutTotal = CoutInit + CoutHFin;
        }

        public void RecalculeCoutTotal() {
            CoutTotal = CoutInit + CoutHFin;
        }
        
        public abstract bool EstEgal(Noeud N);
        public abstract double CoutArc(Noeud N);
        public abstract bool EtatFinal();
        public abstract List<Noeud> ListeSucc();
        public abstract double CalculeCoutHFin();
    }
}

