using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra {
    class NoeudNumero : Noeud {
        //ATTRIBUTS
        public int numero;          //le numéro que porte le noeud


        //CONSTRUCTEURS
        public NoeudNumero(FormDijkstra f) : base(f) { }


        //METHODES
        /*
        * Permet de tester si le noeud courant est égal au noeud 
        */
        public override bool EstEgal(Noeud N) {
            NoeudNumero Nbis = (NoeudNumero) N;
            return numero == Nbis.numero;
        }



        /*
         * Cout d'un arc pour aller d'un noeud à un autre
         */
        public override double CoutArc(Noeud N) {
            NoeudNumero Nbis = (NoeudNumero) N;
            return FormD.Matrice[numero, Nbis.numero];
        }


        
        /*
         * Regarde si le noeud en cours est le noeud final
         */
        public override bool EtatFinal() {
            return (numero == FormD.NoeudArrivee);
        }



        /*
         * La liste des enfants du noeud en cours
         */
        public override List<Noeud> ListeSucc() {
            List<Noeud> lsucc = new List<Noeud>();

            for (int i = 0; i < FormD.NbNoeuds; i++) {
                if (FormD.Matrice[numero, i] != -1) {
                    NoeudNumero newnode2 = new NoeudNumero(FormD);
                    newnode2.numero = i;
                    lsucc.Add(newnode2);
                }
            }
            return lsucc;
        }



        /*
         * Cout heuristique pour aller du noeud courant au noeud final
         */
        public override double CalculeCoutHFin() {
            return (0);
        }



        /*
         * Permet d'afficher le numéro du noeud
         */
        public override string ToString() {
            return Convert.ToString(numero);
        }
    }
}