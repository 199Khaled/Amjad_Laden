
using Busnisse_Layer;
using clsHilfsMethoden;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;

namespace Parfüm2025
{
    public partial class frmpafümAnsicht : Form
    {
        DataTable _dtParfüms;
        DataTable _dtHerrenParfüms;
        DataTable _dtDamenPafüms;

        BindingSource _bindingSourceParfüm;
        BindingSource _bindingSourceHerrenParfüm;
        BindingSource _bindingSourceDamenParfüm;

        // wir haben die lock-Blöcke verwendet um die tabellen sowie die Aktualisierung 
        // der Datenquellen zu Synchronisieren..
        private readonly object _dataloadLock = new object();
        private readonly object _filterLock = new object();
        private readonly object _autoComplateLock = new object();
        public frmpafümAnsicht()
        {
            InitializeComponent();
            // Setze den DrawMode des TabControls
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            _bindingSourceParfüm = new BindingSource();
            _bindingSourceHerrenParfüm = new BindingSource();
            _bindingSourceDamenParfüm = new BindingSource();
        }

        //Lade Daten für Unisexdüfte
        private void _LadeParfümDaten()
        {
            lock (_dataloadLock)
            {
                _dtParfüms = clsParfüm.GetAllParfüms();
                _bindingSourceParfüm.DataSource = _dtParfüms;
                dgvParfüm.DataSource = _bindingSourceParfüm;

                _MarkiereParfümZeilen();
            }
        }

        //Lade Daten für Herrendüfte
        private void _LadeHerrenParfümDaten()
        {
            _dtHerrenParfüms = clsParfüm.GetAllHerrenParfüms();
            _bindingSourceHerrenParfüm.DataSource = _dtHerrenParfüms;
            dgvHerrefDüfte.DataSource = _bindingSourceHerrenParfüm;

        }

