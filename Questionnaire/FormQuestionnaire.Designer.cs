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
            this.lbl_numQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_question
            // 
            this.lbl_question.AutoSize = true;
            this.lbl_question.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.Location = new System.Drawing.Point(58, 114);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(69, 19);
            this.lbl_question.TabIndex = 0;
            this.lbl_question.Text = "question";
            this.lbl_question.Click += new System.EventHandler(this.lbl_question_Click);
            // 
            // radioBtt_reponse1
            // 
            this.radioBtt_reponse1.AutoEllipsis = true;
            this.radioBtt_reponse1.AutoSize = true;
            this.radioBtt_reponse1.Checked = true;
            this.radioBtt_reponse1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtt_reponse1.Location = new System.Drawing.Point(62, 162);
            this.radioBtt_reponse1.Name = "radioBtt_reponse1";
            this.radioBtt_reponse1.Size = new System.Drawing.Size(76, 18);
            this.radioBtt_reponse1.TabIndex = 1;
            this.radioBtt_reponse1.TabStop = true;
            this.radioBtt_reponse1.Text = "reponse1";
            this.radioBtt_reponse1.UseVisualStyleBackColor = true;
            this.radioBtt_reponse1.CheckedChanged += new System.EventHandler(this.radioBtt_reponse1_CheckedChanged);
            // 
            // radioBtt_reponse4
            // 
            this.radioBtt_reponse4.AutoSize = true;
            this.radioBtt_reponse4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtt_reponse4.Location = new System.Drawing.Point(62, 283);
            this.radioBtt_reponse4.Name = "radioBtt_reponse4";
            this.radioBtt_reponse4.Size = new System.Drawing.Size(76, 18);
            this.radioBtt_reponse4.TabIndex = 2;
            this.radioBtt_reponse4.Text = "reponse4";
            this.radioBtt_reponse4.UseVisualStyleBackColor = true;
            this.radioBtt_reponse4.CheckedChanged += new System.EventHandler(this.radioBtt_reponse4_CheckedChanged);
            // 
            // radioBtt_reponse3
            // 
            this.radioBtt_reponse3.AutoSize = true;
            this.radioBtt_reponse3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtt_reponse3.Location = new System.Drawing.Point(62, 242);
            this.radioBtt_reponse3.Name = "radioBtt_reponse3";
            this.radioBtt_reponse3.Size = new System.Drawing.Size(76, 18);
            this.radioBtt_reponse3.TabIndex = 3;
            this.radioBtt_reponse3.Text = "reponse3";
            this.radioBtt_reponse3.UseVisualStyleBackColor = true;
            this.radioBtt_reponse3.CheckedChanged += new System.EventHandler(this.radioBtt_reponse3_CheckedChanged);
            // 
            // radioBtt_reponse2
            // 
            this.radioBtt_reponse2.AutoSize = true;
            this.radioBtt_reponse2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtt_reponse2.Location = new System.Drawing.Point(62, 202);
            this.radioBtt_reponse2.Name = "radioBtt_reponse2";
            this.radioBtt_reponse2.Size = new System.Drawing.Size(76, 18);
            this.radioBtt_reponse2.TabIndex = 4;
            this.radioBtt_reponse2.Text = "reponse2";
            this.radioBtt_reponse2.UseVisualStyleBackColor = true;
            this.radioBtt_reponse2.CheckedChanged += new System.EventHandler(this.radioBtt_reponse2_CheckedChanged);
            // 
            // btt_validation
            // 
            this.btt_validation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_validation.AutoSize = true;
            this.btt_validation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_validation.Location = new System.Drawing.Point(251, 347);
            this.btt_validation.Name = "btt_validation";
            this.btt_validation.Size = new System.Drawing.Size(94, 37);
            this.btt_validation.TabIndex = 5;
            this.btt_validation.Text = "Validation";
            this.btt_validation.UseVisualStyleBackColor = true;
            this.btt_validation.Click += new System.EventHandler(this.btt_validation_Click);
            // 
            // lbl_numQuestion
            // 
            this.lbl_numQuestion.AutoSize = true;
            this.lbl_numQuestion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numQuestion.Location = new System.Drawing.Point(23, 114);
            this.lbl_numQuestion.Name = "lbl_numQuestion";
            this.lbl_numQuestion.Size = new System.Drawing.Size(29, 19);
            this.lbl_numQuestion.TabIndex = 6;
            this.lbl_numQuestion.Text = "nb";
            this.lbl_numQuestion.Click += new System.EventHandler(this.lbl_numQuestion_Click);
            // 
            // FormQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 415);
            this.Controls.Add(this.lbl_numQuestion);
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
        private System.Windows.Forms.Label lbl_numQuestion;
    }
}

