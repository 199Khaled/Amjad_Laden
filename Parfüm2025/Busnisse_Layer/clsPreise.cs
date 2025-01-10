using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busnisse_Layer
{
    public class clsPreise
    {
        private static string ConnectionString = clsPreisDatenzugriff.connection;
        private enum enMode { addnew = 0, update = 1}
        private enMode _mode = enMode.addnew;

        public int preisID { get; set; }
        public int kategorie {  get; set; }
        public int miniMenge {  get; set; }
        public int maxMenge { get; set; }
        public float preisProEinheit {  get; set; }

        private clsPreise(int preisID,int kategorie, int miniMenge, int maxMenge, float preisProEinheit)
        {
            this.preisID = preisID;
            this.kategorie = kategorie;
            this.miniMenge = miniMenge;
            this.maxMenge = maxMenge;
            this.preisProEinheit = preisProEinheit;

            _mode = enMode.update;
        }

        public clsPreise()
        {
            this.preisID = -1;
            this.kategorie = 0;
            this.miniMenge = 0;
            this.maxMenge = 0;
            this.preisProEinheit = 0;

            _mode = enMode.addnew;
        }

        public static clsPreise Find(int preisID)
        {
            int miniMenge = 0, maxMenge = 0;
            int kategorie = 0; float preisProEinheit = 0;
            if (clsPreisDatenzugriff.GetPreisKategorieByID(preisID, ref kategorie, ref miniMenge, ref maxMenge, ref preisProEinheit))
            {
                return new clsPreise(preisID,kategorie, miniMenge, maxMenge, preisProEinheit);
            }
            else
                return null;
        }

        private bool _AddNew()
        {
            this.preisID = clsPreisDatenzugriff.AddNewPreis(this.kategorie, this.miniMenge, this.maxMenge, this.preisProEinheit);

            return (preisID != -1);
        }

        private bool _Update()
        {
            return clsPreisDatenzugriff.UpdatePreise(this.preisID,this.kategorie, this.miniMenge, this.maxMenge, this.preisProEinheit);
        }

        public bool Save()
        {
            switch(_mode)
            {
                case enMode.addnew:
                    if (_AddNew())
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

        public static  DataTable GetAllPreise()
        {
            return clsPreisDatenzugriff.GetAllPreise();
        }

        public bool Delete()
        {
            return clsPreisDatenzugriff.DeletePreise(this.preisID);
        }

        public static float BerechneParfuemPreis(float menge, int kategorie)
        {
            return clsPreisDatenzugriff.BerechnePreis(menge, kategorie);
        }
        public static bool IstkategorieVorhanden(int kategorie)
        {
            return clsPreisDatenzugriff.IstKategorieVorhanden(kategorie);
        }


        public static List<clsPreise> GetPreisKategorieByKategorie(int Kategorie)
        {
            string abfrage = @"SELECT * From Preise Where Kategorie = @Kategorie";

            var preisKategorieListe = new List<clsPreise>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@Kategorie", Kategorie);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                preisKategorieListe.Add(new clsPreise
                                {
                                     kategorie = (int)reader["Kategorie"],
                                    miniMenge = (int)reader["MiniMenge"],
                                    maxMenge = (int)reader["MaxMenge"],
                                    preisProEinheit = (float)reader["PreisProEinheit"]
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return preisKategorieListe;
        }
    }
}
