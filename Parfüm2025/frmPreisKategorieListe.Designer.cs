namespace Parfüm2025
{
    partial class frmPreisKategorieListe
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
            this.dgvPreisKategorie = new System.Windows.Forms.DataGridView();
            this.cmsPreisKategorie = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.entfernePreisdatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualisierePreisdatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPreisProEinheit = new System.Windows.Forms.TextBox();
            this.txtMaxMenge = new System.Windows.Forms.TextBox();
            this.txtMiniMenge = new System.Windows.Forms.TextBox();
            this.txtKategorie = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreisKategorie)).BeginInit();
            this.cmsPreisKategorie.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreisKategorie
            // 
            this.dgvPreisKategorie.AllowUserToAddRows = false;
            this.dgvPreisKategorie.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPreisKategorie.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreisKategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreisKategorie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreisKategorie.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreisKategorie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPreisKategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreisKategorie.ContextMenuStrip = this.cmsPreisKategorie;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreisKategorie.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPreisKategorie.EnableHeadersVisualStyles = false;
            this.dgvPreisKategorie.Location = new System.Drawing.Point(285, 0);
            this.dgvPreisKategorie.Name = "dgvPreisKategorie";
            this.dgvPreisKategorie.ReadOnly = true;
            this.dgvPreisKategorie.RowTemplate.Height = 25;
            this.dgvPreisKategorie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreisKategorie.ShowEditingIcon = false;
            this.dgvPreisKategorie.Size = new System.Drawing.Size(859, 430);
            this.dgvPreisKategorie.TabIndex = 0;
            this.dgvPreisKategorie.DoubleClick += new System.EventHandler(this.dgvPreisKategorie_DoubleClick);
            // 
            // cmsPreisKategorie
            // 
            this.cmsPreisKategorie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsPreisKategorie.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entfernePreisdatenToolStripMenuItem,
            this.aktualisierePreisdatenToolStripMenuItem});
            this.cmsPreisKategorie.Name = "cmsPreisKategorie";
            this.cmsPreisKategorie.Size = new System.Drawing.Size(255, 80);
            // 
            // entfernePreisdatenToolStripMenuItem
            // 
            this.entfernePreisdatenToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.delete_5953478__1_;
            this.entfernePreisdatenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.entfernePreisdatenToolStripMenuItem.Name = "entfernePreisdatenToolStripMenuItem";
            this.entfernePreisdatenToolStripMenuItem.Size = new System.Drawing.Size(254, 38);
            this.entfernePreisdatenToolStripMenuItem.Text = "Entferne Preisdaten";
            this.entfernePreisdatenToolStripMenuItem.Click += new System.EventHandler(this.entfernePreisdatenToolStripMenuItem_Click);
            // 
            // aktualisierePreisdatenToolStripMenuItem
            // 
            this.aktualisierePreisdatenToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.refresh_5791276;
            this.aktualisierePreisdatenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aktualisierePreisdatenToolStripMenuItem.Name = "aktualisierePreisdatenToolStripMenuItem";
            this.aktualisierePreisdatenToolStripMenuItem.Size = new System.Drawing.Size(254, 38);
            this.aktualisierePreisdatenToolStripMenuItem.Text = "Aktualisiere Preisdaten";
            this.aktualisierePreisdatenToolStripMenuItem.Click += new System.EventHandler(this.aktualisierePreisdatenToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.btnAbbrechen);
            this.groupBox1.Controls.Add(this.btnSpeichern);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPreisProEinheit);
            this.groupBox1.Controls.Add(this.txtMaxMenge);
            this.groupBox1.Controls.Add(this.txtMiniMenge);
            this.groupBox1.Controls.Add(this.txtKategorie);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 430);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(104, 325);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(159, 29);
            this.btnAbbrechen.TabIndex = 9;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(104, 276);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(159, 29);
            this.btnSpeichern.TabIndex = 8;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Preis:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "MaxMenge:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "MiniMenge:*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategorie:*";
            // 
            // txtPreisProEinheit
            // 
            this.txtPreisProEinheit.Location = new System.Drawing.Point(104, 212);
            this.txtPreisProEinheit.Name = "txtPreisProEinheit";
            this.txtPreisProEinheit.Size = new System.Drawing.Size(159, 26);
            this.txtPreisProEinheit.TabIndex = 3;
            // 
            // txtMaxMenge
            // 
            this.txtMaxMenge.Location = new System.Drawing.Point(104, 167);
            this.txtMaxMenge.Name = "txtMaxMenge";
            this.txtMaxMenge.Size = new System.Drawing.Size(159, 26);
            this.txtMaxMenge.TabIndex = 2;
            // 
            // txtMiniMenge
            // 
            this.txtMiniMenge.Location = new System.Drawing.Point(104, 121);
            this.txtMiniMenge.Name = "txtMiniMenge";
            this.txtMiniMenge.Size = new System.Drawing.Size(159, 26);
            this.txtMiniMenge.TabIndex = 1;
            // 
            // txtKategorie
            // 
            this.txtKategorie.Location = new System.Drawing.Point(104, 75);
            this.txtKategorie.Name = "txtKategorie";
            this.txtKategorie.Size = new System.Drawing.Size(159, 26);
            this.txtKategorie.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPreisKategorieListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 430);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPreisKategorie);
            this.Name = "frmPreisKategorieListe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preis-KategorieListe";
            this.Load += new System.EventHandler(this.frmPreisKategorieListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreisKategorie)).EndInit();
            this.cmsPreisKategorie.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreisKategorie;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKategorie;
        private System.Windows.Forms.TextBox txtPreisProEinheit;
        private System.Windows.Forms.TextBox txtMaxMenge;
        private System.Windows.Forms.TextBox txtMiniMenge;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip cmsPreisKategorie;
        private System.Windows.Forms.ToolStripMenuItem entfernePreisdatenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktualisierePreisdatenToolStripMenuItem;
    }
}