using Busnisse_Layer;
using clsHilfsMethoden;
using System;
using System.CodeDom;
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
    public partial class ctrAddUpdatePerson : UserControl
    {
        public ctrAddUpdatePerson()
        {
            InitializeComponent();
        }

        ////Declare a delegate
        //public delegate void DataBackEventHandler(object sender, int personID);
        ////declare an event using the delegate
        //public event DataBackEventHandler DataBack;

        //define a custom event handler delegate with parameters
        public event Action<int> OnSelectedPerson;
        //Create a protected methode to raise the event with a parameters
        protected virtual void SelectedPerson(int personID)
        {
            Action<int> handler = OnSelectedPerson;
            if (handler != null)
            {
                handler(personID);  // Rais the event with the parameter.
            }
        }

        private enum enMode { addnew = 0, update = 1 }
        enMode _mode = enMode.addnew;

        private clsPerson _persondaten;

        private readonly object _lockObject = new object();
        private void _GeburtsdatumEinrichten()
        {
            dtpGeburtstag.Format = DateTimePickerFormat.Custom;
            dtpGeburtstag.CustomFormat = "dd.MM.yyyy";
        }
 
        public void HandlePersondaten(int personID)
        {
            if (personID != -1)
            {
                _mode = enMode.update;  
                _ladePersonDaten(personID);
            }
            else
            { 
                _mode = enMode.addnew;
                _persondaten = new clsPerson();
            }

        }
        private void _füllePersonDaten()
        {
            _persondaten.Vorname = txtVorname.Text;
            _persondaten.Nachname = txtNachname.Text;
            _persondaten.GeburtsTag = dtpGeburtstag.Value;
            _persondaten.Geschlecht = Convert.ToChar(cbGeschlecht.SelectedItem.ToString());
            _persondaten.SteuerID = txtSteuerID.Text;
            _persondaten.Email = txtEmail.Text;
            _persondaten.Straße = txtStrasse.Text;
            _persondaten.Stadt = txtStadt.Text;
            _persondaten.Land = cbLand.SelectedItem.ToString();
            _persondaten.Telefon = txtTelefon.Text;
        }

        private void ctrAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetAufStandardWerte();
        }

        public void _GetPersonDetails(int personID)
        {
            _ladePersonDaten(personID);
        }
        private void _ladePersonDaten(int personID)
        {
            lock (_lockObject)
            {
                try
                {
                    _persondaten = clsPerson.Find(personID);

                    if (_persondaten != null)
                    {
                        txtVorname.Text = _persondaten.Vorname;
                        txtNachname.Text = _persondaten.Nachname;
                        dtpGeburtstag.Value = _persondaten.GeburtsTag;
                        cbGeschlecht.SelectedItem = _persondaten.Geschlecht.ToString();
                        txtSteuerID.Text = _persondaten.SteuerID;
                        txtEmail.Text = _persondaten.Email;
                        txtStrasse.Text = _persondaten.Straße;
                        txtStadt.Text = _persondaten.Stadt;
                        cbLand.SelectedItem = _persondaten.Land;
                        txtTelefon.Text = _persondaten.Telefon;
                    }
                    else
                    {
                        MessageBox.Show("Diese Person existiert leider nicht in System!", "Fehlermeldung",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Fehler beim Laden der Personendaten für ID {personID}: {ex.Message}");
                }
            }
        }

        private void _ResetAufStandardWerte()
        {
            _GeburtsdatumEinrichten();
            _FülleLandComboBoxMitLändern();

            txtVorname.Clear();
            txtVorname.Select();
            txtNachname.Clear();
            dtpGeburtstag.Value = DateTime.Now;
            cbGeschlecht.SelectedIndex = 0;
            txtSteuerID.Clear();
            txtEmail.Clear();
            txtStadt.Clear();
            txtStrasse.Clear();
            txtTelefon.Clear();
        }
        private void _FülleLandComboBoxMitLändern()
        {
            string[] europäischeLänder = {
                            "Albanien", "Andorra", "Belgien", "Bosnien und Herzegowina", "Bulgarien",
                             "Dänemark", "Deutschland", "Estland", "Finnland", "Frankreich",
                               "Griechenland", "Irland", "Island", "Italien", "Kasachstan",
                               "Kosovo", "Kroatien", "Lettland", "Liechtenstein", "Litauen",
                                 "Luxemburg", "Malta", "Moldawien", "Monaco", "Montenegro",
                              "Niederlande", "Nordmazedonien", "Norwegen", "Österreich", "Polen",
                             "Portugal", "Rumänien", "Russland", "San Marino", "Schweden",
                             "Schweiz", "Serbien", "Slowakei", "Slowenien", "Spanien",
                             "Tschechien", "Türkei", "Ukraine", "Ungarn", "Vatikanstadt",
                              "Vereinigtes Königreich", "Weißrussland", "Zypern"
                                       };

            AutoComplete.AVLTree tree = new AutoComplete.AVLTree();

            foreach (string land in europäischeLänder)
            {
                cbLand.Items.Add(land);
            }
            cbLand.SelectedItem = "Deutschland";
        }


        private void _SetError(TextBox textbox, string errorMessage)
        {
            errorProvider1.SetError(textbox, errorMessage);
            textbox.BackColor = string.IsNullOrEmpty(errorMessage) ? Color.White : Color.LightPink;
        }
        private bool _ValidiereEinFeld(TextBox txtboxName, string name)
        {
            if (string.IsNullOrEmpty(txtboxName.Text))
            {
                _SetError(txtboxName, $"{name} darf nicht leer sein!");
                return false;
            }
        
            _SetError(txtboxName, null);
            return true;
        }

        private bool _ValiederePersonFelder()
        {
            bool isValid = true;

            isValid &= _ValidiereEinFeld(txtVorname, "Vorname");
            isValid &= _ValidiereEinFeld(txtNachname, "Nachname");
            isValid &= _ValidiereEinFeld(txtSteuerID, "SteuerID");
            isValid &= _ValidiereEinFeld(txtEmail, "Email");
            isValid &= _ValidiereEinFeld(txtStrasse, "Strasse");
            isValid &= _ValidiereEinFeld(txtStadt, "Stadt");

            return isValid; // Gibt zurück, ob alle Felder gültig sind
        }

        private bool _ValidiereEmail()
        {
            if (!clsValidierung.ValidateEmail(txtEmail.Text.Trim()))
            {
                _SetError(txtEmail, "Bitte geben Sie eine gültige E-Mail-Adresse ein!");
                return false;
            }

            _SetError(txtEmail, null);
            return true;
        }

        private bool _IstValidiert()
        {
            if (!_ValiederePersonFelder() || !_ValidiereEmail())
                return false;
            else
                return true;
        }
        public bool speicherePersonDaten()
        {

            lock (_lockObject)
            {
                if (!_IstValidiert())
                    return false;

                _füllePersonDaten();
                if (!_persondaten.Save())
                    return false;

                if (OnSelectedPerson != null)
                {
                    SelectedPerson(_persondaten.PersonID);
                }
                return true;
            }

        }

        private void gbPersondaten_Enter(object sender, EventArgs e)
        {

        }
    }
}
