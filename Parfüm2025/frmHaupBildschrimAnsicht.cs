using Busnisse_Layer;
using clsHilfsMethoden;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.UserDataTasks;
using Windows.ApplicationModel.VoiceCommands;

namespace Parfüm2025
{
    public partial class frmHaupBildschrimAnsicht : Form
    {
        private float _neuerLagerbestand = -1;
        private int _parfümNummer = -1;
        private frmOverly _overlay;
        public frmHaupBildschrimAnsicht()
        {
            InitializeComponent();

            // KeyPreview aktivieren, um Tasteneingaben abzufangen
            this.KeyPreview = true;

            // Ereignis für KeyDown hinzufügen
            this.KeyDown += frmHaupt_KeyDown;


            this.IsMdiContainer = true;
        }

        // KeyDown-Ereignis für die Hauptform
        private void frmHaupt_KeyDown(object sender, KeyEventArgs e)
        {
            // Wenn die F12-Taste gedrückt wird
            if (e.KeyCode == Keys.F12)
            {
                if (_overlay == null || _overlay.IsDisposed)
                {
                    // Overlay-Form erstellen
                    _overlay = new frmOverly();
                    _overlay.Owner = this; // Setze die Hauptform als Owner
                    _overlay.Show();
                }
            }
            else if (e.KeyCode == Keys.F11)
            {
                // Schließe die Overlay-Form, falls sie aktiv ist
                if (_overlay != null && !_overlay.IsDisposed)
                {
                    _overlay.Close();
                }
            }
        }
        private void clsHaupBildschrimAnsicht_FormClosed(object sender, FormClosedEventArgs e)
        {
            _overlay = null; // Setze die Overlay-Instanz zurück

            // Benutzer ausloggen (aktiven Benutzer zurücksetzen)
            if (clsGlobaleKlasse.currentUser != null)
                clsGlobaleKlasse.currentUser = null;

            // Anwendung vollständig beenden
            //Application.Exit();

            this.Close();
        }

        private void parfümAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPermissionService.HatBerechtigung(clsGlobaleKlasse.currentUser.permissionNum, clsPermissionService.ParfuemVerwaltung))
            {
                frmpafümAnsicht frm = new frmpafümAnsicht();
                frm.ShowDialog() ;
            }
            else
            {
                MessageBox.Show("Sie haben nicht die erforderlichen Berechtigungen, um auf diese Funktion zuzugreifen. Bitte wenden Sie sich an den Administrator, um die erforderlichen Rechte zu erhalten.",
                    "Zugriff verweigert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void kundeAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPermissionService.HatBerechtigung(clsGlobaleKlasse.currentUser.permissionNum, clsPermissionService.KundenVerwaltung))
            {
                frmKundeListe frm = new frmKundeListe();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Sie haben nicht die erforderlichen Berechtigungen, um auf diese Funktion zuzugreifen. Bitte wenden Sie sich an den Administrator, um die erforderlichen Rechte zu erhalten.",
               "Zugriff verweigert",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
        }

        private void mitarbeiterAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPermissionService.HatBerechtigung(clsGlobaleKlasse.currentUser.permissionNum, clsPermissionService.MitarbeiterVerwaltung))
            {
                frmMitarbeiterListe frm = new frmMitarbeiterListe();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Sie haben nicht die erforderlichen Berechtigungen, um auf diese Funktion zuzugreifen. Bitte wenden Sie sich an den Administrator, um die erforderlichen Rechte zu erhalten.",
               "Zugriff verweigert",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
        }

        private void benutzerAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPermissionService.HatBerechtigung(clsGlobaleKlasse.currentUser.permissionNum, clsPermissionService.KundenVerwaltung))
            {
                frmUserListe frm = new frmUserListe();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Sie haben nicht die erforderlichen Berechtigungen, um auf diese Funktion zuzugreifen. Bitte wenden Sie sich an den Administrator, um die erforderlichen Rechte zu erhalten.",
               "Zugriff verweigert",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
        }

