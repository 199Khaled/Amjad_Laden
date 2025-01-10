namespace Parfüm2025
{
    partial class frmAddUpdateRechnung
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
            this.gbRechnung = new System.Windows.Forms.GroupBox();
            this.lbVorschläge = new System.Windows.Forms.ListBox();
            this.dtpErstellungsdatum = new System.Windows.Forms.DateTimePicker();
            this.txtKundenname = new System.Windows.Forms.TextBox();
            this.txtBelegID = new System.Windows.Forms.TextBox();
            this.lblErstellungsdatum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.gbRechnung.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRechnung
            // 
            this.gbRechnung.Controls.Add(this.lbVorschläge);
            this.gbRechnung.Controls.Add(this.dtpErstellungsdatum);
            this.gbRechnung.Controls.Add(this.txtKundenname);
            this.gbRechnung.Controls.Add(this.txtBelegID);
            this.gbRechnung.Controls.Add(this.lblErstellungsdatum);
            this.gbRechnung.Controls.Add(this.label2);
            this.gbRechnung.Controls.Add(this.label1);
            this.gbRechnung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRechnung.Location = new System.Drawing.Point(1, 12);
            this.gbRechnung.Name = "gbRechnung";
            this.gbRechnung.Size = new System.Drawing.Size(348, 230);
            this.gbRechnung.TabIndex = 0;
            this.gbRechnung.TabStop = false;
            this.gbRechnung.Text = "Rechnung";
            // 
            // lbVorschläge
            // 
            this.lbVorschläge.FormattingEnabled = true;
            this.lbVorschläge.ItemHeight = 20;
            this.lbVorschläge.Location = new System.Drawing.Point(148, 131);
            this.lbVorschläge.Name = "lbVorschläge";
            this.lbVorschläge.Size = new System.Drawing.Size(182, 84);
            this.lbVorschläge.TabIndex = 6;
            this.lbVorschläge.Visible = false;
            this.lbVorschläge.Click += new System.EventHandler(this.lbVorschläge_Click);
            // 
            // dtpErstellungsdatum
            // 
            this.dtpErstellungsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpErstellungsdatum.Location = new System.Drawing.Point(148, 148);
            this.dtpErstellungsdatum.Name = "dtpErstellungsdatum";
            this.dtpErstellungsdatum.Size = new System.Drawing.Size(182, 26);
            this.dtpErstellungsdatum.TabIndex = 5;
            // 
            // txtKundenname
            // 
            this.txtKundenname.Location = new System.Drawing.Point(148, 101);
            this.txtKundenname.Name = "txtKundenname";
            this.txtKundenname.Size = new System.Drawing.Size(182, 26);
            this.txtKundenname.TabIndex = 4;
            this.txtKundenname.TextChanged += new System.EventHandler(this.txtKundenname_TextChanged);
            // 
            // txtBelegID
            // 
            this.txtBelegID.Location = new System.Drawing.Point(148, 53);
            this.txtBelegID.Name = "txtBelegID";
            this.txtBelegID.ReadOnly = true;
            this.txtBelegID.Size = new System.Drawing.Size(182, 26);
            this.txtBelegID.TabIndex = 3;
            this.txtBelegID.Text = "-1";
            // 
            // lblErstellungsdatum
            // 
            this.lblErstellungsdatum.AutoSize = true;
            this.lblErstellungsdatum.Location = new System.Drawing.Point(5, 153);
            this.lblErstellungsdatum.Name = "lblErstellungsdatum";
            this.lblErstellungsdatum.Size = new System.Drawing.Size(137, 20);
            this.lblErstellungsdatum.TabIndex = 2;
            this.lblErstellungsdatum.Text = "Erstellungsdatum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kundenname:*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "BelegID:";
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbrechen.Location = new System.Drawing.Point(207, 248);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(124, 29);
            this.btnAbbrechen.TabIndex = 1;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeichern.Location = new System.Drawing.Point(72, 247);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(124, 29);
            this.btnSpeichern.TabIndex = 2;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // frmAddUpdateRechnung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 288);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.gbRechnung);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateRechnung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechnung";
            this.Load += new System.EventHandler(this.frmAddUpdateRechnung_Load);
            this.gbRechnung.ResumeLayout(false);
            this.gbRechnung.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRechnung;
        private System.Windows.Forms.Label lblErstellungsdatum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpErstellungsdatum;
        private System.Windows.Forms.TextBox txtKundenname;
        private System.Windows.Forms.TextBox txtBelegID;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.ListBox lbVorschläge;
    }
}