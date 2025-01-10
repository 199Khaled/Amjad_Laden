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
    public partial class frmKundeListe : Form
    {
        DataTable _dtKunde;
        BindingSource _bindingSource;
        public frmKundeListe()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
        }
        private void _setzeKundedaten()
        {
            _dtKunde = clsKunde.GetKundeView();
            _bindingSource.DataSource = _dtKunde;
            dgvKunde.DataSource = _bindingSource;

            lblRecord.Text = _bindingSource.Count.ToString();
        }
        private void frmKundeListe_Load(object sender, EventArgs e)
        {
            cbFilterbei.SelectedIndex = 0;
            cbFilterbei.DropDownStyle = ComboBoxStyle.DropDownList;

            _setzeKundedaten();
        }
        private void btnAktualisieren_Click(object sender, EventArgs e)
        {
            _setzeKundedaten();
        }
        private void _Filteranwenden()
        {
            string filterspalte = cbFilterbei.SelectedItem.ToString();
            string filterwert = txtFilterwert.Text.Trim();

            if (!string.IsNullOrEmpty(filterwert))
            {
                if (filterspalte == "KundenName")
                {
                    _bindingSource.Filter = $"{filterspalte} Like '{filterwert}%'";
                }
                else if (filterspalte == "KundeID")
                    _bindingSource.Filter = $"{filterspalte} = {filterwert}";
            }
            else
            {
                _bindingSource.Filter = string.Empty;
            }

            lblRecord.Text = _bindingSource.Count.ToString();
        }

        private void txtFilterwert_TextChanged(object sender, EventArgs e)
        {
            _Filteranwenden();
        }

        private void cbFilterbei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterbei.SelectedIndex != -1)
            {
                txtFilterwert.Clear();
                txtFilterwert.Focus();
                // _bidingSource.Filter = string.Empty;
            }
        }

        private void txtFilterwert_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterbei.SelectedItem.ToString() == "KundeID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void seheKundeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvKunde.CurrentRow.Cells[1].Value;
            frmAddUpdateNeueKunde frm = new frmAddUpdateNeueKunde(personID, true);
            frm.ShowDialog();
        }

        private void aktualisiereKundedatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvKunde.CurrentRow.Cells[1].Value;
            frmAddUpdateNeueKunde frm = new frmAddUpdateNeueKunde(personID, false);
            frm.ShowDialog();

            _setzeKundedaten();
        }

        private void entferneKundedatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = MessageBox.Show("Sind Sie sicher, Sie möchten diesen Vorgang durchführen?",
                     "Hinweis", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK;

            int kundeID = (int)dgvKunde.CurrentRow.Cells[0].Value;
            clsKunde kunde = clsKunde.FindKundeByID(kundeID);

            if (!result)
                return;

            if (kunde != null && kunde.Delete())
            {
                MessageBox.Show("Der Vorgang wurde erfolgreich durchgeführt", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _setzeKundedaten();
            }
            else
                MessageBox.Show("Fehler ist aufgetreten!", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
        private void btnHinzufügen_Click(object sender, EventArgs e)
        {
            frmAddUpdateNeueKunde frm = new frmAddUpdateNeueKunde(-1, false);
            frm.ShowDialog();

            _setzeKundedaten();
        }

        private void sendeEmailZumKundenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
             string empfaengerEmail = dgvKunde.CurrentRow.Cells[6].Value.ToString();

            // URL mit den Parametern für Gmail
            // string gmailUrl = $"https://mail.google.com/mail/u/0/?view=cm&fs=1&to={empfaengerEmail}";
            //string gmailUrl = //$"https://mail.google.com/mail/u/0/#inbox?compose=new";

            // Öffne die URL im Standard-Webbrowser
            //System.Diagnostics.Process.Start(gmailUrl);

            string outlock = $"mailto:{empfaengerEmail}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = outlock,
                UseShellExecute = true
            });
        }

        private void deaktiviereKundeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int kundeID = (int)dgvKunde.CurrentRow.Cells[0].Value;

            if (!clsKunde.deaktiviereKunde(kundeID))
            {
                MessageBox.Show("Der Kunde ist bereits Inaktive!!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _setzeKundedaten();
        }

        private void aktiviereKundeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int kundeID = (int)dgvKunde.CurrentRow.Cells[0].Value;

            if (!clsKunde.aktiviereKunde(kundeID))
            {
                MessageBox.Show("Der Kunde ist bereits aktive!!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _setzeKundedaten();
        }

        private void dgvKunde_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
