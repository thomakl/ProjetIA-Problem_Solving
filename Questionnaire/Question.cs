using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    public class Question
    {
        public string Enonce_question { get; set; }             // Contient l'énoncé de la question
        public List<Reponse> Liste_reponses { get; set; }       // Contient la liste des réponses possibles
        public int NbPoint { get; set; }                        // Contient le nombre de point attribué à la question
        public string CheminImage { get; set; }                 // Contient le chemin vers l'image correspondant à la question

        public Question(string q, Reponse r1, Reponse r2, Reponse r3, Reponse rv, int NbPoint, string CheminImage)
        {
            Enonce_question = q;
            Liste_reponses = new List<Reponse>();
            Liste_reponses.Add(r1);
            Liste_reponses.Add(r2);
            Liste_reponses.Add(r3);
            Liste_reponses.Add(rv);
            this.NbPoint = NbPoint;
            this.CheminImage = CheminImage;
        }
    }
}
