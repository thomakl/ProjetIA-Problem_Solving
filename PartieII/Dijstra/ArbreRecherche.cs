using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijstra {
    class ArbreRecherche {
        //ATTRIBUTS
        public List<Noeud> L_Ouverts;
        public List<Noeud> L_Fermes;


        //METHODES
        private Noeud ChercheNoeudDansFermes(Noeud N) {
            int i = 0;

            while (i < L_Fermes.Count) {
                if (L_Fermes[i].EstEgal(N))
                    return L_Fermes[i];
                i++;
            }
            return null;
        }


        private Noeud ChercheNoeudDansOuverts(Noeud N) {
            int i = 0;

            while (i < L_Ouverts.Count) {
                if (L_Ouverts[i].EstEgal(N))
                    return L_Ouverts[i];
                i++;
            }
            return null;
        }


        public List<Noeud> RechercheSolutionAEtoile(Noeud N0) {
            L_Ouverts = new List<Noeud>();
            L_Fermes = new List<Noeud>();
            // Le noeud passé en paramètre est supposé être le noeud initial
            Noeud N = N0;
            L_Ouverts.Add(N0);

            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (L_Ouverts.Count != 0 && N.EtatFinal() == false) {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                L_Ouverts.Remove(N);
                L_Fermes.Add(N);

                // Il faut trouver les noeuds successeurs de N
                this.MAJSuccesseurs(N);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (L_Ouverts.Count > 0) {
                    N = L_Ouverts[0];
                } else {
                    N = null;
                }
            }

            // A* terminé
            // On retourne le chemin qui va du noeud initial au noeud final sous forme de liste
            // Le chemin est retrouvé en partant du noeud final et en accédant aux parents de manière
            // itérative jusqu'à ce qu'on tombe sur le noeud initial
            List<Noeud> L_Noeuds = new List<Noeud>();
            if (N != null) {
                L_Noeuds.Add(N);

                while (N != N0) {
                    N = N.GetNoeudParent();
                    L_Noeuds.Insert(0, N);  // On insère en position 1
                }
            }
            return L_Noeuds;
        }


        private void MAJSuccesseurs(Noeud N) {
            // On fait appel à ListeSucc, méthode abstraite qu'on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des noeuds successeurs de N.
            List<Noeud> listsucc = N.ListeSucc();
            foreach (Noeud N2 in listsucc) {
                // N2 est-il une copie d'un nœud déjà vu et placé dans la liste des fermés ?
                Noeud N2bis = ChercheNoeudDansFermes(N2);
                if (N2bis == null) {
                    // Rien dans les fermés. Est-il dans les ouverts ?
                    N2bis = ChercheNoeudDansOuverts(N2);
                    if (N2bis != null) {
                        // Il existe, donc on l'a déjà vu, N2 n'est qu'une copie de N2Bis
                        // Le nouveau chemin passant par N est-il meilleur ?
                        if (N.CoutInit + N.CoutArc(N2) < N2bis.CoutInit) {
                            // Mise à jour de N2bis
                            N2bis.CoutInit = N.CoutInit + N.CoutArc(N2);
                            // CoutHFin pas recalculé car toujours bon
                            N2bis.RecalculeCoutTotal(); // somme de CoutInit et CoutHFin
                            // Mise à jour de la famille ....
                            N2bis.Supprime_Liens_Parent();
                            N2bis.SetNoeudParent(N);
                            // Mise à jour des ouverts
                            L_Ouverts.Remove(N2bis);
                            this.InsertNouvNoeudLOuverts(N2bis);
                        }
                        // else on ne fait rien, car le nouveau chemin est moins bon
                    } else {
                        // N2 est nouveau, MAJ et insertion dans les ouverts
                        N2.CoutInit = N.CoutInit + N.CoutArc(N2);
                        N2.SetNoeudParent(N);
                        N2.CalculCoutTotal(); // somme de CoutInit et CoutHFin
                        this.InsertNouvNoeudLOuverts(N2);
                    }
                }
                // else il est dans les fermés donc on ne fait rien,
                // car on a déjà trouvé le plus court chemin pour aller en N2
            }
        }


        public void InsertNouvNoeudLOuverts(Noeud NouvNoeud) {
            // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
            if (this.L_Ouverts.Count == 0) { L_Ouverts.Add(NouvNoeud); } else {
                Noeud N = L_Ouverts[0];
                bool trouve = false;
                int i = 0;
                do
                    if (NouvNoeud.CoutTotal < N.CoutTotal) {
                        L_Ouverts.Insert(i, NouvNoeud);
                        trouve = true;
                    } else {
                        i++;
                        if (L_Ouverts.Count == i) {
                            N = null;
                            L_Ouverts.Insert(i, NouvNoeud);
                        } else { N = L_Ouverts[i]; }
                    }
                while ((N != null) && (trouve == false));
            }
        }


        // Si on veut afficher l'arbre de recherche, il suffit de passer un treeview en paramètres
        // Celui-ci est mis à jour avec les noeuds de la liste des fermés, on ne tient pas compte des ouverts
        public void GetSearchTree(TreeView TV) {
            if (L_Fermes == null) return;
            if (L_Fermes.Count == 0) return;

            // On suppose le TreeView préexistant
            TV.Nodes.Clear();

            TreeNode TN = new TreeNode("?");
            TV.Nodes.Add(TN);

            AjouteBranche(L_Fermes[0], TN);
        }


        // AjouteBranche est exclusivement appelée par GetSearchTree; les noeuds sont ajoutés de manière récursive
        private void AjouteBranche(Noeud GN, TreeNode TN) {
            foreach (Noeud GNfils in GN.Enfants) {
                TreeNode TNfils = new TreeNode("?");
                TN.Nodes.Add(TNfils);
                if (GNfils.Enfants.Count > 0) AjouteBranche(GNfils, TNfils);
            }
        }


        //Permet de faire A* mais aussi de conserver tous les états des listes de noeuds ouverts et fermés
        public void RechercheSolutionAEtoileListe(Noeud N0, List<List<Noeud>> noeudsOuverts, List<List<Noeud>> noeudsFermes) {
            L_Ouverts = new List<Noeud>();
            L_Fermes = new List<Noeud>();
            // Le noeud passé en paramètre est supposé être le noeud initial
            Noeud N = N0;
            L_Ouverts.Add(N0);

            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (L_Ouverts.Count != 0 && N.EtatFinal() == false) {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                L_Ouverts.Remove(N);
                L_Fermes.Add(N);
                
                // Il faut trouver les noeuds successeurs de N
                this.MAJSuccesseurs(N);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre
                

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (L_Ouverts.Count > 0) {
                    N = L_Ouverts[0];
                } else {
                    N = null;
                }

                noeudsOuverts.Add(new List<Noeud>(L_Ouverts));
                noeudsFermes.Add(new List<Noeud>(L_Fermes));
            }
        }


        

    }
}

