using Busnisse_Layer;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parfüm2025
{
    public partial class frmPreisKategorieListe : Form
    {
        public enum enMode { addnew = 0, update = 1, SeheDetails = 2 }
        public enMode _mode = enMode.addnew;

        DataTable _dtPreiskategorie;
        BindingSource _bindingSource;
        private readonly object _lackObject = new object();
        clsPreise _preisDaten;

        public frmPreisKategorieListe()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();

        }
        private void _SetzePreisKategorie()
        {
            _dtPreiskategorie = clsPreise.GetAllPreise();
            _bindingSource.DataSource = _dtPreiskategorie;
            dgvPreisKategorie.DataSource = _bindingSource;
        }
        private void frmPreisKategorieListe_Load(object sender, EventArgs e)
        {
            _SetzePreisDatenAufStandardWerte();
            _SetzePreisKategorie();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetzePreisDatenAufStandardWerte()
        {
            _mode = enMode.addnew;
            txtKategorie.Clear();
            txtMiniMenge.Clear();
            txtMaxMenge.Clear();
            txtPreisProEinheit.Clear();
            btnSpeichern.Text = "Speichern";
        }
        private void _LadePreisKategorie(int preisID)
        {
            lock (_lackObject)
            {
                try
                {
                    _preisDaten = clsPreise.Find(preisID);
                    if (_preisDaten == null)
                    {
                        MessageBox.Show("Die Preisdaten konnten nicht gefunden werden.", "Fehler",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    txtKategorie.Text =_preisDaten.kategorie.ToString();
                    txtMiniMenge.Text = _preisDaten.miniMenge.ToString();
                    txtMaxMenge.Text = _preisDaten.maxMenge.ToString();
                    txtPreisProEinheit.Text = _preisDaten.preisProEinheit.ToString();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}", "Fehler",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Ein Formatierungsfehler ist aufgetreten: {ex.Message}", "Fehler",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ein allgemeiner Fehler ist aufgetreten: {ex.Message}", "Fehler",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void _FüllePreisDaten()
        {
            if (_mode == enMode.addnew)
            {
                _preisDaten = new clsPreise();
            }
             
            _preisDaten.kategorie = Convert.ToInt32(txtKategorie.Text);
            _preisDaten.miniMenge = Convert.ToInt32(txtMiniMenge.Text);
            _preisDaten.maxMenge = Convert.ToInt32(txtMaxMenge.Text);
            _preisDaten.preisProEinheit = Convert.ToSingle(txtPreisProEinheit.Text);
        }
        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (!_ValiederePreiDaten())
                return;

            _FüllePreisDaten();

            if(_preisDaten.Save())
            {
                MessageBox.Show($"PreisDaten erfolgreich {(_mode == enMode.addnew ? "hinzugefügt" : "aktualisiert")}", "Erfolg",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

                _mode = enMode.update; // wir aktualisieren den Object.
                _SetzePreisDatenAufStandardWerte(); // wir setzten die eingaben zurück.
                _SetzePreisKategorie();
            }
            else
                MessageBox.Show("Fehler beim Speichern der PreisDaten ist aufgetreten", "Fehlermeldung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool _ValidiereEinFeld(TextBox txtboxName, string name)
        {
            if (string.IsNullOrEmpty(txtboxName.Text))
            {
                errorProvider1.SetError(txtboxName, $"{name} darf nicht leer sein!");
                txtboxName.BackColor = Color.LightPink;  // Hintergrundfarbe ändern
                txtboxName.BorderStyle = BorderStyle.FixedSingle;

                return false;
            }
            else
            {
                errorProvider1.SetError(txtboxName, null);
                txtboxName.BackColor = Color.White;  // Standardfarbe wiederherstellen
                txtboxName.BorderStyle = BorderStyle.FixedSingle;
            }

            return true;
        }

        private bool _ValiederePreiDaten()
        {
            bool isValid = true;

            isValid = _ValidiereEinFeld(txtKategorie, "Kategorie");
            isValid &= _ValidiereEinFeld(txtMiniMenge, "MiniMenge");
            isValid &= _ValidiereEinFeld(txtMaxMenge, "MaxMenge");
            isValid &= _ValidiereEinFeld(txtPreisProEinheit, "Preis");

            return isValid; // Gibt zurück, ob alle Felder gültig sind
        }

        private void dgvPreisKategorie_DoubleClick(object sender, EventArgs e)
        {
            int preisID = (int)dgvPreisKategorie.CurrentRow.Cells[0].Value;
            _LadePreisKategorie(preisID);
            _mode = enMode.update;
            btnSpeichern.Text = "Aktualisieren";

            _SetzePreisKategorie();
        }

        private void entfernePreisdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = MessageBox.Show("Möchten Sie wirklich diesen Vorgangen durchführen", "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes;

            if (!result)
                return;

            int preisID = (int)dgvPreisKategorie.CurrentRow.Cells[0].Value;
            _preisDaten = clsPreise.Find(preisID);

            if (_preisDaten != null && _preisDaten.Delete())
            {
                MessageBox.Show("Die Preisdaten wurden erfolgreich entfernt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _SetzePreisKategorie();
            }
            else
            {
                MessageBox.Show("Das Entfernen der Preisdaten ist fehlgeschlagen. Bitte versuchen Sie es erneut.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aktualisierePreisdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int preisID = (int)dgvPreisKategorie.CurrentRow.Cells[0].Value;
            _LadePreisKategorie(preisID);
            _mode = enMode.update;
            btnSpeichern.Text = "Aktualisieren";

            _SetzePreisKategorie();
        }
    }
}
