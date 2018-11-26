namespace Dijstra
{
    partial class FormDijkstra
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
            this.txtBoxFrep = new System.Windows.Forms.TextBox();
            this.txtBoxOrep = new System.Windows.Forms.TextBox();
            this.txtBoxFsaisie = new System.Windows.Forms.TextBox();
            this.txtBoxOsaisie = new System.Windows.Forms.TextBox();
            this.lblF = new System.Windows.Forms.Label();
            this.lblO = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.lblEnonce = new System.Windows.Forms.Label();
            this.treeViewSaisie = new System.Windows.Forms.TreeView();
            this.lblArbre = new System.Windows.Forms.Label();
            this.listBoxEnonce = new System.Windows.Forms.ListBox();
            this.textBoxDepart = new System.Windows.Forms.TextBox();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblArrive = new System.Windows.Forms.Label();
            this.textBoxArrive = new System.Windows.Forms.TextBox();
            this.btnOkArbre = new System.Windows.Forms.Button();
            this.txtBoxSaisieArb = new System.Windows.Forms.TextBox();
            this.lblInstrArbre = new System.Windows.Forms.Label();
            this.btnAbandonListe = new System.Windows.Forms.Button();
            this.btnAbandonArbre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxFrep
            // 
            this.txtBoxFrep.Location = new System.Drawing.Point(69, 208);
            this.txtBoxFrep.Multiline = true;
            this.txtBoxFrep.Name = "txtBoxFrep";
            this.txtBoxFrep.ReadOnly = true;
            this.txtBoxFrep.Size = new System.Drawing.Size(162, 82);
            this.txtBoxFrep.TabIndex = 0;
            // 
            // txtBoxOrep
            // 
            this.txtBoxOrep.Location = new System.Drawing.Point(272, 208);
            this.txtBoxOrep.Multiline = true;
            this.txtBoxOrep.Name = "txtBoxOrep";
            this.txtBoxOrep.ReadOnly = true;
            this.txtBoxOrep.Size = new System.Drawing.Size(162, 82);
            this.txtBoxOrep.TabIndex = 1;
            // 
            // txtBoxFsaisie
            // 
            this.txtBoxFsaisie.Location = new System.Drawing.Point(69, 324);
            this.txtBoxFsaisie.Name = "txtBoxFsaisie";
            this.txtBoxFsaisie.Size = new System.Drawing.Size(162, 20);
            this.txtBoxFsaisie.TabIndex = 2;
            // 
            // txtBoxOsaisie
            // 
            this.txtBoxOsaisie.Location = new System.Drawing.Point(272, 324);
            this.txtBoxOsaisie.Name = "txtBoxOsaisie";
            this.txtBoxOsaisie.Size = new System.Drawing.Size(162, 20);
            this.txtBoxOsaisie.TabIndex = 3;
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.Location = new System.Drawing.Point(104, 183);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(93, 13);
            this.lblF.TabIndex = 4;
            this.lblF.Text = "Noeuds fermés (F)";
            // 
            // lblO
            // 
            this.lblO.AutoSize = true;
            this.lblO.Location = new System.Drawing.Point(305, 183);
            this.lblO.Name = "lblO";
            this.lblO.Size = new System.Drawing.Size(99, 13);
            this.lblO.TabIndex = 5;
            this.lblO.Text = "Noeuds ouverts (O)";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(156, 368);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Valider";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(272, 368);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 7;
            this.btnInit.Text = "Réinitialiser";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lblEnonce
            // 
            this.lblEnonce.AutoSize = true;
            this.lblEnonce.Location = new System.Drawing.Point(57, 42);
            this.lblEnonce.Name = "lblEnonce";
            this.lblEnonce.Size = new System.Drawing.Size(253, 13);
            this.lblEnonce.TabIndex = 9;
            this.lblEnonce.Text = "Enoncé : Trouver le plus court chemin de ce graphe";
            // 
            // treeViewSaisie
            // 
            this.treeViewSaisie.Location = new System.Drawing.Point(334, 432);
            this.treeViewSaisie.Name = "treeViewSaisie";
            this.treeViewSaisie.Size = new System.Drawing.Size(121, 97);
            this.treeViewSaisie.TabIndex = 10;
            this.treeViewSaisie.Visible = false;
            this.treeViewSaisie.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewSaisie_NodeMouseClick);
            // 
            // lblArbre
            // 
            this.lblArbre.AutoSize = true;
            this.lblArbre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArbre.Location = new System.Drawing.Point(94, 388);
            this.lblArbre.Name = "lblArbre";
            this.lblArbre.Size = new System.Drawing.Size(125, 17);
            this.lblArbre.TabIndex = 12;
            this.lblArbre.Text = "Saisir l\'arbre final :";
            this.lblArbre.Visible = false;
            // 
            // listBoxEnonce
            // 
            this.listBoxEnonce.FormattingEnabled = true;
            this.listBoxEnonce.Location = new System.Drawing.Point(348, 36);
            this.listBoxEnonce.Name = "listBoxEnonce";
            this.listBoxEnonce.Size = new System.Drawing.Size(120, 95);
            this.listBoxEnonce.TabIndex = 13;
            // 
            // textBoxDepart
            // 
            this.textBoxDepart.Location = new System.Drawing.Point(50, 102);
            this.textBoxDepart.Name = "textBoxDepart";
            this.textBoxDepart.ReadOnly = true;
            this.textBoxDepart.Size = new System.Drawing.Size(100, 20);
            this.textBoxDepart.TabIndex = 14;
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(57, 86);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(93, 13);
            this.lblDepart.TabIndex = 15;
            this.lblDepart.Text = "Noeud de départ :";
            // 
            // lblArrive
            // 
            this.lblArrive.AutoSize = true;
            this.lblArrive.Location = new System.Drawing.Point(207, 86);
            this.lblArrive.Name = "lblArrive";
            this.lblArrive.Size = new System.Drawing.Size(88, 13);
            this.lblArrive.TabIndex = 17;
            this.lblArrive.Text = "Noeud d\'arrivée :";
            // 
            // textBoxArrive
            // 
            this.textBoxArrive.Location = new System.Drawing.Point(200, 102);
            this.textBoxArrive.Name = "textBoxArrive";
            this.textBoxArrive.ReadOnly = true;
            this.textBoxArrive.Size = new System.Drawing.Size(100, 20);
            this.textBoxArrive.TabIndex = 16;
            // 
            // btnOkArbre
            // 
            this.btnOkArbre.Location = new System.Drawing.Point(308, 551);
            this.btnOkArbre.Name = "btnOkArbre";
            this.btnOkArbre.Size = new System.Drawing.Size(75, 23);
            this.btnOkArbre.TabIndex = 18;
            this.btnOkArbre.Text = "Valider";
            this.btnOkArbre.UseVisualStyleBackColor = true;
            this.btnOkArbre.Visible = false;
            this.btnOkArbre.Click += new System.EventHandler(this.btnOkArbre_Click);
            // 
            // txtBoxSaisieArb
            // 
            this.txtBoxSaisieArb.Location = new System.Drawing.Point(130, 509);
            this.txtBoxSaisieArb.Name = "txtBoxSaisieArb";
            this.txtBoxSaisieArb.Size = new System.Drawing.Size(101, 20);
            this.txtBoxSaisieArb.TabIndex = 20;
            this.txtBoxSaisieArb.Visible = false;
            // 
            // lblInstrArbre
            // 
            this.lblInstrArbre.Location = new System.Drawing.Point(104, 423);
            this.lblInstrArbre.Name = "lblInstrArbre";
            this.lblInstrArbre.Size = new System.Drawing.Size(169, 71);
            this.lblInstrArbre.TabIndex = 21;
            this.lblInstrArbre.Text = "Pour remplir les noeuds de l\'arbre : saisir la valeur dans le champs ci-dessous e" +
    "t cliquer sur le noeud à modifier directement dans la vue de l\'arbre.";
            this.lblInstrArbre.Visible = false;
            // 
            // btnAbandonListe
            // 
            this.btnAbandonListe.Location = new System.Drawing.Point(213, 418);
            this.btnAbandonListe.Name = "btnAbandonListe";
            this.btnAbandonListe.Size = new System.Drawing.Size(75, 23);
            this.btnAbandonListe.TabIndex = 22;
            this.btnAbandonListe.Text = "Abandonner";
            this.btnAbandonListe.UseVisualStyleBackColor = true;
            this.btnAbandonListe.Click += new System.EventHandler(this.btnAbandonListe_Click);
            // 
            // btnAbandonArbre
            // 
            this.btnAbandonArbre.Location = new System.Drawing.Point(414, 551);
            this.btnAbandonArbre.Name = "btnAbandonArbre";
            this.btnAbandonArbre.Size = new System.Drawing.Size(75, 23);
            this.btnAbandonArbre.TabIndex = 23;
            this.btnAbandonArbre.Text = "Abandonner";
            this.btnAbandonArbre.UseVisualStyleBackColor = true;
            this.btnAbandonArbre.Visible = false;
            this.btnAbandonArbre.Click += new System.EventHandler(this.btnAbandonArbre_Click);
            // 
            // FormDijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 624);
            this.Controls.Add(this.btnAbandonArbre);
            this.Controls.Add(this.btnAbandonListe);
            this.Controls.Add(this.lblInstrArbre);
            this.Controls.Add(this.txtBoxSaisieArb);
            this.Controls.Add(this.btnOkArbre);
            this.Controls.Add(this.lblArrive);
            this.Controls.Add(this.textBoxArrive);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.textBoxDepart);
            this.Controls.Add(this.listBoxEnonce);
            this.Controls.Add(this.lblArbre);
            this.Controls.Add(this.treeViewSaisie);
            this.Controls.Add(this.lblEnonce);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblO);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.txtBoxOsaisie);
            this.Controls.Add(this.txtBoxFsaisie);
            this.Controls.Add(this.txtBoxOrep);
            this.Controls.Add(this.txtBoxFrep);
            this.Name = "FormDijkstra";
            this.Text = "Questions sur Dijkstra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxFrep;
        private System.Windows.Forms.TextBox txtBoxOrep;
        private System.Windows.Forms.TextBox txtBoxFsaisie;
        private System.Windows.Forms.TextBox txtBoxOsaisie;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Label lblO;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label lblEnonce;
        private System.Windows.Forms.TreeView treeViewSaisie;
        private System.Windows.Forms.Label lblArbre;
        private System.Windows.Forms.ListBox listBoxEnonce;
        private System.Windows.Forms.TextBox textBoxDepart;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblArrive;
        private System.Windows.Forms.TextBox textBoxArrive;
        private System.Windows.Forms.Button btnOkArbre;
        private System.Windows.Forms.TextBox txtBoxSaisieArb;
        private System.Windows.Forms.Label lblInstrArbre;
        private System.Windows.Forms.Button btnAbandonListe;
        private System.Windows.Forms.Button btnAbandonArbre;
    }
}

