using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.VoiceCommands;

namespace Parfüm2025
{
    public partial class frmOverly : Form
    {
        public frmOverly()
        {
            InitializeComponent();

            // Eigenschaften für die Überlagerung
            this.FormBorderStyle = FormBorderStyle.None; // Keine Rahmen
            this.WindowState = FormWindowState.Maximized; // Vollbild
            this.BackColor = Color.White; // Hintergrundfarbe (kann angepasst werden)
            this.Opacity = 0.9; // Transparenz (50% Sichtbarkeit)
            this.TopMost = true; // Immer im Vordergrund

            // KeyPreview aktivieren, um Tastenanschläge abzufangen
            this.KeyPreview = true;

            // KeyDown-Ereignis abonnieren
            this.KeyDown += frmOverlay_KeyDown;
        }
        private void frmOverlay_KeyDown(object sender, KeyEventArgs e)
        {
            // Wenn F11 gedrückt wird, schließe die Overlay-Form
            if(e.KeyCode == Keys.F11)
            {
                this.Close();
            }
        }
        private void frmOverly_Load(object sender, EventArgs e)
        {

        }
    }
}
