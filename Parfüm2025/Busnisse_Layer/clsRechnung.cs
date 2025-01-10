using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Busnisse_Layer
{
    public class clsRechnung
    {  

        private enum enMode { addnew = 0, update = 1 }
        enMode _mode = enMode.addnew;
        public int belegID { get; set; }
        public int kundeID { get; set; }
        public clsKunde kundeInfos
        {
            get { return clsKunde.FindKundeByID(this.kundeID); }
        }
        public DateTime erstellungsDatum { get; set; }
        public float gesammtSumme { get; set; }

        private clsRechnung(int belegID, int kundeID, DateTime erstellungsdatum, float gesamtSumme)
        {
            this.belegID = belegID;
            this.kundeID = kundeID;
            this.erstellungsDatum = erstellungsdatum;
            this.gesammtSumme = gesamtSumme;

            _mode = enMode.update;
        }

        public clsRechnung()
        {
            this.belegID = -1;
            this.kundeID = -1;
            this.erstellungsDatum = DateTime.Now;
            this.gesammtSumme = 0;

            _mode = enMode.addnew;
        }

        private bool _AddNewRechnung()
        {
            this.belegID = clsRechnugDatenzugriff.NeueRechnungErstellen(this.kundeID, this.gesammtSumme);

            return (this.belegID != -1);
        }
        private bool _Update()
        {
            return clsRechnugDatenzugriff.UpdateRechnung(this.belegID, this.kundeID, this.gesammtSumme);
        }

        public bool Save()
        {
            switch(_mode)
            {
                case enMode.addnew:
                    if (_AddNewRechnung())
                    {
                        _mode = enMode.update;
                        return true;
                    }
                    else
                        return false;

                case enMode.update:
                    return _Update();
            }

            return false;
        }
        public static clsRechnung Find(int belegID)
        {
            int kundeID = -1; DateTime erstellungsDatum = DateTime.Now; float gesammtSumme = 0;

            if (clsRechnugDatenzugriff.GetRechnungByID(belegID, ref kundeID, ref erstellungsDatum, ref gesammtSumme))
            {
                return new clsRechnung(belegID, kundeID, erstellungsDatum, gesammtSumme);
            }
            else
                return null;
        }

        public static clsRechnung FindByKundeID(int kundeID)
        {
            int belegID = -1; DateTime erstellungsDatum = DateTime.Now; float gesammtSumme = 0;

            if (clsRechnugDatenzugriff.GetRechnungByKundeID(ref belegID, kundeID, ref erstellungsDatum, ref gesammtSumme))
            {
                return new clsRechnung(belegID, kundeID, erstellungsDatum, gesammtSumme);
            }
            else
                return null;
        }

        public static DataTable GetRechnungsRecordAnzahlProSeite(int ZeileProSeite, int SeiteNummer)
        {
            return clsRechnugDatenzugriff.GetRecordAnzahlProSeite(ZeileProSeite, SeiteNummer);
        }
       
        public bool Delete()
        {
            return clsRechnugDatenzugriff.DeleteRechnung(this.belegID);
        }
    }
}
