using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Busnisse_Layer
{
    public class clsKunde : clsPerson
    {
        public enum enMode { addNew = 0, Update = 1 }
        private enMode _Mode = enMode.addNew;

        public int kundeID { get; set; }
        public string firmaName{ get; set; }
        public DateTime regestriertAm { get; set; }
        public bool istAktive { get; set; }
        private clsKunde(int personID, string vorname, string nachname, DateTime geburtstag, char geschlecht,
            string steuerID, string email, string strasse, string stadt, string land, string telefon,
            int kundeID, string firmaName, DateTime regestriertAm, bool istAktive)
            : base(personID, vorname, nachname, geburtstag, geschlecht, steuerID, email, strasse, stadt, land, telefon)
        {
            this.kundeID = kundeID;
            this.firmaName = firmaName;
            this.regestriertAm = regestriertAm;
            this.istAktive = istAktive;

            _Mode = enMode.Update;
        }

        public clsKunde()
        {
            this.kundeID = -1;
            this.firmaName = string.Empty;
            this.regestriertAm = DateTime.Now;
            this.istAktive = true;

            _Mode = enMode.addNew;
        }

        private bool _AddNew()
        {
            this.kundeID = clsKundeDatenzugriff.AddNewKunde(this.PersonID, this.firmaName, this.regestriertAm, this.istAktive);
            return (this.kundeID != -1);
        }

        private bool _Update()
        {
            return clsKundeDatenzugriff.UpdateKunde(this.kundeID, this.firmaName, this.regestriertAm, this.istAktive);
        }

        public override bool Save()
        {

            switch (_Mode)
            {
                case enMode.addNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        base.Delete();
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static clsKunde FindKundeByID(int kundeID)
        {
            int personID = -1; string firmaName = string.Empty; DateTime regestriertAm = DateTime.Now; bool istAktive = false;

            bool isfound = clsKundeDatenzugriff.GetKundebyID(kundeID, ref personID, ref firmaName, ref regestriertAm, ref istAktive);

            if (!isfound) return null;// falls ist nicht gefunden.

            //wir suchen nach der generischen Person für diesen Mitarbeiter
            clsPerson person = clsPerson.Find(personID);

            if (person != null)
            {
                return new clsKunde(person.PersonID, person.Vorname, person.Nachname, person.GeburtsTag, person.Geschlecht,
                    person.SteuerID, person.Email, person.Straße, person.Stadt, person.Land, person.Telefon,
                    kundeID, firmaName, regestriertAm, istAktive);
            }
            else
                return null;
        }

        public static clsKunde FindKundeByPersonID(int personID)
        {
            int kundeID = -1; string firmaName = string.Empty; DateTime regestriertAm = DateTime.Now; bool istAktive = false;

            bool isfound = clsKundeDatenzugriff.GetKundebyPersonID(ref kundeID, personID, ref firmaName, ref regestriertAm, ref istAktive);

            if (!isfound) return null; // falls ist nicht gefunden.

            //wir suchen nach der generischen Person für diesen Mitarbeiter
            clsPerson person = clsPerson.Find(personID);

            if (person != null)
            {
                return new clsKunde(person.PersonID, person.Vorname, person.Nachname, person.GeburtsTag, person.Geschlecht,
                    person.SteuerID, person.Email, person.Straße, person.Stadt, person.Land, person.Telefon,
                    kundeID, firmaName, regestriertAm, istAktive);
            }
            else
                return null;
        }
        public static clsKunde FindKundeByPersonName(string vollName)
        {
            int kundeID = -1; int personID = -1;string firmaName = string.Empty;
            DateTime regestriertAm = DateTime.Now; bool istAktive = false;

            bool isfound = clsKundeDatenzugriff.GetKundebyPersonName(vollName, ref kundeID, ref personID, ref firmaName, ref regestriertAm, ref istAktive);

            if (!isfound) return null; // falls ist nicht gefunden.

            //wir suchen nach der generischen Person für diesen Mitarbeiter
            clsPerson person = clsPerson.Find(personID);

            if (person != null)
            {
                return new clsKunde(person.PersonID, person.Vorname, person.Nachname, person.GeburtsTag, person.Geschlecht,
                    person.SteuerID, person.Email, person.Straße, person.Stadt, person.Land, person.Telefon,
                    kundeID, firmaName, regestriertAm, istAktive);
            }
            else
                return null;
        }

        public override bool Delete()
        {
            bool Done = clsKundeDatenzugriff.DeleteKunde(this.kundeID);

            if (!Done)
                return false;

            //wir löschen dann die generische Person vom System.
            return clsPerson.Delete(this.PersonID);
        }

        public static bool DeleteKunde(int KundeID, int personID)
        {
            bool Done = clsKundeDatenzugriff.DeleteKunde(KundeID);

            if (Done)
            {
                //wir löschen dann die generische Person vom System.
                return clsPerson.Delete(personID);
            }
            else
                return false;
        }

        public static DataTable GetAllKunde()
        {
            return clsKundeDatenzugriff.GetAllKunde();
        }

        public static DataTable GetAllKundeName()
        {
            return clsKundeDatenzugriff.GetAllKundenName();  // Die Name zum Hinfügen in AutoComplate .
        }

        public static DataTable GetKundeByName(string vollname)
        {
            return clsKundeDatenzugriff.GetKundeByName(vollname);
        }
        public static DataTable GetKundeView()
        {
            return clsKundeDatenzugriff.GetAllKunde_View();
        }

        public static bool deaktiviereKunde(int kundeID)
        {
            return clsKundeDatenzugriff.deaktiviereKunde(kundeID);
        }

        public static bool aktiviereKunde(int kundeID)
        {
            return clsKundeDatenzugriff.aktiviereKunde(kundeID);
        }
    }
}
