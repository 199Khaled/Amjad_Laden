using Busnisse_Layer;
using clsHilfsMethoden;
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
    public partial class frmKundeSucheFilter : Form
    {
        private readonly object _autoComplateLock = new object();
        public frmKundeSucheFilter()
        {
            InitializeComponent();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuche_Click(object sender, EventArgs e)
        {
            string kundename = txtKundeSuche.Text.Trim();
            frmKundenSucheAnsicht frm = new frmKundenSucheAnsicht(kundename);
            frm.ShowDialog();
        }

        private void lbVorschläge_Click(object sender, EventArgs e)
        {
            if (lbVorschläge.Items.Count == 0)
            {
                MessageBox.Show("Die Liste ist leer.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //wir setzen den ausgewählten Vorschlag in das "txtFilterBeiName" Textfeld und verbergen wir  die listboxw
            if (lbVorschläge.SelectedItem != null)
            {
                string selectedItem = lbVorschläge.SelectedItem.ToString();
                txtKundeSuche.Text = selectedItem;
                lbVorschläge.Visible = false;
            }
            else
            {
                MessageBox.Show("Kein gültiger Eintrag ausgewählt.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void _AvlBaumImplemetierung()
        {
            DataTable dtkudenName = clsKunde.GetAllKundeName();
            if (dtkudenName == null)
                return;

            AutoComplete.AVLTree tree = new AutoComplete.AVLTree();

            foreach(DataRow row in dtkudenName.Rows)
            {
                tree.Insert(row["Vollname"].ToString());
            }

            string perfix = txtKundeSuche.Text.Trim();
            var vorschläge = tree.AutoComplete(perfix);

            _UpdateAutoComplateListBox(vorschläge);
        }
        private void _UpdateAutoComplateListBox(IEnumerable<string> vorschläge)
        {
            lock(_autoComplateLock)
            {
                lbVorschläge.Items.Clear();

                foreach(var vorschlag in vorschläge)
                {
                    lbVorschläge.Items.Add(vorschlag.ToString());
                }
                if(!string.IsNullOrEmpty(txtKundeSuche.Text))
                {
                    lbVorschläge.Visible = lbVorschläge.Items.Count > 0;
                }
                else
                {
                    lbVorschläge.Items.Clear();
                    lbVorschläge.Visible = false;
                }
            }
        }
        private void txtKundeSuche_TextChanged(object sender, EventArgs e)
        {
            _AvlBaumImplemetierung();
        }
    }
}