        private void einkaufAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPermissionService.HatBerechtigung(clsGlobaleKlasse.currentUser.permissionNum, clsPermissionService.LagerVerwaltung))
            {
                frmEinkaufsDatenListe frm = new frmEinkaufsDatenListe();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Sie haben nicht die erforderlichen Berechtigungen, um auf diese Funktion zuzugreifen. Bitte wenden Sie sich an den Administrator, um die erforderlichen Rechte zu erhalten.",
               "Zugriff verweigert",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
        }

        private void verkaufAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPermissionService.HatBerechtigung(clsGlobaleKlasse.currentUser.permissionNum, clsPermissionService.LagerVerwaltung))
            {
                frmVerkaufsDatenListe frm = new frmVerkaufsDatenListe();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Sie haben nicht die erforderlichen Berechtigungen, um auf diese Funktion zuzugreifen. Bitte wenden Sie sich an den Administrator, um die erforderlichen Rechte zu erhalten.",
               "Zugriff verweigert",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
        }

        private void ausloggenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HinzufügeNeueParfümtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewPerfum frm = new frmAddUpdateNewPerfum(-1);
            frm.ShowDialog();
        }

        private void hinzufügeNeuenKundenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNeueKunde frm = new frmAddUpdateNeueKunde(-1, false);
            frm.ShowDialog();
        }

        private void hinzufügeNeuenMitarbeiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNeueMitarbeiter frm = new frmAddUpdateNeueMitarbeiter(-1, false);
            frm.ShowDialog();
        }

        private void hinzufügeNeuenEinkaufToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNeueParfümMenge frm = new frmAddUpdateNeueParfümMenge(-1, frmAddUpdateNeueParfümMenge.enMode.addnew);
            frm.ShowDialog();
        }

        private void hinzufügeNeuenVerkaufToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateRechnung frm = new frmAddUpdateRechnung(-1, frmAddUpdateRechnung.enMode.addnew);
          //  frm.lagerbestandAktualisiert +=  _ÜberprüfeLagerbestand;
            frm.ShowDialog();

 
        }

        private void _ÜberprüfeLagerbestand(object sender, float neuerLagerbestand, int parfümNummer)
        {
            _neuerLagerbestand = neuerLagerbestand;
            _parfümNummer = parfümNummer;
        }

        private void _SetzeNotifikation()
        {
            new ToastContentBuilder()
                 .AddText("Achtung: Niedriger Lagerbestand!")
                   .AddText($"Der Lagerbestand für die ParfümNummer {_parfümNummer} ist unter 50 gefallen. Bitte prüfen Sie die Bestände.")
                   .SetToastDuration(ToastDuration.Long) // Toast länger anzeigen
                     .Show();

            _neuerLagerbestand = -1;  // neuelagerbestand zurücksetzen
            _parfümNummer = -1;    // parfümNummer zurücksetzen 
        }

        private void sucheEinenKundenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKundeSucheFilter frm = new frmKundeSucheFilter();
            frm.ShowDialog();
        }

        private void _BackupDatabase()
        {

            if(DateTime.Now.DayOfWeek == DayOfWeek.Tuesday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                // Überprüfen, ob Backup schon durchgeführt wurde
                string letzterBackupTag = Properties.Settings.Default.LetztesBackupDatum;
                string heutigesDatum = DateTime.Now.ToString("yyyy-MM-dd");

                if (letzterBackupTag != heutigesDatum)
                {
                    //Backup erstellen
                    bool backupErfolgreich = clsBackupDatenbank.IsBackupSuccessfulByMacAdresse();

                    if (backupErfolgreich)
                    {
                        new ToastContentBuilder()
                     .AddText("Backup erfolgreich")
                       .AddText("Das Backup der Datenbank wurde erfolgreich erstellt.")
                       .SetToastDuration(ToastDuration.Long).Show(); // Toast länger anzeigen

                        // Datum speichern
                        Properties.Settings.Default.LetztesBackupDatum = heutigesDatum;
                        Properties.Settings.Default.Save();

                    }
                }
            }
        }
        private void frmHaupBildschrimAnsicht_Load(object sender, EventArgs e)
        {
            _BackupDatabase();
        }
    }
}
