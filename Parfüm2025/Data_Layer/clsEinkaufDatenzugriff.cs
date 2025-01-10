using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class clsEinkaufDatenzugriff
    {

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public static bool GetEinkaufDatenByParfümID(int parfümNummer, ref string parfümName, ref string batchNummer,
                    ref string parfümCode, ref float lagerbestand, ref int preisKategorie,  ref DateTime erstellungsDatum)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Einkauf Where parfümNummer= @parfümNummer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                parfümName = (string)reader["parfümName"];
                                batchNummer = (string)reader["batchNummer"];
                                parfümCode = (string)reader["parfümCode"];
                                lagerbestand = (float)reader["lagerbestand"];
                                preisKategorie = (int)reader["preisKategorie"];
                                erstellungsDatum = (DateTime)reader["erstellungsDatum"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isfound = false;
                throw;
            }

            return isfound;
        }

        public static bool GetEinkaufDatenByParfümName(ref int parfümNummer, string parfümName, ref string batchNummer,
                    ref string parfümCode, ref float lagerbestand, ref int preisKategorie, ref DateTime erstellungsDatum)
        {

            bool isfound = false;

            string abfrage = @"SELECT * From Einkauf Where parfümName = @parfümName";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümName",parfümName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                parfümNummer = (int)reader["parfümNummer"];
                                batchNummer = (string)reader["batchNummer"];
                                parfümCode = (string)reader["parfümCode"];
                                lagerbestand = (float)reader["lagerbestand"];
                                preisKategorie = (int)reader["preisKategorie"];
                                erstellungsDatum = (DateTime)reader["erstellungsDatum"];

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isfound = false;
                throw;
            }

            return isfound;
        }



        public static DataTable GetAllEinkaufDaten()
        {
            DataTable dt = new DataTable();

            string abfrage = @"Select * From  Einkauf
                                                  Order by erstellungsDatum Desc";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return dt;
        }
        public static bool AddNewEinkaufDaten(int parfümNummer,string parfümName, string batchNummer,
                    string parfümCode,float lagerbestand, int preisKategorie, DateTime erstellungsDatum)
        {
            int rowAffected = 0;

            string abfrage = @"Insert into Einkauf (parfümNummer,parfümName,batchNummer,parfümCode,lagerbestand, preisKategorie, erstellungsDatum)
                                        Values  (@parfümNummer, @parfümName, @batchNummer, @parfümCode, @lagerbestand,@preisKategorie, @erstellungsDatum)";
       
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Über Parameter hinzufügen
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);
                        command.Parameters.AddWithValue("@parfümName", parfümName);
                        command.Parameters.AddWithValue("@batchNummer", batchNummer);
                        command.Parameters.AddWithValue("@parfümCode", parfümCode);
                        command.Parameters.AddWithValue("@lagerbestand", lagerbestand);
                        command.Parameters.AddWithValue("@preisKategorie", preisKategorie);
                        command.Parameters.AddWithValue("@erstellungsDatum", erstellungsDatum);

                        connection.Open();

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return (rowAffected > 0);
        }

        public static bool UpdateEinkaufDaten(int parfümNummer, string batchNummer,
                    string parfümCode, float lagerbestand, int preisKategorie, DateTime erstellungsDatum)
        {
            int RowAffected = 0;
            string abfrage = @"Update Einkauf  Set
                                                  batchNummer = @batchNummer,
                                                  parfümCode  = @parfümCode,
                                                  lagerbestand = @lagerbestand,
                                                  preisKategorie = @preisKategorie,
                                                  erstellungsDatum = @erstellungsDatum
                                            Where parfümNummer = @parfümNummer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);
                        command.Parameters.AddWithValue("@batchNummer", batchNummer);
                        command.Parameters.AddWithValue("@parfümCode", parfümCode);
                        command.Parameters.AddWithValue("@lagerbestand", lagerbestand);
                        command.Parameters.AddWithValue("@preisKategorie", preisKategorie);
                        command.Parameters.AddWithValue("@erstellungsDatum", erstellungsDatum);

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }


        public static bool UpdateLagerbestand(int parfümNummer, float neueLagerbestand)
        {
            int RowAffected = 0;
            string abfrage = @"Update Einkauf  Set
                                                  lagerbestand = @neueLagerbestand,
                                                  erstellungsDatum = GetDate()
                                            Where parfümNummer = @parfümNummer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);
                        command.Parameters.AddWithValue("@neueLagerbestand", neueLagerbestand);
          
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }
        public static bool DeleteEinkaufDaten(int parfümNummer)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Einkauf Where ParfümNummer = @parfümNummer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);

                        //Öffene die verbindung und ausführe den Befehl
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }

        public static bool IstParfümNummerVerfügbar(int parfümNummer)
        {
            bool istVerfügbar = false;

            string abfrage = @"Select 1 From Einkauf where parfümNummer = @parfümNummer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);

                        //Öffene die verbindung und ausführe den Befehl
                        connection.Open();

                        object result = command.ExecuteScalar();
                        istVerfügbar = (result != null && (int)result == 1);
                    }
                }
            }
            catch (SqlException ex)
            {
                istVerfügbar = false;
                throw;
            }
            return istVerfügbar;
        }
    }
}
