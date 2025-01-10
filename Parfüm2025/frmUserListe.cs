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

namespace Parfüm2025
{
    public partial class frmUserListe : Form
    {
        DataTable _user;
        
        public frmUserListe()
        {
            InitializeComponent();
        }

        private void _setzeUserdaten()
        {
            _user = clsUser.GetAllUser();
            dgvUser.DataSource = _user;
            lblRecord.Text = dgvUser.Rows.Count.ToString();
        }

        private void frmUserListe_Load(object sender, EventArgs e)
        {
            _setzeUserdaten();
        }

        private void SeheBenutzerDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int mitarbeiterID = (int)dgvUser.CurrentRow.Cells[1].Value;
            frmAddUpdateNeueUser frm = new frmAddUpdateNeueUser(mitarbeiterID, frmAddUpdateNeueUser.enMode.seheDetails);
            frm.ShowDialog();
        }

        private void aktualisiereBenutzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int mitarbeiterID = (int)dgvUser.CurrentRow.Cells[1].Value;
            frmAddUpdateNeueUser frm = new frmAddUpdateNeueUser(mitarbeiterID, frmAddUpdateNeueUser.enMode.update);
            frm.ShowDialog();

            _setzeUserdaten();
        }

        private void entferneBenutzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = MessageBox.Show("Sind Sie sicher, Sie möchten diesen Vorgang durchführen?",
                      "Hinweis", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK;

            int mitarbeiterID = (int)dgvUser.CurrentRow.Cells[1].Value;
            clsUser user = clsUser.FindUserByMitarbeiterID(mitarbeiterID);

            if (!result)
                return;

            if (user != null && user.Delete())
            {
                MessageBox.Show("Der Vorgang wurde erfolgreich durchgeführt", "Erfolg",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _setzeUserdaten();
            }
            else
                MessageBox.Show("Fehler ist aufgetreten!", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void deaktiviereBenutzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvUser.CurrentRow.Cells[0].Value;

            if (!clsUser.deaktiviereUser(userID))
            {
                MessageBox.Show("Der Benutzer ist bereits Inaktive!!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _setzeUserdaten();
        }

        private void aktiviereBenutzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvUser.CurrentRow.Cells[0].Value;

            if (!clsUser.aktiviereUser(userID))
            {
                MessageBox.Show("Der Benutzer ist bereits Aktive!!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _setzeUserdaten();
        }
    }
}