        //Lade Daten für Damendüfte
        private void _LadeDamenParfümDaten()
        {
            _dtDamenPafüms = clsParfüm.GetAllDamenParfüms();
            _bindingSourceDamenParfüm.DataSource = _dtDamenPafüms;
            dgvDamenParfüm.DataSource = _bindingSourceDamenParfüm;
        }
        private void _MarkiereParfümZeilen()
        {
            foreach (DataGridViewRow row in dgvParfüm.Rows)
            {
                if (row.Cells["IstVorhanden"].Value != null && Convert.ToBoolean(row.Cells["IstVorhanden"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink; // Hintergrundfarbe
                    row.DefaultCellStyle.ForeColor = Color.Black;    // Schriftfarbe
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbFilterBei.SelectedIndex = 2;
            // Verhindert, dass der Benutzer den Text ändert
            cbFilterBei.DropDownStyle = ComboBoxStyle.DropDownList;
            _LadeParfümDaten();
            _LadeHerrenParfümDaten();
            _LadeDamenParfümDaten();
        }

        private void mehrDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentName = dgvParfüm.CurrentRow.Cells[2].Value.ToString();
            // URL, die im Browser geöffnet werden soll
            string url = "https://www.parfumo.de/s_perfumes_x.php?in=1&filter=" + currentName;

            // Starten Sie den Standard-Webbrowser mit der angegebenen URL
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        private void txtParfümFilterbeiNummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //Ab Hier für Herrendüfte
        private void _FilterAnwendenFürHerrenParfüms(string spalteName, string filterwert)
        {
            if (!string.IsNullOrEmpty(filterwert))
            {
                _bindingSourceHerrenParfüm.Filter = $" {spalteName} Like '{filterwert}%'";
            }
            else
                _bindingSourceHerrenParfüm.Filter = string.Empty;
        }
        private void txtHerrenParfümFilterbeiName_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtHerrenParfümFilterbeiMarke.Text) || !string.IsNullOrEmpty(txtHerrenParfümFilterbeiNummer.Text))
            {
                txtHerrenParfümFilterbeiMarke.Clear();
                txtHerrenParfümFilterbeiNummer.Clear();
            }

            _FilterAnwendenFürHerrenParfüms("Name", txtHerrenParfümFilterbeiName.Text.Trim());
        }
        private void txtHerrenParfümFilterbeiMarke_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtHerrenParfümFilterbeiName.Text) || !string.IsNullOrEmpty(txtHerrenParfümFilterbeiNummer.Text))
            {
                txtHerrenParfümFilterbeiName.Clear();
                txtHerrenParfümFilterbeiNummer.Clear();
            }
            _FilterAnwendenFürHerrenParfüms("Marke", txtHerrenParfümFilterbeiMarke.Text.Trim());

        }

        private void _FilterBeiNummerFürHerrenParfüm(string spalteName, string filterwert)
        {
            if (!string.IsNullOrEmpty(txtHerrenParfümFilterbeiNummer.Text.Trim()))
            {
                _bindingSourceHerrenParfüm.Filter = $"{spalteName} = {Convert.ToInt32(filterwert)}";
            }
            else
                _bindingSourceHerrenParfüm.Filter = string.Empty;
        }
        private void txtHerrenParfümFilterbeiNummer_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtHerrenParfümFilterbeiName.Text) || !string.IsNullOrEmpty(txtHerrenParfümFilterbeiMarke.Text))
            {
                txtHerrenParfümFilterbeiName.Clear();
                txtHerrenParfümFilterbeiMarke.Clear();
            }
            _FilterBeiNummerFürHerrenParfüm("parfümNummer", txtHerrenParfümFilterbeiNummer.Text.Trim());

        }

        private void txtHerrenParfümFilterbeiNummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }


        //Ab hier für Damendüfte
        private void _FilterAnwendenFürDamenParfüms(string spalteName, string filterwert)
        {
            if (!string.IsNullOrEmpty(filterwert))
            {
                _bindingSourceDamenParfüm.Filter = $" {spalteName} Like '{filterwert}%'";
            }
            else
                _bindingSourceDamenParfüm.Filter = string.Empty;
        }

        private void _FilterBeiNummerFürDamenParfüm(string spalteName, string filterwert)
        {
            if (!string.IsNullOrEmpty(txtDamenPafrümFilterBeiNummer.Text.Trim()))
            {
                _bindingSourceDamenParfüm.Filter = $"{spalteName} = {Convert.ToInt32(filterwert)}";
            }
            else
                _bindingSourceDamenParfüm.Filter = string.Empty;
        }
        private void txtDamenPafrümFilterBeiNummer_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDamenParfümFilterbeiName.Text) || !string.IsNullOrEmpty(txtDamenParfümFilterBeiMarke.Text))
            {
                txtDamenParfümFilterbeiName.Clear();
                txtDamenParfümFilterBeiMarke.Clear();
            }
            _FilterBeiNummerFürDamenParfüm("parfümNummer", txtDamenPafrümFilterBeiNummer.Text.Trim());
        }

        private void txtDamenParfümFilterBeiMarke_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDamenParfümFilterbeiName.Text) || !string.IsNullOrEmpty(txtDamenPafrümFilterBeiNummer.Text))
            {
                txtDamenParfümFilterbeiName.Clear();
                txtDamenPafrümFilterBeiNummer.Clear();
            }

            _FilterAnwendenFürDamenParfüms("Marke", txtDamenParfümFilterBeiMarke.Text.Trim());
        }

        private void txtDamenParfümFilterbeiName_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDamenParfümFilterBeiMarke.Text) || !string.IsNullOrEmpty(txtDamenPafrümFilterBeiNummer.Text))
            {
                txtDamenParfümFilterBeiMarke.Clear();
                txtDamenPafrümFilterBeiNummer.Clear();
            }

            _FilterAnwendenFürDamenParfüms("Name", txtDamenParfümFilterbeiName.Text.Trim());
        }

        private void txtDamenPafrümFilterBeiNummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Bestimme die Farbe, die für das ausgewählte und das nicht ausgewählte Tab verwendet wird
            Color selectedColor = Color.DarkGray;  // Farbe für den ausgewählten Tab
            Color unselectedColor = Color.LightGray; // Farbe für nicht ausgewählte Tabs

            // Prüfe, ob der Tab ausgewählt ist
            bool isSelected = e.Index == tabControl1.SelectedIndex;

            // Setze die Hintergrundfarbe entsprechend der Auswahl
            e.Graphics.FillRectangle(new SolidBrush(isSelected ? selectedColor : unselectedColor), e.Bounds);

            // Zeichne den Tab-Text in Schwarz oder einer anderen Farbe deiner Wahl
            string tabText = tabControl1.TabPages[e.Index].Text;
            TextRenderer.DrawText(e.Graphics, tabText, tabControl1.Font, e.Bounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void txtParfümSuchen_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.Handled = true;
            //    btnSuchen.PerformClick();
           
            //}
        }

        private void txtParfümSuchen_TextChanged(object sender, EventArgs e)
        {
            _AvlBaumImplementierung();

        }
        private void _AvlBaumImplementierung()
        {
            AutoComplete.AVLTree tree = new AutoComplete.AVLTree();

            foreach (DataRow row in _dtParfüms.Rows)
            {
                tree.Insert(row["Name"].ToString());
            }

            string perfix = txtParfümSuchen.Text.Trim();
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

                if (!string.IsNullOrEmpty(txtParfümSuchen.Text.Trim()))
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

        private void lbVorschläge_Click_1(object sender, EventArgs e)
        {
           
            //wir setzen den ausgewählten Vorschlag in das "txtFilterBeiName" Textfeld und verbergen wir  die listboxw
            if (lbVorschläge.SelectedItem != null)
            {
                txtParfümSuchen.Text = lbVorschläge.SelectedItem.ToString();
                lbVorschläge.Visible = false;
            }
            else
                MessageBox.Show("Kein gültiger Eintrag ausgewählt,\n" +
                    "Bitte wählen Sie einen gültigen Eintrag aus","Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnSuchen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtParfümSuchen.Text))
            {
                string gesuchteDaten = txtParfümSuchen.Text.Trim();
                // URL, die im Browser geöffnet werden soll
                string url = "https://www.parfumo.de/s_perfumes_x.php?in=1&filter=" + gesuchteDaten;

                // Starten Sie den Standard-Webbrowser mit der angegebenen URL
                Process.Start(new ProcessStartInfo(url));
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Suchbegriff ein.");
            }
        }

        private void txtParfümSuchen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Verhindern, dass die Enter-Taste in das Textfeld eingegeben wird (kein Signalton)
                e.Handled = true;

                // Klick den Such-Button auslösen
                btnSuchen.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmAddUpdateNewPerfum frm = new frmAddUpdateNewPerfum(-1))
            {
                frm.ShowDialog();
            }
            _LadeParfümDaten();
        }

        private void duftEntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            bool result = (MessageBox.Show("Sind Sie sicher, Sie möchten " +
              "diesen Vorgang durchführen","Hinweis",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning,
              MessageBoxDefaultButton.Button2) == DialogResult.OK);

            if (!result)
                return;

            int parfümNummer = (int)dgvParfüm.CurrentRow.Cells[0].Value;
            clsParfüm parfuemDaten = clsParfüm.FindByParfümNummer(parfümNummer);

         
            if (parfuemDaten != null && parfuemDaten.Delete())
            {
                AutoComplete.AVLTree tree = new AutoComplete.AVLTree();
                tree.Delete(parfuemDaten.Name);

                MessageBox.Show("Parfümdaten wurden erfolgreich entfernt","Entfernung",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _LadeParfümDaten();
            }
            else
                MessageBox.Show("Parfümdaten wurden nicht gefunden, \nbitte versuchen Sie es erneut.", "Entfernung",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void parfümHinzufügentoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmAddUpdateNewPerfum frm = new frmAddUpdateNewPerfum(-1))
            {
                frm.ShowDialog();
            }
            _LadeParfümDaten();
        }

        private void pafümAktualisierentoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int parfümNummer = (int)dgvParfüm.CurrentRow.Cells[0].Value;

            using(frmAddUpdateNewPerfum frm = new frmAddUpdateNewPerfum(parfümNummer))
            {
                frm.ShowDialog();
            }
            _LadeParfümDaten();
        }

        private void btnDatenAktualisieren_Click(object sender, EventArgs e)
        {
            _LadeParfümDaten();
        }

        private void _FilterAnwendenFürParfüms()
        {
            string spalteName = cbFilterBei.SelectedItem.ToString();
            string filterwert = txtFilterWert.Text;
            string[] wort = filterwert.Split(' ');

            lock (_filterLock)
            {
                if (cbFilterBei.SelectedIndex != -1)
                {
                    if (!string.IsNullOrEmpty(filterwert) )
                    {
                        if(spalteName == "ParfümNummer")
                        {
                            _bindingSourceParfüm.Filter = $"{spalteName} = {filterwert}";
                        }
                        else
                        {
                            if (wort.Length == 1)
                            {
                                _bindingSourceParfüm.Filter = $" {spalteName} Like '%{wort[0]}%'";
                            }
                            else if(wort.Length > 1)
                            {
                                _bindingSourceParfüm.Filter = $"{spalteName} Like '%{wort[0]}%' OR {spalteName} Like '%{wort[1]}%'";
                            }
                        }
                    }
                    else
                        _bindingSourceParfüm.Filter = string.Empty;
                }
            }
            _MarkiereParfümZeilen();
        }
        private void txtFilterWert_TextChanged(object sender, EventArgs e)
        {
            _FilterAnwendenFürParfüms();
        }

        private void cbFilterBei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBei.SelectedIndex != -1)
            {
                txtFilterWert.Clear();
                txtFilterWert.Focus();
            }
        }

        private void txtFilterWert_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedItem = cbFilterBei.SelectedItem.ToString();

            if (selectedItem == "ParfümNummer")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool running = false;  // Gibt an, ob der Server aktiv ist
        private async void btnFreigabe_Click(object sender, EventArgs e)
        {
            ////if (running)
            ////{
            ////    MessageBox.Show("Der Server läuft bereits!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    return; // Keine Aktion, wenn der Server bereits läuft
            ////}

            //try
            //{
            //    // Deaktiviere die Schaltfläche, um doppelte Klicks zu verhindern
            //    btnFreigabe.Enabled = false;

            //    // Starte den Server
            //    running = true;
            //    string result = await clsKomminikationsService.StartServerAsync();  // Server starten
            //    txtServerDienst.Text = result;  // Ergebnis anzeigen
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Fehler: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    // Reaktiviere die Schaltfläche
            //    btnFreigabe.Enabled = true;
            //    clsKomminikationsService.StopServer();
            //}

        }
        private void _ErstellePdfVonParfuem()
        {
            // Pfad zum Desktop des aktuellen Benutzers
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Name und Pfad der PDF-Datei
            string fileName = "Parfuemliste.pdf";
            string filePath = Path.Combine(desktopPath, fileName);

            try
            {
                // PDF speichern
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document pdfDoc = new Document())
                    {
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // Erstelle eine Tabelle mit 2 Spalten (Parfümnummer und Parfümname)
                        PdfPTable table = new PdfPTable(3);
                        table.WidthPercentage = 100;

                        // Füge Header zur Tabelle hinzu
                        table.AddCell("Parfümnummer");
                        table.AddCell("Parfümmarke");
                        table.AddCell("Parfümname");

                        // Füge die Daten aus dem DataGridView hinzu (Parfümnummer und Name)
                        foreach (DataGridViewRow row in dgvParfüm.Rows)
                        {
                            if (!row.IsNewRow) // Leere Zeilen überspringen
                            {
                                // Überprüfen, ob die Werte in der jeweiligen Spalte vorhanden sind
                                var parfuemNummer = row.Cells["Parfümnummer"]?.Value?.ToString();
                                var parfuemMarke = row.Cells["Marke"]?.Value.ToString();
                                var parfuemName = row.Cells["Name"]?.Value?.ToString();

                                if (!string.IsNullOrEmpty(parfuemNummer) && !string.IsNullOrEmpty(parfuemMarke) && !string.IsNullOrEmpty(parfuemName))
                                {
                                    // Füge Parfümnummer und Parfümname zur Tabelle hinzu
                                    table.AddCell(parfuemNummer);
                                    table.AddCell(parfuemMarke);
                                    table.AddCell(parfuemName);
                                }
                            }
                        }

                        // Füge die Tabelle zur PDF hinzu
                        pdfDoc.Add(table);

                        pdfDoc.Close();
                    }
                }

                // Erfolgreiche Speicherung anzeigen
                MessageBox.Show($"Die Datei wurde erfolgreich auf dem Desktop gespeichert:\n{filePath}", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung
                MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void erstelleEineParfümlisteAlsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ErstellePdfVonParfuem();
        }

        private void btnErstelleEineParfümListePdf_Click(object sender, EventArgs e)
        {
            _ErstellePdfVonParfuem();
        }
        private void dgvParfüm_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _MarkiereParfümZeilen();
        }
    }
}
