using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questionnaire
{
    public partial class FormQuestionnaire : Form
    {
        public Question QuestionActive { get; set; }

        public FormQuestionnaire()
        {
            InitializeComponent();
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
            Random r = new Random(Question.nbQuestion); // Ca va pas faut continuer...
        }
    }
}
