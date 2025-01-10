using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Busnisse_Layer
{
    public class clsEinkauf
    {
        public enum enMode { addnew = 0, update = 1 }
        private enMode _mode = enMode.addnew;

        public enum enUpdate { UpdateDurchParfümNummer = 0, UpdateDurchParfümName}

        public int parfümNummer { get; set; }
        public string parfümName { get; set; }
        public string batchNummer { get; set; }
        public string parfümCode { get; set; }
        public float lagerbestand { get; set; }
        public int preisKategorie { get; set; }
        public DateTime erstellungsDatum { get; set; }

        private clsEinkauf(int parfümNummer, string parfümName, string batchNummer, string parfümCode,
            float lagerbestand, int preisKategorie, DateTime erstellungsDatum)
        {
            this.parfümNummer = parfümNummer;
            this.parfümName = parfümName;
            this.batchNummer = batchNummer;
            this.parfümCode = parfümCode;
            this.lagerbestand = lagerbestand;
            this.preisKategorie = preisKategorie;
            this.erstellungsDatum = erstellungsDatum;

            _mode = enMode.update;
        }

        public clsEinkauf()
        {
            this.parfümNummer = -1;
            this.parfümName = string.Empty;
            this.batchNummer = string.Empty;
            this.parfümCode = string.Empty;
            this.lagerbestand = 0;
            this.preisKategorie = 1;
            this.erstellungsDatum = DateTime.Now;

            _mode = enMode.addnew;
        }

        public static clsEinkauf FindEinkaufDatenByParfümNummer(int parfümNummer)
        {
            string parfümName = string.Empty; string batchNummer = string.Empty;
            string parfümCode = string.Empty; float lagerbestand = 0;
            int preisKategorie = 1;  DateTime erstellungsDatum = DateTime.Now;

            if (clsEinkaufDatenzugriff.GetEinkaufDatenByParfümID(parfümNummer, ref parfümName, ref batchNummer,
                                                         ref parfümCode, ref lagerbestand, ref preisKategorie, ref erstellungsDatum))
            {
                return new clsEinkauf(parfümNummer, parfümName, batchNummer, parfümCode, lagerbestand, preisKategorie, erstellungsDatum);
            }
            else
                return null;
        }
        private bool _AddNewEinkaufDaten()
        {
            return clsEinkaufDatenzugriff.AddNewEinkaufDaten(this.parfümNummer, this.parfümName, this.batchNummer,
                                                            this.parfümCode, this.lagerbestand,this.preisKategorie, this.erstellungsDatum);
        }

        //public bool _UpdateByParfümName()
        //{
        //    return clsEinkaufDatenzugriff.UpdateMengeByParfümName(this.parfümName, this.batchNummer, this.parfümCode,
        //                                                           this.lagerbestand, erstellungsDatum);
        //}

        public bool _UpdateByParfümNummer()
        {
            return clsEinkaufDatenzugriff.UpdateEinkaufDaten(this.parfümNummer, this.batchNummer, this.parfümCode,
                                                                   this.lagerbestand,this.preisKategorie, erstellungsDatum);
        }

        public static bool UpdateLagerbestand(int parfümNummer, float neueLagerbestand)
        {
            return clsEinkaufDatenzugriff.UpdateLagerbestand(parfümNummer, neueLagerbestand);
        }
        public bool Save()
        {
            switch(_mode)
            {
                case enMode.addnew:
                    if (_AddNewEinkaufDaten())
                    {
                        _mode = enMode.update;
                        return true;
                    }
                    else
                        return false;


                case enMode.update:
                    {
                        return _UpdateByParfümNummer();
                    }
            }
            return false;
        }

        public static bool istParfümNummerVerfügbar(int parfümNummer)
        {
            return clsEinkaufDatenzugriff.IstParfümNummerVerfügbar(parfümNummer);
        }

        public bool Delete()
        {
            return clsEinkaufDatenzugriff.DeleteEinkaufDaten(this.parfümNummer);
        }

        public static DataTable GetAllEinkaufDaten()
        {
            return clsEinkaufDatenzugriff.GetAllEinkaufDaten();
        }

    }
}
