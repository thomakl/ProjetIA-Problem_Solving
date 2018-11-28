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
using Dijstra;

namespace Questionnaire
{
    public partial class FormQuestionnaire : Form
    {
        public Question QuestionActive { get; set; }                // Question qui est affichée sur le form
        public List<int> ListeQuestionsSorties { get; set; }        // Liste qui contient les questions déjà sorties pour éviter les répétitions
        public int Note { get; set; }                               // Note (sur 20) de l'utilisateur


        public FormQuestionnaire()
        {
            InitializeComponent();

            // Créer la liste qui contiendria les numéros des questions déjà sorties
            ListeQuestionsSorties = new List<int>();

            // Initialiser la note de l'utilisateur à 0
            Note = 0;

            // Donner une question à QuestionActive
            RemplirQuestionActive(false,0);

            // Replir le formulaire
            remplirForm();

        }

        public void RemplirQuestionActive(bool questionSpecifique, int numQuestion)
        {
            Random r = new Random();
            int numeroQuestion;
            if (questionSpecifique == false)
            {
                // Création d'un nombre aléatoire qui permettra de choisir une question       
                numeroQuestion = r.Next(1, RecupererNbQuestion());
            }
            else
            {
                numeroQuestion = numQuestion;
            }
            

            // Chercher un numeroQuestion qui n'a jamais été choisi pour éviter les répétitions        
            while (ListeQuestionsSorties.Contains(numeroQuestion))
            {
                numeroQuestion = r.Next(RecupererNbQuestion());
            }
            ListeQuestionsSorties.Add(numeroQuestion);

            // Obtenir la question correspondant à numeroQuestion
            XmlNode question = RecupererFichier().GetElementsByTagName("question")[numeroQuestion];

            // Donner le titre de la question
            XmlNode titreQuestion = question.SelectSingleNode("titreQuestion");

            //Donner les propositions de la question
            XmlNodeList propositions = question.SelectNodes("proposition");

            // Donner la réponse de la question
            XmlNode reponse = question.SelectSingleNode("reponse");

            // Donner le point attribué à la question
            XmlNode point = question.SelectSingleNode("point");

            // Donne le chemin vers l'image si existant
            XmlNode cheminImageXML = question.SelectSingleNode("cheminImage");     

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

            // Nombre de point attribué à la question
            int NbPoint = Convert.ToInt32(point.InnerText);

            // Récupérer le chemin de l'image si il existe
            string CheminImage = "";
            try
            {
                // chemin de l'image 
                CheminImage = cheminImageXML.InnerText;
            }
            catch (Exception e)
            { }
            
            // Implémentation de QuestionActive avec les paramètres obtenus
            QuestionActive = new Question(titreQuestion.InnerText, r1, r2, r3, r4, NbPoint, CheminImage);
        }

        // Récupérer le fichier XML où sont contenues les questions et les réponses
        public XmlDocument RecupererFichier()
        {
            XmlDocument questionnaire = new XmlDocument();
            questionnaire.Load("..\\..\\questionnaire.xml");
            return questionnaire;
        }

        // Récuperer le nombre de questions contenues dans le fichier XML
        public int RecupererNbQuestion()
        {
            int nbQuestion = RecupererFichier().GetElementsByTagName("question").Count;
            return nbQuestion;
        }
        // Remplir le formulaire en écrivant une question et ses réponses
        public void remplirForm()
        {
            lbl_numQuestion.Text = Convert.ToString(ListeQuestionsSorties.Count());
            lbl_question.Text = QuestionActive.Enonce_question;

            // Ajout de l'image selon le cas
            if (QuestionActive.CheminImage != "")
            {
                imgBox.Image = Image.FromFile(QuestionActive.CheminImage);
                imgBox.SizeMode = PictureBoxSizeMode.Zoom;
                imgBox.Show();
            }
            else
            {
                imgBox.Hide();
            }

            lbl_reponse1.Text = QuestionActive.Liste_reponses[0].Enonce_reponse;
            lbl_reponse_2.Text = QuestionActive.Liste_reponses[1].Enonce_reponse;
            lbl_reponse_3.Text = QuestionActive.Liste_reponses[2].Enonce_reponse;
            //radioBtt_reponse4.Text = QuestionActive.Liste_reponses[3].Enonce_reponse;
            label1.Text = QuestionActive.Liste_reponses[3].Enonce_reponse;


            // Décocher les reponse lors de l'initialisation de la question
            radioBtt_reponse1.Checked = false;
            radioBtt_reponse2.Checked = false;
            radioBtt_reponse3.Checked = false;
            radioBtt_reponse4.Checked = false;

           
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
            // Vérifier la validité de la réponse de l'utilisateur et le corriger s'il a eu faux
            if (radioBtt_reponse1.Checked && QuestionActive.Liste_reponses[0].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                Note = Note + QuestionActive.NbPoint;
            }
            else if (radioBtt_reponse2.Checked && QuestionActive.Liste_reponses[1].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                Note = Note + QuestionActive.NbPoint;
            }
            else if (radioBtt_reponse3.Checked && QuestionActive.Liste_reponses[2].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                Note = Note + QuestionActive.NbPoint;
            }
            else if (radioBtt_reponse4.Checked && QuestionActive.Liste_reponses[3].veracite == 1)
            {
                MessageBox.Show("Vous avez trouvez la bonne réponse");
                Note = Note + QuestionActive.NbPoint;
            }
            else
            {
                // Récupérer la bonne réponse
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

            // Compter le nombre de question déjà réalisées par l'utilisatuer
            // si l'utilisateur a répondu à 20 questions, quitter le form, sinon passer à la question suivante
            
            // /!\ Probleme d'affichage de la quesion à 2 pts
            if (ListeQuestionsSorties.Count() < 14)
            {
                // Passer à la question suivante
                RemplirQuestionActive(false, 0);
                remplirForm();
               
            }
            else if (ListeQuestionsSorties.Count() == 14) 
            {
                RemplirQuestionActive(true, 0);
                remplirForm();
            }
            else
            {
                FormDijkstra formDijkstra = new FormDijkstra(Note);
                // Affichage non modal : l'utilisateur doit finir la tâche secondaire pour revenir à la tâche primaire
                formDijkstra.ShowDialog(this);

                // Si l'utilisateur clic sur valider le Dijkstra, on lui affiche la note
         
                
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_numQuestion_Click(object sender, EventArgs e)
        {

        }

        private void imgBox_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbl_reponse1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_reponse_2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_reponse_3_Click(object sender, EventArgs e)
        {

        }
    }
}
