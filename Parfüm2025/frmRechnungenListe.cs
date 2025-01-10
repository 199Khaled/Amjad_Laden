using Busnisse_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.ApplicationModel.UserDataTasks;




namespace Parfüm2025
{
    public partial class frmVerkaufsDatenListe : Form
    {
        DataTable _dtRechnungsdaten;
        BindingSource _bindingSource;
        private readonly object _lockObject = new object();
        public frmVerkaufsDatenListe()
        {
            InitializeComponent();

            _bindingSource = new BindingSource();
        }
        private void _SetzteRechnungsdaten()
        {
            float gesamtSumme = 0;
            _dtRechnungsdaten = clsRechnung.GetRechnungsRecordAnzahlProSeite(300, 1);
            _bindingSource.DataSource = _dtRechnungsdaten;
            dgvVerkaufsDaten.DataSource = _bindingSource;

            //Wie Bekommen die Gesamtsumme aus der Liste für alle Gesamtpreise.
            foreach (DataRow row in _dtRechnungsdaten.Rows)
            {
                if (row["BelegID"] != DBNull.Value)
                {
                    int belegID = Convert.ToInt32(row["BelegID"]);
                    List<clsRechnungsdetails> rechnugnsdetails = clsRechnungsdetails.LadeRechnungsDetails(belegID);

                    foreach (var element in rechnugnsdetails)
                    {
                        gesamtSumme += element.gesamtPreis;
                    }

                    row["GesamtSumme"] = gesamtSumme;
                }

                gesamtSumme = 0;
            }

            // Setze die GesamtSumme 

            //  _setzePassendeFarbeFürLagerbestand();
            lblRecord.Text = _bindingSource.Count.ToString();
        }
        private void btnAktualisereVerkaufsDaten_Click(object sender, EventArgs e)
        {
            _SetzteRechnungsdaten();
        }
        private void frmVerkaufsDatenListe_Load(object sender, EventArgs e)
        {
            cbFilterbei.SelectedIndex = 0;
            cbFilterbei.DropDownStyle = ComboBoxStyle.DropDownList; //verhindert die Combobox Einträge zu ändern.


            _SetzteRechnungsdaten();
        }

        private void _Filteranwenden()
        {
            string filterspalte = cbFilterbei.SelectedItem.ToString();
            string filterwert = txtFilerwert.Text.Trim();

            lock (_lockObject)
            {
                if(filterspalte == "erstellungsDatum")
                {
                    DateTime selectedDate = dtpErstellungsdatum.Value.Date; // Nur das Datum, keine Zeit

                    // Start- und Endzeit des Tages
                    DateTime startOfDay = selectedDate;
                    DateTime endOfDay = selectedDate.AddDays(1).AddTicks(-1);

                    // Formatieren der Werte für den Filter
                    string startFormatted = startOfDay.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    string endFormatted = endOfDay.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    // Filter setzen für den gesamten Tag
                    _bindingSource.Filter = $"{filterspalte} >= #{startFormatted}# AND {filterspalte} <= #{endFormatted}#";
                    //_bindingSource.Filter = $"{filterspalte} = #{startFormatted}#";
                    return;
                }

                if (!string.IsNullOrEmpty(filterwert))
                {
                    if (filterspalte == "ParfümNummer" || filterspalte == "BelegID")
                    {

                        _bindingSource.Filter = $"{filterspalte} = {filterwert}";
                    }
                    else if (filterspalte == "KundenName")
                    {                  
                        _bindingSource.Filter = $"{filterspalte} Like '{filterwert}%'";
                    }                  
                }
                else
                {
                    _bindingSource.Filter = string.Empty;
                }
                
                lblRecord.Text = _bindingSource.Count.ToString();
            }
        }
        private void txtFilerwert_TextChanged(object sender, EventArgs e)
        {
            _Filteranwenden();
        }

        private void cbFilterbei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterbei.SelectedItem.ToString() == "erstellungsDatum")
            {
                dtpErstellungsdatum.Visible = true;
                dtpErstellungsdatum.Focus();
                txtFilerwert.Visible = false;

            }
            else
            {
                dtpErstellungsdatum.Visible = false;
                txtFilerwert.Visible = true;
                _bindingSource.Filter = string.Empty;
            }

