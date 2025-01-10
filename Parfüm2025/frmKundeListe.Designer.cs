namespace Parfüm2025
{
    partial class frmKundeListe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAktualisieren = new System.Windows.Forms.Button();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterbei = new System.Windows.Forms.ComboBox();
            this.txtFilterwert = new System.Windows.Forms.TextBox();
            this.btnHinzufügen = new System.Windows.Forms.Button();
            this.dgvKunde = new System.Windows.Forms.DataGridView();
            this.cmsKunde = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seheKundeDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualisiereKundedatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entferneKundedatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deaktiviereKundeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktiviereKundeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendeEmailZumKundenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunde)).BeginInit();
            this.cmsKunde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAktualisieren
            // 
            this.btnAktualisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAktualisieren.BackColor = System.Drawing.Color.Gold;
            this.btnAktualisieren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAktualisieren.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAktualisieren.Location = new System.Drawing.Point(855, 272);
            this.btnAktualisieren.Name = "btnAktualisieren";
            this.btnAktualisieren.Size = new System.Drawing.Size(280, 43);
            this.btnAktualisieren.TabIndex = 16;
            this.btnAktualisieren.Text = "Akutalisiere Kundedaten";
            this.btnAktualisieren.UseVisualStyleBackColor = false;
            this.btnAktualisieren.Click += new System.EventHandler(this.btnAktualisieren_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(100, 689);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(39, 20);
            this.lblRecord.TabIndex = 15;
            this.lblRecord.Text = "###";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 689);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Record:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Filter bei:";
            // 
            // cbFilterbei
            // 
            this.cbFilterbei.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterbei.FormattingEnabled = true;
            this.cbFilterbei.Items.AddRange(new object[] {
            "KundenName",
            "KundeID"});
            this.cbFilterbei.Location = new System.Drawing.Point(115, 286);
            this.cbFilterbei.Name = "cbFilterbei";
            this.cbFilterbei.Size = new System.Drawing.Size(175, 28);
            this.cbFilterbei.TabIndex = 12;
            this.cbFilterbei.SelectedIndexChanged += new System.EventHandler(this.cbFilterbei_SelectedIndexChanged);
            // 
            // txtFilterwert
            // 
            this.txtFilterwert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterwert.Location = new System.Drawing.Point(296, 286);
            this.txtFilterwert.Name = "txtFilterwert";
            this.txtFilterwert.Size = new System.Drawing.Size(451, 29);
            this.txtFilterwert.TabIndex = 11;
            this.txtFilterwert.TextChanged += new System.EventHandler(this.txtFilterwert_TextChanged);
            this.txtFilterwert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterwert_KeyPress);
            // 
            // btnHinzufügen
            // 
            this.btnHinzufügen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHinzufügen.BackColor = System.Drawing.Color.Gold;
            this.btnHinzufügen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHinzufügen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHinzufügen.Location = new System.Drawing.Point(1141, 271);
            this.btnHinzufügen.Name = "btnHinzufügen";
            this.btnHinzufügen.Size = new System.Drawing.Size(280, 43);
            this.btnHinzufügen.TabIndex = 10;
            this.btnHinzufügen.Text = "Hinzufüge einen neuen Kunden";
            this.btnHinzufügen.UseVisualStyleBackColor = false;
            this.btnHinzufügen.Click += new System.EventHandler(this.btnHinzufügen_Click);
            // 
            // dgvKunde
            // 
            this.dgvKunde.AllowUserToAddRows = false;
            this.dgvKunde.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvKunde.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKunde.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKunde.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKunde.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKunde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKunde.ContextMenuStrip = this.cmsKunde;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKunde.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKunde.EnableHeadersVisualStyles = false;
            this.dgvKunde.Location = new System.Drawing.Point(28, 319);
            this.dgvKunde.MultiSelect = false;
            this.dgvKunde.Name = "dgvKunde";
            this.dgvKunde.ReadOnly = true;
            this.dgvKunde.RowHeadersWidth = 51;
            this.dgvKunde.RowTemplate.Height = 30;
            this.dgvKunde.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKunde.Size = new System.Drawing.Size(1392, 352);
            this.dgvKunde.TabIndex = 9;
            this.dgvKunde.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKunde_CellContentClick);
            // 
            // cmsKunde
            // 
            this.cmsKunde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsKunde.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsKunde.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seheKundeDetailsToolStripMenuItem,
            this.aktualisiereKundedatenToolStripMenuItem,
            this.entferneKundedatenToolStripMenuItem,
            this.deaktiviereKundeToolStripMenuItem,
            this.aktiviereKundeToolStripMenuItem,
            this.sendeEmailZumKundenToolStripMenuItem});
            this.cmsKunde.Name = "cmsKunde";
            this.cmsKunde.Size = new System.Drawing.Size(273, 232);
            // 
            // seheKundeDetailsToolStripMenuItem
            // 
            this.seheKundeDetailsToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.PersonDetails_32;
            this.seheKundeDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.seheKundeDetailsToolStripMenuItem.Name = "seheKundeDetailsToolStripMenuItem";
            this.seheKundeDetailsToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.seheKundeDetailsToolStripMenuItem.Text = "Sehe Kunde Details";
            this.seheKundeDetailsToolStripMenuItem.Click += new System.EventHandler(this.seheKundeDetailsToolStripMenuItem_Click);
            // 
            // aktualisiereKundedatenToolStripMenuItem
            // 
            this.aktualisiereKundedatenToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.recycle_171638181;
            this.aktualisiereKundedatenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aktualisiereKundedatenToolStripMenuItem.Name = "aktualisiereKundedatenToolStripMenuItem";
            this.aktualisiereKundedatenToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.aktualisiereKundedatenToolStripMenuItem.Text = "Aktualisiere Kundedaten";
            this.aktualisiereKundedatenToolStripMenuItem.Click += new System.EventHandler(this.aktualisiereKundedatenToolStripMenuItem_Click);
            // 
            // entferneKundedatenToolStripMenuItem
            // 
            this.entferneKundedatenToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.Delete_32;
            this.entferneKundedatenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.entferneKundedatenToolStripMenuItem.Name = "entferneKundedatenToolStripMenuItem";
            this.entferneKundedatenToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.entferneKundedatenToolStripMenuItem.Text = "Entferne Kundedaten";
            this.entferneKundedatenToolStripMenuItem.Click += new System.EventHandler(this.entferneKundedatenToolStripMenuItem_Click);
            // 
            // deaktiviereKundeToolStripMenuItem
            // 
            this.deaktiviereKundeToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.unemployed_97729491;
            this.deaktiviereKundeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deaktiviereKundeToolStripMenuItem.Name = "deaktiviereKundeToolStripMenuItem";
            this.deaktiviereKundeToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.deaktiviereKundeToolStripMenuItem.Text = "Deaktiviere Kunde";
            this.deaktiviereKundeToolStripMenuItem.Click += new System.EventHandler(this.deaktiviereKundeToolStripMenuItem_Click_1);
            // 
            // aktiviereKundeToolStripMenuItem
            // 
            this.aktiviereKundeToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.tester_41572771;
            this.aktiviereKundeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aktiviereKundeToolStripMenuItem.Name = "aktiviereKundeToolStripMenuItem";
            this.aktiviereKundeToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.aktiviereKundeToolStripMenuItem.Text = "Aktiviere Kunde";
            this.aktiviereKundeToolStripMenuItem.Click += new System.EventHandler(this.aktiviereKundeToolStripMenuItem_Click_1);
            // 
            // sendeEmailZumKundenToolStripMenuItem
            // 
            this.sendeEmailZumKundenToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.email_15254895;
            this.sendeEmailZumKundenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendeEmailZumKundenToolStripMenuItem.Name = "sendeEmailZumKundenToolStripMenuItem";
            this.sendeEmailZumKundenToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.sendeEmailZumKundenToolStripMenuItem.Text = "Sende Email zum Kunden";
            this.sendeEmailZumKundenToolStripMenuItem.Click += new System.EventHandler(this.sendeEmailZumKundenToolStripMenuItem_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gold;
            this.pictureBox1.Image = global::Parfüm2025.Properties.Resources.Alowidat_Final_Logo_02;
            this.pictureBox1.Location = new System.Drawing.Point(26, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1394, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // frmKundeListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 718);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAktualisieren);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterbei);
            this.Controls.Add(this.txtFilterwert);
            this.Controls.Add(this.btnHinzufügen);
            this.Controls.Add(this.dgvKunde);
            this.Name = "frmKundeListe";
            this.Text = "frmKundeListe";
            this.Load += new System.EventHandler(this.frmKundeListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunde)).EndInit();
            this.cmsKunde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAktualisieren;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterbei;
        private System.Windows.Forms.TextBox txtFilterwert;
        private System.Windows.Forms.Button btnHinzufügen;
        private System.Windows.Forms.DataGridView dgvKunde;
        private System.Windows.Forms.ContextMenuStrip cmsKunde;
        private System.Windows.Forms.ToolStripMenuItem seheKundeDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktualisiereKundedatenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entferneKundedatenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deaktiviereKundeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktiviereKundeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendeEmailZumKundenToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}