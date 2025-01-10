namespace Parfüm2025
{
    partial class frmAddUpdateNeueUser
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
            this.gbUserdaten = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMitarbeiterID = new System.Windows.Forms.TextBox();
            this.chbIstAktive = new System.Windows.Forms.CheckBox();
            this.txtUserPasswort = new System.Windows.Forms.TextBox();
            this.txtUserrolle = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.gbPermission = new System.Windows.Forms.GroupBox();
            this.chbUserverwaltung = new System.Windows.Forms.CheckBox();
            this.chbAdminBerechtigung = new System.Windows.Forms.CheckBox();
            this.chbLageverwaltung = new System.Windows.Forms.CheckBox();
            this.chbMitarbeiterverwaltung = new System.Windows.Forms.CheckBox();
            this.chbKundeverwaltung = new System.Windows.Forms.CheckBox();
            this.chbParfümverwaltung = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbUserdaten.SuspendLayout();
            this.gbPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUserdaten
            // 
            this.gbUserdaten.Controls.Add(this.label5);
            this.gbUserdaten.Controls.Add(this.txtMitarbeiterID);
            this.gbUserdaten.Controls.Add(this.chbIstAktive);
            this.gbUserdaten.Controls.Add(this.txtUserPasswort);
            this.gbUserdaten.Controls.Add(this.txtUserrolle);
            this.gbUserdaten.Controls.Add(this.txtUserID);
            this.gbUserdaten.Controls.Add(this.label4);
            this.gbUserdaten.Controls.Add(this.label3);
            this.gbUserdaten.Controls.Add(this.label2);
            this.gbUserdaten.Controls.Add(this.label1);
            this.gbUserdaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUserdaten.Location = new System.Drawing.Point(12, 28);
            this.gbUserdaten.Name = "gbUserdaten";
            this.gbUserdaten.Size = new System.Drawing.Size(365, 239);
            this.gbUserdaten.TabIndex = 8;
            this.gbUserdaten.TabStop = false;
            this.gbUserdaten.Text = "Userdaten";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "mitarbeiterID:";
            // 
            // txtMitarbeiterID
            // 
            this.txtMitarbeiterID.Location = new System.Drawing.Point(122, 76);
            this.txtMitarbeiterID.Name = "txtMitarbeiterID";
            this.txtMitarbeiterID.ReadOnly = true;
            this.txtMitarbeiterID.Size = new System.Drawing.Size(222, 26);
            this.txtMitarbeiterID.TabIndex = 8;
            this.txtMitarbeiterID.Text = "-1";
            // 
            // chbIstAktive
            // 
            this.chbIstAktive.AutoSize = true;
            this.chbIstAktive.Checked = true;
            this.chbIstAktive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIstAktive.Location = new System.Drawing.Point(122, 200);
            this.chbIstAktive.Name = "chbIstAktive";
            this.chbIstAktive.Size = new System.Drawing.Size(71, 24);
            this.chbIstAktive.TabIndex = 7;
            this.chbIstAktive.Text = "Aktive";
            this.chbIstAktive.UseVisualStyleBackColor = true;
            this.chbIstAktive.CheckedChanged += new System.EventHandler(this.chbIstAktive_CheckedChanged);
            // 
            // txtUserPasswort
            // 
            this.txtUserPasswort.Location = new System.Drawing.Point(122, 155);
            this.txtUserPasswort.Name = "txtUserPasswort";
            this.txtUserPasswort.Size = new System.Drawing.Size(222, 26);
            this.txtUserPasswort.TabIndex = 6;
            // 
            // txtUserrolle
            // 
            this.txtUserrolle.Location = new System.Drawing.Point(122, 115);
            this.txtUserrolle.Name = "txtUserrolle";
            this.txtUserrolle.Size = new System.Drawing.Size(222, 26);
            this.txtUserrolle.TabIndex = 5;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(122, 37);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(222, 26);
            this.txtUserID.TabIndex = 4;
            this.txtUserID.Text = "-1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "istAktive:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "userPasswort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "userRolle:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "userID:";
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbrechen.Location = new System.Drawing.Point(213, 544);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(164, 31);
            this.btnAbbrechen.TabIndex = 7;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeichern.Location = new System.Drawing.Point(12, 544);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(164, 31);
            this.btnSpeichern.TabIndex = 6;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // gbPermission
            // 
            this.gbPermission.Controls.Add(this.chbUserverwaltung);
            this.gbPermission.Controls.Add(this.chbAdminBerechtigung);
            this.gbPermission.Controls.Add(this.chbLageverwaltung);
            this.gbPermission.Controls.Add(this.chbMitarbeiterverwaltung);
            this.gbPermission.Controls.Add(this.chbKundeverwaltung);
            this.gbPermission.Controls.Add(this.chbParfümverwaltung);
            this.gbPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPermission.Location = new System.Drawing.Point(12, 273);
            this.gbPermission.Name = "gbPermission";
            this.gbPermission.Size = new System.Drawing.Size(365, 253);
            this.gbPermission.TabIndex = 5;
            this.gbPermission.TabStop = false;
            this.gbPermission.Text = "Permission";
            // 
            // chbUserverwaltung
            // 
            this.chbUserverwaltung.AutoSize = true;
            this.chbUserverwaltung.Location = new System.Drawing.Point(43, 167);
            this.chbUserverwaltung.Name = "chbUserverwaltung";
            this.chbUserverwaltung.Size = new System.Drawing.Size(260, 24);
            this.chbUserverwaltung.TabIndex = 5;
            this.chbUserverwaltung.Text = "Berechtigung für Userverwaltung";
            this.chbUserverwaltung.UseVisualStyleBackColor = true;
            // 
            // chbAdminBerechtigung
            // 
            this.chbAdminBerechtigung.AutoSize = true;
            this.chbAdminBerechtigung.Location = new System.Drawing.Point(43, 223);
            this.chbAdminBerechtigung.Name = "chbAdminBerechtigung";
            this.chbAdminBerechtigung.Size = new System.Drawing.Size(73, 24);
            this.chbAdminBerechtigung.TabIndex = 4;
            this.chbAdminBerechtigung.Text = "Admin";
            this.chbAdminBerechtigung.UseVisualStyleBackColor = true;
            this.chbAdminBerechtigung.CheckedChanged += new System.EventHandler(this.chbAdminBerechtigung_CheckedChanged);
            // 
            // chbLageverwaltung
            // 
            this.chbLageverwaltung.AutoSize = true;
            this.chbLageverwaltung.Location = new System.Drawing.Point(43, 137);
            this.chbLageverwaltung.Name = "chbLageverwaltung";
            this.chbLageverwaltung.Size = new System.Drawing.Size(262, 24);
            this.chbLageverwaltung.TabIndex = 3;
            this.chbLageverwaltung.Text = "Berechtigung für Lageverwaltung";
            this.chbLageverwaltung.UseVisualStyleBackColor = true;
            // 
            // chbMitarbeiterverwaltung
            // 
            this.chbMitarbeiterverwaltung.AutoSize = true;
            this.chbMitarbeiterverwaltung.Location = new System.Drawing.Point(43, 107);
            this.chbMitarbeiterverwaltung.Name = "chbMitarbeiterverwaltung";
            this.chbMitarbeiterverwaltung.Size = new System.Drawing.Size(301, 24);
            this.chbMitarbeiterverwaltung.TabIndex = 2;
            this.chbMitarbeiterverwaltung.Text = "Berechtigung für Mitarbeiterverwaltung";
            this.chbMitarbeiterverwaltung.UseVisualStyleBackColor = true;
            // 
            // chbKundeverwaltung
            // 
            this.chbKundeverwaltung.AutoSize = true;
            this.chbKundeverwaltung.Location = new System.Drawing.Point(43, 77);
            this.chbKundeverwaltung.Name = "chbKundeverwaltung";
            this.chbKundeverwaltung.Size = new System.Drawing.Size(272, 24);
            this.chbKundeverwaltung.TabIndex = 1;
            this.chbKundeverwaltung.Text = "Berechtigung für Kundeverwaltung";
            this.chbKundeverwaltung.UseVisualStyleBackColor = true;
            // 
            // chbParfümverwaltung
            // 
            this.chbParfümverwaltung.AutoSize = true;
            this.chbParfümverwaltung.Location = new System.Drawing.Point(43, 47);
            this.chbParfümverwaltung.Name = "chbParfümverwaltung";
            this.chbParfümverwaltung.Size = new System.Drawing.Size(277, 24);
            this.chbParfümverwaltung.TabIndex = 0;
            this.chbParfümverwaltung.Text = "Berechtigung für Parfümverwaltung";
            this.chbParfümverwaltung.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateNeueUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 600);
            this.Controls.Add(this.gbUserdaten);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.gbPermission);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateNeueUser";
            this.Text = "Add-Update-NeueUser";
            this.Load += new System.EventHandler(this.frmAddUpdateNeueUser_Load);
            this.gbUserdaten.ResumeLayout(false);
            this.gbUserdaten.PerformLayout();
            this.gbPermission.ResumeLayout(false);
            this.gbPermission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUserdaten;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMitarbeiterID;
        private System.Windows.Forms.CheckBox chbIstAktive;
        private System.Windows.Forms.TextBox txtUserPasswort;
        private System.Windows.Forms.TextBox txtUserrolle;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.GroupBox gbPermission;
        private System.Windows.Forms.CheckBox chbAdminBerechtigung;
        private System.Windows.Forms.CheckBox chbLageverwaltung;
        private System.Windows.Forms.CheckBox chbMitarbeiterverwaltung;
        private System.Windows.Forms.CheckBox chbKundeverwaltung;
        private System.Windows.Forms.CheckBox chbParfümverwaltung;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chbUserverwaltung;
    }
}