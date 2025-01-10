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
using System.Globalization;
using clsHilfsMethoden;
using System.Data.SqlClient;
using Windows.ApplicationModel.VoiceCommands;

namespace Parfüm2025
{
    public partial class frmAddUpdateRechnungsDetails : Form
    {
        public enum enMode { addnew = 0, update = 1, SeheDetails = 2}
        public enMode _mode = enMode.addnew;
        private int _detailID= -1;
        private int _belegID = -1;
        private string _kundenname = string.Empty;
        private readonly object _lackObject = new object();
        clsRechnungsdetails _rechnungsDetailsDaten;
        public delegate void GesamtSummeBack(object senden, float GesamtSumme);
        public event GesamtSummeBack sendeGesamtSumme;
        public frmAddUpdateRechnungsDetails(int detailID, int belegID, string kundenname, enMode mode)
        {
            InitializeComponent();

            _detailID = detailID;
            _belegID = belegID;
            _kundenname = kundenname;
            this._mode = mode;
        }
        private void _setzeVerkaufsDatenAufStandardWerte()
        {
            txtParfümNummer.Clear();
            txtVerkaufsMenge.Clear();
            txtLagerbestand.Text = "0";
            txtNormalPreis.Clear();
            txtGesamtPreis.Clear();
        }

        private void _ladeRechnungsDetailsDaten()
        {
            lock (_lackObject)
            {
                try
                { 

                    _rechnungsDetailsDaten = clsRechnungsdetails.Find(_detailID);

                    if (_rechnungsDetailsDaten == null)
                    {
                        MessageBox.Show("Die Verkaufsdaten konnten nicht gefunden werden.", "Fehler",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    txtBelegID.Text = _rechnungsDetailsDaten.belegID.ToString();
                    txtParfümNummer.Text = _rechnungsDetailsDaten.parfümNummer.ToString();
                    txtKundeName.Text = _kundenname;
                    txtVerkaufsMenge.Text = _rechnungsDetailsDaten.verkaufsMenge.ToString();
   
                    // Lagerbestand abrufen
                    txtLagerbestand.Text = clsEinkauf.FindEinkaufDatenByParfümNummer(_rechnungsDetailsDaten.parfümNummer).lagerbestand.ToString();
                    // Preise formatieren
                    txtNormalPreis.Text = _rechnungsDetailsDaten.normalPreis.ToString("C", CultureInfo.GetCultureInfo("de-DE"));
                    txtGesamtPreis.Text = _rechnungsDetailsDaten.gesamtPreis.ToString("C", CultureInfo.GetCultureInfo("de-DE"));

                    chMitSteuer.Checked = (_rechnungsDetailsDaten.gesamtPreis != 0);
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

        private bool _ValiedereVerkaufsdatenMenge()
        {
            bool isValid = true;

            isValid = _ValidiereEinFeld(txtParfümNummer, "ParfümNummer");
            isValid &= _ValidiereEinFeld(txtKundeName, "KundeName");
            isValid &= _ValidiereEinFeld(txtVerkaufsMenge, "VerkaufsMenge");
            isValid &= _ValidiereEinFeld(txtNormalPreis, "NormalPreis");
        
            return isValid; // Gibt zurück, ob alle Felder gültig sind
        }


        private bool _FülleRechnungsDetailsDaten()
        {
            _rechnungsDetailsDaten.belegID = Convert.ToInt32(txtBelegID.Text);
            //Wir bearbeiten die Rechnungsdetails daten.
            _rechnungsDetailsDaten.parfümNummer = Convert.ToInt32(txtParfümNummer.Text);
            _rechnungsDetailsDaten.verkaufsMenge = Convert.ToSingle(txtVerkaufsMenge.Text.Trim());

            float lagerbestand = Convert.ToSingle(txtLagerbestand.Text.Trim());
            float verkaufsMenge = Convert.ToSingle(txtVerkaufsMenge.Text.Trim());

            if(lagerbestand < verkaufsMenge)
            {
                MessageBox.Show("Die Verkaufsmenge überschreitet den Lagerbestand. Bitte passen Sie die Menge an.",
                  "Warnung",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return false;
            }

            _rechnungsDetailsDaten.lagerbestand = Convert.ToSingle(txtLagerbestand.Text.Trim());
            _rechnungsDetailsDaten.normalPreis = _ExtractNumber(txtNormalPreis.Text.Trim()) ;
            if (!string.IsNullOrEmpty(txtGesamtPreis.Text))
            {
                _rechnungsDetailsDaten.gesamtPreis = _ExtractNumber(txtGesamtPreis.Text.Trim()); // Mit Seteuer dazu.
            }

            return true;
        }

        private float _ExtractNumber(string text)
        {
            // Entfernt alle Tausendertrennzeichen (Punkte in deutscher Kultur)
            string cleanedInput = text.Replace(".", "");

            // Filtert nur Ziffern und das Dezimaltrennzeichen (Komma für de-DE)
            string numericPart = new string(cleanedInput.Where(c => char.IsDigit(c) || c == ',').ToArray());

            // Ersetzt das Komma durch einen Punkt (falls notwendig)
            numericPart = numericPart.Replace(',', '.');

            // Versucht, die gefilterte Zeichenkette in eine Zahl umzuwandeln
            if (float.TryParse(numericPart, NumberStyles.Float, CultureInfo.InvariantCulture, out float number))
            {
                return number;
            }
            else
            {
                MessageBox.Show($"Die Eingabe {text} enthält keine gültige Zahl.");
                return 0f;
            }
        }
        private bool _ExistiertParfümNummer()
        {
            int parfümNummer = Convert.ToInt32(txtParfümNummer.Text.Trim());

            if(!clsParfüm.IstParfümNummerVergeben(parfümNummer))
            {
                MessageBox.Show("Diese Parfümnummer existiert nicht in der Parfümliste.", "Fehlermeldung",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;   
        }
        private void _speicherEinkaufsdaten()
        {
            if (!_ValiedereVerkaufsdatenMenge())
                return;

            if (!_ExistiertParfümNummer())
                return;


            if (_ExtractNumber(txtVerkaufsMenge.Text.Trim()) == 0f)
            {
                errorProvider1.SetError(txtVerkaufsMenge, "Der Feld nimmt nur Nummer auf");
                return;
            }

            if (_ExtractNumber(txtNormalPreis.Text.Trim()) == 0f)
            {
                errorProvider1.SetError(txtNormalPreis, "Der Feld nimmt nur Nummer auf");
                return;
            }

            if(!_FülleRechnungsDetailsDaten())
                return;

            if (_rechnungsDetailsDaten.Save())
            {

                // Wir geben die gesamtsumme zurückt for die Rechnungsform.
                float gesamtSumme = 0;
                 gesamtSumme+= _rechnungsDetailsDaten.gesamtPreis;
                this.sendeGesamtSumme?.Invoke(this, gesamtSumme); 

                MessageBox.Show($"Verkauf Daten erfolgreich {(_mode == enMode.addnew ? "hinzugefügt" : "aktualisiert")}", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mode = enMode.update; // wir aktualisieren den Status des Objects.

                //Wir fragen, ob man noch details hinzufügen will.
                bool AddMore = MessageBox.Show("Wollen Sie noch Details zur Liste Addieren?", "Frage",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

                if (AddMore)
                {
                    //Zurücksetze die Felder für neue Eingabe...
                    _setzeVerkaufsDatenAufStandardWerte();
                    txtParfümNummer.Focus();
                    chMitSteuer.Checked = false;
                    _rechnungsDetailsDaten = new clsRechnungsdetails(); // Neue Instanz hinzufügen.
                }
                else
                    this.Close();
            }
            else
                MessageBox.Show("Fehler beim Speichern der Rechnungsdetails ist aufgetreten", "Fehlermeldung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmAddUpdateVerkaufDaten_Load(object sender, EventArgs e)
        {
            _setzeVerkaufsDatenAufStandardWerte();

            if(_mode == enMode.update)
            {
                _ladeRechnungsDetailsDaten();
                btnSpeichern.Text = "Update Details";
            }
            else if(_mode == enMode.SeheDetails)
            {
                _ladeRechnungsDetailsDaten();
                btnSpeichern.Enabled = false;
            }
            else
            {
                _rechnungsDetailsDaten = new clsRechnungsdetails(); // Neue Instanz der Klasse Rechnungsdetails erzeugen.
                txtKundeName.Text = _kundenname;
                txtBelegID.Text = _belegID.ToString();
            }
        }

        private void txtParfümNummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            _speicherEinkaufsdaten();

        }

        private void txtParfümNummer_TextChanged(object sender, EventArgs e)
        {
            txtVerkaufsMenge.Clear(); 
            txtNormalPreis.Clear();

            if (!string.IsNullOrEmpty(txtParfümNummer.Text.Trim()))
            {
                int parfümNum = Convert.ToInt32(txtParfümNummer.Text.Trim());
                clsEinkauf einkaufsdaten = clsEinkauf.FindEinkaufDatenByParfümNummer(parfümNum);
                if (einkaufsdaten != null)
                {
                    txtLagerbestand.Text = einkaufsdaten.lagerbestand.ToString();
                }
                else
                    txtLagerbestand.Text = "0";
            }
            else
                txtLagerbestand.Clear();
        }
        private void chMitSteuer_CheckedChanged(object sender, EventArgs e)
        {
            string formattedPrice = txtNormalPreis.Text.Trim();
            float normalPreise;

            if (!string.IsNullOrEmpty(txtNormalPreis.Text.Trim()) && chMitSteuer.Checked)
            {
                if (float.TryParse(formattedPrice, NumberStyles.Currency, CultureInfo.GetCultureInfo("de-DE"), out normalPreise))
                {
                    float gesamtPreis = Convert.ToSingle(normalPreise * 1.19);
                    txtGesamtPreis.Text = gesamtPreis.ToString("C", CultureInfo.GetCultureInfo("de-DE"));
                }
            }
            else
                txtGesamtPreis.Text = "0";
        }

        private void txtVerkaufsMenge_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtVerkaufsMenge.Text) && !string.IsNullOrEmpty(txtParfümNummer.Text))
            {

                int parfuemNummer = Convert.ToInt32(txtParfümNummer.Text);
                int preisKategorie = clsEinkauf.FindEinkaufDatenByParfümNummer(parfuemNummer).preisKategorie;
                string formattedVerkaufsmenge = txtVerkaufsMenge.Text.Trim();

                if (float.TryParse(formattedVerkaufsmenge, out float verkaufsmenge))
                {
                    float verkaufsmengeInGramm = verkaufsmenge * 1000;
                    float PreisProEinheit = clsPreise.BerechneParfuemPreis(verkaufsmengeInGramm, preisKategorie);
                    float berechnePreis = verkaufsmengeInGramm * PreisProEinheit;
                    txtNormalPreis.Text = berechnePreis.ToString();
                }
                else
                    MessageBox.Show("Bitte geben Sie eine gültige Verkaufsmenge in Kilogramm ein.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                txtNormalPreis.Clear();
        }

        private void btnPreisKategorie_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtParfümNummer.Text))
            {
                int parfümNummer = Convert.ToInt32(txtParfümNummer.Text.Trim());
                int preisKategorie = clsEinkauf.FindEinkaufDatenByParfümNummer(Convert.ToInt32(txtParfümNummer.Text)).preisKategorie;
                List<clsPreise> preisKategorieListe = clsPreise.GetPreisKategorieByKategorie(preisKategorie);

                frmPreisKategorie frm = new frmPreisKategorie(preisKategorieListe);
                frm.ShowDialog();
                
            }
            else
                MessageBox.Show("ParfümNummer muss eingegeben werden", "Parfümnummer fehlt", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
