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
    public class clsRechnugDatenzugriff
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public static string connectionString { get { return ConnectionString; } }

        public static bool GetRechnungByID(int belegID, ref int kundeID, ref DateTime erstellungsdatum, ref float gesamtSumme)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Rechnung Where belegID= @belegID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@belegID", belegID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                       
                                kundeID = (int)reader["KundeID"];
                                erstellungsdatum = (DateTime)reader["ErstellungsDatum"];

                                if (reader["GesamtSumme"] == DBNull.Value)
                                    gesamtSumme = 0;
                                else
                                   gesamtSumme = (float)reader["GesamtSumme"];
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
        public static bool GetRechnungByKundeID(ref int belegID, int kundeID, ref DateTime erstellungsdatum, ref float gesamtSumme)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Rechnung Where kundeID= @kundeID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@kundeID", kundeID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;


                                belegID = (int)reader["belegID"];
                                erstellungsdatum = (DateTime)reader["ErstellungsDatum"];
                                gesamtSumme = (float)reader["GesamtSumme"];
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

        public static  int NeueRechnungErstellen(int KundeID, float gesamtSumme)
        {
            int belegID = -1;
            string query = @"INSERT INTO Rechnung (KundeID, Erstellungsdatum, GesamtSumme)
                                               VALUES (@KundeID, @Erstellungsdatum, @GesamtSumme)
                                    Select Scope_Identity(); ";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@KundeID", KundeID);
                    command.Parameters.AddWithValue("@Erstellungsdatum", DateTime.Now);
                    command.Parameters.AddWithValue("@GesamtSumme", gesamtSumme);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        belegID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return belegID;
        }

        public static bool UpdateRechnung(int belegID, int KundeID, float GesamtSumme)
        {
            int rowAffected = 0;
            string query = @"Update Rechnung Set 
                                                KundeID = @KundeID,
                                                ErstellungsDatum = @Erstellungsdatum,
                                                GesamtSumme = @GesamtSumme
                                       Where belegID = @belegID; ";

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@belegID", belegID);
                    command.Parameters.AddWithValue("@KundeID", KundeID);
                    command.Parameters.AddWithValue("@Erstellungsdatum", DateTime.Now);
                    command.Parameters.AddWithValue("@GesamtSumme", GesamtSumme);

                    rowAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rowAffected > 0;
        }
        public static DataTable GetRecordAnzahlProSeite(int ZeileProSeite, int SeiteNummer)
        {
            DataTable dt = new DataTable();

            string abfrage = @"select BelegID,   (Person.Vorname + ' ' + Person.Nachname) As Kundenname,
                                                Erstellungsdatum, GesamtSumme
                                              From Rechnung 
                                               INNER JOIN Kunde ON
                                              Rechnung.KundeID = Kunde.KundeID
                                               INNER JOIN Person ON
                                                    Kunde.PersonID = Person.PersonID
                                          Order by BelegID Desc";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@ZeileProSeite", ZeileProSeite);
                        command.Parameters.AddWithValue("@SeiteNummer", SeiteNummer);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return dt;
        }

     
     
        public static bool DeleteRechnung(int belegID)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Rechnung Where belegID = @belegID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@belegID", belegID);

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

    }
}

