namespace Questionnaire
{
    partial class FormQuestionnaire
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_question = new System.Windows.Forms.Label();
            this.radioBtt_reponse1 = new System.Windows.Forms.RadioButton();
            this.radioBtt_reponse4 = new System.Windows.Forms.RadioButton();
            this.radioBtt_reponse3 = new System.Windows.Forms.RadioButton();
            this.radioBtt_reponse2 = new System.Windows.Forms.RadioButton();
            this.btt_validation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_question
            // 
            this.lbl_question.AutoSize = true;
            this.lbl_question.Location = new System.Drawing.Point(152, 135);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(47, 13);
            this.lbl_question.TabIndex = 0;
            this.lbl_question.Text = "question";
            this.lbl_question.Click += new System.EventHandler(this.lbl_question_Click);
            // 
            // radioBtt_reponse1
            // 
            this.radioBtt_reponse1.AutoSize = true;
            this.radioBtt_reponse1.Location = new System.Drawing.Point(72, 188);
            this.radioBtt_reponse1.Name = "radioBtt_reponse1";
            this.radioBtt_reponse1.Size = new System.Drawing.Size(69, 17);
            this.radioBtt_reponse1.TabIndex = 1;
            this.radioBtt_reponse1.TabStop = true;
            this.radioBtt_reponse1.Text = "reponse1";
            this.radioBtt_reponse1.UseVisualStyleBackColor = true;
            this.radioBtt_reponse1.CheckedChanged += new System.EventHandler(this.radioBtt_reponse1_CheckedChanged);
            // 
            // radioBtt_reponse4
            // 
            this.radioBtt_reponse4.AutoSize = true;
            this.radioBtt_reponse4.Location = new System.Drawing.Point(72, 309);
            this.radioBtt_reponse4.Name = "radioBtt_reponse4";
            this.radioBtt_reponse4.Size = new System.Drawing.Size(69, 17);
            this.radioBtt_reponse4.TabIndex = 2;
            this.radioBtt_reponse4.TabStop = true;
            this.radioBtt_reponse4.Text = "reponse4";
            this.radioBtt_reponse4.UseVisualStyleBackColor = true;
            this.radioBtt_reponse4.CheckedChanged += new System.EventHandler(this.radioBtt_reponse4_CheckedChanged);
            // 
            // radioBtt_reponse3
            // 
            this.radioBtt_reponse3.AutoSize = true;
            this.radioBtt_reponse3.Location = new System.Drawing.Point(72, 268);
            this.radioBtt_reponse3.Name = "radioBtt_reponse3";
            this.radioBtt_reponse3.Size = new System.Drawing.Size(69, 17);
            this.radioBtt_reponse3.TabIndex = 3;
            this.radioBtt_reponse3.TabStop = true;
            this.radioBtt_reponse3.Text = "reponse3";
            this.radioBtt_reponse3.UseVisualStyleBackColor = true;
            this.radioBtt_reponse3.CheckedChanged += new System.EventHandler(this.radioBtt_reponse3_CheckedChanged);
            // 
            // radioBtt_reponse2
            // 
            this.radioBtt_reponse2.AutoSize = true;
            this.radioBtt_reponse2.Location = new System.Drawing.Point(72, 228);
            this.radioBtt_reponse2.Name = "radioBtt_reponse2";
            this.radioBtt_reponse2.Size = new System.Drawing.Size(69, 17);
            this.radioBtt_reponse2.TabIndex = 4;
            this.radioBtt_reponse2.TabStop = true;
            this.radioBtt_reponse2.Text = "reponse2";
            this.radioBtt_reponse2.UseVisualStyleBackColor = true;
            this.radioBtt_reponse2.CheckedChanged += new System.EventHandler(this.radioBtt_reponse2_CheckedChanged);
            // 
            // btt_validation
            // 
            this.btt_validation.Location = new System.Drawing.Point(333, 391);
            this.btt_validation.Name = "btt_validation";
            this.btt_validation.Size = new System.Drawing.Size(75, 23);
            this.btt_validation.TabIndex = 5;
            this.btt_validation.Text = "Validation";
            this.btt_validation.UseVisualStyleBackColor = true;
            this.btt_validation.Click += new System.EventHandler(this.btt_validation_Click);
            // 
            // FormQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 535);
            this.Controls.Add(this.btt_validation);
            this.Controls.Add(this.radioBtt_reponse2);
            this.Controls.Add(this.radioBtt_reponse3);
            this.Controls.Add(this.radioBtt_reponse4);
            this.Controls.Add(this.radioBtt_reponse1);
            this.Controls.Add(this.lbl_question);
            this.Name = "FormQuestionnaire";
            this.Text = "Questionnaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.RadioButton radioBtt_reponse1;
        private System.Windows.Forms.RadioButton radioBtt_reponse4;
        private System.Windows.Forms.RadioButton radioBtt_reponse3;
        private System.Windows.Forms.RadioButton radioBtt_reponse2;
        private System.Windows.Forms.Button btt_validation;
    }
}

