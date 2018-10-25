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
        public int NumQuestion { get; set; }
        public List<Reponse> Liste_reponses { get; set; }
        public static int nbQuestion { get; private set; }

        public Question()
        {
            nbQuestion = nbQuestion + 1;
            NumQuestion = nbQuestion;
            // A COMPLTER !!!
        }
    }
}
