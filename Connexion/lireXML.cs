using System;
using System.Xml;

namespace Connexion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // numéro de la question
            int numeroQuestion = 1;
            // Lecture du fichier XML
            XmlDocument questionnaire = new XmlDocument();
            questionnaire.Load("questionnaire.xml");

            // Selectionne la question
            XmlNode question = questionnaire.GetElementsByTagName("question")[numeroQuestion];

            // Donne le titre de la question
            XmlNode titreQuestion = question.SelectSingleNode("titreQuestion");
            Console.WriteLine("# "+ titreQuestion.InnerText);

            //Donne les propositions de la question
            XmlNodeList propositions = question.SelectNodes("proposition");
            foreach (XmlNode propos in propositions)
            {
                Console.WriteLine("- "+propos.InnerText);

            }
            //// Donne la réponse de la question
            XmlNode reponse = question.SelectSingleNode("reponse");
            Console.WriteLine("\n• "+ reponse.InnerText); 


            Console.ReadLine();
        }


    }
}

