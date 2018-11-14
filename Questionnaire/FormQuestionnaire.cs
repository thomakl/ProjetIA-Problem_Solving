using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Questionnaire
{
    public partial class FormQuestionnaire : Form
    {
        public Question QuestionActive { get; set; }
        public List<int> ListeQuestionsSorties { get; set; } // Litse qui contient les questions déjà sorties pour éviter les répétitions

        public FormQuestionnaire()
        {
            InitializeComponent();

            // numéro de la question
            Random r = new Random();
            //int numeroQuestion = r.Next(RecupererNbQuestion() + 1);
            int numeroQuestion = 1;
            List<int> ListeQuestionsSorties = new List<int>();
            ListeQuestionsSorties.Add(numeroQuestion); // Ajout à la liste pour que la question ne retombe pas            

            // Obtenir la question correspondant à numeroQuestion
            XmlNode question = RecupererFichier().GetElementsByTagName("question")[numeroQuestion];

            // Donne le titre de la question
            XmlNode titreQuestion = question.SelectSingleNode("titreQuestion");

            //Donne les propositions de la question
            XmlNodeList propositions = question.SelectNodes("proposition");

            //// Donne la réponse de la question
            XmlNode reponse = question.SelectSingleNode("reponse");

            // Création de la question et des réponses
            Reponse r1 = new Reponse(propositions[0].InnerText, 0);
            Reponse r2 = new Reponse(propositions[1].InnerText, 0);
            Reponse r3 = new Reponse(propositions[2].InnerText, 0);
            Reponse rv = new Reponse(reponse.InnerText, 1);
            QuestionActive = new Question(titreQuestion.InnerText, r1, r2, r3, rv);

            // Utiliser la méthode remplireForm pour la question correspondant à numQuestion
            remplirForm();

        }

        // Récupérer le fichier Xml
        public XmlDocument RecupererFichier()
        {
            XmlDocument questionnaire = new XmlDocument();
            questionnaire.Load("questionnaire.xml");

            return questionnaire;
        }

        // Recuperer le nombre de question
        public int RecupererNbQuestion()
        {
            int nbQuestion = RecupererFichier().GetElementsByTagName("question").Count;

            return nbQuestion;
        }
        // Méthode qui permet d'écrire la question et ses réponses
        public void remplirForm()
        { 
            lbl_question.Text = QuestionActive.Enonce_question;
            radioBtt_reponse1.Text = QuestionActive.Liste_reponses[0].Enonce_reponse;
            radioBtt_reponse2.Text = QuestionActive.Liste_reponses[1].Enonce_reponse;
            radioBtt_reponse3.Text = QuestionActive.Liste_reponses[2].Enonce_reponse;
            radioBtt_reponse4.Text = QuestionActive.Liste_reponses[3].Enonce_reponse;
        }

        private void lbl_question_Click(object sender, EventArgs e)
        {

        }

        private void radioBtt_reponse1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioBtt_reponse2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioBtt_reponse3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioBtt_reponse4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btt_validation_Click(object sender, EventArgs e)
        {
            // Correction => Voir si l'utilisateur à cocher la bonne réponse, et le corriger s'il a eu faux
            if (radioBtt_reponse1.Checked && QuestionActive.Liste_reponses[0].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
            }
            else if (radioBtt_reponse2.Checked && QuestionActive.Liste_reponses[1].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
            }
            else if (radioBtt_reponse3.Checked && QuestionActive.Liste_reponses[2].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
            }
            else if (radioBtt_reponse4.Checked && QuestionActive.Liste_reponses[3].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
            }
            else
            {
                int numReponseJuste = 0;
                for (int i = 0; i < QuestionActive.Liste_reponses.Count(); ++i)
                {
                    switch (QuestionActive.Liste_reponses[i].veracite)
                    {
                        case 0:
                            break;
                        case 1:
                            numReponseJuste = i;
                            break;
                    }
                }
                numReponseJuste = numReponseJuste + 1;

                MessageBox.Show("Vous avez échouez... La bonne réponse était la réponse : " + numReponseJuste);
            }

            // Chargement d'une nouvelle question

            Random r = new Random();
            int num = r.Next(1);

            // Chercher un num qui n'a jamais été choisi, pour s'assurer que l'utilisateur ne passe pas plusieurs fois la même question          
            while (ListeQuestionsSorties.Contains(num))
            {
                num = r.Next(RecupererNbQuestion() + 1);
            }

            ListeQuestionsSorties.Add(num);
        
            // attribuer à questionActive la question numéro num
            // ...
        }
    }
}
