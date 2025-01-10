using Busnisse_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parfüm2025
{
    public partial class frmPreisKategorie : Form
    {
        List<clsPreise> _preisListe;
        public frmPreisKategorie(List<clsPreise> preisListe)
        {
            InitializeComponent();
            _preisListe = preisListe;
        }

        private void _SetzePreisListe()
        {
            dgvPreisKategorie.Rows.Clear();
            if(_preisListe.Count > 0)
            {
                foreach (var item in _preisListe)
                    dgvPreisKategorie.Rows.Add(item.kategorie, item.miniMenge, item.maxMenge, item.preisProEinheit);
            }
        }

        private void frmPreisKategorie_Load(object sender, EventArgs e)
        {
            _SetzePreisListe();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPreisKategorie = new System.Windows.Forms.DataGridView();
            this.Kategorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiniMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreisProEinheit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreisKategorie)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreisKategorie
            // 
            this.dgvPreisKategorie.AllowUserToAddRows = false;
            this.dgvPreisKategorie.AllowUserToDeleteRows = false;
            this.dgvPreisKategorie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreisKategorie.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreisKategorie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPreisKategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreisKategorie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kategorie,
            this.MiniMenge,
            this.MaxMenge,
            this.PreisProEinheit});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreisKategorie.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPreisKategorie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreisKategorie.EnableHeadersVisualStyles = false;
            this.dgvPreisKategorie.Location = new System.Drawing.Point(0, 0);
            this.dgvPreisKategorie.Name = "dgvPreisKategorie";
            this.dgvPreisKategorie.ReadOnly = true;
            this.dgvPreisKategorie.RowTemplate.Height = 30;
            this.dgvPreisKategorie.Size = new System.Drawing.Size(618, 168);
            this.dgvPreisKategorie.TabIndex = 0;
            // 
            // Kategorie
            // 
            this.Kategorie.HeaderText = "Kategorie";
            this.Kategorie.Name = "Kategorie";
            this.Kategorie.ReadOnly = true;
            this.Kategorie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MiniMenge
            // 
            this.MiniMenge.HeaderText = "MiniMenge";
            this.MiniMenge.Name = "MiniMenge";
            this.MiniMenge.ReadOnly = true;
            this.MiniMenge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaxMenge
            // 
            this.MaxMenge.HeaderText = "MaxMenge";
            this.MaxMenge.Name = "MaxMenge";
            this.MaxMenge.ReadOnly = true;
            this.MaxMenge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PreisProEinheit
            // 
            this.PreisProEinheit.HeaderText = "PreisProEinheit";
            this.PreisProEinheit.Name = "PreisProEinheit";
            this.PreisProEinheit.ReadOnly = true;
            this.PreisProEinheit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmPreisKategorie
            // 
            this.ClientSize = new System.Drawing.Size(618, 168);
            this.Controls.Add(this.dgvPreisKategorie);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreisKategorie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preis-Kategorie";
            this.Load += new System.EventHandler(this.frmPreisKategorie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreisKategorie)).EndInit();
            this.ResumeLayout(false);

        }

        private DataGridView dgvPreisKategorie;
        private DataGridViewTextBoxColumn Kategorie;
        private DataGridViewTextBoxColumn MiniMenge;
        private DataGridViewTextBoxColumn MaxMenge;
        private DataGridViewTextBoxColumn PreisProEinheit;

    }
}
