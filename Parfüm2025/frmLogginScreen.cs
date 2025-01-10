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
    public partial class frmLogginScreen : Form
    {
        public frmLogginScreen()
        {
            InitializeComponent();
        }
        private void btnSchliessen_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private bool _ValiedereEinloggenFelder()
        {
            bool isValid = true;

            isValid = _ValidiereEinFeld(txtUsername, "Username");
            isValid &= _ValidiereEinFeld(txtPasswort, "Passwort");

            return isValid; // Gibt zurück, ob alle Felder gültig sind
        }

        private void _Einlogging()
        {
            string username = txtUsername.Text.Trim();
            string passwort = txtPasswort.Text.Trim();

            clsUser user = clsUser.FindUserByUsernameAndPasswort(username, passwort);

            if (user == null)
            {
                MessageBox.Show("Benutzer wurde nicht gefunden. Bitte überprüfen Sie Ihre Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!user.istAktive)
            {
                MessageBox.Show("Dieser Benutzer ist deaktiviert. Bitte kontaktieren Sie den Administrator.", "Zugriff verweigert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            clsGlobaleKlasse.currentUser = user; // Lade User in currentUser.
            if (clsGlobaleKlasse.currentUser == null)
            {
                MessageBox.Show("Ein interner Fehler ist aufgetreten. Benutzer konnte nicht geladen werden.", "Systemfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Benutzername und Passwort zurücksetzen
                txtUsername.Clear();
                txtPasswort.Clear();

                // Hauptfenster erstellen
                frmHaupBildschrimAnsicht frm = new frmHaupBildschrimAnsicht();

                // Login-Fenster verstecken
                this.Hide();

                // Hauptfenster als modales Fenster öffnen
                frm.ShowDialog();

                // Login-Fenster wieder anzeigen (nach Schließen des Hauptfensters)
                this.Show();
            }
            catch (Exception ex)
            {
                // Fehler anzeigen und Login-Fenster sichtbar machen
                MessageBox.Show($"Fehler beim Öffnen des Hauptfensters: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }
            
        private void btnEinloggen_Click(object sender, EventArgs e)
        {
            if (!_ValiedereEinloggenFelder())
                return;

            //if (!_CheckProduktSchluessel())
            //    return;

            _Einlogging();
        }

        private bool _CheckProduktSchluessel()
        {
            string lizenzKey = Properties.Settings.Default.LizenzKey;

            DataTable dtSchleusselDaten = clsProduktSchluessel.GetDatumAndAblaufdatumBySchluessel(lizenzKey);

            if (dtSchleusselDaten.Rows.Count > 0)
            {
                DateTime ablaufdatum = DateTime.MinValue;
                if (dtSchleusselDaten.Rows[0]["ablaufdatum"] != DBNull.Value)
                {
                    ablaufdatum = Convert.ToDateTime(dtSchleusselDaten.Rows[0]["ablaufdatum"]);
                }

                if(ablaufdatum < DateTime.Now)
                {
                    // Ablaufdatum in der Vergangenheit
                    MessageBox.Show("Der Produktschlüssel ist abgelaufen. Bitte erneuern Sie Ihre Lizenz, um fortzufahren.",
                                    "Lizenz abgelaufen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        
                    frmLizenzEigabeBildschirm frm = new frmLizenzEigabeBildschirm();
                    this.Hide();
                    frm.ShowDialog();

                    if (!frm.GetValidKey())
                    {
                        // Falls der Lizenzschlüssel ungültig ist, das Programm beenden oder weitere Schritte unternehmen
                        MessageBox.Show("Bitte geben Sie einen gültigen Lizenzschlüssel ein, um fortzufahren.",
                                        "Ungültiger Schlüssel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit(); // Optional: Programm beenden, falls kein gültiger Schlüssel eingegeben wurde
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
            else
            {
                // Keine gültigen Daten für den Produktschlüssel gefunden
                MessageBox.Show("Kein Produktschlüssel gefunden. Bitte geben Sie einen gültigen Schlüssel ein.",
                                "Lizenz erforderlich", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
