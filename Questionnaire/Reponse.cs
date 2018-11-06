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
        public Question questionLiee { get; set; }
        public int veracite { get; set; }
        public int NumReponse { get; set; }

        public Reponse()
        {

        }
    }
}
