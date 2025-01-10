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
    public partial class frmAddUpdateNewPerfum : Form
    {
        private enum enMode { addnew = 0, update = 1}
        enMode _mode = enMode.addnew;
        clsParfüm _parfüm;
        int _parfümNummer;
        public frmAddUpdateNewPerfum(int parfümNummer)
        {
            InitializeComponent();
            this._parfümNummer = parfümNummer;
        }
        private void frmAddUpdateNewPerfum_Load(object sender, EventArgs e)
        {
            if (_parfümNummer != -1)
            {
                _mode = enMode.update;
                _holeParfümDatenFromDatenbank();
            }
            else
            {
                _parfüm = new clsParfüm();
                _mode = enMode.addnew;
            }
        }
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _TextFelderValidierung(TextBox name, string feldname)
        {
            if(string.IsNullOrEmpty(name.Text))
            {
                errorProvider1.SetError(name,feldname + " darf nicht leer sein!");
                name.BackColor = Color.LightPink;
                name.BorderStyle = BorderStyle.FixedSingle;
                return false;
            }
            else
            {
                errorProvider1.SetError(name, null);
                name.BackColor = Color.White;
                name.BorderStyle = BorderStyle.FixedSingle;
                return true;
            }
        }

        private bool _istValidiert()
        {
            bool istValid = true;

            istValid = _TextFelderValidierung(txtparfümNummer, "pafrümNummer");
            istValid &= _TextFelderValidierung(txtMarke, "Marke");
            istValid &= _TextFelderValidierung(txtName, "Name");
            istValid &= _TextFelderValidierung(txtKategorie, "Kategorie");

            return istValid;
        }
        private void _holeParfümDatenFromDatenbank()
        {
            _parfüm = clsParfüm.FindByParfümNummer(_parfümNummer);

            if(_parfüm != null)
            {
                txtparfümNummer.Text = _parfüm.parfümNummer.ToString();
                txtMarke.Text = _parfüm.Marke;
                txtName.Text = _parfüm.Name;
                txtKategorie.Text = _parfüm.Kategorie;
                txtDuftrichtung.Text = _parfüm.Duftrichtung;
                txtJahreszeiten.Text = _parfüm.Jahreszeiten;
                chbIstVorhanden.Checked = _parfüm.IstVorhanden;
            }
            else
            {
                MessageBox.Show("Fehler beim Laden der Parfümdaten ist aufgetreten","fehlermeldung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool _IstAlteParfümNummerGleichWieNeue()
        {
            int alteParfümNummer = 0;
            int AktuelleParfümNummer = 0;
            if(_mode == enMode.update)
            {
                alteParfümNummer = _parfüm.parfümNummer;
                AktuelleParfümNummer = Convert.ToInt32(txtparfümNummer.Text);

                if (alteParfümNummer == AktuelleParfümNummer)
                    return true;
            }
            return false;
        }
        private void _fülleParfümDaten()
        {
             if(_mode == enMode.update)
                 _parfüm.neuParfümNummer = Convert.ToInt32(txtparfümNummer.Text);
             else
                _parfüm.parfümNummer = Convert.ToInt32(txtparfümNummer.Text);

            _parfüm.Marke = txtMarke.Text;
            _parfüm.Name = txtName.Text;
            _parfüm.Kategorie = txtKategorie.Text;
            _parfüm.Duftrichtung = txtDuftrichtung.Text;
            _parfüm.Jahreszeiten = txtJahreszeiten.Text;
            _parfüm.IstVorhanden = chbIstVorhanden.Checked;
        }

        private bool _IstParfümNummerVergeben()
        {
            int parfümNummer = Convert.ToInt32(txtparfümNummer.Text);
            if(clsParfüm.IstParfümNummerVergeben(parfümNummer) && !_IstAlteParfümNummerGleichWieNeue())
            {
                MessageBox.Show("Diese Nummer ist vergeben\nVersuchen Sie bitte " +
                    "mit anderer Nummer erneut","Hinweis",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true ;
            }
            else { return false; }
        }
        private void _parfümDatenSpeichern()
        {
            if (!_istValidiert())  //wir überprüfen, ob bestimmte felder leer sind.
                return;

            if (_IstParfümNummerVergeben() ) // wir überprüfen, ob die Nummer bereits vorhanden ist.
                return;

            _fülleParfümDaten();

            string status;
            if (_mode == enMode.addnew)
                status = "hinzugefügt";
            else
                status = "aktualisiert";

            AutoComplete.AVLTree tree = new AutoComplete.AVLTree();
            if(_parfüm.Save())
            {
                tree.Insert(_parfüm.Name); // Hier addieren wir jeden neuen Parfüm in AVL Tree.

                MessageBox.Show($"Parfümdaten erfolgreich {status}", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                btnspeichern.Enabled = false;
            }
            else
                MessageBox.Show($"Fehler beim {status} ist aufgetreten.", "Erorr",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnspeichern_Click(object sender, EventArgs e)
        {
            _parfümDatenSpeichern();
        }
    }
}
