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
        public Question QuestionActive { get; set; } // Question qui est affichée sur le form
        public List<int> ListeQuestionsSorties { get; set; } // Liste qui contient les questions déjà sorties pour éviter les répétitions
        public int note { get; set; } // Note de l'utilisateur


        public FormQuestionnaire()
        {
            InitializeComponent();

            ListeQuestionsSorties = new List<int>();
            note = 0;

            RemplirQuestionActive();

            remplirForm();

        }

        public void RemplirQuestionActive()
        {
            // Création d'un bombre aléatoire qui permettra de choisir une question
            Random r = new Random();
            int numeroQuestion = r.Next(RecupererNbQuestion());

            // Chercher un numeroQuestion qui n'a jamais été choisi         
            while (ListeQuestionsSorties.Contains(numeroQuestion))
            {
                numeroQuestion = r.Next(RecupererNbQuestion() + 1);
            }
            ListeQuestionsSorties.Add(numeroQuestion);

            // Obtenir la question correspondant à numeroQuestion
            XmlNode question = RecupererFichier().GetElementsByTagName("question")[numeroQuestion];

            // Donne le titre de la question
            XmlNode titreQuestion = question.SelectSingleNode("titreQuestion");

            //Donne les propositions de la question
            XmlNodeList propositions = question.SelectNodes("proposition");

            //// Donne la réponse de la question
            XmlNode reponse = question.SelectSingleNode("reponse");

            // Création de la question et des réponses
            Reponse r1;
            Reponse r2;
            Reponse r3;
            Reponse r4;
            if (propositions[0].InnerText == reponse.InnerText)
            {
                r1 = new Reponse(propositions[0].InnerText, 1);
                r2 = new Reponse(propositions[1].InnerText, 0);
                r3 = new Reponse(propositions[2].InnerText, 0);
                r4 = new Reponse(propositions[3].InnerText, 0);
            }
            else if (propositions[1].InnerText == reponse.InnerText)
            {
                r1 = new Reponse(propositions[0].InnerText, 0);
                r2 = new Reponse(propositions[1].InnerText, 1);
                r3 = new Reponse(propositions[2].InnerText, 0);
                r4 = new Reponse(propositions[3].InnerText, 0);
            }
            else if (propositions[2].InnerText == reponse.InnerText)
            {
                r1 = new Reponse(propositions[0].InnerText, 0);
                r2 = new Reponse(propositions[1].InnerText, 0);
                r3 = new Reponse(propositions[2].InnerText, 1);
                r4 = new Reponse(propositions[3].InnerText, 0);
            }
            else
            {
                r1 = new Reponse(propositions[0].InnerText, 0);
                r2 = new Reponse(propositions[1].InnerText, 0);
                r3 = new Reponse(propositions[2].InnerText, 0);
                r4 = new Reponse(propositions[3].InnerText, 1);
            }

            QuestionActive = new Question(titreQuestion.InnerText, r1, r2, r3, r4);
        }

        // Permet de récupérer le fichier XML où sont contenues les questions et les réponses
        public XmlDocument RecupererFichier()
        {
            XmlDocument questionnaire = new XmlDocument();
            questionnaire.Load("questionnaire.xml");
            return questionnaire;
        }

        // Recuperer le nombre de questions contenues dans le fichier XML
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
                note = note + 1;
            }
            else if (radioBtt_reponse2.Checked && QuestionActive.Liste_reponses[1].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                note = note + 1;
            }
            else if (radioBtt_reponse3.Checked && QuestionActive.Liste_reponses[2].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                note = note + 1;
            }
            else if (radioBtt_reponse4.Checked && QuestionActive.Liste_reponses[3].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                note = note + 1;
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

                MessageBox.Show("Vous avez échouez... La bonne réponse était la réponse " + numReponseJuste + " :\n" + QuestionActive.Liste_reponses[numReponseJuste - 1].Enonce_reponse);
            }

            // Compter le nombre de question déjà réalisé par le joueur, si le joueur a fait 20 questions, quitter le form
            if (ListeQuestionsSorties.Count() == 20)
            {
                MessageBox.Show("Vous avez terminé le test ! Félicitations !\n Votre note est de : " + note + "/20");
                Application.Exit();
            }
            else
            {
                // Passer à la question suivante
                RemplirQuestionActive();
                remplirForm();
            }
        }
    }
}
