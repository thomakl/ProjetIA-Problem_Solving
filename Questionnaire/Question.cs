using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    public class Question
    {
        public string Enonce_question { get; set; }
        public List<Reponse> Liste_reponses { get; set; }
        public int NbPoint { get; }

        public Question(string q, Reponse r1, Reponse r2, Reponse r3, Reponse rv, int NbPoint)
        {
            Enonce_question = q;
            Liste_reponses = new List<Reponse>();
            Liste_reponses.Add(r1);
            Liste_reponses.Add(r2);
            Liste_reponses.Add(r3);
            Liste_reponses.Add(rv);
        }
    }
}
