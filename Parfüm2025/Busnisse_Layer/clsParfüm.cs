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
    public class clsParfüm
    {
        public enum enMode { addnew = 0, update = 1 }
        private enMode _mode = enMode.addnew;
        public int parfümNummer { get; set; }
        public int neuParfümNummer { get; set; }
        public string Marke { get; set; }
        public string Name { get; set; }
        public string Kategorie { get; set; }
        public string Duftrichtung { get; set; }
        public string Jahreszeiten { get; set; }
        public bool IstVorhanden { get; set; }
        private clsParfüm(int parfümNummer, string  marke, string name, string kategorie,
                                   string duftrichtung, string jahreszeitn, bool istVorhanden)
        {
            this.parfümNummer = parfümNummer;
            this.Marke = marke;
            this.Name = name;
            this.Kategorie = kategorie;
            this.Duftrichtung = duftrichtung;
            this.Jahreszeiten = jahreszeitn;
            IstVorhanden = istVorhanden;

            _mode = enMode.update;
        }

        public clsParfüm()
        {
            this.parfümNummer = -1;
            this.Marke = string.Empty;
            this.Name = string.Empty;
            this.Kategorie = string.Empty;
            this.Duftrichtung = string.Empty;
            this.Jahreszeiten = string.Empty;
            this.IstVorhanden = true;

            _mode = enMode.addnew;
        }

        public static clsParfüm FindByParfümNummer(int parfümNummer)
        {
            string marke = string.Empty; string name = string.Empty; string kategorie = string.Empty;
            string duftrichtung = string.Empty; string jahreszeiten = string.Empty; bool istvorhanden = false;

            if (clsParfümDatenzugriff.Find(parfümNummer, ref marke, ref name, ref kategorie,
                ref duftrichtung, ref jahreszeiten, ref istvorhanden))
            {
                return new clsParfüm(parfümNummer, marke, name, kategorie, duftrichtung, jahreszeiten,istvorhanden);
            }
            else
                return null;
        }

        private bool _Addnew()
        {
            if (clsParfümDatenzugriff.AddNewPerfum(this.parfümNummer, this.Marke, this.Name,
                 this.Kategorie, this.Duftrichtung, this.Jahreszeiten,this.IstVorhanden))
            {
                return true;
            }
            else
                return false;
        }

        private bool _Update()
        {
            return clsParfümDatenzugriff.UpdatePerfum(this.neuParfümNummer, this.parfümNummer, this.Marke, this.Name,
                this.Kategorie, this.Duftrichtung, this.Jahreszeiten, this.IstVorhanden);
        }

        public static bool Delete(int parfümNummer)
        {
            return clsParfümDatenzugriff.Delete(parfümNummer);
        }

        public bool Delete()
        {
            return clsParfümDatenzugriff.Delete(this.parfümNummer);
        }
        public bool Save()
        {
            switch(_mode)
            {
                case enMode.addnew:
                    if (_Addnew())
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
        public static DataTable GetAllParfüms()
        {
            return clsParfümDatenzugriff.GetAllParfüms();
        }

        public static DataTable GetAllHerrenParfüms()
        {
            return clsParfümDatenzugriff.GetAllHerrenParfüms();
        }

        public static DataTable GetAllDamenParfüms()
        {
            return clsParfümDatenzugriff.GetAllDamenParfüms();
        }

        public static bool IstParfümNummerVergeben(int parfümNummer)
        {
            return clsParfümDatenzugriff._IstParfümNummerVergeben(parfümNummer);
        }
    }
}
