using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busnisse_Layer
{
    public class clsUser
    {
        public enum enMode { addNew = 0, Update = 1 }
        private enMode _Mode = enMode.addNew;

        public int userID { get; set; }
        public int mitarbeiterID { get; set; }
        public string userRolle { get; set; }
        public string userPasswort { get; set; }
        public int permissionNum { get; set; }
        public bool istAktive { get; set; }
        private clsUser(int userID, int mitarbeiterID, string userRolle, string userPasswort, int permissionNum, bool istAktive)
        {
            this.userID = userID;
            this.mitarbeiterID = mitarbeiterID;
            this.userRolle = userRolle;
            this.userPasswort = userPasswort;
            this.permissionNum = permissionNum;
            this.istAktive = istAktive;

            _Mode = enMode.Update;
        }

        public clsUser()
        {
            this.userID = -1;
            this.mitarbeiterID = -1;
            this.userRolle = string.Empty;
            this.userPasswort = string.Empty;
            this.permissionNum = 0;
            this.istAktive = true;

            _Mode = enMode.addNew;
        }

        private bool _AddNew()
        {
            this.userID = clsUserDatenzugriff.AddNewUser(this.mitarbeiterID, this.userRolle, this.userPasswort,this.permissionNum,this.istAktive);
            return (this.userID != -1);
        }

        private bool _Update()
        {
            return clsUserDatenzugriff.UpdateUser(this.userID, this.userRolle, this.userPasswort, this.permissionNum, this.istAktive);
        }

        public  bool Save()
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
                        return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static clsUser FindUserByID(int userID)
        {
            int mitarbeiterID = -1; string userRolle = string.Empty; string userPasswort = string.Empty
                ; int permissionNum = 0;  bool istAktive = false;

            bool isfound = clsUserDatenzugriff.GetUserbyID(userID, ref mitarbeiterID, ref userRolle, ref userPasswort, ref permissionNum, ref istAktive);

            if (!isfound) return null;// falls ist nicht gefunden.

            return new clsUser(userID, mitarbeiterID, userRolle, userPasswort, permissionNum, istAktive);
        }

        public static clsUser FindUserByUsernameAndPasswort(string username, string passwort)
        {
            int mitarbeiterID = -1; int userID = -1;
            ; int permissionNum = 0; bool istAktive = false;

            bool isfound = clsUserDatenzugriff.GetUserByUsernameAndPasswort(ref userID, ref mitarbeiterID, username, passwort, ref permissionNum, ref istAktive);

            if (!isfound) return null;// falls ist nicht gefunden.

            return new clsUser(userID, mitarbeiterID, username, passwort, permissionNum, istAktive);
        }


        public static clsUser FindUserByMitarbeiterID(int mitarbeiterID)
        {
            int userID = -1; string userRolle = string.Empty; string userPasswort = string.Empty
                ; int permissionNum = 0; bool istAktive = false;

            bool isfound = clsUserDatenzugriff.GetUserByMitarbeiterID(ref userID,  mitarbeiterID, ref userRolle, ref userPasswort, ref permissionNum, ref istAktive);

            if (!isfound) return null;// falls ist nicht gefunden.

            return new clsUser(userID, mitarbeiterID, userRolle, userPasswort, permissionNum, istAktive);
        }


        public bool Delete()
        {
            return clsUserDatenzugriff.DeleteUser(this.userID);
        }

        public static bool DeleteUserByMitarbeiterID(int mitarbeiterID)
        {
            return clsUserDatenzugriff.DeleteUserByMitarbeiterID(mitarbeiterID);
        }

        public static DataTable GetAllUser()
        {
            return clsUserDatenzugriff.GetAllUser();
        }

        public static bool deaktiviereUser(int userID)
        {
            return clsUserDatenzugriff.deaktiviereUser(userID);
        }

        public static bool aktiviereUser(int userID)
        {
            return clsUserDatenzugriff.aktiviereUser(userID);
        }

        public static bool ExistUserForThisMitarbeiter(int mitarbeiterID)
        {
            return clsUserDatenzugriff.ExistUserForThisMitarbeiterID(mitarbeiterID);
        }
    }
}
