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
    public partial class frmAddUpdateNeueUser : Form
    {
        private int permissions = 0;  // Standardmäßig keine Berechtigungen
        private int _mitarbeiterID = -1;
        private bool _flage = true;
        private clsUser _user;
        public enum enMode { addnew = 0, update = 1, seheDetails = 2 }
        private enMode _mode = enMode.addnew;
        public frmAddUpdateNeueUser(int mitarbeiterID, enMode mode)
        {
            InitializeComponent();
            this._mitarbeiterID = mitarbeiterID;
            this._mode = mode;
        }

        private int _BerechnePermission()
        {
            // Falls Admin ausgewählt wurde, alle Rechte setzen
            if (chbAdminBerechtigung.Checked)
            {
                permissions = clsPermissionService.Admin;
            }
            else
            {
                // Berechtigungen basierend auf Checkboxen setzen
                permissions = 0; // Zurücksetzen, um keine doppelten Rechte zu haben
                if (chbParfümverwaltung.Checked)
                    permissions = clsPermissionService.BerechtigungHinzufuegen(permissions, clsPermissionService.ParfuemVerwaltung);

                if (chbKundeverwaltung.Checked)
                    permissions = clsPermissionService.BerechtigungHinzufuegen(permissions, clsPermissionService.KundenVerwaltung);

                if (chbMitarbeiterverwaltung.Checked)
                    permissions = clsPermissionService.BerechtigungHinzufuegen(permissions, clsPermissionService.MitarbeiterVerwaltung);

                if (chbLageverwaltung.Checked)
                    permissions = clsPermissionService.BerechtigungHinzufuegen(permissions, clsPermissionService.LagerVerwaltung);

                if (chbUserverwaltung.Checked)
                    permissions = clsPermissionService.BerechtigungHinzufuegen(permissions, clsPermissionService.UserVerwaltung);
            }

            return permissions;

        }

        private void _ladePermission(int permission)
        {
            if (clsPermissionService.IstAdmin(permission))
            {
                chbAdminBerechtigung.Checked = true;
                return;
            }

            if (clsPermissionService.HatBerechtigung(permission, clsPermissionService.ParfuemVerwaltung))
                chbParfümverwaltung.Checked = true;

            if (clsPermissionService.HatBerechtigung(permission, clsPermissionService.KundenVerwaltung))
                chbKundeverwaltung.Checked = true;

            if (clsPermissionService.HatBerechtigung(permission, clsPermissionService.MitarbeiterVerwaltung))
                chbMitarbeiterverwaltung.Checked = true;

            if (clsPermissionService.HatBerechtigung(permission, clsPermissionService.LagerVerwaltung))
                chbLageverwaltung.Checked = true;

            if (clsPermissionService.HatBerechtigung(permissions, clsPermissionService.UserVerwaltung))
                chbUserverwaltung.Checked = true;
        }
        private void _fülleUserdaten()
        {
            
            _user.mitarbeiterID = Convert.ToInt32(txtMitarbeiterID.Text);
            _user.userRolle = txtUserrolle.Text;
            _user.userPasswort = txtUserPasswort.Text;
            _user.permissionNum = _BerechnePermission();
            _user.istAktive = chbIstAktive.Checked;         
        }

        private void _speichereUserdaten()
        {
            if (!_ValiedereUserFelder())
                return;


            _fülleUserdaten();
            if (_user.Save())
            {
                txtUserID.Text = _user.userID.ToString();
                MessageBox.Show($"Userdaten erfolgreich {(_mode == enMode.addnew ? "hinzugefügt" : "aktualisiert")}", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _mode = enMode.update;
                btnSpeichern.Enabled = false;
            }
            else
            {
                MessageBox.Show("Fheler beim Speichern Userdaten ist aufgetreten", "fehlermeldung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _ladeUserdaten()
        {
            _user = clsUser.FindUserByMitarbeiterID(_mitarbeiterID);
            if (_user != null)
            {
                txtUserID.Text = _user.userID.ToString();
                txtMitarbeiterID.Text = _user.mitarbeiterID.ToString();
                txtUserrolle.Text = _user.userRolle;
                txtUserPasswort.Text = _user.userPasswort;
                _ladePermission(_user.permissionNum);
                chbIstAktive.Checked = _user.istAktive;
            }
            else
                MessageBox.Show("User not found", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            _speichereUserdaten();
        }

        private void chbAdminBerechtigung_CheckedChanged(object sender, EventArgs e)
        {
            // Wenn Admin ausgewählt wird, deaktivieren wir die anderen Checkboxen
            bool istAdmin = chbAdminBerechtigung.Checked;

            chbParfümverwaltung.Enabled = !istAdmin;
            chbKundeverwaltung.Enabled = !istAdmin;
            chbMitarbeiterverwaltung.Enabled = !istAdmin;
            chbLageverwaltung.Enabled = !istAdmin;
            chbUserverwaltung.Enabled = !istAdmin;

            if (istAdmin)
            {
                permissions = clsPermissionService.Admin; // Admin-Berechtigungen sofort setzen
            }
        }

        private void frmAddUpdateNeueUser_Load(object sender, EventArgs e)
        {
            if(_mode == enMode.seheDetails)
            {
                _ladeUserdaten();
                btnSpeichern.Enabled = false;
            }
            if (_mode == enMode.update)
            {
                _ladeUserdaten();
            }
            else
            {
                txtMitarbeiterID.Text = this._mitarbeiterID.ToString();
                _mode = enMode.addnew;
                _user = new clsUser();
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

        private bool _ValiedereUserFelder()
        {
            bool isValid = true;

            isValid = _ValidiereEinFeld(txtUserrolle, "userRolle");
            isValid &= _ValidiereEinFeld(txtUserPasswort, "userPasswort");

            return isValid; // Gibt zurück, ob alle Felder gültig sind
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
    }
}
