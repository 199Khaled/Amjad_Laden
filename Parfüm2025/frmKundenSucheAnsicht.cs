using Busnisse_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Graphics.Printing.PrintSupport;

namespace Parfüm2025
{
    public partial class frmKundenSucheAnsicht : Form
    {
        private readonly object _lockObj = new object();
        private string _kundeName = string.Empty;
        public frmKundenSucheAnsicht(string kundeName)
        {
            InitializeComponent();
            _kundeName = kundeName;
        }

        private void _SetzeKundeDaten()
        {
            // Optionaler Lock für Thread-Sicherheit
            lock (_lockObj)
            {
                // Abrufen der Kundendaten
                DataTable kundedaten = clsKunde.GetKundeByName(_kundeName);

                if (kundedaten != null && kundedaten.Rows.Count > 0)
                {
                    dgvKundedaten.DataSource = kundedaten;
                }
                else
                {
                    // Keine Daten gefunden
                    dgvKundedaten.DataSource = null;
                    MessageBox.Show($"Es wurden keine Daten für den Kunden '{_kundeName}' gefunden.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void frmKundenSucheAnsicht_Load(object sender, EventArgs e)
        {
            
            _SetzeKundeDaten();
        }
    }
}
