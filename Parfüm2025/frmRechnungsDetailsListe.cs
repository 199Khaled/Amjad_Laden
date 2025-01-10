using Busnisse_Layer;
using iTextSharp.text.pdf;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.VoiceCommands;
using iTextSharp.text;

namespace Parfüm2025
{
    public partial class frmRechnungsDetailsListe : Form
    {
        private int _belegID;
        private string _kundenname;
        List<clsRechnungsdetails> _rechnungsDetails;

        public delegate void Databack(object senden, float lagerbestand, int parfümNummer);
        public event Databack lagerbestandAktualisiert;
        public frmRechnungsDetailsListe(int belegID, string kundenname)
        {
            InitializeComponent();

            _belegID = belegID;
            _kundenname = kundenname;
        }

        private void _SetzeRechnungsDetailsDaten()
        {
            _rechnungsDetails = clsRechnungsdetails.LadeRechnungsDetails(_belegID);
            dgvRechnungsdetails.Rows.Clear();

            if (_rechnungsDetails.Count > 0)
            {
                foreach (var details in _rechnungsDetails)
                {
                    string verkaufsmenge = details.verkaufsMenge.ToString() + "     kg";
                    string lagerbestand = details.lagerbestand.ToString() + "     kg";
                    string normalPreis = details.normalPreis.ToString("C", CultureInfo.GetCultureInfo("de-DE"));
                    string gesamtPreis = details.gesamtPreis.ToString("C", CultureInfo.GetCultureInfo("de-DE"));

                    dgvRechnungsdetails.Rows.Add(details.detailID, details.belegID, details.parfümNummer,
                   verkaufsmenge, lagerbestand, normalPreis, gesamtPreis, details.lagerbestandAktualisiert);
                }
            }

            _setzePassendeFarbeFürLagerbestand();
        }
        private void frmRechnungsDetailsListe_Load(object sender, EventArgs e)
        {
            _SetzeRechnungsDetailsDaten();
        }


        private void aktualisiereRechnungsdetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int detailID = (int)dgvRechnungsdetails.CurrentRow.Cells[0].Value;
            int belegID = (int)dgvRechnungsdetails.CurrentRow.Cells[1].Value;

            frmAddUpdateRechnungsDetails frm = new frmAddUpdateRechnungsDetails(detailID, belegID, _kundenname, frmAddUpdateRechnungsDetails.enMode.update);
            frm.ShowDialog();