            if (cbFilterbei.SelectedIndex != -1)
            {
                txtFilerwert.Clear();
                txtFilerwert.Focus();
            }
            
            lblRecord.Text = _bindingSource.Count.ToString();
        }

        private void txtFilerwert_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterbei.SelectedItem.ToString() == "ParfümNummer" || cbFilterbei.SelectedItem.ToString() == "BelegID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnHinzufügeVerkaufsDaten_Click(object sender, EventArgs e)
        {
            frmAddUpdateRechnung frm = new frmAddUpdateRechnung(-1, frmAddUpdateRechnung.enMode.addnew);
            frm.ShowDialog();

            _SetzteRechnungsdaten();
        }
  
        private void entferneVerkaufsdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int belegID = (int)dgvVerkaufsDaten.CurrentRow.Cells[0].Value;
            clsRechnung rechnungsdaten = clsRechnung.Find(belegID);

            List<clsRechnungsdetails> rechnungsdetailsDaten = clsRechnungsdetails.LadeRechnungsDetails(belegID);
       
            bool result = (MessageBox.Show("Sind Sie sicher, Sie möchten diesen Vorgang durchführen?", "Hinweis",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes);

            bool deleteSuccess = true; // Lokale Variable, um den Status der Löschoperation zu verfolgen.
            if (rechnungsdetailsDaten.Count > 0)
            {
                foreach (var detail in rechnungsdetailsDaten)
                {
                    if(!detail.Delete())
                    {
                        deleteSuccess = false; // Wenn ein Detail nicht gelöscht wird, setze deleteSuccess auf false.
                    }
                }

            }

            if (!result)
                return;

            if (result && deleteSuccess && rechnungsdaten != null && rechnungsdaten.Delete())
            {
                MessageBox.Show("Rechnung erfolgreich entfernt", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _SetzteRechnungsdaten();
            }
            else
                MessageBox.Show("Fehler beim Entfernen der Rechnung ist aufgetreten.", "Fehlermeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dtpErstellungsdatum_ValueChanged(object sender, EventArgs e)
        {
            _Filteranwenden();
        }


        private void GeheZurRechnungsdetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int belegID = (int)dgvVerkaufsDaten.CurrentRow.Cells[0].Value;
            string kundenName = dgvVerkaufsDaten.CurrentRow.Cells[1].Value.ToString();
            frmRechnungsDetailsListe frm = new frmRechnungsDetailsListe(belegID, kundenName);
            frm.ShowDialog();

            _SetzteRechnungsdaten();
        }

        private void aktualisiereVerkaufdatentoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int belegID = (int)dgvVerkaufsDaten.CurrentRow.Cells[0].Value;
            frmAddUpdateRechnung frm = new frmAddUpdateRechnung(belegID, frmAddUpdateRechnung.enMode.update);
            frm.ShowDialog();

            _SetzteRechnungsdaten();
        }

        private void erstelleEineRechnungsvorlageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int belegID = (int)dgvVerkaufsDaten.CurrentRow.Cells[0].Value;
            clsRechnung rechnung = clsRechnung.Find(belegID);
            List<clsRechnungsdetails>rechnungsdetails = clsRechnungsdetails.LadeRechnungsDetails(belegID);
            clsKunde kundedaten = clsKunde.FindKundeByID(rechnung.kundeID);

            frmDruckvorschau frm = new frmDruckvorschau(belegID, rechnungsdetails, kundedaten);
            frm.Show();
           
        }

        private void dgvVerkaufsDaten_DoubleClick(object sender, EventArgs e)
        {
            int belegID = (int)dgvVerkaufsDaten.CurrentRow.Cells[0].Value;
            string kundenName = dgvVerkaufsDaten.CurrentRow.Cells[1].Value.ToString();
            frmRechnungsDetailsListe frm = new frmRechnungsDetailsListe(belegID, kundenName);
            frm.ShowDialog();

            _SetzteRechnungsdaten();
        }
    }
}
