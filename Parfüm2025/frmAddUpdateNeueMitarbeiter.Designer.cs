namespace Parfüm2025
{
    partial class frmAddUpdateNeueMitarbeiter
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbMitarbeiterdaten = new System.Windows.Forms.GroupBox();
            this.chbIstAktive = new System.Windows.Forms.CheckBox();
            this.dtpEingestelltAm = new System.Windows.Forms.DateTimePicker();
            this.txtVersicherungsNummer = new System.Windows.Forms.TextBox();
            this.txtVersicherungsName = new System.Windows.Forms.TextBox();
            this.txtMitarbeiterID = new System.Windows.Forms.TextBox();
            this.txtPersonID = new System.Windows.Forms.TextBox();
            this.btnSpeicherin = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrAddUpdatePerson1 = new Parfüm2025.ctrAddUpdatePerson();
            this.gbMitarbeiterdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "EingestelltAm:*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(340, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "istAktive:*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "PersonID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(340, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "MitarbeiterID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "VersicherungsName:*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(340, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "VersicherungsNummer:*";
            // 
            // gbMitarbeiterdaten
            // 
            this.gbMitarbeiterdaten.Controls.Add(this.chbIstAktive);
            this.gbMitarbeiterdaten.Controls.Add(this.dtpEingestelltAm);
            this.gbMitarbeiterdaten.Controls.Add(this.txtVersicherungsNummer);
            this.gbMitarbeiterdaten.Controls.Add(this.txtVersicherungsName);
            this.gbMitarbeiterdaten.Controls.Add(this.txtMitarbeiterID);
            this.gbMitarbeiterdaten.Controls.Add(this.txtPersonID);
            this.gbMitarbeiterdaten.Controls.Add(this.label7);
            this.gbMitarbeiterdaten.Controls.Add(this.label6);
            this.gbMitarbeiterdaten.Controls.Add(this.label8);
            this.gbMitarbeiterdaten.Controls.Add(this.label5);
            this.gbMitarbeiterdaten.Controls.Add(this.label9);
            this.gbMitarbeiterdaten.Controls.Add(this.label10);
            this.gbMitarbeiterdaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMitarbeiterdaten.Location = new System.Drawing.Point(30, 473);
            this.gbMitarbeiterdaten.Name = "gbMitarbeiterdaten";
            this.gbMitarbeiterdaten.Size = new System.Drawing.Size(641, 245);
            this.gbMitarbeiterdaten.TabIndex = 6;
            this.gbMitarbeiterdaten.TabStop = false;
            this.gbMitarbeiterdaten.Text = "Mitarbeiterdaten";
            // 
            // chbIstAktive
            // 
            this.chbIstAktive.AutoSize = true;
            this.chbIstAktive.Checked = true;
            this.chbIstAktive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIstAktive.Location = new System.Drawing.Point(344, 197);
            this.chbIstAktive.Name = "chbIstAktive";
            this.chbIstAktive.Size = new System.Drawing.Size(71, 24);
            this.chbIstAktive.TabIndex = 11;
            this.chbIstAktive.Text = "Aktive";
            this.chbIstAktive.UseVisualStyleBackColor = true;
            this.chbIstAktive.CheckedChanged += new System.EventHandler(this.chbIstAktive_CheckedChanged);
            // 
            // dtpEingestelltAm
            // 
            this.dtpEingestelltAm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEingestelltAm.Location = new System.Drawing.Point(17, 193);
            this.dtpEingestelltAm.Name = "dtpEingestelltAm";
            this.dtpEingestelltAm.Size = new System.Drawing.Size(278, 26);
            this.dtpEingestelltAm.TabIndex = 12;
            // 
            // txtVersicherungsNummer
            // 
            this.txtVersicherungsNummer.Location = new System.Drawing.Point(344, 125);
            this.txtVersicherungsNummer.MaxLength = 15;
            this.txtVersicherungsNummer.Name = "txtVersicherungsNummer";
            this.txtVersicherungsNummer.Size = new System.Drawing.Size(280, 26);
            this.txtVersicherungsNummer.TabIndex = 11;
            // 
            // txtVersicherungsName
            // 
            this.txtVersicherungsName.Location = new System.Drawing.Point(17, 126);
            this.txtVersicherungsName.MaxLength = 50;
            this.txtVersicherungsName.Name = "txtVersicherungsName";
            this.txtVersicherungsName.Size = new System.Drawing.Size(278, 26);
            this.txtVersicherungsName.TabIndex = 10;
            // 
            // txtMitarbeiterID
            // 
            this.txtMitarbeiterID.Location = new System.Drawing.Point(344, 51);
            this.txtMitarbeiterID.Name = "txtMitarbeiterID";
            this.txtMitarbeiterID.ReadOnly = true;
            this.txtMitarbeiterID.Size = new System.Drawing.Size(280, 26);
            this.txtMitarbeiterID.TabIndex = 16;
            this.txtMitarbeiterID.Text = "-1";
            // 
            // txtPersonID
            // 
            this.txtPersonID.Location = new System.Drawing.Point(17, 51);
            this.txtPersonID.Name = "txtPersonID";
            this.txtPersonID.ReadOnly = true;
            this.txtPersonID.Size = new System.Drawing.Size(278, 26);
            this.txtPersonID.TabIndex = 15;
            this.txtPersonID.Text = " -1";
            // 
            // btnSpeicherin
            // 
            this.btnSpeicherin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeicherin.Location = new System.Drawing.Point(47, 724);
            this.btnSpeicherin.Name = "btnSpeicherin";
            this.btnSpeicherin.Size = new System.Drawing.Size(278, 39);
            this.btnSpeicherin.TabIndex = 13;
            this.btnSpeicherin.Text = "Speichern";
            this.btnSpeicherin.UseVisualStyleBackColor = true;
            this.btnSpeicherin.Click += new System.EventHandler(this.btnSpeicherin_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbrechen.Location = new System.Drawing.Point(376, 724);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(278, 39);
            this.btnAbbrechen.TabIndex = 14;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrAddUpdatePerson1
            // 
            this.ctrAddUpdatePerson1.Location = new System.Drawing.Point(12, 12);
            this.ctrAddUpdatePerson1.Name = "ctrAddUpdatePerson1";
            this.ctrAddUpdatePerson1.Size = new System.Drawing.Size(659, 455);
            this.ctrAddUpdatePerson1.TabIndex = 9;
            this.ctrAddUpdatePerson1.OnSelectedPerson += new System.Action<int>(this.ctrAddUpdatePerson1_OnSelectedPerson);
            // 
            // frmAddUpdateNeueMitarbeiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 793);
            this.Controls.Add(this.ctrAddUpdatePerson1);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnSpeicherin);
            this.Controls.Add(this.gbMitarbeiterdaten);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateNeueMitarbeiter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdate-NeueMitarbeiter";
            this.Load += new System.EventHandler(this.frmAddUpdateNeueMitarbeiter_Load);
            this.gbMitarbeiterdaten.ResumeLayout(false);
            this.gbMitarbeiterdaten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbMitarbeiterdaten;
        private System.Windows.Forms.TextBox txtVersicherungsNummer;
        private System.Windows.Forms.TextBox txtVersicherungsName;
        private System.Windows.Forms.TextBox txtMitarbeiterID;
        private System.Windows.Forms.TextBox txtPersonID;
        private System.Windows.Forms.CheckBox chbIstAktive;
        private System.Windows.Forms.DateTimePicker dtpEingestelltAm;
        private System.Windows.Forms.Button btnSpeicherin;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrAddUpdatePerson ctrAddUpdatePerson1;
    }
}