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
        /*
         * Getter du noeudParent
         */
        public Noeud GetNoeudParent() {
            return noeudParent;
        }
        

        /*
         * Setter du noeudParent
         * Permet aussi de modifier l'enfant de n
         */
        public void SetNoeudParent(Noeud n) {
            noeudParent = n;
            n.Enfants.Add(this);
        }
        

        /*
         * Supprime les liens d'un noeud avec ses enfants et supprime le noeud
         */
        public void Supprime_Liens_Parent() {
            if (noeudParent == null) return;
            noeudParent.Enfants.Remove(this);
            noeudParent = null;
        }


        /*
         * Calcule le coût pour aller d'un noeud à un autre
         */
        public void CalculCoutTotal() {
            CoutHFin = CalculeCoutHFin();
            CoutTotal = CoutInit + CoutHFin;
        }


        /*
         * Calcule le coût pour aller d'un noeud à un autre
         */
        public void RecalculeCoutTotal() {
            CoutTotal = CoutInit + CoutHFin;
        }
        

        /*
         * Permet de tester si le noeud courant est égal au noeud 
         */
        public abstract bool EstEgal(Noeud N);


        /*
         * Cout d'un arc pour aller d'un noeud à un autre
         */
        public abstract double CoutArc(Noeud N);


        /*
         * Regarde si le noeud en cours est le noeud final
         */
        public abstract bool EtatFinal();


        /*
         * La liste des enfants du noeud en cours
         */
        public abstract List<Noeud> ListeSucc();


        /*
         * Cout heuristique pour aller du noeud courant au noeud final
         */
        public abstract double CalculeCoutHFin();
    }
}

