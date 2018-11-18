using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra {
    class NoeudNumero : Noeud {
        //ATTRIBUTS
        public int numero;


        //CONSTRUCTEURS
        public NoeudNumero(FormDijkstra f) : base(f) { }


        //METHODES
        public override bool EstEgal(Noeud N) {
            NoeudNumero Nbis = (NoeudNumero) N;
            return numero == Nbis.numero;
        }


        public override double CoutArc(Noeud N) {
            NoeudNumero Nbis = (NoeudNumero) N;
            return FormD.Matrice[numero, Nbis.numero];
        }


        public override bool EtatFinal() {
            return (numero == FormD.NoeudArrivee);
        }


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


        public override double CalculeCoutHFin() {
            return (0);
        }


        public override string ToString() {
            return Convert.ToString(numero);
        }


    }
}
