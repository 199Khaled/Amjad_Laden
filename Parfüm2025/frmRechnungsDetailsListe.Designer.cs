namespace Parfüm2025
{
    partial class frmRechnungsDetailsListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRechnungsDetailsListe));
            this.dgvRechnungsdetails = new System.Windows.Forms.DataGridView();
            this.DetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BelegID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParfümNummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verkaufsmenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lagerbestand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Normalpreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gesamtpreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LagerbestandAktualisiert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HinzufügeRechnungsdetailstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualisiereRechnungsdetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entferneRechnungsdetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddRechnungsDetails = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRealisiereRechnungsdetails = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechnungsdetails)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRechnungsdetails
            // 
            this.dgvRechnungsdetails.AllowUserToAddRows = false;
            this.dgvRechnungsdetails.AllowUserToDeleteRows = false;
            this.dgvRechnungsdetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRechnungsdetails.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRechnungsdetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRechnungsdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechnungsdetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailID,
            this.BelegID,
            this.ParfümNummer,
            this.Verkaufsmenge,
            this.Lagerbestand,
            this.Normalpreis,
            this.Gesamtpreis,
            this.LagerbestandAktualisiert});
            this.dgvRechnungsdetails.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRechnungsdetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRechnungsdetails.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.dgvRechnungsdetails, "dgvRechnungsdetails");
            this.dgvRechnungsdetails.MultiSelect = false;
            this.dgvRechnungsdetails.Name = "dgvRechnungsdetails";
            this.dgvRechnungsdetails.ReadOnly = true;
            this.dgvRechnungsdetails.RowTemplate.Height = 25;
            this.dgvRechnungsdetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRechnungsdetails.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvRechnungsdetails_RowsAdded);
            // 
            // DetailID
            // 
            this.DetailID.FillWeight = 30F;
            resources.ApplyResources(this.DetailID, "DetailID");
            this.DetailID.Name = "DetailID";
            this.DetailID.ReadOnly = true;
            this.DetailID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BelegID
            // 
            this.BelegID.FillWeight = 30F;
            resources.ApplyResources(this.BelegID, "BelegID");
            this.BelegID.Name = "BelegID";
            this.BelegID.ReadOnly = true;
            this.BelegID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ParfümNummer
            // 
            this.ParfümNummer.FillWeight = 30F;
            resources.ApplyResources(this.ParfümNummer, "ParfümNummer");
            this.ParfümNummer.Name = "ParfümNummer";
            this.ParfümNummer.ReadOnly = true;
            this.ParfümNummer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Verkaufsmenge
            // 
            this.Verkaufsmenge.FillWeight = 40F;
            resources.ApplyResources(this.Verkaufsmenge, "Verkaufsmenge");
            this.Verkaufsmenge.Name = "Verkaufsmenge";
            this.Verkaufsmenge.ReadOnly = true;
            this.Verkaufsmenge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lagerbestand
            // 
            this.Lagerbestand.FillWeight = 40F;
            resources.ApplyResources(this.Lagerbestand, "Lagerbestand");
            this.Lagerbestand.Name = "Lagerbestand";
            this.Lagerbestand.ReadOnly = true;
            this.Lagerbestand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Normalpreis
            // 
            this.Normalpreis.FillWeight = 30F;
            resources.ApplyResources(this.Normalpreis, "Normalpreis");
            this.Normalpreis.Name = "Normalpreis";
            this.Normalpreis.ReadOnly = true;
            this.Normalpreis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Gesamtpreis
            // 
            this.Gesamtpreis.FillWeight = 30F;
            resources.ApplyResources(this.Gesamtpreis, "Gesamtpreis");
            this.Gesamtpreis.Name = "Gesamtpreis";
            this.Gesamtpreis.ReadOnly = true;
            this.Gesamtpreis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LagerbestandAktualisiert
            // 
            this.LagerbestandAktualisiert.FillWeight = 40F;
            resources.ApplyResources(this.LagerbestandAktualisiert, "LagerbestandAktualisiert");
            this.LagerbestandAktualisiert.Name = "LagerbestandAktualisiert";
            this.LagerbestandAktualisiert.ReadOnly = true;
            this.LagerbestandAktualisiert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HinzufügeRechnungsdetailstoolStripMenuItem1,
            this.aktualisiereRechnungsdetailsToolStripMenuItem,
            this.entferneRechnungsdetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // HinzufügeRechnungsdetailstoolStripMenuItem1
            // 
            resources.ApplyResources(this.HinzufügeRechnungsdetailstoolStripMenuItem1, "HinzufügeRechnungsdetailstoolStripMenuItem1");
            this.HinzufügeRechnungsdetailstoolStripMenuItem1.Image = global::Parfüm2025.Properties.Resources.plus_10021331;
            this.HinzufügeRechnungsdetailstoolStripMenuItem1.Name = "HinzufügeRechnungsdetailstoolStripMenuItem1";
            this.HinzufügeRechnungsdetailstoolStripMenuItem1.Click += new System.EventHandler(this.HinzufügeRechnungsdetailstoolStripMenuItem1_Click);
            // 
            // aktualisiereRechnungsdetailsToolStripMenuItem
            // 
            resources.ApplyResources(this.aktualisiereRechnungsdetailsToolStripMenuItem, "aktualisiereRechnungsdetailsToolStripMenuItem");
            this.aktualisiereRechnungsdetailsToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.refresh_5791276;
            this.aktualisiereRechnungsdetailsToolStripMenuItem.Name = "aktualisiereRechnungsdetailsToolStripMenuItem";
            this.aktualisiereRechnungsdetailsToolStripMenuItem.Click += new System.EventHandler(this.aktualisiereRechnungsdetailsToolStripMenuItem_Click);
            // 
            // entferneRechnungsdetailsToolStripMenuItem
            // 
            resources.ApplyResources(this.entferneRechnungsdetailsToolStripMenuItem, "entferneRechnungsdetailsToolStripMenuItem");
            this.entferneRechnungsdetailsToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.delete_5953478__1_;
            this.entferneRechnungsdetailsToolStripMenuItem.Name = "entferneRechnungsdetailsToolStripMenuItem";
            this.entferneRechnungsdetailsToolStripMenuItem.Click += new System.EventHandler(this.entferneRechnungsdetailsToolStripMenuItem_Click);
            // 
            // btnAddRechnungsDetails
            // 
            this.btnAddRechnungsDetails.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.btnAddRechnungsDetails, "btnAddRechnungsDetails");
            this.btnAddRechnungsDetails.ForeColor = System.Drawing.Color.White;
            this.btnAddRechnungsDetails.Name = "btnAddRechnungsDetails";
            this.btnAddRechnungsDetails.UseVisualStyleBackColor = false;
            this.btnAddRechnungsDetails.Click += new System.EventHandler(this.btnAddRechnungsDetails_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRealisiereRechnungsdetails
            // 
            this.btnRealisiereRechnungsdetails.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.btnRealisiereRechnungsdetails, "btnRealisiereRechnungsdetails");
            this.btnRealisiereRechnungsdetails.ForeColor = System.Drawing.Color.White;
            this.btnRealisiereRechnungsdetails.Name = "btnRealisiereRechnungsdetails";
            this.btnRealisiereRechnungsdetails.UseVisualStyleBackColor = false;
            this.btnRealisiereRechnungsdetails.Click += new System.EventHandler(this.btnRealisiereRechnungsdetails_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmRechnungsDetailsListe
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRealisiereRechnungsdetails);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddRechnungsDetails);
            this.Controls.Add(this.dgvRechnungsdetails);
            this.MaximizeBox = false;
            this.Name = "frmRechnungsDetailsListe";
            this.Load += new System.EventHandler(this.frmRechnungsDetailsListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechnungsdetails)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRechnungsdetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aktualisiereRechnungsdetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entferneRechnungsdetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HinzufügeRechnungsdetailstoolStripMenuItem1;
        private System.Windows.Forms.Button btnAddRechnungsDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRealisiereRechnungsdetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BelegID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParfümNummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verkaufsmenge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lagerbestand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Normalpreis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gesamtpreis;
        private System.Windows.Forms.DataGridViewTextBoxColumn LagerbestandAktualisiert;
        private System.Windows.Forms.Button button2;
    }
}