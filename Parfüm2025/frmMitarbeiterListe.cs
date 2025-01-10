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
    public partial class frmMitarbeiterListe : Form
    {
        DataTable _dtmitarbeiter;
        BindingSource _bidingSource;
        public frmMitarbeiterListe()
        {
            InitializeComponent();
            _bidingSource = new BindingSource();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void _SetzeMitarbeiterdaten()
        {
            _dtmitarbeiter = clsMitarbeiter.GetAllMitarbeiterView();
            _bidingSource.DataSource = _dtmitarbeiter;
            dgvMitarbeiter.DataSource = _bidingSource;
        }

        private void btnAddnewMitarbeiter_Click(object sender, EventArgs e)
        {
            frmAddUpdateNeueMitarbeiter frm = new frmAddUpdateNeueMitarbeiter(-1, false);
            frm.ShowDialog();

            _SetzeMitarbeiterdaten();
        }

        private void _Filteranwenden()
        {
            string filterspalte = cbFilterBei.SelectedItem.ToString();
            string filterwert = txtFilterwert.Text.Trim();

            if (!string.IsNullOrEmpty(filterwert))
            {
                if (filterspalte == "Vollname")
                {
                    _bidingSource.Filter = $"{filterspalte} Like '{filterwert}%'";
                }
                else if (filterspalte == "MitarbeiterID")
                    _bidingSource.Filter = $"{filterspalte} = {filterwert}";
            }
            else
            {
                _bidingSource.Filter = string.Empty;
            }
            lblRecord.Text = _bidingSource.Count.ToString();

        }
        private void cbFilterBei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBei.SelectedIndex != -1)
            {
                txtFilterwert.Clear();
                txtFilterwert.Focus();
               // _bidingSource.Filter = string.Empty;
            }
        }

        private void txtFilterwert_TextChanged(object sender, EventArgs e)
        {
            _Filteranwenden();
        }

        private void frmMitarbeiterListe_Load(object sender, EventArgs e)
        {
            cbFilterBei.SelectedIndex = 0;
            // Verhindert, dass der Benutzer den Text ändert
            cbFilterBei.DropDownStyle = ComboBoxStyle.DropDownList;

            _SetzeMitarbeiterdaten();
        }

        private void seheMitarbeiterDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvMitarbeiter.CurrentRow.Cells[1].Value;

            frmAddUpdateNeueMitarbeiter frm = new frmAddUpdateNeueMitarbeiter(personID, true);
            frm.ShowDialog();
        }

        private void aktualisiereMitarbeiterdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvMitarbeiter.CurrentRow.Cells[1].Value;

            frmAddUpdateNeueMitarbeiter frm = new frmAddUpdateNeueMitarbeiter(personID, false);
            frm.ShowDialog();

            _SetzeMitarbeiterdaten();
        }

        private void entferneMitarbeiterdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = MessageBox.Show("Sind Sie sicher, Sie möchten diesen Vorgang durchführen?",
                      "Hinweis", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK;

            int mitarbeiterID = (int)dgvMitarbeiter.CurrentRow.Cells[0].Value;
            clsMitarbeiter mitarbeiter = clsMitarbeiter.FindMitarbeiterByID(mitarbeiterID);

            if (result && mitarbeiter != null && mitarbeiter.Delete())
            {
                MessageBox.Show("Der Vorgang wurde erfolgreich durchgeführt", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _SetzeMitarbeiterdaten();
            }
            else
                MessageBox.Show("Fehler ist aufgetreten!", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void deaktiviereMitarbeiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int mitarbeiterID = (int)dgvMitarbeiter.CurrentRow.Cells[0].Value;

            if(!clsMitarbeiter.deaktiviereMitarbeiter(mitarbeiterID))
            {
                MessageBox.Show("Mitarbeiter ist schon Inaktive!", "Hinweis");
                return;
            }

            _SetzeMitarbeiterdaten();
        }

        private void aktiviereMitarbeiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int mitarbeiterID = (int)dgvMitarbeiter.CurrentRow.Cells[0].Value;

            if(!clsMitarbeiter.aktiviereMitarbeiter(mitarbeiterID))
            {
                MessageBox.Show("Mitarbeiter ist schon Aktive!", "Hinweis");
                return;
            }
            _SetzeMitarbeiterdaten();
        }

        private void txtFilterwert_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBei.SelectedItem.ToString() == "MitarbeiterID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnAktualisieren_Click(object sender, EventArgs e)
        {
            _SetzeMitarbeiterdaten();
        }

        private void HinzufügeBenutzerrechtetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int mitarbeiterID = (int)dgvMitarbeiter.CurrentRow.Cells[0].Value;

            frmAddUpdateNeueUser frm = new frmAddUpdateNeueUser(mitarbeiterID, frmAddUpdateNeueUser.enMode.addnew);
            frm.ShowDialog();
        }

        private void AktualisiereBenutzerrechtetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int mitarbeiterID = (int)dgvMitarbeiter.CurrentRow.Cells[0].Value;

            frmAddUpdateNeueUser frm = new frmAddUpdateNeueUser(mitarbeiterID, frmAddUpdateNeueUser.enMode.update);
            frm.ShowDialog();
        }

        private void cmsMitarbeiter_Opening(object sender, CancelEventArgs e)
        {
            int mitarbeiterID = (int)dgvMitarbeiter.CurrentRow.Cells[0].Value;

            HinzufügeBenutzerrechtetoolStripMenuItem1.Enabled = (!clsUser.ExistUserForThisMitarbeiter(mitarbeiterID)); //falls der _persondaten user im system definiert.
            AktualisiereBenutzerrechtetoolStripMenuItem2.Enabled = (clsUser.ExistUserForThisMitarbeiter(mitarbeiterID));
        }
    }
}
