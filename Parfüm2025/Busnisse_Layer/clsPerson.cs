using Data_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busnisse_Layer
{
    public class clsPerson
    {

        public enum enMode { Addnew = 0, Update }
        public enMode Mode = enMode.Addnew;

        public int PersonID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Vollname
        {
            get { return Vorname + " " + Nachname; }
        }
        public DateTime GeburtsTag { get; set; }
        public char Geschlecht { get; set; }
        public string SteuerID { get; set; }
        public string Email { get; set; }
        public string Straße { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
        public string Telefon { get; set; }

        public clsPerson(int personID,string vorname, string nachname,
                  DateTime geburtsTag, char geschlecht,string steuerID, string email,
                   string straße, string stadt, string land, string telefon)
        {
            this.PersonID = personID;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.GeburtsTag = geburtsTag;
            this.Geschlecht = geschlecht;
            this.SteuerID = steuerID;
            this.Email = email;
            this.Straße = straße;
            this.Stadt = stadt;
            this.Land = land;
            this.Telefon = telefon;

            Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.Vorname = string.Empty;
            this.Nachname = string.Empty;
            this.GeburtsTag = DateTime.Now;
            this.Geschlecht = 'W';
            this.SteuerID = string.Empty;
            this.Email = string.Empty;
            this.Straße = string.Empty;
            this.Stadt = string.Empty;
            this.Land = string.Empty;
            this.Telefon = string.Empty;

            Mode = enMode.Addnew;
        }

        public static clsPerson Find(int PersonID)
        {
             string Vorname = string.Empty; string Nachname = string.Empty; DateTime GeburtsTag = DateTime.Now;
            char Geschlecht = 'W'; string steuerID = string.Empty; string Email = string.Empty;
            string Straße = string.Empty; string Stadt = string.Empty; string Land = string.Empty; string Telefon = string.Empty;

            if (clsPersonDatenzugriff.GetPersonDataByPersonID(PersonID, ref Vorname, ref Nachname, ref GeburtsTag, ref Geschlecht,
                ref steuerID, ref Email, ref Straße, ref Stadt, ref Land, ref Telefon))
            {
                return new clsPerson(PersonID, Vorname, Nachname, GeburtsTag, Geschlecht, steuerID, Email, Straße, Stadt, Land, Telefon);
            }
          
            else
                return null;
        }

        public static clsPerson FindByEmailAddresse(string Email)
        {
            int PersonID = -1;  string Vorname = string.Empty; string Nachname = string.Empty; DateTime GeburtsTag = DateTime.Now;
            char Geschlecht = 'W'; string steuerID = string.Empty; 
            string Straße = string.Empty; string Stadt = string.Empty; string Land = string.Empty; string Telefon = string.Empty;

            if (clsPersonDatenzugriff.GetPersonDataByEmailAdresse(ref PersonID, ref Vorname, ref Nachname, ref GeburtsTag, ref Geschlecht,
               ref steuerID, Email, ref Straße, ref Stadt, ref Land, ref Telefon))
            {
                return new clsPerson(PersonID, Vorname, Nachname, GeburtsTag, Geschlecht, steuerID, Email, Straße, Stadt, Land, Telefon);
            }
            else
                return null;
        }

        public static clsPerson FindByPersonName(string PersonName)
        {
            int PersonID = -1; string Vorname = string.Empty; string Nachname = string.Empty; DateTime GeburtsTag = DateTime.Now;
            char Geschlecht = 'W'; string steuerID = string.Empty;string Email = string.Empty;
            string Straße = string.Empty; string Stadt = string.Empty; string Land = string.Empty; string Telefon = string.Empty;

            if (clsPersonDatenzugriff.GetPersonDataByPersonName(PersonName,ref PersonID, ref Vorname, ref Nachname, ref GeburtsTag, ref Geschlecht,
               ref steuerID, ref Email, ref Straße, ref Stadt, ref Land, ref Telefon))
            {
                return new clsPerson(PersonID, Vorname, Nachname, GeburtsTag, Geschlecht, steuerID, Email, Straße, Stadt, Land, Telefon);
            }
            else
                return null;
        }
 
       private  bool _AddNew()
        {
            this.PersonID = clsPersonDatenzugriff.AddNewPerson(this.Vorname, this.Nachname, this.GeburtsTag,this.Geschlecht, this.SteuerID,
                this.Email, this.Straße, this.Stadt, this.Land, this.Telefon);

            return (this.PersonID != -1);
        }

        private bool _Update()
        {
            return clsPersonDatenzugriff.UpdatePerson(this.PersonID, this.Vorname, this.Nachname, this.GeburtsTag, this.Geschlecht, this.SteuerID,
                this.Email, this.Straße, this.Stadt, this.Land, this.Telefon);
        }

        public virtual bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonDatenzugriff.IsPersonExist(PersonID);
        }
        public  static bool Delete(int PersonID)
        {
            return clsPersonDatenzugriff.DeletePerson(PersonID);
        }

        public virtual bool Delete()
        {
            return clsPersonDatenzugriff.DeletePerson(PersonID);
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonDatenzugriff.GetAllPersons();
        }

    }
}

