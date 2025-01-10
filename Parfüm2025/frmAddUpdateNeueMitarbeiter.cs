using Busnisse_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parfüm2025
{
    public partial class frmAddUpdateNeueMitarbeiter : Form
    {
        private int _personID;
        private bool _flage = true; //für Aktive und Inaktive
        clsMitarbeiter _mitarbeiter;
        private int _selectedPersonID = -1;
        enum enMode { addnew = 0, update = 1 }
        enMode _mode = enMode.addnew;
        private bool _seheDetails = false;

        public frmAddUpdateNeueMitarbeiter(int personID, bool SeheDetails)
        {
            InitializeComponent();
            this._personID = personID;
            _seheDetails = SeheDetails;
        }

        private void _ResetDatenAufStandardWerte()
        {
            _EingestelltAmDatumEinrichten();

            txtPersonID.Text = "-1";
            txtMitarbeiterID.Text = "-1";
            txtVersicherungsName.Clear();
            txtVersicherungsNummer.Clear();
            dtpEingestelltAm.Value = DateTime.Now;
            chbIstAktive.Checked = true;
        }
        private void _EingestelltAmDatumEinrichten()
        {
            dtpEingestelltAm.Format = DateTimePickerFormat.Custom;
            dtpEingestelltAm.CustomFormat = "dd.MM.yyyy";
        }
        private void _fülleMitarbeiterDaten()
        {
            _mitarbeiter.PersonID = _selectedPersonID;
            _mitarbeiter.VersicherungsName = txtVersicherungsName.Text;
            _mitarbeiter.VersicherungsNummer = txtVersicherungsNummer.Text;
            _mitarbeiter.EingestelltAm = dtpEingestelltAm.Value;
            _mitarbeiter.istAktive = chbIstAktive.Checked;
        }

        private void _ladeMitarbeiterDaten()
        {
            _mitarbeiter = clsMitarbeiter.FindMitarbeiterByPersonID(_personID);

            if (_mitarbeiter != null)
            {
                txtMitarbeiterID.Text = _mitarbeiter.MitarbeiterID.ToString();
                txtPersonID.Text = _mitarbeiter.PersonID.ToString();
                txtVersicherungsName.Text = _mitarbeiter.VersicherungsName;
                txtVersicherungsNummer.Text = _mitarbeiter.VersicherungsNummer;
                dtpEingestelltAm.Value = _mitarbeiter.EingestelltAm;
                chbIstAktive.Checked = _mitarbeiter.istAktive;
            }
        }
        private void frmAddUpdateNeueMitarbeiter_Load(object sender, EventArgs e)
        {
            _ResetDatenAufStandardWerte();

            //wenn wir die Mitarbeiterdaten nur zum anzeigen aufrufen.
            if(_seheDetails)
            {
                ctrAddUpdatePerson1._GetPersonDetails(_personID);
                _ladeMitarbeiterDaten();
                btnSpeicherin.Enabled = false;
                return;
            }

            ctrAddUpdatePerson1.HandlePersondaten(_personID); // Wir bearbeiten die persondaten.

            if (_personID != -1)
            {
                //im fall aktualiesieren
                _mode = enMode.update;
                _ladeMitarbeiterDaten();
            }
            else
            {
                 //im fall addieren.
                _mode = enMode.addnew;
                _mitarbeiter = new clsMitarbeiter();
            }
        }

        private void _MitarbeiterDatenSpeichern()
        {
            if (!_ValiedereMitarbeiterFelder())
                return;

            bool personGespeichert = ctrAddUpdatePerson1.speicherePersonDaten();

            if (_selectedPersonID == -1)
                return;

            _fülleMitarbeiterDaten();

            string status = string.Empty;
            if (_mode == enMode.update) { status = "Mitarbeiterdaten wurden erfolgreich aktualisiert."; }
            else status = "Mitarbeiterdaten wurden erfolgreich hinzugefügt.";

            if (personGespeichert &&  _mitarbeiter.Save())
            {
                _mode = enMode.update;
                txtMitarbeiterID.Text = _mitarbeiter.MitarbeiterID.ToString();
                MessageBox.Show($"{status}", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
                MessageBox.Show("Fehler ist aufgetreten", "fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSpeicherin_Click(object sender, EventArgs e)
        {
            _MitarbeiterDatenSpeichern();
        }

        private void chbIstAktive_CheckedChanged(object sender, EventArgs e)
        {
            if (_flage)
            {
                chbIstAktive.Text = "Inaktive";
            }
            else
                chbIstAktive.Text = "Aktive";

            _flage = !_flage;
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
            bool isValid = true;

            isValid = _ValidiereEinFeld(txtVersicherungsName, "VersicherungsName");
            isValid &= _ValidiereEinFeld(txtVersicherungsNummer, "VersicherungsNummer");

            return isValid; // Gibt zurück, ob alle Felder gültig sind
        }

        private void ctrAddUpdatePerson1_OnSelectedPerson(int obj)
        {
          _selectedPersonID = obj;
          txtPersonID.Text = _selectedPersonID.ToString();  
        }
    }
}
