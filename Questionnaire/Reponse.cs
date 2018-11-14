using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    public class Reponse
    {
        public string Enonce_reponse { get; set; }
        public int veracite { get; set; }

        public Reponse(string reponse, int ver)
        {
            Enonce_reponse = reponse;
            veracite = ver;
        }
    }
}
