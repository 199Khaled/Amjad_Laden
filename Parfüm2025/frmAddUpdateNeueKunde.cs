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
    public partial class frmAddUpdateNeueKunde : Form
    {
        private int _personID;
        private bool _flage = true; //für Aktive und Inaktive
        clsKunde _kunde;
        private int _selectedPersonID = -1;
        enum enMode { addnew = 0, update = 1 }
        enMode _mode = enMode.addnew;
        private bool _seheDetails = false;
        private readonly object _lockObject = new object();
        public frmAddUpdateNeueKunde(int personID, bool seheDetails)
        {
            InitializeComponent();
            this._personID = personID;
            this._seheDetails = seheDetails;
        }

        private void _ResetDatenAufStandardWerte()
        {
            _EingestelltAmDatumEinrichten();

            txtPersonID.Text = "-1";
            txtKundeID.Text = "-1";
            txtFirmaName.Clear();
            dtpRegestriertAm.Value = DateTime.Now;
            chbIstAktive.Checked = true;
        }
        private void _EingestelltAmDatumEinrichten()
        {
            dtpRegestriertAm.Format = DateTimePickerFormat.Custom;
            dtpRegestriertAm.CustomFormat = "dd.MM.yyyy";
        }

        private void _fülleKundedaten()
        {
            _kunde.PersonID = _selectedPersonID;
            _kunde.firmaName = txtFirmaName.Text;
            _kunde.regestriertAm = dtpRegestriertAm.Value;
            _kunde.istAktive = chbIstAktive.Checked;
        }

        private void _ladeKundedaten()
        {
            lock (_lockObject)
            {
                _kunde = clsKunde.FindKundeByPersonID(_personID);

                if (_kunde != null)
                {
                    txtKundeID.Text = _kunde.kundeID.ToString();
                    txtPersonID.Text = _kunde.PersonID.ToString();
                    txtFirmaName.Text = _kunde.firmaName;
                    dtpRegestriertAm.Value = _kunde.regestriertAm;
                    chbIstAktive.Checked = _kunde.istAktive;
                }
                else
                {
                    MessageBox.Show("Der gesuchte Kunde wurde nicht gefunden.", "Fehlermeldung",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private bool _ValiedereMitarbeiterFelder()
        {
            bool isValid = _ValidiereEinFeld(txtFirmaName, "FirmaName");
            return isValid; // Gibt zurück, ob alle Felder gültig sind
        }
        private void _KundedatenSpeichern()
        {
            if (!_ValiedereMitarbeiterFelder())
                return;

            lock (_lockObject)
            {
                bool personGespeichert = ctrAddUpdatePerson1.speicherePersonDaten();

                if (_selectedPersonID == -1)
                    return;

                _fülleKundedaten();

                string status = string.Empty;
                if (_mode == enMode.update) { status = "Kundedaten wurden erfolgreich aktualisiert."; }
                else status = "Kundedaten wurden erfolgreich hinzugefügt.";


                if (personGespeichert && _kunde.Save())
                {
                    _mode = enMode.update;
                    txtKundeID.Text = _kunde.kundeID.ToString();
                    MessageBox.Show($"{status}", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                    MessageBox.Show("Fehler beim Speichern ist aufgetreten", "fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            _KundedatenSpeichern();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateNeueKunde_Load(object sender, EventArgs e)
        {
            _ResetDatenAufStandardWerte();

            //wenn wir die Mitarbeiterdaten nur zum anzeigen aufrufen.
            if (_seheDetails)
            {
                ctrAddUpdatePerson1._GetPersonDetails(_personID);
                _ladeKundedaten();
                btnSpeichern.Enabled = false;
                return;
            }

            ctrAddUpdatePerson1.HandlePersondaten(_personID); // Wir bearbeiten die persondaten.

            if (_personID != -1)
            {
                //im fall aktualiesieren
                _mode = enMode.update;
                _ladeKundedaten();
                btnSpeichern.Enabled = !_seheDetails; // wenn die Kundedaten nur zum anzeigen aufgerufen werden.
            }
            else
            {
                //im fall addieren.
                _mode = enMode.addnew;
                _kunde = new clsKunde();
            }
        }

        private void chbIstAktive_CheckedChanged(object sender, EventArgs e)
        {
            if (_flage)
                chbIstAktive.Text = "Inaktive";
            else
                chbIstAktive.Text = "Aktive";

            _flage = !_flage;
        }

        private void ctrAddUpdatePerson1_OnSelectedPerson(int obj)
        {
            _selectedPersonID = obj;
            txtPersonID.Text = _selectedPersonID.ToString();
        }
    }
}
