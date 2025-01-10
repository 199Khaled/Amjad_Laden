namespace Parfüm2025
{
    partial class frmKundeSucheFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKundeSuche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSuche = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.lbVorschläge = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtKundeSuche
            // 
            this.txtKundeSuche.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKundeSuche.Location = new System.Drawing.Point(31, 63);
            this.txtKundeSuche.Name = "txtKundeSuche";
            this.txtKundeSuche.Size = new System.Drawing.Size(273, 24);
            this.txtKundeSuche.TabIndex = 0;
            this.txtKundeSuche.TextChanged += new System.EventHandler(this.txtKundeSuche_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bitte geben Sie den Kundenname ein:";
            // 
            // btnSuche
            // 
            this.btnSuche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuche.Location = new System.Drawing.Point(31, 111);
            this.btnSuche.Name = "btnSuche";
            this.btnSuche.Size = new System.Drawing.Size(108, 31);
            this.btnSuche.TabIndex = 2;
            this.btnSuche.Text = "Suche";
            this.btnSuche.UseVisualStyleBackColor = true;
            this.btnSuche.Click += new System.EventHandler(this.btnSuche_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbrechen.Location = new System.Drawing.Point(196, 111);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(108, 31);
            this.btnAbbrechen.TabIndex = 3;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // lbVorschläge
            // 
            this.lbVorschläge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVorschläge.FormattingEnabled = true;
            this.lbVorschläge.ItemHeight = 18;
            this.lbVorschläge.Location = new System.Drawing.Point(31, 91);
            this.lbVorschläge.Name = "lbVorschläge";
            this.lbVorschläge.Size = new System.Drawing.Size(273, 130);
            this.lbVorschläge.TabIndex = 4;
            this.lbVorschläge.Visible = false;
            this.lbVorschläge.Click += new System.EventHandler(this.lbVorschläge_Click);
            // 
            // frmKundeSucheFilter
            // 
            this.AcceptButton = this.btnSuche;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 229);
            this.Controls.Add(this.lbVorschläge);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnSuche);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKundeSuche);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKundeSucheFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKundeSucheFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKundeSuche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuche;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.ListBox lbVorschläge;
    }
}