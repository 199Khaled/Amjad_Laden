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
using Windows.ApplicationModel.VoiceCommands;

namespace Parfüm2025
{
    public partial class frmAddUpdateRechnung : Form
    {
        private readonly object _autoComplateLock = new object();

        public enum enMode { addnew = 0, update = 1, SeheDetails = 2 }
        public enMode _mode = enMode.addnew;
        private int _belegID;

        clsRechnung _rechnungsDaten;

        public frmAddUpdateRechnung(int belegID, enMode mode)
        {
            InitializeComponent();

            _belegID = belegID;
            _mode = mode;
        }

        private void _SetzteDatenAufStandardWerte()
        {
            txtBelegID.Text = "-1";
            txtKundenname.Clear();
            dtpErstellungsdatum.Value = DateTime.Now;
        }
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateRechnung_Load(object sender, EventArgs e)
        {
            _SetzteDatenAufStandardWerte();

            if (_mode == enMode.update)
            {
                _ladeRechnungDaten();
                lbVorschläge.Visible = false;
            }
            else if (_mode == enMode.SeheDetails)
            {
                btnSpeichern.Enabled = false;
                lbVorschläge.Visible = false;
                _ladeRechnungDaten();
            }
            else
            {
                _rechnungsDaten = new clsRechnung();  // Neue Insatanz der Klasse Rechnung erzeugen 
            }
        }

        private void _ladeRechnungDaten()
        {
            _rechnungsDaten = clsRechnung.Find(_belegID);
            if (_rechnungsDaten == null)
            {
                MessageBox.Show("Die Rechnungsdaten konnten nicht gefunden werden.", "Fehler",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtBelegID.Text = _rechnungsDaten.belegID.ToString();
            txtKundenname.Text = _rechnungsDaten.kundeInfos.Vollname;
            dtpErstellungsdatum.Value = _rechnungsDaten.erstellungsDatum;
        }

        private bool _FülleRechnungsdaten()
        {
          
            clsKunde kundedaten = clsKunde.FindKundeByPersonName(txtKundenname.Text.Trim());
            if (kundedaten == null)
            {
                MessageBox.Show("Dieser Kunde existiert leider nicht im system.\nBitte geben Sie einen gültigen Kunden ein.", "Fehlermeldung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Wir bearbeiten die Rechnungsdaten .  
            _rechnungsDaten.kundeID = kundedaten.kundeID;
            _rechnungsDaten.erstellungsDatum = dtpErstellungsdatum.Value.Date;

            return true;
        }
        private void _AvlBaumImplementierung()
        {
            DataTable kundenName = clsKunde.GetAllKundeName();
            if (kundenName == null)
                return;

            AutoComplete.AVLTree tree = new AutoComplete.AVLTree();

            foreach (DataRow row in kundenName.Rows)
            {
                tree.Insert(row["Vollname"].ToString());
            }

            string perfix = txtKundenname.Text.Trim();
            var completions = tree.AutoComplete(perfix);

            //wir aktualisieren die listbox, um vorschläge anzuzeigen.
            UpdateAutoCompleteListeBox(completions);

        }

        private void UpdateAutoCompleteListeBox(IEnumerable<string> completions)
        {
            lock (_autoComplateLock)
            {
                lbVorschläge.Items.Clear();

                //wir füllen dann die listebox mit vorschlägen
                foreach (var suggestion in completions)
                {
                    lbVorschläge.Items.Add(suggestion.ToString());
                }

                if (!string.IsNullOrEmpty(txtKundenname.Text.Trim()))
                {
                    //die liste wird angezeigt, wenn da Vorschläge gibt.
                    lbVorschläge.Visible = lbVorschläge.Items.Count > 0;
                }
                else
                {
                    lbVorschläge.Items.Clear();
                    lbVorschläge.Visible = false;
                }
            }
        }
        private void txtKundenname_TextChanged(object sender, EventArgs e)
        {
            _AvlBaumImplementierung();
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
                txtKundenname.Text = selectedItem;
                MessageBox.Show($"Ausgewählt: {selectedItem}");
                lbVorschläge.Visible = false;
            }
            else
            {
                MessageBox.Show("Kein gültiger Eintrag ausgewählt.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (!_FülleRechnungsdaten())
                return;

            if (_rechnungsDaten.Save())
            {

                MessageBox.Show($"Rechnungsdaten erfolgreich {(_mode == enMode.addnew ? "hinzugefügt" : "aktualisiert")}", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBelegID.Text = _rechnungsDaten.belegID.ToString();

                _mode = enMode.update; // wir aktualisieren den Object.
                this.Close();
            }
            else
                MessageBox.Show("Fehler beim Speichern der Rechnungsdetails ist aufgetreten", "Fehlermeldung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
