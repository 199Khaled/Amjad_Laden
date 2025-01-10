using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parfüm2025
{
    public class clsDruckerService
    {

        private List<(string text, Point position)> _GetPanelContenteWithPosition(Panel panel)
        {
            List<(string, Point)> contentWithPosition = new List<(string text, Point position)>();

            foreach (Control control in panel.Controls)
            {
                if (!string.IsNullOrEmpty(control.Text))
                {
                    contentWithPosition.Add((control.Text, control.Location));
                }
            }
            return contentWithPosition;
        }

        private void _print(Panel panel, ComboBox cbPrinter)
        {

            _sucheDrucker(cbPrinter);  //Diese Methode sucht nach allen verfügbaren Printer
            PrintDocument printDocument = new PrintDocument();

            var contenWithPosition = _GetPanelContenteWithPosition(panel);

            if (contenWithPosition.Count == 0)
            {
                MessageBox.Show("Keine Inhalte zum Drucken gefunden.");
                return;
            }

            printDocument.PrintPage += (sender, e) =>
            {
                int offsetX = 50;
                int offsetY = 50;

                foreach (var (text, position) in contenWithPosition)
                {
                    var drawPostion = new Point(position.X + offsetX, position.Y + offsetY);
                    e.Graphics.DrawString(text, new Font("Arial", 12), Brushes.Black, drawPostion);
                }
            };

            //PrintPreviewDialog preveiwDialog = new PrintPreviewDialog
            //{
            //    Document = printDocument
            //};
            //preveiwDialog.ShowDialog();

            // Druck - Dialog anzeigen
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocument.Print(); // Drucken
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Druck fehlgeschlagen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

        }

        private void _sucheDrucker(ComboBox cbPrinter)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cbPrinter.Items.Add(printer);
            }

            if (cbPrinter.Items.Count > 0)
                cbPrinter.SelectedIndex = 0;
        }
    }
}
