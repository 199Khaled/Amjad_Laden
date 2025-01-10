using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Activation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Busnisse_Layer;
using Windows.ApplicationModel.VoiceCommands;
using clsHilfsMethoden;

namespace Parfüm2025
{
    public partial class frmDruckvorschau : Form
    {
        int ZeileHinzugefügt = 0;
        float gesamtpreis = 0;
        List<clsRechnungsdetails> _verkaufsdatenListe;
        clsKunde _kudedaten;
        int _belegID;
        public frmDruckvorschau(int belegID,List<clsRechnungsdetails> verkaufsdatenListe, clsKunde kudedaten)
        {
            InitializeComponent();

            _verkaufsdatenListe = verkaufsdatenListe;

            lblDatum.Text = DateTime.Now.ToString();
            _kudedaten = kudedaten;
            _belegID = belegID;
        }
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
        }


        private void SavePanelToPdf()
        {
            // Pfad zum Desktop des aktuellen Benutzers
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string kundenname = _kudedaten.Vollname;
            string rechnungsDatum = clsDatumFormat.DateToShort(DateTime.Now.Date);
            // Name und Pfad der PDF-Datei
            string fileName = kundenname + rechnungsDatum + ".pdf";
            string filePath = Path.Combine(desktopPath, fileName);

            try
            {
                // Bitmap aus dem Panel erstellen
                using (Bitmap bitmap = new Bitmap(pnlHaupPanel.Width, pnlHaupPanel.Height))
                {
                    pnlHaupPanel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, pnlHaupPanel.Width, pnlHaupPanel.Height));

                    // PDF speichern
                    using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (Document pdfDoc = new Document(new iTextSharp.text.Rectangle(bitmap.Width, bitmap.Height)))
                        {
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // Konvertiere Bitmap zu iTextSharp-Image
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Png);

                            // Skalierung auf 15 % der Originalgröße
                            pdfImage.ScalePercent(90);

                            pdfImage.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                            // Füge das Bild zur PDF hinzu
                            pdfDoc.Add(pdfImage);

                            pdfDoc.Close();
                        }
                    }

                    MessageBox.Show($"Die Datei wurde erfolgreich auf dem Desktop gespeichert:\n{filePath}", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void _FülleKundedaten()
        {
            lblVollname.Text = _kudedaten.Vollname;
            lblStrasse.Text = _kudedaten.Straße;
            lblStadt.Text = _kudedaten.Stadt;
        }

        public void _FülleRechnungsdetails()
        {
            lblBelegID.Text = _belegID.ToString();
            foreach (var item in _verkaufsdatenListe)
            {
              
                dgvVerkaufsdaten.Rows.Add(
                    item.parfümNummer,
                    item.verkaufsMenge + " Kg"
                    , 19,
                    item.normalPreis,
                    item.gesamtPreis);
            }
            //AddOrUpdateSummeRow();
            UpdateSummeRow();
        }

        //private void AddOrUpdateSummeRow()
        //{
        //    // Prüfen, ob die Summenzeile bereits existiert
        //    if (dgvVerkaufsdaten.Rows.Count > 0 && dgvVerkaufsdaten.Rows[dgvVerkaufsdaten.Rows.Count -1 ].Tag?.ToString() == "Summe")
        //    {
        //        UpdateSummeRow();
        //        return;
        //    }

        //    // Summenzeile erstellen
        //    DataGridViewRow summeRow = new DataGridViewRow();
        //    summeRow.CreateCells(dgvVerkaufsdaten);
        //    summeRow.Tag = "Summe"; // Markiere diese Zeile als Summenzeile
        //    summeRow.DefaultCellStyle.Font = new System.Drawing.Font(dgvVerkaufsdaten.Font, FontStyle.Bold);
        //    summeRow.DefaultCellStyle.BackColor = Color.LightGray; // Optisch hervorheben

        //    summeRow.Cells[0].Value = "Summe"; // Text in der ersten Spalte
        //    summeRow.Cells[4].Value = gesamtpreis; // Initialer Summenwert in der letzten Spalte

        //    dgvVerkaufsdaten.Rows.Add(summeRow);
        //   UpdateSummeRow(); // Initiale Berechnung
        //}
        private void UpdateSummeRow()
        {
            float summe = 0;

            // Summe aller relevanten Zeilen berechnen
            foreach (DataGridViewRow row in dgvVerkaufsdaten.Rows)
            {
                if (row.Cells["Gesamt"].Value != null)
                {
                    float gesamtpreis = 0;
                    if (float.TryParse(row.Cells["Gesamt"].Value.ToString(), out gesamtpreis))
                        this.gesamtpreis = gesamtpreis;
                    summe += gesamtpreis;
                }
            }

            _BearbeiteSteuerdaten(summe);
        }

        private void _BearbeiteSteuerdaten(float summe)
        {
            // Bruttobetrag anzeigen
            lblBrutto.Text = summe.ToString("C");
    

            // Steueranteil berechnen und anzeigen
            float steuer = (summe * 19) / 119;
            lblSteuer.Text = steuer.ToString("C");

            float nettoPreis = 0;
       
            foreach (var item in _verkaufsdatenListe)
            {
               nettoPreis += item.normalPreis;
            }
            
            lblNetto.Text = nettoPreis.ToString("C");

           // lblRechnungsbetrag.Text = summe.ToString("C");
        }
        private void UpdateDataGridViewHeight()
        {
            int rowHeight = dgvVerkaufsdaten.RowTemplate.Height;  // Höhe einer Zeile
            int columnHeaderHeight = dgvVerkaufsdaten.ColumnHeadersHeight;  // Höhe des Headers
            int rowCount = dgvVerkaufsdaten.Rows.Count;  // Anzahl der Zeilen

            // Berechne die neue Höhe des DataGridView
            int newHeight = (rowHeight * rowCount) + columnHeaderHeight;

            int maxHeight = 400; // Max Höhe
            // Setze die neue Höhe
            dgvVerkaufsdaten.Height = Math.Min(newHeight, maxHeight);


            pnlNettoBrutto.Top= dgvVerkaufsdaten.Bottom + 1;

            pnlHaupPanel.Invalidate();
        }

 
        private void frmDruckvorschau_Load(object sender, EventArgs e)
        {
            _FülleKundedaten();
            _FülleRechnungsdetails();
            UpdateDataGridViewHeight();
        }

        private void dgvVerkaufsdaten_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //UpdateSummeRow();

           // _FülleRechnungsdetails();
            ZeileHinzugefügt = 17 * dgvVerkaufsdaten.Rows.Count;
            UpdateEcke();
            UpdateDataGridViewHeight();

        }

        private void dgvVerkaufsdaten_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           // UpdateSummeRow();

            ZeileHinzugefügt = 19 * dgvVerkaufsdaten.Rows.Count;
            UpdateEcke();
            UpdateDataGridViewHeight();

        }

        private void UpdateEcke()
        {
            pnlHaupPanel.Invalidate();
        }
        private void pnlHaupPanel_Paint(object sender, PaintEventArgs e)
        {
           // Erstelle ein Panel für die Ecke


                // Grafikobjekt für das Panel
                Graphics g = e.Graphics;

            // Berechne die Position und Größe des Panels
            int width = pnlHaupPanel.Width;  // Breite des Panels
            int height = pnlHaupPanel.Height; // Höhe des Panels      

            // Definiere die Punkte für das Dreieck in der unteren rechten Ecke
            Point[] points = new Point[]
            {
                    new Point(width, height),       // Untere rechte Ecke
                    new Point(width - 800, height),  //  Pixel nach links (unten)             
                     new Point(width, height - (480 - ZeileHinzugefügt))   // Pixel nach oben (rechts)
            };

            // Fülle das Dreieck mit der grünen Farbe
            g.FillPolygon(Brushes.YellowGreen, points);


            ZeileHinzugefügt = 0;
        }

        private void konvertiereZurPdfDateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePanelToPdf();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavePanelToPdf();
            this.Close();
        }
    }
}
