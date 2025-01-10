using Busnisse_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parfüm2025
{
    public partial class frmEinkaufsDatenListe : Form
    {
        DataTable _dtEinkaufsdaten;
        BindingSource _bindingSource;
        private readonly object _lockObject = new object();
        public frmEinkaufsDatenListe()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
        }

        private void btnHinzufügeNeueMenge_Click(object sender, EventArgs e)
        {
            frmAddUpdateNeueParfümMenge frm = new frmAddUpdateNeueParfümMenge(-1, frmAddUpdateNeueParfümMenge.enMode.addnew);
            frm.ShowDialog();

            _setzeEinkaufsDaten();
        }

        private void _setzeEinkaufsDaten()
        {
            _dtEinkaufsdaten = clsEinkauf.GetAllEinkaufDaten();
            _bindingSource.DataSource = _dtEinkaufsdaten;
            dgvLager.DataSource = _bindingSource;
        }
        private void frmLagerListe_Load(object sender, EventArgs e)
        {
            cbFilterbei.SelectedIndex = 0;
            cbFilterbei.DropDownStyle = ComboBoxStyle.DropDownList; // verhindert die ComboBox Einträge zu ändern.
             
            _setzeEinkaufsDaten();
        }

        private void btnAktualisereParfümMenge_Click(object sender, EventArgs e)
        {
            _setzeEinkaufsDaten();  // Nur zum Aktualisieren....
        }

        private void aktualisiereParfümMengeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int parfümNummer = (int)dgvLager.CurrentRow.Cells[0].Value;
            frmAddUpdateNeueParfümMenge frm = new frmAddUpdateNeueParfümMenge(parfümNummer, frmAddUpdateNeueParfümMenge.enMode.update);
            frm.ShowDialog();

            _setzeEinkaufsDaten();
        }

        private void entferneParfümToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int parfümNummer = (int)dgvLager.CurrentRow.Cells[0].Value;

            clsEinkauf einkaufdaten = clsEinkauf.FindEinkaufDatenByParfümNummer(parfümNummer);

            bool result = (MessageBox.Show("Sind Sie sicher, Sie möchten diesen Vorgang durchführen?", "Hinweis",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);

            if (!result)
                return;

            if(result && einkaufdaten != null && einkaufdaten.Delete())
            {
                MessageBox.Show("Einkaufsdaten erfolgreich entfernt", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _setzeEinkaufsDaten();
            }
            else
                MessageBox.Show("Fehler beim Entfernen der Einkaufsdaten ist aufgetreten.", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbFilterbei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterbei.SelectedIndex != -1)
            {
                txtFilerwert.Clear();
                txtFilerwert.Focus();
            }
        }

        private void _Filteranwenden()
        {
            string filterspalte = cbFilterbei.SelectedItem.ToString();
            string filterwert = txtFilerwert.Text.Trim();

            lock (_lockObject)
            {
                if (!string.IsNullOrEmpty(filterwert))
                {
                    if (filterspalte == "ParfümName")
                    {
                        _bindingSource.Filter = $"{filterspalte} Like '{filterwert}%'";
                    }
                    else if (filterspalte == "ParfümNummer")
                        _bindingSource.Filter = $"{filterspalte} = {filterwert}";
                }
                else
                {
                    _bindingSource.Filter = string.Empty;
                }
            }
        }
        private void txtFilerwert_TextChanged(object sender, EventArgs e)
        {
            _Filteranwenden();
        }

        private void txtFilerwert_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterbei.SelectedItem.ToString() == "ParfümNummer")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void seheVerkaufsDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int parfümNummer = (int)dgvLager.CurrentRow.Cells[0].Value;
            frmAddUpdateNeueParfümMenge frm = new frmAddUpdateNeueParfümMenge(parfümNummer,frmAddUpdateNeueParfümMenge.enMode.sehedetails);
            frm.ShowDialog();
        }
    }
}
