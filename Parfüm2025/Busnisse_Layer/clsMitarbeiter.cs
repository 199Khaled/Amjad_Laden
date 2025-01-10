using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busnisse_Layer
{
    public class clsMitarbeiter : clsPerson
    {
        public enum enMode { addNew = 0, Update = 1 }
        private enMode _Mode = enMode.addNew;

        public int MitarbeiterID { get; set; }
        public string VersicherungsName { get; set; }
        public string VersicherungsNummer { get; set; }
        public DateTime EingestelltAm { get; set; }
        public bool istAktive { get; set; }
        private clsMitarbeiter(int personID, string vorname, string nachname, DateTime geburtstag, char geschlecht, 
            string steuerID, string email , string strasse, string stadt, string land, string telefon,
            int mitarbeiterID, string versicherungsName, string versicherungsNummer, DateTime eingestelltAm, bool istAktive) 
            : base(personID, vorname, nachname, geburtstag, geschlecht, steuerID, email, strasse, stadt, land, telefon)
        {
            this.MitarbeiterID = mitarbeiterID;
            this.VersicherungsName = versicherungsName;
            this.VersicherungsNummer = versicherungsNummer;
            this.EingestelltAm = eingestelltAm;
            this.istAktive = istAktive;

            _Mode = enMode.Update;
        }

        public clsMitarbeiter()
        {
            this.MitarbeiterID = -1;
            this.VersicherungsName = string.Empty;
            this.VersicherungsNummer = string.Empty;
            this.EingestelltAm = DateTime.Now;
            this.istAktive = true;
          
            _Mode = enMode.addNew;
        }

        private bool _AddNew()
        {
            this.MitarbeiterID = clsMitarbeiterDatenzugriff.AddNewMitarbeiter(this.PersonID, this.VersicherungsName, this.VersicherungsNummer,
                                                                                   this.EingestelltAm, this.istAktive);
            return (this.MitarbeiterID != -1);
        }

        private bool _Update()
        {
            return clsMitarbeiterDatenzugriff.UpdateMitarbeiter(this.MitarbeiterID, this.VersicherungsName, this.VersicherungsNummer,
                                                                this.EingestelltAm, this.istAktive);
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

        public  static clsMitarbeiter FindMitarbeiterByID(int mitarbeiterID)
        {
            int personID = -1;
            string versicherungsName = string.Empty; string versicherungsNummer = string.Empty;
            DateTime eingestelltAm = DateTime.Now; bool istAktive = false;

            bool isfound = clsMitarbeiterDatenzugriff.GetMitarbeiterbyID(mitarbeiterID, ref personID, ref versicherungsName, ref versicherungsNummer,
                                                                            ref eingestelltAm, ref istAktive);

            if (!isfound) return null;
            
            //wir suchen nach der generischen Person für diesen Mitarbeiter
            clsPerson person = clsPerson.Find(personID);

           if (person != null)
            {
             return new clsMitarbeiter(person.PersonID, person.Vorname, person.Nachname, person.GeburtsTag, person.Geschlecht, person.SteuerID,
                                      person.Email, person.Straße, person.Stadt, person.Land, person.Telefon,
                                      mitarbeiterID, versicherungsName, versicherungsNummer, eingestelltAm, istAktive);
            }
           else
               return null;
        }

        public static clsMitarbeiter FindMitarbeiterByPersonID(int personID)
        {
            int mitarbeiterID = -1;
            string versicherungsName = string.Empty; string versicherungsNummer = string.Empty;
            DateTime eingestelltAm = DateTime.Now; bool istAktive = false;

            bool isfound = clsMitarbeiterDatenzugriff.GetMitarbeiterbyPersonID(ref mitarbeiterID, personID, ref versicherungsName, ref versicherungsNummer,
                                                                            ref eingestelltAm, ref istAktive);

            if (!isfound) return null;

            //wir suchen nach der generischen Person für diesen Mitarbeiter
            clsPerson person = clsPerson.Find(personID);

            if (person != null)
            {
                return new clsMitarbeiter(person.PersonID, person.Vorname, person.Nachname, person.GeburtsTag, person.Geschlecht, person.SteuerID,
                                         person.Email, person.Straße, person.Stadt, person.Land, person.Telefon,
                                         mitarbeiterID, versicherungsName, versicherungsNummer, eingestelltAm, istAktive);
            }
            else
                return null;
        }
        public static DataTable FindMitarbeiterByPersonName(string personName)
        {
            return clsMitarbeiterDatenzugriff.GetMitarbeiterByPersonName(personName);
        }

        public override bool Delete()
        {
            bool UserEntfernt = true;
            if (clsUser.ExistUserForThisMitarbeiter(this.MitarbeiterID)) // wir überprüfen, Ob Benutzer für diesen Mitarbeiter existiert.
                UserEntfernt = clsUser.DeleteUserByMitarbeiterID(this.MitarbeiterID);  // wenn Ja, dann löschen.

            if (!UserEntfernt)
                return false; ;

            bool MitarbeiterEntfernt = clsMitarbeiterDatenzugriff.DeleteMitarbeiter(this.MitarbeiterID);

            if (!MitarbeiterEntfernt)
                return false;

            //wir löschen dann die generische Person vom System.
            return clsPerson.Delete(this.PersonID);
        }

        public static bool DeleteMitarbeiter(int MitarbeiterID, int personID)
        {
            bool MitarbeiterEntfernt = clsMitarbeiterDatenzugriff.DeleteMitarbeiter(MitarbeiterID);

            if (MitarbeiterEntfernt)
            {
                //wir löschen dann die generische Person vom System.
                return clsPerson.Delete(personID);
            }
            else
                return false;
        }

        public static DataTable GetAllMitarbeiter()
        {
            return clsMitarbeiterDatenzugriff.GetAllMitarbeiter();
        }
        public static DataTable GetAllMitarbeiterView()
        {
            return clsMitarbeiterDatenzugriff.GetAllMitarbeiter_View();
        }

        public static bool deaktiviereMitarbeiter(int mitarbeiterID)
        {
            return clsMitarbeiterDatenzugriff.deaktiviereMitarbeiter(mitarbeiterID);
        }

        public static bool aktiviereMitarbeiter(int mitarbeiterID)
        {
            return clsMitarbeiterDatenzugriff.aktiviereMitarbeiter(mitarbeiterID);
        }

    }
}