            _SetzeRechnungsDetailsDaten();
        }
        private void _SetzeNotifikation(int parfümNummer)
        {
            new ToastContentBuilder()
                 .AddText("Achtung: Niedriger Lagerbestand!")
                   .AddText($"Der Lagerbestand für die ParfümNummer {parfümNummer} ist gefallen. Bitte prüfen Sie die Bestände.")
                   .SetToastDuration(ToastDuration.Short) // Toast länger anzeigen
                     .Show();
        }
        private float _ToFloat(string text)
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
                MessageBox.Show($"Die Eingabe '{text}' enthält keine gültige Zahl.");
                return 0f;
            }
        }

        private void entferneRechnungsdetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int detailID = (int)dgvRechnungsdetails.CurrentRow.Cells[0].Value;
            clsRechnungsdetails rechnungsdetail = clsRechnungsdetails.Find(detailID);


            bool result = (MessageBox.Show("Sind Sie sicher, Sie möchten diesen Vorgang durchführen?", "Hinweis",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);

            if (!result)
                return;

            if (result && rechnungsdetail != null && rechnungsdetail.Delete())
            {
                MessageBox.Show("Rechnungsdetails erfolgreich entfernt", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _SetzeRechnungsDetailsDaten();
            }
            else
                MessageBox.Show("Fehler beim Entfernen der Rechnungsdetails ist aufgetreten.", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _setzePassendeFarbeFürLagerbestand()
        {
            foreach (DataGridViewRow row in dgvRechnungsdetails.Rows)
            {
                if (row.Cells["lagerbestand"].Value != null) // Sicherstellen, dass die Zelle nicht null ist
                {
                    // Konvertiere den Zellwert in einen float
                    float lagerbestand = _ToFloat(row.Cells["lagerbestand"].Value.ToString());

                    // Beispiel: Verwende den lagerbestand-Wert
                    if (lagerbestand < 1)
                    {
                        row.Cells["lagerbestand"].Style.BackColor = Color.Red;
                        row.Cells["lagerbestand"].Style.ForeColor = Color.White; // Weißer Text
                    }
                    else
                    {
                        row.Cells["lagerbestand"].Style.BackColor = Color.White;
                        row.Cells["lagerbestand"].Style.ForeColor = Color.Black; // Schwarzer Text
                    }
                }
            }
        }

        private void HinzufügeRechnungsdetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int belegID = (int)dgvRechnungsdetails.CurrentRow.Cells[1].Value;

            frmAddUpdateRechnungsDetails frm = new frmAddUpdateRechnungsDetails(-1, belegID, _kundenname, frmAddUpdateRechnungsDetails.enMode.addnew);
            frm.ShowDialog();
            _SetzeRechnungsDetailsDaten();
        }

        private void dgvRechnungsdetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void btnAddRechnungsDetails_Click(object sender, EventArgs e)
        {
            frmAddUpdateRechnungsDetails frm = new frmAddUpdateRechnungsDetails(-1, _belegID, _kundenname, frmAddUpdateRechnungsDetails.enMode.addnew);
            frm.ShowDialog();
            _SetzeRechnungsDetailsDaten();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRealisiereRechnungsdetails_Click(object sender, EventArgs e)
        {

            if (_rechnungsDetails.Count > 0 && _rechnungsDetails != null)
            {
                foreach (var element in _rechnungsDetails)
                {
                    if (element.lagerbestandAktualisiert == false)
                    {
                        float neueLagerbestand = element.lagerbestand - element.verkaufsMenge;
                        clsEinkauf.UpdateLagerbestand(element.parfümNummer, neueLagerbestand);

                        if (!clsRechnungsdetails.SetzeLagerbestandAktualisiert(element.detailID, neueLagerbestand, true))
                        {
                            MessageBox.Show($"Fehler beim Aktualisieren des Lagerbestands für Detail-ID {element.detailID}. Bitte überprüfen Sie die Daten und versuchen Sie es erneut.",
                                "Lagerbestand-Fehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        if (neueLagerbestand < 1)
                        {
                            _SetzeNotifikation(element.parfümNummer);
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Keine Rechnungsdetails vorhanden, die verarbeitet werden können.",
                    "Keine Daten",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            _SetzeRechnungsDetailsDaten();
        }

        private void _ErstellePdfVonParfuem()
        {
            // Pfad zum Desktop des aktuellen Benutzers
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Name und Pfad der PDF-Datei
            string fileName = _kundenname + "_Rechnungsdetails.pdf";
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
                        PdfPTable table = new PdfPTable(2);
                        table.WidthPercentage = 100;

                        // Füge Header zur Tabelle hinzu
                        table.AddCell("Parfümnummer");
                        table.AddCell("VerkaufsMenge");


                        // Füge die Daten aus dem DataGridView hinzu (Parfümnummer und Name)
                        foreach (DataGridViewRow row in dgvRechnungsdetails.Rows)
                        {
                            if (!row.IsNewRow) // Leere Zeilen überspringen
                            {
                                // Überprüfen, ob die Werte in der jeweiligen Spalte vorhanden sind
                                var parfuemNummer = row.Cells["parfümnummer"]?.Value?.ToString();
                                var parfuemMarke = row.Cells["verkaufsMenge"]?.Value.ToString();

                                if (!string.IsNullOrEmpty(parfuemNummer) && !string.IsNullOrEmpty(parfuemMarke))
                                {
                                    // Füge Parfümnummer und Parfümname zur Tabelle hinzu
                                    table.AddCell(parfuemNummer);
                                    table.AddCell(parfuemMarke);
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

        private void button2_Click(object sender, EventArgs e)
        {
            _ErstellePdfVonParfuem();
        }
    }
}
