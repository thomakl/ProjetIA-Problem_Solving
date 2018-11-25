using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    public class Reponse
    {
        public string Enonce_reponse { get; set; }          // Contient l'énoncé de la réponse
        public int veracite { get; set; }                   // Contient la véracité de la réponse (1 pour vrai, 0 pour faux)

        public Reponse(string reponse, int ver)
        {
            Enonce_reponse = reponse;
            veracite = ver;
        }
    }
}
